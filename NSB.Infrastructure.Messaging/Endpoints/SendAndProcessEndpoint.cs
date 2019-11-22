using NServiceBus;
using System;
using System.Threading.Tasks;
using Autofac;
using NSB.Infrastructure.Messaging.Configurations;

namespace NSB.Infrastructure.Messaging.Endpoints
{
    public class SendAndProcessEndpoint<T>
        where T : BaseEndpointConfig
    {
        #region Member Variables and Constatns

        private readonly BaseEndpointConfig _endPointConfig;
        //private EndpointConfiguration _nsbConfig;
        //private static IEndpointInstance _endpointInstance;
        //private static IContainer _container;
        IStartableEndpoint _startableEndpoint;
        IEndpointInstance _endpointInstance;

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

        //public IContainer GetEndpointContainer()
        //{
        //    return _endPointConfig.GetEndpointContainer();
        //}

        public async Task<IContainer> Create(ContainerBuilder builder)
        {
            //_nsbConfig = _endPointConfig.BuildConfig();
            //return _nsbConfig;
            // Variation on https://docs.particular.net/samples/dependency-injection/autofac/

            var endpointConfiguration = _endPointConfig.BuildConfig();

            builder.Register(x => _endpointInstance)
                .As<IEndpointInstance>()
                .SingleInstance();

            var container = builder.Build();

            endpointConfiguration.UseContainer<AutofacBuilder>(c => c.ExistingLifetimeScope(container));

            _startableEndpoint = await Endpoint.Create(endpointConfiguration).ConfigureAwait(false);

            return container;
        }

        public virtual async Task StartEndpoint()
        {
            // Resolve via container, afterall, why register it?
            //var container = _endPointConfig.GetEndpointContainer();
            //_endpointInstance = container.Resolve<IEndpointInstance>();
            _endpointInstance = await _startableEndpoint.Start().ConfigureAwait(false);
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
