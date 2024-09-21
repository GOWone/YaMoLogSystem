/***********************************************************************************************
 * Copyright(c) 2018-2024 YaMo Studio All rights reserved.
 * 
 * File Infomation:
 *      Class Name : LoggerConfiguration
 *      Description : class description
 *      Author : YaMo Studio
 *      Create Date : 2024/4/18 21:03:15
 * 
 * Revision Record:
 *      1.Create this file at 2024/4/18 21:03:15 by YaMo Studio.
 ***********************************************************************************************/

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
