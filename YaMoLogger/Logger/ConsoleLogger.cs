/***********************************************************************************************
 * Copyright(c) 2018-2024 YaMo Studio All rights reserved.
 * 
 * File Infomation:
 *      Class Name : LoggerConfiguration
 *      Description : class description
 *      Author : YaMo Studio
 *      Create Date : 2024/4/19 21:03:15
 * 
 * Revision Record:
 *      1.Create this file at 2024/4/19 21:03:15 by YaMo Studio.
 ***********************************************************************************************/

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
