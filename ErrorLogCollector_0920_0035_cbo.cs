// 代码生成时间: 2025-09-20 00:35:59
using System;
using System.IO;
using Microsoft.Extensions.Logging;

namespace ErrorLogCollector
{
    // 错误日志收集器类
    public class ErrorLogCollector
    {
        private readonly ILogger<ErrorLogCollector> _logger;
        private readonly string _logFilePath;

        // 构造函数，注入ILogger和日志文件路径
        public ErrorLogCollector(ILogger<ErrorLogCollector> logger, string logFilePath)
        {
            _logger = logger;
            _logFilePath = logFilePath;
        }

        // 记录错误日志
        public void LogError(Exception ex)
        {
            try
            {
                string logEntry = $"{DateTime.Now}: {ex.Message}
{ex.StackTrace}";
                File.AppendAllText(_logFilePath, logEntry + "
");
            }
            catch (Exception logEx)
            {
                // 记录日志时遇到错误，使用内置的ILogger记录异常
                _logger.LogError(logEx, "Error occurred while logging an exception.");
            }
        }

        // 清除错误日志
        public void ClearLogs()
        {
            try
            {
                File.WriteAllText(_logFilePath, "");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while clearing logs.");
            }
        }
    }
}
