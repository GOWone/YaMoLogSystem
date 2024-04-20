using Microsoft.Extensions.FileSystemGlobbing.Internal;
using YaMoLogger;

namespace YaMoLogger
{
    /// <summary>
    /// 控制台日志器
    /// </summary>
    public class ConsoleLogger : Logger
    {
        public override void Log(string message, LoggerPriority priority)
        {
            if (this.IsWriteable(priority))
            {
                Console.WriteLine(message);
            }
        }
    }
}
