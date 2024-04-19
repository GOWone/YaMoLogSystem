using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YaMoLogger.Parameters;

namespace YaMoLogger
{
    public static class YaMoLoggerHepler
    {
        private readonly static IConfigurationRoot configuration;
        private readonly static ConsoleLogger consoleLogger;
        private readonly static FileLogger fileLogger;

        static YaMoLoggerHepler()
        {
            consoleLogger = new ConsoleLogger();
            fileLogger = new FileLogger();
            configuration = new ConfigurationBuilder()
                .AddXmlFile("YaMoLogger.config", true, true)
                .Build();
        }

        public static Logger? GetLogger(LoggerPriority curPriority)
        {
            var target = configuration["logger:target:value"];
            var priority = configuration["logger:priority:value"];

            Logger? logger = target?.ToLower() switch
            {
                "console" => consoleLogger,
                "file" => fileLogger,
                _ => null,
            };
            return priority?.ToLower() switch
            {
                "debug" => logger,
                "info" => curPriority >= LoggerPriority.Info ? logger : null,
                "warn" => curPriority >= LoggerPriority.Warn ? logger : null,
                "error" => curPriority >= LoggerPriority.Error ? logger : null,
                "fatal" => curPriority >= LoggerPriority.Fatal ? logger : null,
                _ => null
            };

        }

        public static void Debug(string message)
        {
            GetLogger(LoggerPriority.Debug)?.Debug(message);
        }

        public static void Info(string message)
        {
            GetLogger(LoggerPriority.Info)?.Info(message);
        }

        public static void Warn(string message)
        {
            GetLogger(LoggerPriority.Warn)?.Warn(message);
        }

        public static void Error(string message)
        {
            GetLogger(LoggerPriority.Error)?.Error(message);
        }

        public static void Fatal(string message)
        {
            GetLogger(LoggerPriority.Fatal)?.Fatal(message);
        }
    }
}
