/***********************************************************************************************
 * Copyright(c) 2018-2024 YaMo Studio All rights reserved.
 * 
 * File Infomation:
 *      Class Name : LoggerConfiguration
 *      Description : class description
 *      Author : YaMo Studio
 *      Create Date : 2024/4/20 21:03:15
 * 
 * Revision Record:
 *      1.Create this file at 2024/4/20 21:03:15 by YaMo Studio.
 ***********************************************************************************************/

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
