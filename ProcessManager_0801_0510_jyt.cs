// 代码生成时间: 2025-08-01 05:10:26
using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;

// 进程管理器类
public class ProcessManager
{
    // 获取所有正在运行的进程
    public List<Process> GetAllProcesses()
    {
        // 使用Process类获取所有进程
        return Process.GetProcesses().ToList();
    }

    // 启动一个新进程
    public void StartProcess(string fileName, string arguments)
    {
        try
        {
            ProcessStartInfo startInfo = new ProcessStartInfo()
            {
                FileName = fileName,
                Arguments = arguments,
                UseShellExecute = false,
                RedirectStandardOutput = true
            };

            using (Process proc = Process.Start(startInfo))
            {
                // 这里可以添加代码来读取进程的输出
                // proc.StandardOutput.ReadToEnd();
            }
        }
        catch (Exception ex)
        {
            // 错误处理
            Console.WriteLine($"Failed to start process: {ex.Message}");
        }
    }

    // 终止一个进程
    public bool TerminateProcess(int processId)
    {
        try
        {
            Process process = Process.GetProcessById(processId);
            process.Kill();
            return true;
        }
        catch (Exception ex)
        {
            // 错误处理
            Console.WriteLine($"Failed to terminate process: {ex.Message}");
            return false;
        }
    }

    // 根据进程名查找进程
    public List<Process> FindProcessesByName(string processName)
    {
        return Process.GetProcesses()
                     .Where(p => p.ProcessName.Contains(processName, StringComparison.OrdinalIgnoreCase))
                     .ToList();
    }
}
