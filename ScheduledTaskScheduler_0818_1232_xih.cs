// 代码生成时间: 2025-08-18 12:32:54
using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace MyApp
{
    public class ScheduledTaskScheduler : BackgroundService
    {
        private readonly ILogger<ScheduledTaskScheduler> _logger;
        private Timer _timer;
        private readonly TimeSpan _timerInterval;

        public ScheduledTaskScheduler(ILogger<ScheduledTaskScheduler> logger, TimeSpan timerInterval)
        {
            _logger = logger;
            _timerInterval = timerInterval;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("ScheduledTaskScheduler is starting.");
            _timer = new Timer(DoWork, null, TimeSpan.Zero, _timerInterval);
            return Task.CompletedTask;
        }

        private void DoWork(object state)
        {
            try
            {
                // 这里放置实际的任务逻辑
                ExecuteTask();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred executing the scheduled task.");
            }
        }

        private void ExecuteTask()
        {
            // 任务执行的具体逻辑
            _logger.LogInformation("Executing scheduled task...");
            // 模拟任务执行时间
            Thread.Sleep(1000);
            _logger.LogInformation("Scheduled task executed.");
        }

        public override Task StopAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("ScheduledTaskScheduler is stopping.");
            _timer?.Change(Timeout.Infinite, 0);
            _timer?.Dispose();
            return base.StopAsync(stoppingToken);
        }

        public override void Dispose()
        {
            _timer?.Dispose();
            base.Dispose();
        }
    }
}
