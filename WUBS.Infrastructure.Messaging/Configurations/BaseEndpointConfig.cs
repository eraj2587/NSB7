using Autofac;
using NServiceBus;
using NServiceBus.Hosting.Helpers;
using NServiceBus.Logging;
using NServiceBus.Persistence;
using NServiceBus.Transport.SQLServer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using WUBS.Infrastructure.Logging;
using Environment = NHibernate.Cfg.Environment;


namespace WUBS.Infrastructure.Messaging.Configurations
{
    public abstract class BaseEndpointConfig : IEndpointConfig
    {
        #region Member Variables and Constants

        protected const string DefaultNsbSchema = "nsb";
        private const string DefaultServiceControlSchema = "dbo";

        internal string _configEndpointName;

        protected bool _isSendOnly;

        private readonly TypeScanner typeScanner;

        private IContainer _container;
        private ContainerBuilder builder;

        #endregion

        #region Constructors

        protected BaseEndpointConfig() :
            this(null)
        {
        }

        protected BaseEndpointConfig(string endpointName)
        {
            _configEndpointName = string.IsNullOrEmpty(endpointName) ? GetEndpointName() : endpointName;
            typeScanner = new TypeScanner(GetAssembliesToScan());
        }

        #endregion

        #region Members

        public virtual EndpointConfiguration BuildConfig()
        {
            LogManager.Use<DefaultFactory>().Level(LogLevel.Debug);

            if (string.IsNullOrEmpty(_configEndpointName))
                throw new ArgumentNullException(_configEndpointName, "Endpoint name cannot be null");

            var endpointConfiguration = new EndpointConfiguration(_configEndpointName);

            if (_isSendOnly)
                endpointConfiguration.SendOnly();

            builder = GetContainerBuilder();
            IEndpointInstance endpoint;

            // Variation on https://docs.particular.net/samples/dependency-injection/autofac/
            builder.Register(x => Endpoint.Start(endpointConfiguration).GetAwaiter().GetResult())
                .As<IEndpointInstance>()
                .SingleInstance();

            _container = builder.Build();

            //var temp = _container.Resolve<IScheduledTask[]>(); 

            endpointConfiguration.UseContainer<AutofacBuilder>(c => c.ExistingLifetimeScope(_container));

            endpointConfiguration.EnableUniformSession();

            endpointConfiguration.SendFailedMessagesTo(GetErrorQueueName());
            endpointConfiguration.AuditProcessedMessagesTo(GetAuditQueueName());

            endpointConfiguration.UseSerialization<NewtonsoftSerializer>();
            // endpointConfiguration.HeartbeatPlugin(serviceControlQueue: "ServiceControl_Queue");

            //enable installers for DEV purposes
            if (GetInstallerFlag())
                endpointConfiguration.EnableInstallers(); // TODO: Move to the appropriate place
                                                          //  else
                                                          //     endpointConfiguration.DisableInstallers();

            //var assemblyScanner = endpointConfiguration.AssemblyScanner();
            //assemblyScanner.ThrowExceptions = false;

            var transportMode = GetTransportMode();
            if (transportMode == TransportMode.LocalFile)
            {
                var transport = endpointConfiguration.UseTransport<LearningTransport>();
                transport.StorageDirectory(GetLocalFileTransportModeLocation());
                BuildEndpointRouting(transport.Routing());
                endpointConfiguration.UsePersistence<LearningPersistence>();
            }
            else
            {
                var transport =
                    endpointConfiguration.UseTransport<SqlServerTransport>()
                        .ConnectionString(GetTransportConnectionString());

                transport.DefaultSchema(DefaultNsbSchema);
                BuildEndpointRouting(transport.Routing());

                var nhConfig = new NHibernate.Cfg.Configuration();
                nhConfig.SetProperty(Environment.ConnectionProvider, "NHibernate.Connection.DriverConnectionProvider");
                nhConfig.SetProperty(Environment.ConnectionDriver, "NHibernate.Driver.Sql2008ClientDriver");
                nhConfig.SetProperty(Environment.Dialect, "NHibernate.Dialect.MsSql2008Dialect");
                nhConfig.SetProperty(Environment.ConnectionString, GetPersistenceConnectionString());
                nhConfig.SetProperty(Environment.DefaultSchema, DefaultNsbSchema);
                endpointConfiguration.UsePersistence<NHibernatePersistence>()

#if !DEBUG
               .DisableSchemaUpdate()
#endif
                .UseConfiguration(nhConfig);
            }


            //Set message conventions
            endpointConfiguration.Conventions()
                .DefiningEventsAs(DefineEventTypes())
                .DefiningCommandsAs(DefineCommandTypes())
                .DefiningMessagesAs(DefineMessageTypes());

            //Set max concurrency;
            endpointConfiguration.LimitMessageProcessingConcurrencyTo(25);

            //Set retry
            var recoverability = endpointConfiguration.Recoverability();
            //immediate
            recoverability.Immediate(
            immediate =>
            {
                immediate.NumberOfRetries(3);
            });
            //delayed
            recoverability.Delayed(
            delayed =>
            {
                delayed.NumberOfRetries(2);
                delayed.TimeIncrease(TimeSpan.FromMinutes(3));
            });


            // Metrics does not apply top send only endpoints
            if (!_isSendOnly && GetMetricsFlag())
            {
                var performanceCounters = endpointConfiguration.EnableWindowsPerformanceCounters();
                performanceCounters.EnableSLAPerformanceCounters(TimeSpan.FromMinutes(GetMetricsSla()));
                //performanceCounters. UpdateCounterEvery(TimeSpan.FromSeconds(GetMetricsInterval()));

                var metrics = endpointConfiguration.EnableMetrics();

                metrics.SendMetricDataToServiceControl(
                    serviceControlMetricsAddress: "Particular.Monitoring",
                    interval: TimeSpan.FromSeconds(10));

            }

            // Activate Custom checks if enabled
            if (GetCustomCheckFlag())
            {
                var queue = GetCustomCheckQueueName();
                if (!string.IsNullOrEmpty(queue))
                    endpointConfiguration.ReportCustomChecksTo(queue, TimeSpan.FromMinutes(GetCustomCheckTtlInMinutes()));
            }

            // Activate saga plugin if enabled
            if (GetSagaPluginFlag())
            {
                endpointConfiguration.AuditSagaStateChanges(serviceControlQueue: "particular.servicecontrol@machine");
            }

            // Set up logging
            var logConfiguration = LogConfiguration.ReadFromConfigurationWithDefaultValues();
            logConfiguration.LogFileName = _configEndpointName;
            logConfiguration.EventSource = _configEndpointName;
            LogConfigurator.Configure(logConfiguration);

            // Set up audit logging
            LogConfigurator.ConfigureAudit(logConfiguration);

            // Set NSB to use NLog
            LogManager.Use<NLogFactory>();

            LocalCustomize(endpointConfiguration);

            return endpointConfiguration;
        }

