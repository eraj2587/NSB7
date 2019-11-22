using NServiceBus;

namespace NSB.Contracts.Commands
{
    public class StopScheduledTask : ICommand
    {
        public virtual string TaskTypeFullName { get; set; }
    }
}
