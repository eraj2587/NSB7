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

        protected async Task OnStartAsync()
        {
            _endpointName = EndpointConfig.GetEndpointName();

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
