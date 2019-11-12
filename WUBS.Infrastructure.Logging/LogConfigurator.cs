using NLog;
using NLog.Config;
using NLog.Targets;
using System;

namespace WUBS.Infrastructure.Logging
{
    public static class LogConfigurator
    {
        public static void Configure(LogConfiguration configuration)
        {
            var logFolder = configuration.LogFolder;
            var archiveAboveSize = configuration.MaxSizeOfFile;
            var maxArchiveFiles = configuration.MaxNumberOfLogFiles;
            var eventLogName = configuration.EventLog;
            var eventLogSourceName = string.IsNullOrEmpty(configuration.Environment)
                ? configuration.EventSource
                : string.Format("{0}_{1}", configuration.Environment, configuration.EventSource);

            var config = new LoggingConfiguration();

            var consoleTarget = new ColoredConsoleTarget();
            config.AddTarget("console", consoleTarget);
            var fileTarget = new FileTarget();
            config.AddTarget("file", fileTarget);
            var eventLogTarget = new EventLogTarget();
            config.AddTarget("event", eventLogTarget);

            var consoleLogLevel = ConvertToNLogLogLevel(configuration.LogLevel);
            var fileLogLevel = ConvertToNLogLogLevel(configuration.LogLevel);
            var eventLogLevel = LogLevel.Warn;//ConvertToNLogLogLevel(configuration.LogLevel);

            consoleTarget.Layout = "${logger} ${message} ${onexception:${newline}${exception:format=tostring}}";

            fileTarget.FileName = String.Format("{0}/{1}_{2}", logFolder, configuration.LogFileName, "${shortdate}.log");
            fileTarget.ArchiveFileName = String.Format("{0}/{1}_{2}", logFolder, configuration.LogFileName, "${shortdate}_{#}.log");
            fileTarget.Layout = "${longdate} ${level} ${logger} ${message}${onexception:${newline}${exception:format=tostring}}";
            fileTarget.ArchiveAboveSize = Convert.ToInt64(archiveAboveSize);
            fileTarget.ArchiveNumbering = ArchiveNumberingMode.Sequence;
            fileTarget.MaxArchiveFiles = Convert.ToInt32(maxArchiveFiles);
            fileTarget.ConcurrentWrites = false;

            eventLogTarget.Layout = "${logger} ${message} ${onexception:${newline}${exception:format=tostring}}";
            eventLogTarget.Log = eventLogName;
            eventLogTarget.Source = eventLogSourceName;
            eventLogTarget.EventId = string.Format("${{when:inner={0}:when='${{level}}'=='Info'}}${{when:inner={1}:when='${{level}}'=='Error'}}${{when:inner={2}:when='${{level}}'=='Warn'}}",
                    EventCode.UndefinedInfo.GetHashCode(), EventCode.UndefinedError.GetHashCode(), EventCode.UndefinedWarning.GetHashCode());

            var consoleRule = new LoggingRule("*", consoleLogLevel, consoleTarget);
            config.LoggingRules.Add(consoleRule);
            var fileRule = new LoggingRule("*", fileLogLevel, fileTarget);
            config.LoggingRules.Add(fileRule);
            var eventLogRule = new LoggingRule("*", eventLogLevel, eventLogTarget);
            config.LoggingRules.Add(eventLogRule);

            LogManager.Configuration = config;
        }

        public static void ConfigureAudit(LogConfiguration configuration)
        {
            var logFolder = configuration.LogFolder;
            var logFileName = string.IsNullOrEmpty(configuration.Environment)
                ? configuration.LogFileName
                : string.Format("{0}_{1}", configuration.Environment, configuration.LogFileName);
            var archiveAboveSize = configuration.MaxSizeOfFile;

            var config = new LoggingConfiguration();

            var consoleTarget = new ColoredConsoleTarget();
            config.AddTarget("console", consoleTarget);
            var fileTarget = new FileTarget();
            config.AddTarget("file", fileTarget);

            var consoleLogLevel = ConvertToNLogLogLevel(configuration.LogLevel);
            var fileLogLevel = ConvertToNLogLogLevel(configuration.LogLevel);

            consoleTarget.Layout = "${message} ${onexception:${newline}${exception:format=tostring}}";

            fileTarget.Layout = "${message} ${onexception:${newline}${exception:format=tostring}}";
            fileTarget.FileName = String.Format("{0}/{1}_Audit_{2}", logFolder, logFileName, "${shortdate}.log");
            fileTarget.ArchiveFileName = String.Format("{0}/{1}_Audit_{2}", logFolder, logFileName, "${shortdate}_{#}.log");
            fileTarget.ArchiveAboveSize = Convert.ToInt64(archiveAboveSize);
            fileTarget.ArchiveNumbering = ArchiveNumberingMode.Sequence;
            fileTarget.MaxArchiveFiles = 0;  //0 means old files are not deleted
            fileTarget.EnableFileDelete = false;
            fileTarget.ConcurrentWrites = false;

            var consoleRule = new LoggingRule("*", consoleLogLevel, consoleTarget);
            config.LoggingRules.Add(consoleRule);
            var fileRule = new LoggingRule("*", fileLogLevel, fileTarget);
            config.LoggingRules.Add(fileRule);

            LogConfiguration.NLogFactoryInstance = new LogFactory(config);
        }

        private static LogLevel ConvertToNLogLogLevel(string logLevel)
        {
            switch (logLevel.ToLowerInvariant())
            {
                case "debug":
                    return LogLevel.Debug;
                case "info":
                    return LogLevel.Info;
                case "error":
                    return LogLevel.Error;
                default:
                    return LogLevel.Info;
            }
        }
    }
}
