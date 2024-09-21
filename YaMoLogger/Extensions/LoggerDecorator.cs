namespace YaMoLogger.Extensions
{
    /// <summary>
    /// Logger装饰器类
    /// </summary>
    public class LoggerDecorator : Logger
    {
        private readonly Logger _logger;
        public LoggerDecorator(Logger logger)
        {
            this._logger = logger;
        }

        public override void Log(string message, LoggerPriority priority)
        {
            var priorityStr = priority switch
            {
                LoggerPriority.Debug => "Debug",
                LoggerPriority.Info => "Info",
                LoggerPriority.Warn => "Warn",
                LoggerPriority.Error => "Error",
                LoggerPriority.Fatal => "Fatal",
                _ => "Normal"
            };

            var newMsg = LoggerConfigHelper.GetMsgPattern().Replace("%date", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                .Replace("%priority", priorityStr)
                .Replace("%message", message)
                .Replace("%newline", Environment.NewLine);
            this._logger.Log(newMsg, priority);
        }
    }
}