        #endregion

        #region Protected Methods

        public virtual IContainer GetEndpointContainer()
        {
            return _container;
        }

        protected virtual Func<Type, bool> DefineMessageTypes()
        {
            return TypeScanner.IsMessage;
        }

        protected virtual Func<Type, bool> DefineCommandTypes()
        {
            return TypeScanner.IsCommand;
        }

        protected virtual Func<Type, bool> DefineEventTypes()
        {
            return TypeScanner.IsEvent;
        }

        protected virtual void LocalCustomize(EndpointConfiguration configuration) { }

        protected abstract IEnumerable<Type> GetServiceReferences();

        public virtual ContainerBuilder GetContainerBuilder()
        {
            return new DependenciesBuilder(typeScanner.GetAllScannedTypes()).CreateContainer();
        }

        protected virtual string GetSchemaForEndpoint(string endpointName)
        {
            if (endpointName == null) throw new ArgumentNullException("endpointName");

            if (String.Equals(endpointName, GetAuditQueueName(), StringComparison.InvariantCultureIgnoreCase))
                return GetDefaultServiceControlSchema();

            if (String.Equals(endpointName, GetErrorQueueName(), StringComparison.InvariantCultureIgnoreCase))
                return GetDefaultServiceControlSchema();

            if (String.Equals(endpointName, GetServiceControlQueueName(), StringComparison.InvariantCultureIgnoreCase))
                return GetDefaultServiceControlSchema();

            if (String.Equals(endpointName, GetMonitoringServiceQueueName(), StringComparison.InvariantCultureIgnoreCase))
                return GetDefaultServiceControlSchema();


            return GetTransportSchema();
        }

