using System;
using NServiceBus;
using NServiceBus.UniformSession;
using WUBS.Infrastructure.Messaging;

namespace WUBS.Endpoints.Server
{
    public class SampleScheduledTask : ScheduledTaskDefinition
    {
        public override bool IsEnabled { get { return false; } }
        public override TimeSpan WaitDuration { get { return TimeSpan.FromSeconds(10); } }

        public SampleScheduledTask(IUniformSession session) : base(session)
        {
        }

        public override bool Run()
        {
            return true;
        }

       
    }
}
