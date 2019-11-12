using System;

namespace WUBS.Infrastructure.Messaging
{
    public interface IScheduledTask
    {
        //return true to request to be run again immediately
        bool Run();
        TimeSpan WaitDuration { get; }
        bool IsEnabled { get; }
    }
}
