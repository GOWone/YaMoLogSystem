using YaMoLogger.Extensions;

namespace YaMoLogger
{
    public static class YaMoLoggerHepler
    {
        /// <summary>
        /// 控制台日志
        /// </summary>
        private readonly static LoggerDecorator consoleLogger;
        /// <summary>
        /// 文件日志
        /// </summary>
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

        /// <summary>
        /// Debug
        /// </summary>
        /// <param name="message"></param>
        public static void Debug(string message)
        {
            GetLogger()?.Log(message, LoggerPriority.Debug);
        }

        /// <summary>
        /// Info
        /// </summary>
        /// <param name="message"></param>
        public static void Info(string message)
        {
            GetLogger()?.Log(message, LoggerPriority.Info);
        }

        /// <summary>
        /// Warn
        /// </summary>
        /// <param name="message"></param>
        public static void Warn(string message)
        {
            GetLogger()?.Log(message, LoggerPriority.Warn);
        }

        /// <summary>
        /// Error
        /// </summary>
        /// <param name="message"></param>
        public static void Error(string message)
        {
            GetLogger()?.Log(message, LoggerPriority.Error);
        }

        /// <summary>
        /// Fatal
        /// </summary>
        /// <param name="message"></param>
        public static void Fatal(string message)
        {
            GetLogger()?.Log(message, LoggerPriority.Fatal);
        }
    }
}
