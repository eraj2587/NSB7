using NServiceBus;
using System;
using System.Threading.Tasks;
using Autofac;
using WUBS.Infrastructure.Messaging.Configurations;

namespace WUBS.Infrastructure.Messaging.Endpoints
{
    public class SendAndProcessEndpoint<T>
        where T : BaseEndpointConfig
    {
        #region Member Variables and Constatns

        private readonly BaseEndpointConfig _endPointConfig;
        private EndpointConfiguration _nsbConfig;
        private static IEndpointInstance _endpointInstance;
        private static IContainer _container;

        #endregion

        #region Constructors

        public SendAndProcessEndpoint(T config)
        {
            if (config == null)
                throw new ArgumentNullException("Endpoint configuration cannot be null");

            _endPointConfig = config;
        }


        #endregion

        #region Public Methods

        public IContainer GetEndpointContainer()
        {
            return _endPointConfig.GetEndpointContainer();
        }

        public EndpointConfiguration Initialize()
        {
            _nsbConfig = _endPointConfig.BuildConfig();
            return _nsbConfig;
        }

        public virtual async Task StartEndpoint()
        {
            // Resolve via container, afterall, why register it?
            var container = _endPointConfig.GetEndpointContainer();
            _endpointInstance = container.Resolve<IEndpointInstance>();
        }

        public virtual async Task StopEndpoint()
        {
            if (_endpointInstance != null)
                await _endpointInstance.Stop().ConfigureAwait(false);
        }

        public virtual async Task SendMessage(object message)
        {
            if (_endpointInstance != null)
                await _endpointInstance.Send(message).ConfigureAwait(false);
        }

        public virtual async Task SendMessage<TCommand>(TCommand message)
        {
            if (_endpointInstance != null)
                await _endpointInstance.Send(message).ConfigureAwait(false);
        }

        public virtual async Task SendMessage<TCommand>(Action<TCommand> messageConstructor)
        {
            if (_endpointInstance != null)
                await _endpointInstance.Send(messageConstructor).ConfigureAwait(false);
        }

        public virtual void PublishMessage(object message)
        {
            if (_endpointInstance != null)
                _endpointInstance.Publish(message).ConfigureAwait(false);
        }


        public virtual void PublishMessage<TEvent>(TEvent message)
        {
            if (_endpointInstance != null)
                _endpointInstance.Publish(message).ConfigureAwait(false);
        }

        public virtual void PublishMessage<TEvent>(Action<TEvent> messageConstructor)
        {
            if (_endpointInstance != null)
                _endpointInstance.Publish(messageConstructor, new PublishOptions()).ConfigureAwait(false);
        }

        public string GetEndpointName()
        {
            return _endPointConfig._configEndpointName;
        }

        public IEndpointInstance GetEndpointInstance()
        {
            return _endpointInstance;
        }


        #endregion
    }
}
