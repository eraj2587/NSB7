using System;
using System.Linq;
using Autofac;
using NSB.Infrastructure.Messaging.Features;
using NSB.Infrastructure.Wcf;

namespace NSB.Infrastructure.Messaging
{
    public class ServiceHostsActivator : IDisposable
    {
        public IStartableServiceHost[] ServiceHosts { get; }

        public ServiceHostsActivator(IStartableServiceHost[] serviceHosts)
        {
            ServiceHosts = serviceHosts;
        }

        private void InvokeHostStart()
        {
            {
                foreach (var host in ServiceHosts)
                {
                    host.Start();
                }
            }
        }

        private void InvokeHostStop()
        {
            if (ServiceHosts.Any())
            {
                foreach (var host in ServiceHosts)
                {
                    host.Stop();
                }
            }
        }

        public void Stop()
        {
            InvokeHostStop();
        }

        public void Start()
        {
           // ServiceHosts = Container.Resolve<IStartableServiceHost[]>();
            InvokeHostStart();
        }

        //void Run(Configure config)
        //{
        //    var scope = config.Settings.GetOrDefault<ILifetimeScope>("ExistingLifetimeScope");
        //    if (scope == null) return;
        //    InProcFactory.Scope = scope;
        //    InProcFactory.SetGenericResolver(scope.ComponentRegistry.Registrations.Select(r => r.Activator.LimitType).ToArray());
        //    InProcFactory.SetDefaultServiceBehaviour(new AuditInterceptorServiceBehavior(), new ErrorHandlerServiceBehaviour());
        //}

        //void IWantToRunWhenConfigurationIsComplete.Run(Configure config)
        //{
        //    Start();
        //}

        public void Dispose()
        {
            Stop();
            GC.SuppressFinalize(this);
        }

    }
}