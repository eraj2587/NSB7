
namespace WUBS.Infrastructure.Messaging.Configurations
{
    public class NSBEndpoints
    {
        public const string InternalNotificationsEndpoint = "WUBS.Endpoints.InternalNotifications";
    }

    public class MessageTypes
    {
        public const string Commands = "WUBS.Messages.Commands";
        public const string Events = "WUBS.Messages.Events";
        public const string Messages = "WUBS.Messages";
    }

    public class Defaults
    {
        public const string DatabaseSchema = "nsb";
        public const int MetricsSlaInMinutes = 1;
        public const int MetricsIntervalInSeconds = 2;
        public const double CustomHealthCheckTtlInMinutes = 30;
        public const int CustomHealthCheckIntervalInMinutes = 30;
    }
}
