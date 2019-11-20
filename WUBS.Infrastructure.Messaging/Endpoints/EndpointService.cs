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
        private IContainer _container;

        #endregion

        #region Public Methods

        protected override void OnStart(string[] args)
        {
            OnStartAsync().GetAwaiter().GetResult();
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

        async Task OnStartAsync()
        {
            _endpointName = EndpointConfig.GetEndpointName();

            try
            {
                _endpoint = new SendAndProcessEndpoint<BaseEndpointConfig>(EndpointConfig);
                _endpoint.Initialize();

                await _endpoint.StartEndpoint().ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                //TODO: Log Exception
                Environment.FailFast("Failed to start " + _endpointName + " Endpoint." + ex.GetBaseException() + ex);
            }

            _container = _endpoint.GetEndpointContainer();
            await PerformStartupOperations().ConfigureAwait(false);
        }

        #endregion

        #region Private Methods

        private async Task PerformStartupOperations()
        {
            try
            {
                //starts wcf host
                _serviceHostsActivator = new ServiceHostsActivator
                {
                    Container = EndpointConfig.GetEndpointContainer()
                };
                _serviceHostsActivator.Start();

                _serviceStartAndShutDownActivator = new StartupAndShutdownActivator
                {
                    Container = EndpointConfig.GetEndpointContainer()
                };
                await _serviceStartAndShutDownActivator.Start().ConfigureAwait(false);
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
                    "Failed to execute PerformOnStopOperations() for " + _endpointName +".", ex);
            }
        }

        #endregion
    }

}
