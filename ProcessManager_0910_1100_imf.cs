// 代码生成时间: 2025-09-10 11:00:21
// <copyright file="ProcessManager.cs" company="YourCompany">
// 版权所有 (c) YourCompany. 保留所有权利。
// </copyright>

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace YourNamespace
{
    /// <summary>
    /// 进程管理器，用于管理系统的进程。
    /// </summary>
    public class ProcessManager
    {
        /// <summary>
        /// 获取系统中所有活动的进程。
        /// </summary>
        /// <returns>进程列表</returns>
        public List<Process> GetAllProcesses()
        {
            try
            {
                return Process.GetProcesses().ToList();
            }
            catch (Exception ex)
            {
                // 处理获取进程失败的情况
                Console.WriteLine($"获取进程信息失败：{ex.Message}");
                return new List<Process>();
            }
        }

        /// <summary>
        /// 启动一个新的进程。
        /// </summary>
        /// <param name="processName">进程名称</param>
        public void StartProcess(string processName)
        {
            try
            {
                Process.Start(processName);
            }
            catch (Exception ex)
            {
                // 处理启动进程失败的情况
                Console.WriteLine($"启动进程失败：{ex.Message}");
            }
        }

        /// <summary>
        /// 结束指定的进程。
        /// </summary>
        /// <param name="processId">进程ID</param>
        public void KillProcess(int processId)
        {
            try
            {
                var process = Process.GetProcessById(processId);
                process.Kill();
            }
            catch (Exception ex)
            {
                // 处理结束进程失败的情况
                Console.WriteLine($"结束进程失败：{ex.Message}");
            }
        }

        /// <summary>
        /// 搜索具有特定名称的进程。
        /// </summary>
        /// <param name="processName">进程名称</param>
        /// <returns>匹配的进程列表</returns>
        public List<Process> FindProcessesByName(string processName)
        {
            try
            {
                return Process.GetProcesses()
                    .Where(p => p.ProcessName.Contains(processName, StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }
            catch (Exception ex)
            {
                // 处理搜索进程失败的情况
                Console.WriteLine($"搜索进程失败：{ex.Message}");
                return new List<Process>();
            }
        }
    }
}
