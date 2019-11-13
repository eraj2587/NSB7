using Autofac;
using System;
using System.ServiceProcess;
using System.Threading.Tasks;
using NServiceBus;
using WUBS.Infrastructure.Messaging;
using WUBS.Infrastructure.Messaging.Configurations;
using WUBS.Infrastructure.Messaging.Endpoints;
using WUBS.Infrastructure.Wcf;
using ServiceHostsActivator = WUBS.Infrastructure.Messaging.ServiceHostsActivator;

namespace WUBS.Infrastructure.Endpoints
{
    public abstract class EndpointService : ServiceBase
    {
        #region Member Variables and Constants

        private SendAndProcessEndpoint<BaseEndpointConfig> _endpoint;

        protected abstract BaseEndpointConfig EndpointConfig { get; }

        private string _endpointName;
        private ServiceHostsActivator _serviceHostsActivator;
        private StartupAndShutdownActivator _serviceStartAndShutDownActivator;
        private ContainerBuilder _builder;
        private IContainer _container;

        #endregion

        #region Public Methods

        protected override void OnStart(string[] args)
        {
            _endpointName = EndpointConfig.GetEndpointName();
            _builder = EndpointConfig.GetContainerBuilder();
            OnStartAsync().GetAwaiter().GetResult();
            _container = _endpoint.GetEndpointContainer();
            PerformStartupOperations();
        }

        protected override void OnStop()
        {
            _endpoint?.StopEndpoint();
            PerformOnStopOperations();
        }

        public SendAndProcessEndpoint<BaseEndpointConfig> GetEndpoint()
        {
            return _endpoint;
        }

        protected async Task OnStartAsync()
        {
            try
            {
                _endpoint = new SendAndProcessEndpoint<BaseEndpointConfig>(EndpointConfig);
                _endpoint.Initialize();
               
                

                await _endpoint.StartEndpoint();
            }
            catch (Exception ex)
            {
                //TODO: Log Exception
                Environment.FailFast("Failed to start " + _endpointName + " Endpoint." + ex.GetBaseException()+ex);
            }
        }

        #endregion

        #region Private Methods

        private void PerformStartupOperations()
        {
            try
            {
                //wire up IEndpointInstance
                //var session = _endpoint.GetEndpointInstance();
                //_builder.RegisterInstance(session)
                //    .PropertiesAutowired()
                //    .SingleInstance()
                //    .As<IEndpointInstance>();

                //using (var scope = _container.BeginLifetimeScope(builder=>
                //{
                //    builder.RegisterInstance(session)
                //        .PropertiesAutowired()
                //        .SingleInstance()
                //        .As<IEndpointInstance>();
                //    builder.Update(_container);
                //}
                //))
                //{
                //    // Resolve services from a scope that is a child
                //    // of the root container.
                //    var serviceHosts = scope.Resolve<IStartableServiceHost[]>();

                //    foreach (var host in serviceHosts)
                //    {
                //        host.Start();
                //    }
                //}
                
                _container = _builder.Build();
                //starts wcf host
                _serviceHostsActivator = new ServiceHostsActivator
                {
                    Container = _container
                };
                _serviceHostsActivator.Start();

                _serviceStartAndShutDownActivator = new StartupAndShutdownActivator
                {
                    Container = _container
                };
                _serviceStartAndShutDownActivator.Start();
            }
            catch (Exception ex)
            {
                //TODO: Log Exception
                Environment.FailFast(
                    "Failed to execute PerformStartupOperations() for " + _endpointName +".", ex);
            }
        }

        private void PerformOnStopOperations()
        {
            try
            {
                _serviceHostsActivator.Stop();
            }
            catch (Exception ex)
            {
                //TODO: Log Exception
                Environment.FailFast(
                    "Failed to execute PerformOnStopOperations() for " + _endpointName +".", ex);
            }
        }

        #endregion
    }

}