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

using Microsoft.Extensions.Configuration;

namespace YaMoLogger
{
    /// <summary>
    /// YaMoLogger配置
    /// </summary>
    public static class LoggerConfigHelper
    {
        private readonly static IConfigurationRoot configuration;

        static LoggerConfigHelper()
        {
            configuration = new ConfigurationBuilder()
                .AddXmlFile("YaMoLogger.config", optional: true, reloadOnChange: true)
                .Build();
        }

        /// <summary>
        /// 获取配置文件-日志类型
        /// </summary>
        /// <returns></returns>
        public static string? GetLoggerType()
        {
            var target = configuration["logger:target:value"];
            return target;
        }

        /// <summary>
        /// 获取配置文件-日志级别
        /// </summary>
        /// <returns></returns>
        public static string? GetPriority()
        {
            var priority = configuration["logger:priority:value"];
            return priority;
        }

        /// <summary>
        /// 获取配置文件-日志格式
        /// </summary>
        /// <returns></returns>
        public static string GetMsgPattern()
        {
            return configuration["logger:pattern:value"] ??= "%date [%priority] %message%newline";
        }

        /// <summary>
        /// 获取配置文件-日志文件路径
        /// </summary>
        /// <returns></returns>
        public static string GetLogPath()
        {
            return configuration["logger:target:file"] ??= DateTime.Now.ToString("yyyy-MM-dd") + ".log";
        }

        /// <summary>
        /// 获取配置文件-日志滚动时间(Minutes)
        /// </summary>
        /// <returns></returns>
        public static int GetRollTimeInMinutes()
        {
            var rollTime = configuration["logger:target:rollTimeInMinutes"] ??= "0";
            _ = int.TryParse(rollTime, out int result);
            return result;
        }

        /// <summary>
        /// 获取配置文件-日志滚动标记
        /// </summary>
        /// <returns></returns>
        public static string GetRollBackupsFlag()
        {
            var rollFlag = configuration["logger:target:flag"] ??= "ymlog";
            return rollFlag;
        }

        /// <summary>
        /// 获取配置文件-日志滚动大小(Kb)
        /// </summary>
        /// <returns></returns>
        public static int GetRollSizeInKb()
        {
            var rollSize = configuration["logger:target:rollSizeInKb"] ??= "0";
            _ = int.TryParse(rollSize, out int result);
            return result;
        }

        /// <summary>
        /// 获取配置文件-日志最大滚动数
        /// </summary>
        /// <returns></returns>
        public static int GetMaxRollBackups()
        {
            var maxRollBackups = configuration["logger:target:maxRollBackups"] ??= "0";
            _ = int.TryParse(maxRollBackups, out int result);
            return result;
        }
    }
}