        private Assembly[] GetAssembliesToScan()
        {
            var scannableAssembies = new AssemblyScanner().GetScannableAssemblies().Assemblies.ToArray();
            //root assembly direct referenced assemblies
            var directReferencedAssemblies = GetType().Assembly.GetReferences(scannableAssembies).ToArray();
            //service assemblies
            var referencedServicesAssemblies = GetServiceReferences().Select(refType => refType.Assembly).ToArray();
            //service assemblies' referenced assemblies
            var referencedAssembliesByServices = referencedServicesAssemblies.SelectMany(a => a.GetReferences(scannableAssembies)).ToArray();

            //NSB assemblies
            var nsbAssemblies =
                scannableAssembies.Where(
                        a => a.FullName.StartsWith("ServiceControl.", StringComparison.OrdinalIgnoreCase) ||
                             a.FullName.StartsWith("NServiceBus.", StringComparison.OrdinalIgnoreCase))
                    .ToArray();

            var toScanAssemblies = new[] { GetType().Assembly }
                .Union(directReferencedAssemblies)
                .Union(referencedServicesAssemblies)
                .Union(referencedAssembliesByServices)
                .Union(nsbAssemblies)
                .Distinct();

            return toScanAssemblies.ToArray();
        }

        protected virtual string GetDefaultServiceControlSchema()
        {
            return DefaultServiceControlSchema;
        }

        protected string GetAuditQueueName()
        {
            return "Audit";
        }

        protected string GetErrorQueueName()
        {
            return "Error";
        }

        private string GetServiceControlQueueName()
        {
            return GetEndpointNameWithPrefixedEnvironment(GetEnvironmentName(), "Particular.ServiceControl");
        }

        private string GetMonitoringServiceQueueName()
        {
            return GetEndpointNameWithPrefixedEnvironment(GetEnvironmentName(), "Particular.Monitoring");
        }

        protected abstract string GetPersistenceConnectionString();

        protected abstract string GetServiceControlConnectionString();

        protected virtual string GetConnectionStringForEndpoint(string endpointName)
        {
            if (endpointName == null) throw new ArgumentNullException("endpointName");

            if (endpointName.Contains(GetEndpointName()))
                return GetTransportConnectionString();

            if (string.Equals(endpointName, GetAuditQueueName(), StringComparison.InvariantCultureIgnoreCase))
                return GetServiceControlConnectionString();

            if (string.Equals(endpointName, GetErrorQueueName(), StringComparison.InvariantCultureIgnoreCase))
                return GetServiceControlConnectionString();

            if (string.Equals(endpointName, GetServiceControlQueueName(), StringComparison.InvariantCultureIgnoreCase))
                return GetServiceControlConnectionString();

            if (string.Equals(endpointName, GetMonitoringServiceQueueName(), StringComparison.InvariantCultureIgnoreCase))
                return GetServiceControlConnectionString();

            var connectionString = ConfigurationManager.AppSettings[GetConnectionStringConfigNameFromEndpointName(endpointName)];

            if (string.IsNullOrEmpty(connectionString))
                throw new ArgumentException(string.Format("The configuration doesn't have the connection string '{1}' for endpoint '{0}' or the value is empty", endpointName, connectionString), "endpointName");

            return connectionString;
        }

        protected virtual string GetConnectionStringConfigNameFromEndpointName(string endpointName)
        {
            if (endpointName == null) throw new ArgumentNullException("endpointName");
            var parts = endpointName.Split('.');
            if (parts.Length < 3 ||
                !parts[0].EndsWith("WUBS", StringComparison.OrdinalIgnoreCase) ||
                !parts[1].Equals("Endpoints", StringComparison.OrdinalIgnoreCase))
            {
                throw new ArgumentException(string.Format("Endpoint '{0}' doesn't follow convention WUBS.Endpoints.*. Can't guess the connection string suffix for this endpoint.", endpointName), "endpointName");
            }
            var endpointNameSuffix = parts[2];
            return string.Format("ConnectionString.{0}", endpointNameSuffix);
        }

        protected abstract string GetTransportConnectionString();

        private static string GetEndpointNameWithPrefixedEnvironment(string environment, string endpointName)
        {
            return !string.IsNullOrWhiteSpace(environment) ? string.Format("{0}_{1}", environment, endpointName) : endpointName;
        }


        protected bool GetInstallerFlag()
        {
            var cfg = "Installer.Enabled";
            return ConfigurationManager.AppSettings[cfg] != null &&
                   Convert.ToBoolean(ConfigurationManager.AppSettings[cfg]);
        }

        protected abstract string GetEnvironmentName();

        public virtual string GetEndpointName()
        {
            var endpointName = GetQueueName();
            var environment = GetEnvironmentName();

            return GetEndpointNameWithPrefixedEnvironment(environment, endpointName);
        }

