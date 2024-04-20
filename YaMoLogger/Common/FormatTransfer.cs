namespace YaMoLogger
{
    public static class FormatTransfer
    {
        public static string GetFormatMessage(string pattern, LoggerPriority priority, string msg)
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

            return pattern.Replace("%date", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                .Replace("%priority", priorityStr)
                .Replace("%message", msg)
                .Replace("%newline", Environment.NewLine);
        }
    }
}
