using Autofac;
using Autofac.Integration.Wcf;
using NServiceBus.Logging;
using ServiceModelEx;
using System;
using System.Collections.Generic;
using System.IdentityModel.Configuration;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceModel.Security;
using WUBS.Infrastructure.Wcf.Audit;
using WUBS.Infrastructure.Wcf.Security;

namespace WUBS.Infrastructure.Wcf
{
    public abstract class AbstractStartableServiceHost<T> : ServiceHost<T>, IStartableServiceHost
    {
        public ILifetimeScope RootScope { get; set; }
        public IEnumerable<IServiceAuthorizer> ServiceAuthorizers { get; set; }
        public IEnumerable<IServiceAuthenticator> ServiceAuthenticators { get; set; }

        protected readonly ILog Logger;
        private readonly ServiceSecurityMode[] serviceSecurityModes;
        private ILifetimeScope hostContainer;

        protected AbstractStartableServiceHost(Uri[] baseAddresses) : base(baseAddresses)
        {
            Logger = LogManager.GetLogger(GetType().Name);
            serviceSecurityModes = ServiceSecurityMode.GetSecurityModesFromConfig();
        }

        private void Configure()
        {
            this.Credentials.UseIdentityConfiguration = true;
            this.Credentials.IdentityConfiguration = new IdentityConfiguration()
            {
                ClaimsAuthenticationManager = new AuthenticationManager(ServiceAuthenticators, BaseAddresses.ToArray()),
                ClaimsAuthorizationManager = new AuthorizationManager(ServiceAuthorizers, BaseAddresses.ToArray()),
                IssuerNameRegistry = new X509CertIssuerNameRegistry(),
                CertificateValidationMode = X509CertificateValidationMode.None
            };
            this.Description.Behaviors.Find<ServiceAuthorizationBehavior>().PrincipalPermissionMode = PrincipalPermissionMode.Always;

            foreach (var serviceSecurityMode in serviceSecurityModes)
            {
                if (serviceSecurityMode is NoneServiceSecurityMode) Logger.WarnFormat("*** Security mode is set to None which is insecure! ***");
                var endpoints = this.AddServiceEndpoints(serviceSecurityMode);
                foreach (var serviceEndpoint in endpoints)
                {
                    Logger.InfoFormat("Endpoint {0} added, security mode {1}, uri {2}", serviceEndpoint.Contract.ContractType.FullName, serviceSecurityMode, serviceEndpoint.Address.Uri);
                }
            }
            this.SetServiceHostSecurity(serviceSecurityModes);
            this.EnableMetadataExchange();

            this.AddDependencyInjectionBehavior<T>(hostContainer);
            this.EnableTransactionFlowAndReliableMessaging();
            this.IncludeExceptionDetailInFaults = DebugHelper.IncludeExceptionDetailInFaults;
            this.AddErrorHandler(new ErrorHandler(Logger));
            this.SecurityAuditEnabled = true;

            this.Description.Behaviors.Find<ServiceBehaviorAttribute>().InstanceContextMode =
                InstanceContextMode.PerCall;
            this.Description.Behaviors.Add(new AuditInterceptorServiceBehavior());
            this.TypesToResolve = RootScope.ComponentRegistry.Registrations.Select(r => r.Activator.LimitType).ToArray();
        }

        public void Start()
        {
            hostContainer = RootScope.BeginLifetimeScope();
            Logger.InfoFormat("Starting Service Host for '{0}'", typeof(T).Name);
            Configure();
            Open();
            Logger.InfoFormat("ServiceHost for '{0}' started successfully", typeof(T).Name);
        }

        public void Stop()
        {
            Logger.InfoFormat("Stopping Service Host for '{0}'", typeof(T).Name);
            Close(TimeSpan.FromSeconds(30));
            hostContainer.Dispose();
            Logger.InfoFormat(" ServiceHost for '{0}' was stopped successfully", typeof(T).Name);
        }
    }
}