        private string GetQueueName()
        {
            return GetType().Assembly.GetName().Name;
        }

        protected TransportMode GetTransportMode()
        {
            var cKey = "Transport.Mode";
            var cfg = ConfigurationManager.AppSettings[cKey] ?? "Database";

            return cfg.ToLower() == "localfile" ? TransportMode.LocalFile : TransportMode.Database;
        }

        protected string GetLocalFileTransportModeLocation()
        {
            var cKey = "Transport.LocalFile.Path";
            var cfg = ConfigurationManager.AppSettings[cKey] ?? string.Empty;

            if (string.IsNullOrEmpty(cfg))
                throw new ArgumentNullException(
                    "Transport.LocalFile.Path cannot be null or empty in the endpoint config file");
            return cfg;
        }

        protected bool GetMetricsFlag()
        {
            var cfg = "Metrics.Enabled";
            return ConfigurationManager.AppSettings[cfg] != null &&
                   Convert.ToBoolean(ConfigurationManager.AppSettings[cfg]);
        }

        protected bool GetSagaPluginFlag()
        {
            var cfg = "SagaPlugin.Enabled";
            return ConfigurationManager.AppSettings[cfg] != null &&
                   Convert.ToBoolean(ConfigurationManager.AppSettings[cfg]);
        }

        protected bool GetCustomCheckFlag()
        {
            var cfg = "CustomHealthCheck.Enabled";
            return ConfigurationManager.AppSettings[cfg] != null &&
                   Convert.ToBoolean(ConfigurationManager.AppSettings[cfg]);
        }

        protected string GetCustomCheckQueueName()
        {
            var cKey = "CustomHealthCheck.ServiceControlQueue";
            var cfg = ConfigurationManager.AppSettings[cKey] ?? string.Empty;

            return cfg;
        }

        protected double GetCustomCheckTtlInMinutes()
        {
            var cKey = "CustomHealthCheck.TTL.Minutes";

            var value = ConfigurationManager.AppSettings[cKey];
            double cfg;
            if (!Double.TryParse(value, out cfg))
                return Defaults.CustomHealthCheckTtlInMinutes;

            return Convert.ToDouble(cfg);
        }

        protected string GetTransportSchema()
        {
            var cKey = "Connection.Transport.Schema";
            var cfg = ConfigurationManager.AppSettings[cKey] ?? Defaults.DatabaseSchema;

            return cfg;
        }

        protected string GetPersistenseSchema()
        {
            var cKey = "Connection.Persistence.Schema";
            var cfg = ConfigurationManager.AppSettings[cKey] ?? Defaults.DatabaseSchema;

            return cfg;
        }

        protected int GetMetricsSla()
        {
            var cKey = "Metrics.SLA.Minutes";
            int cfg;

            return (int.TryParse(ConfigurationManager.AppSettings[cKey], out cfg) && cfg > 0
                ? cfg
                : Defaults.MetricsSlaInMinutes);
        }

        protected int GetMetricsInterval()
        {
            var cKey = "Metrics.Interval.Seconds";
            int cfg;

            return (int.TryParse(ConfigurationManager.AppSettings[cKey], out cfg) && cfg > 0
                ? cfg
                : Defaults.MetricsIntervalInSeconds);
        }

        #endregion

        #region Private Methods

        public virtual RoutingSettings<SqlServerTransport> BuildEndpointRouting(
            RoutingSettings<SqlServerTransport> routing)
        {

            var routes = typeScanner.GetAllTypesWithPublishingEndpoints();

            foreach (var route in routes)
            {
                var assemblyType = route.Item1;
                var endpoint = GetEndpointNameWithPrefixedEnvironment(GetEnvironmentName(), route.Item2);

                if (assemblyType.IsInterface)
                {
                    routing.RegisterPublisher(assemblyType, endpoint);
                }
                else if (assemblyType.IsClass && !assemblyType.IsAbstract)
                {
                    routing.RouteToEndpoint(assemblyType, endpoint);
                }
            }

            return routing;
        }

        public virtual RoutingSettings<LearningTransport> BuildEndpointRouting(
            RoutingSettings<LearningTransport> routing)
        {
            var routes = typeScanner.GetAllTypesWithPublishingEndpoints();

            foreach (var route in routes)
            {
                var assemblyType = route.Item1;
                var endpoint = GetEndpointNameWithPrefixedEnvironment(GetEnvironmentName(), route.Item2);
                routing.RouteToEndpoint(assemblyType, endpoint);
            }

            return routing;
        }

        #endregion
    }
}
