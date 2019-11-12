using NServiceBus;

namespace WUBS.Contracts.Commands
{
    public class StopScheduledTask : ICommand
    {
        public virtual string TaskTypeFullName { get; set; }
    }
}
