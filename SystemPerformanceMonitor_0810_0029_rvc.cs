// 代码生成时间: 2025-08-10 00:29:27
// <copyright file="SystemPerformanceMonitor.cs" company="YourCompanyName">
//     Copyright (c) YourCompanyName. All rights reserved.
// </copyright>

using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace YourNamespace
{
    /// <summary>
    /// A controller for system performance monitoring.
    /// </summary>
    [ApiController]
    [Route("[controller]/[action]")]
    public class SystemPerformanceMonitorController : ControllerBase
    {
        private readonly ILogger<SystemPerformanceMonitorController> _logger;

        /// <summary>
        /// Initializes a new instance of the SystemPerformanceMonitorController class.
        /// </summary>
        /// <param name="logger">The logger instance.</param>
        public SystemPerformanceMonitorController(ILogger<SystemPerformanceMonitorController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Gets the current system performance metrics.
        /// </summary>
        /// <returns>A task that returns the performance metrics as JSON.</returns>
        [HttpGet]
        public async Task<IActionResult> GetPerformanceMetrics()
        {
            try
            {
                // Collect performance metrics from the system
                var metrics = await Task.Run(() =>
                {
                    var cpuUsage = GetCpuUsage();
                    var memoryUsage = GetMemoryUsage();
                    var diskUsage = GetDiskUsage();

                    return new
                    {
                        CpuUsage = cpuUsage,
                        MemoryUsage = memoryUsage,
                        DiskUsage = diskUsage
                    };
                });

                return Ok(metrics);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving performance metrics");
                return StatusCode(500, "An error occurred while retrieving performance metrics.");
            }
        }

        /// <summary>
        /// Gets the CPU usage as a percentage.
        /// </summary>
        /// <returns>The CPU usage as a percentage.</returns>
        private double GetCpuUsage()
        {
            return Process.GetCurrentProcess().CpuUsage();
        }

        /// <summary>
        /// Gets the memory usage of the system in megabytes.
        /// </summary>
        /// <returns>The memory usage in megabytes.</returns>
        private long GetMemoryUsage()
        {
            return Process.GetCurrentProcess().WorkingSet64 / (1024 * 1024);
        }

        /// <summary>
        /// Gets the disk usage of the system.
        /// </summary>
        /// <returns>The disk usage in gigabytes.</returns>
        private double GetDiskUsage()
        {
            var drives = DriveInfo.GetDrives();
            double totalDiskUsage = 0;
            foreach (var drive in drives)
            {
                if (drive.IsReady)
                {
                    totalDiskUsage += drive.TotalSize;
                }
            }
            return totalDiskUsage / (1024 * 1024 * 1024); // Convert bytes to gigabytes
        }
    }
}
