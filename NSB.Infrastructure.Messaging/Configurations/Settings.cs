
namespace NSB.Infrastructure.Messaging.Configurations
{
    public class NSBEndpoints
    {
        public const string InternalNotificationsEndpoint = "NSB.Endpoints.InternalNotifications";
    }

    public class MessageTypes
    {
        public const string Commands = "NSB.Messages.Commands";
        public const string Events = "NSB.Messages.Events";
        public const string Messages = "NSB.Messages";
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
