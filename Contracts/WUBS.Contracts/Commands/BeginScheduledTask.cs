using System;
using NServiceBus;

namespace WUBS.Contracts.Commands
{
    public class BeginScheduledTask : ICommand
    {
        public virtual string TaskTypeFullName { get; set; }
        public virtual TimeSpan WaitDuration { get; set; }
    }
}
