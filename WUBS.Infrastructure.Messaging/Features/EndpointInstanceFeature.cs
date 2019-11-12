using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NServiceBus.Features;
using Autofac;
using ServiceModelEx;
using WUBS.Infrastructure.Wcf;
using WUBS.Infrastructure.Wcf.Audit;

namespace WUBS.Infrastructure.Messaging.Features
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
