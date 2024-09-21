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

using System.Text.RegularExpressions;

namespace YaMoLogger
{
    /// <summary>
    /// 文件日志器
    /// </summary>
    public class FileLogger : Logger
    {
        private readonly object _lock = new();   
        /// <summary>
        /// 输出日志
        /// </summary>
        /// <param name="message"></param>
        /// <param name="priority"></param>
        public override void Log(string message, LoggerPriority priority)
        {
            var logPath = LoggerConfigHelper.GetLogPath();
            if (this.IsWriteable(priority))
            {
                lock (_lock)
                {
                    CheckIsBackups();
                    CheckDirectory(logPath);
                    File.AppendAllText(logPath, message);
                }
            }
        }

        /// <summary>
        /// 检查是否需要日志滚动 
        /// </summary>
        public static void CheckIsBackups()
        {
            var logPath = LoggerConfigHelper.GetLogPath();
            var rollTime = LoggerConfigHelper.GetRollTimeInMinutes();
            var rollSize = LoggerConfigHelper.GetRollSizeInKb();
            var file = new FileInfo(logPath);
            if (!file.Exists)
            {
                return;
            }
            var timeDiff = DateTime.Now - file.CreationTime;
            var fileSizeInKb = file.Length / 1024;
            if (rollTime > 0 && timeDiff.TotalMinutes >= rollTime ||
                rollSize > 0 && fileSizeInKb >= rollSize)
            {
                LogRollBackups();
            }
        }

        /// <summary>
        /// 日志滚动
        /// </summary>
        public static void LogRollBackups()
        {
            var flag = LoggerConfigHelper.GetRollBackupsFlag();
            var newLogPath = $"{flag}.{DateTime.Now:yyyy-MM-dd-HH-mm}.log";
            var logPath = LoggerConfigHelper.GetLogPath();
            try
            {
                // 最大滚动数检查
                var maxRollBackups = LoggerConfigHelper.GetMaxRollBackups();
                if (maxRollBackups > 0)
                {
                    ClearOldRollBackups(maxRollBackups);
                }
                File.Move(logPath, newLogPath);
                File.Create(logPath).Close();
                // 重置创建时间
                File.SetCreationTime(logPath, DateTime.Now);
            }
            catch (Exception ex)
            {
                var msg = $"{ex.Message}{ex.StackTrace}{Environment.NewLine}";
                File.AppendAllText("Exception.log", msg);
            }
        }

        /// <summary>
        /// 清理过期日志
        /// </summary>
        private static void ClearOldRollBackups(int maxRollBackups)
        {
            var logPath = LoggerConfigHelper.GetLogPath();
            var backupsDir = Path.GetDirectoryName(logPath);
            var flag = LoggerConfigHelper.GetRollBackupsFlag();
            if (string.IsNullOrWhiteSpace(backupsDir))
            {
                backupsDir = Environment.CurrentDirectory;
            }

            var logFilePattern = $@"{Regex.Escape(flag)}\..*";
            var targetFiles = Directory.GetFiles(backupsDir)
                .Where(f => Regex.IsMatch(Path.GetFileName(f), logFilePattern))
                .ToArray();

            if (targetFiles.Length >= maxRollBackups)
            {
                Array.Sort(targetFiles, (a, b) => File.GetCreationTime(a).CompareTo(File.GetCreationTime(b)));

                for (int i = 0; i <= targetFiles.Length - maxRollBackups; i++)
                {
                    File.Delete(targetFiles[i]);
                }
            }
        }

        /// <summary>
        /// 路径检查
        /// </summary>
        /// <param name="path"></param>
        private static void CheckDirectory(string path)
        {
            var dir = Path.GetDirectoryName(path);
            if (!string.IsNullOrWhiteSpace(dir))
            {
                if (!Directory.Exists(dir))
                {
                    Directory.CreateDirectory(dir);
                }
            }
        }
    }
}
