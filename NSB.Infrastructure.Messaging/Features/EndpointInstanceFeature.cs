using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NServiceBus.Features;
using Autofac;
using ServiceModelEx;
using NSB.Infrastructure.Wcf;
using NSB.Infrastructure.Wcf.Audit;

namespace NSB.Infrastructure.Messaging.Features
{
    public abstract class EndpointInstanceFeature // : Feature
    {
        public EndpointInstanceFeature()
        {
           // EnableByDefault();
        }
        protected  void Setup(FeatureConfigurationContext context)
        {
            var scope = context.Settings.GetOrDefault<ILifetimeScope>("ExistingLifetimeScope");
            if (scope == null) return;
            InProcFactory.Scope = scope;
            InProcFactory.SetGenericResolver(scope.ComponentRegistry.Registrations.Select(r => r.Activator.LimitType).ToArray());
            InProcFactory.SetDefaultServiceBehaviour(new AuditInterceptorServiceBehavior(), new ErrorHandlerServiceBehaviour());
            Start();
        }

        public abstract void Start();
        public abstract void Stop();
    }
}
