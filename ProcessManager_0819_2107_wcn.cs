// 代码生成时间: 2025-08-19 21:07:50
using System;
using System.Diagnostics;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ProcessManagerApp.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ProcessManagerController : ControllerBase
    {
        private readonly ILogger<ProcessManagerController> _logger;

        public ProcessManagerController(ILogger<ProcessManagerController> logger)
        {
            _logger = logger;
        }

        // GET: /ProcessManager/ListProcesses
        [HttpGet]
        public IActionResult ListProcesses()
        {
            try
            {
                // 获取所有进程
                Process[] processes = Process.GetProcesses();

                // 将进程信息转换为列表
                List<ProcessInfo> processList = processes.Select(p => new ProcessInfo
                {
                    Id = p.Id,
                    ProcessName = p.ProcessName,
                    StartTime = p.StartTime
                }).ToList();

                // 返回进程列表
                return Ok(processList);
            }
            catch (Exception ex)
            {
                // 记录错误日志
                _logger.LogError(ex, "Error occurred while listing processes.");
                return StatusCode(500, "Internal Server Error");
            }
        }

        // POST: /ProcessManager/KillProcess
        [HttpPost]
        public IActionResult KillProcess(int id)
        {
            try
            {
                // 查找指定ID的进程
                Process process = Process.GetProcessById(id);

                // 尝试停止进程
                process.Kill();
                process.WaitForExit();

                // 返回成功消息
                return Ok($"Process {id} has been killed.");
            }
            catch (Exception ex)
            {
                // 记录错误日志
                _logger.LogError(ex, $"Error occurred while killing process {id}.");
                return StatusCode(500, $"Error occurred while killing process {id}.");
            }
        }

        // 数据模型用于进程信息
        public class ProcessInfo
        {
            public int Id { get; set; }
            public string ProcessName { get; set; }
            public DateTime StartTime { get; set; }
        }
    }
}
