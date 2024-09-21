/***********************************************************************************************
 * Copyright(c) 2018-2024 YaMo Studio All rights reserved.
 * 
 * File Infomation:
 *      Class Name : LoggerConfiguration
 *      Description : class description
 *      Author : YaMo Studio
 *      Create Date : 2024/9/21 21:03:15
 * 
 * Revision Record:
 *      1.Create this file at 2024/9/21 21:03:15 by YaMo Studio.
 ***********************************************************************************************/
namespace YaMoLogger.Extensions
{
    /// <summary>
    /// class description
    /// </summary>
    public class LoggerConfiguration
    {
        /// <summary>
        /// ��־������
        /// </summary>
        public LoggerType LoggerType {  get; set; } = LoggerType.File;

        /// <summary>
        /// ��־�ļ�����
        /// </summary>
        public string LoggerFileName { get; set; } = "file.log";

        /// <summary>
        /// ��־�洢·��
        /// </summary>
        public string LoggerFilePath { get; set; } = "log/";

        /// <summary>
        /// ��־����
        /// </summary>
        public LoggerPriority LoggerPriority { get; set; } = LoggerPriority.Info;
    }
}
