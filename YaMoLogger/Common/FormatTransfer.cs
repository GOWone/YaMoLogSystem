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
