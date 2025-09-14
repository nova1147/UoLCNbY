// 代码生成时间: 2025-09-14 09:39:14
using System;
using System.Diagnostics;
using System.Threading.Tasks;

/// <summary>
/// This class provides system performance monitoring functionality.
/// </summary>
public class SystemPerformanceMonitor
{
    /// <summary>
    /// Gets the current CPU usage as a percentage.
    /// </summary>
    /// <returns>The CPU usage as a double.</returns>
    public double GetCpuUsage()
    {
        var cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
        return cpuCounter.NextValue();
    }

    /// <summary>
    /// Gets the current memory usage in bytes.
    /// </summary>
    /// <returns>The total memory in bytes.</returns>
    public long GetMemoryUsage()
    {
        using var memoryInfo = new PerformanceCounter("Memory", "Available MBytes");
        var availableMemory = memoryInfo.NextValue();
        return (long)(availableMemory * 1024 * 1024); // Convert MB to bytes
    }

    /// <summary>
    /// Gets the current disk usage as a percentage of total disk space.
    /// </summary>
    /// <param name="drive">The drive letter to check, e.g., C.</param>
    /// <returns>The disk usage as a double.</returns>
    public double GetDiskUsage(char drive)
    {
        var diskInfo = new DriveInfo(drive + ":");
        return diskInfo.UsedPercentage;
    }

    /// <summary>
    /// Monitors the system performance and logs the data periodically.
    /// </summary>
    /// <param name="interval">The interval in milliseconds between logs.</param>
    public void MonitorPerformance(int interval)
    {
        try
        {
            while (true)
            {
                var cpuUsage = GetCpuUsage();
                var memoryUsage = GetMemoryUsage();

                Console.WriteLine($"CPU Usage: {cpuUsage}%");
                Console.WriteLine($"Memory Usage: {memoryUsage} bytes");

                // You can extend this to monitor other system metrics
                // and log them to a file, database, or any other storage.

                Task.Delay(interval).Wait();
            }
        }
        catch (Exception ex)
        {
            // Log the exception details to a file or external logging system.
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}
