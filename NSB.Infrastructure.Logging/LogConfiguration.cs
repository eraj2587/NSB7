using NLog;
using System;
using System.Configuration;

namespace NSB.Infrastructure.Logging
{
    public class LogConfiguration
    {
        public string LogFolder { get; set; }
        public string LogLevel { get; set; }
        public int MaxNumberOfLogFiles { get; set; }
        public long MaxSizeOfFile { get; set; }
        public string EventLog { get; set; }
        public string EventSource { get; set; }
        public string LogFileName { get; set; }
        public string Environment { get; set; }
        public static LogFactory NLogFactoryInstance;

        public static LogConfiguration ReadFromConfigurationWithDefaultValues()
        {
            return new LogConfiguration()
            {
                EventSource = GetLoggingEventSource(),
                EventLog = GetLoggingEventLogName(),
                MaxSizeOfFile = GetLoggingArchiveAboveSize(),
                MaxNumberOfLogFiles = GetLoggingMaxArchiveFiles(),
                LogFileName = GetLogFileName(),
                LogLevel = GetLoggingLevel(),
                LogFolder = GetLoggingFolder(),
                Environment = GetEnvironmentName()
            };
        }

        private static string GetLoggingEventSource()
        {
            return string.Empty;
        }

        private static string GetEnvironmentName()
        {
            var configValue = ConfigurationManager.AppSettings["Environment"];
            return string.IsNullOrEmpty(configValue) ? String.Empty : configValue;
        }

        private static string GetLogFileName()
        {
            return string.Empty;
        }

        private static string GetLoggingLevel()
        {
            var configValue = ConfigurationManager.AppSettings["Log.Level"];
            return (string.IsNullOrEmpty(configValue) ? "info" : configValue);
        }

        private static string GetLoggingFolder()
        {
            var configValue = ConfigurationManager.AppSettings["Log.Directory"];
            return string.IsNullOrEmpty(configValue) ? ".\\" : configValue;
        }

        private static long GetLoggingArchiveAboveSize()
        {
            return 10485760; // 10 MB
        }

        private static int GetLoggingMaxArchiveFiles()
        {
            var configValue = ConfigurationManager.AppSettings["Log.UnrestrictedLogsPerDay"];

            bool unrestrictedLogsPerDay = false;
            Boolean.TryParse(configValue, out unrestrictedLogsPerDay);

            return unrestrictedLogsPerDay ? 0 : 10;
        }

        private static string GetLoggingEventLogName()
        {
            // Must be in sync with Install enpoint script as event log is created by this script.
            return "NSB2";
        }
    }
}
