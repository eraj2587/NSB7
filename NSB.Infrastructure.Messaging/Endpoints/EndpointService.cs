using Autofac;
using System;
using System.ServiceProcess;
using System.Threading.Tasks;
using NServiceBus;
using NSB.Infrastructure.Messaging;
using NSB.Infrastructure.Messaging.Configurations;
using NSB.Infrastructure.Messaging.Endpoints;
using NSB.Infrastructure.Wcf;
using ServiceHostsActivator = NSB.Infrastructure.Messaging.ServiceHostsActivator;

namespace NSB.Infrastructure.Endpoints
{
    public abstract class EndpointService : ServiceBase
    {
        #region Member Variables and Constants

        private SendAndProcessEndpoint<BaseEndpointConfig> _endpoint;

        protected abstract BaseEndpointConfig EndpointConfig { get; }

        private string _endpointName;
        private ServiceHostsActivator _serviceHostsActivator;
        private StartupAndShutdownActivator _serviceStartAndShutDownActivator;
        //private ContainerBuilder _builder;
        //private IContainer _container;

        #endregion

        #region Public Methods

        protected override void OnStart(string[] args)
        {
            _endpointName = EndpointConfig.GetEndpointName();
            // _builder = EndpointConfig.GetContainerBuilder();
            OnStartAsync().GetAwaiter().GetResult();
            //_container = _endpoint.GetEndpointContainer();
            PerformStartupOperations();
        }

        protected override void OnStop()
        {
            OnStopAsync().GetAwaiter().GetResult();
        }

        protected async Task OnStopAsync()
        {
            if (_endpoint != null) await _endpoint.StopEndpoint().ConfigureAwait(false);
            await PerformOnStopOperations().ConfigureAwait(false);
        }



        public SendAndProcessEndpoint<BaseEndpointConfig> GetEndpoint()
        {
            return _endpoint;
        }

        protected async Task OnStartAsync()
        {
            try
            {
                var builder = EndpointConfig.GetContainerBuilder();
                _endpoint = new SendAndProcessEndpoint<BaseEndpointConfig>(EndpointConfig);
                var container = await _endpoint.Create(builder).ConfigureAwait(false);
                await _endpoint.StartEndpoint().ConfigureAwait(false);

                //starts wcf host
                _serviceHostsActivator = container.Resolve<ServiceHostsActivator>();
                _serviceStartAndShutDownActivator = container.Resolve<StartupAndShutdownActivator>();

                await PerformStartupOperations().ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                //TODO: Log Exception
                Environment.FailFast("Failed to start " + _endpointName + " Endpoint." + ex.GetBaseException() + ex);
            }
        }

        #endregion

        #region Private Methods

        private async Task PerformStartupOperations()
        {
            try
            {
                _serviceHostsActivator.Start();
                _serviceStartAndShutDownActivator.Start();
                //wire up IEndpointInstance
                //var instance = _endpoint.GetEndpointInstance();
                //_builder.RegisterInstance(instance)
                //    .PropertiesAutowired()
                //    .SingleInstance()
                //    .As<IEndpointInstance>();



                // _container = _builder.Build();
                //starts wcf host
                //_serviceHostsActivator = new ServiceHostsActivator
                //{
                //    // Container = _container
                //    Container = EndpointConfig.GetEndpointContainer()
                //};
                //_serviceHostsActivator.Start();

                //_serviceStartAndShutDownActivator = new StartupAndShutdownActivator
                //{
                //    //Container = _container
                //    Container = EndpointConfig.GetEndpointContainer()
                //};
                //await _serviceStartAndShutDownActivator.Start().ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                //TODO: Log Exception
                Environment.FailFast(
                    "Failed to execute PerformStartupOperations() for " + _endpointName + ".", ex);
            }
        }

        private async Task PerformOnStopOperations()
        {
            try
            {
                await _serviceStartAndShutDownActivator.Stop().ConfigureAwait(false);
                _serviceHostsActivator.Stop();
            }
            catch (Exception ex)
            {
                //TODO: Log Exception
                Environment.FailFast(
                    "Failed to execute PerformOnStopOperations() for " + _endpointName + ".", ex);
            }
        }

        #endregion
    }

}