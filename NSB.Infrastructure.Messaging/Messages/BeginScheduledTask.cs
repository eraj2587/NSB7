using NServiceBus;
using System;

namespace WUBS.Infrastructure.Messaging.Messages
{
    public class BeginScheduledTask : ICommand
    {
        public virtual string TaskTypeFullName { get; set; }
        public virtual TimeSpan WaitDuration { get; set; }
    }
}
