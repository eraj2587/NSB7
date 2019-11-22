using Autofac;
using NServiceBus;
using System;
using System.Collections.Generic;
using System.Configuration;
using WUBS.Endpoints.Server;
using WUBS.Infrastructure.Messaging.Configurations;

namespace ServerEndpoint
{
    public class ServerEndpointConfig : BaseEndpointConfig
    {
        #region Overrides of BaseEndpointConfig

        public override RoutingSettings<SqlServerTransport> BuildEndpointRouting(
            RoutingSettings<SqlServerTransport> routing)
        {
            var routes = base.BuildEndpointRouting(routing);
            //add any additional routes if any
            return routing;
        }

        protected override string GetEnvironmentName()
        {
            return ConfigurationManager.AppSettings["Environment"] ?? string.Empty;
        }

        protected override string GetPersistenceConnectionString()
        {
            return ConfigurationManager.AppSettings["ConnectionString.Payments"];
        }

        protected override string GetServiceControlConnectionString()
        {
            return ConfigurationManager.AppSettings["ConnectionString.servicecontrol"];
        }

        protected override IEnumerable<Type> GetServiceReferences()
        {
            return new List<Type>
            {
                typeof (PaymentManager)
            };
        }

        protected override string GetTransportConnectionString()
        {
            return ConfigurationManager.AppSettings["ConnectionString.Payments"];
        }

        public override ContainerBuilder GetContainerBuilder()
        {
            var containerBuilder = base.GetContainerBuilder();
            //do additional registration
            return containerBuilder;
        }

        protected virtual void SetMaximumConcurrencyLevel(EndpointConfiguration config)
        {
            config.LimitMessageProcessingConcurrencyTo(10);
        }

        #endregion
    }
}
