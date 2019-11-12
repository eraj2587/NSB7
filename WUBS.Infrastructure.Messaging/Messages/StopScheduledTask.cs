using NServiceBus;

namespace WUBS.Infrastructure.Messaging.Messages
{
    public class StopScheduledTask : ICommand
    {
        public virtual string TaskTypeFullName { get; set; }
    }
}
