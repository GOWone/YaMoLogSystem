namespace YaMoLogger
{
    public class FileLogger : Logger
    {
        private readonly string _logPath = "log.txt";

        public override void Debug(string message)
        {
           File.AppendAllText(_logPath, message + Environment.NewLine);
        }

        public override void Error(string message)
        {
            File.AppendAllText(_logPath, message + Environment.NewLine);
        }

        public override void Fatal(string message)
        {
            File.AppendAllText(_logPath, message + Environment.NewLine);
        }

        public override void Info(string message)
        {
            File.AppendAllText(_logPath, message + Environment.NewLine);
        }

        public override void Warn(string message)
        {
            File.AppendAllText(_logPath, message + Environment.NewLine);
        }
    }
}
