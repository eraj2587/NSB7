using System;
using NServiceBus;
using WUBS.Infrastructure.Messaging;

namespace WUBS.Endpoints.Server
{
    public class SampleScheduledTask : ScheduledTaskDefinition
    {
        private readonly IEndpointInstance instance;

        public override bool IsEnabled { get { return false; } }
        public override TimeSpan WaitDuration { get { return TimeSpan.FromSeconds(10); } }

        public SampleScheduledTask(IEndpointInstance _instance) : base(_instance)
        {
            instance = _instance;
        }

        public override bool Run()
        {
            return true;
        }

       
    }
}
