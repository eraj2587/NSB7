using System;
using NServiceBus;
using NServiceBus.UniformSession;
using WUBS.Infrastructure.Messaging;

namespace WUBS.Endpoints.Server
{
    public class SampleScheduledTask  : ScheduledTaskDefinition
    {
         private readonly IEndpointInstance instance;
        //IUniformSession _session;

        public override bool IsEnabled { get { return false; } }
        public override TimeSpan WaitDuration { get { return TimeSpan.FromSeconds(10); } }

        public SampleScheduledTask(IEndpointInstance _instance) : base(_instance)
        {
            instance = _instance;
        }

        //public SampleScheduledTask(IUniformSession session) //: base(session)
        //{
        //    _session = session;
        //}

        public override bool Run()
        {
            return true;
        }


    }
}
