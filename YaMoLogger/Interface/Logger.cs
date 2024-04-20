namespace YaMoLogger
{
    public abstract class Logger
    {
        public abstract void Log(string message, LoggerPriority priority);

        /// <summary>
        /// 控制日志级别
        /// </summary>
        /// <param name="curPriority"></param>
        /// <returns></returns>
        public virtual bool IsWriteable(LoggerPriority curPriority)
        {
            return LoggerConfigHelper.GetPriority()?.ToLower() switch
            {
                "debug" => true,
                "info" => curPriority >= LoggerPriority.Info,
                "warn" => curPriority >= LoggerPriority.Warn,
                "error" => curPriority >= LoggerPriority.Error,
                "fatal" => curPriority >= LoggerPriority.Fatal,
                _ => true
            };
        }
    }
}
