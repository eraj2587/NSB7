using System;
using NServiceBus;
using NServiceBus.UniformSession;
using NSB.Infrastructure.Messaging;

namespace NSB.Endpoints.Server
{
    public class SampleScheduledTask : ScheduledTaskDefinition
    {
        //private readonly IEndpointInstance instance;
        private readonly IUniformSession session;
        public override bool IsEnabled { get { return false; } }
        public override TimeSpan WaitDuration { get { return TimeSpan.FromSeconds(10); } }

        //public SampleScheduledTask(IEndpointInstance _instance) : base(_instance)
        //{
        //    instance = _instance;
        //}

        public SampleScheduledTask(IUniformSession session) : base(session)
        {
            this.session = session;
        }

        public override bool Run()
        {
            return true;
        }


    }
}
