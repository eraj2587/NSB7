using System;
using NServiceBus;

namespace NSB.Contracts.Commands
{
    public class BeginScheduledTask : ICommand
    {
        public virtual string TaskTypeFullName { get; set; }
        public virtual TimeSpan WaitDuration { get; set; }
    }
}
