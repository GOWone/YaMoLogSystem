using YaMoLogger.Extensions;

namespace YaMoLogger
{
    public static class YaMoLoggerHepler
    {

        private readonly static LoggerDecorator consoleLogger;
        private readonly static LoggerDecorator fileLogger;

        static YaMoLoggerHepler()
        {
            consoleLogger = new LoggerDecorator(new ConsoleLogger());
            fileLogger = new LoggerDecorator(new FileLogger());

        }

        /// <summary>
        /// 获取日志器
        /// </summary>
        /// <returns></returns>
        public static Logger? GetLogger()
        {
            return LoggerConfigHelper.GetLoggerType()?.ToLower() switch
            {
                "console" => consoleLogger,
                "file" => fileLogger,
                _ => null,
            };
        }

        public static void Debug(string message)
        {
            GetLogger()?.Log(message, LoggerPriority.Debug);
        }

        public static void Info(string message)
        {
            GetLogger()?.Log(message, LoggerPriority.Info);
        }

        public static void Warn(string message)
        {
            GetLogger()?.Log(message, LoggerPriority.Warn);
        }

        public static void Error(string message)
        {
            GetLogger()?.Log(message, LoggerPriority.Error);
        }

        public static void Fatal(string message)
        {
            GetLogger()?.Log(message, LoggerPriority.Fatal);
        }
    }
}
