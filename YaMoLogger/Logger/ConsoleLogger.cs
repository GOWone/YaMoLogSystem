using YaMoLogger;

namespace YaMoLogger
{
    public class ConsoleLogger : Logger
    {
        public override void Debug(string message)
        {
           Console.WriteLine(message);
        }

        public override void Error(string message)
        {
            Console.WriteLine(message);
        }

        public override void Fatal(string message)
        {
            Console.WriteLine(message);
        }

        public override void Info(string message)
        {
            Console.WriteLine(message);
        }

        public override void Warn(string message)
        {
            Console.WriteLine(message);
        }
    }
}
