// 代码生成时间: 2025-08-06 04:19:30
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace DatabaseMigrationTool
{
    // 定义数据库迁移工具类
    public static class DatabaseMigrationTool
    {
        /// <summary>
        /// 执行数据库迁移
        /// </summary>
        /// <param name="context">数据库上下文</param>
        /// <returns>Task</returns>
        public static async Task MigrateDatabaseAsync(DbContext context)
        {
            // 确保上下文不为空
            if (context == null) throw new ArgumentNullException(nameof(context));

            try
            {
                // 获取迁移服务
                var migrationBuilder = context.Database.GetService<IMigrationInterpreter>();
                // 获取迁移历史服务
                var migrationHistory = context.Database.GetService<IHistoryRepository>();

                // 获取已应用的迁移列表
                var appliedMigrations = await migrationHistory.GetAppliedMigrationsAsync();
                // 获取待应用的迁移列表
                var pendingMigrations = migrationBuilder.GetPendingMigrations().GetEnumerator();

                // 检查是否有待应用的迁移
                if (!pendingMigrations.MoveNext())
                {
                    Console.WriteLine("No pending migrations.");
                    return;
                }

                do
                {
                    // 获取下一个待应用的迁移
                    var pendingMigration = pendingMigrations.Current;
                    // 应用迁移
                    Console.WriteLine($"Applying migration: {pendingMigration}");
                    await migrationBuilder.MigrateAsync(pendingMigration);
                }
                while (pendingMigrations.MoveNext());
            }
            catch (Exception ex)
            {
                // 处理迁移过程中的异常
                Console.WriteLine($"An error occurred while migrating the database: {ex.Message}");
                throw;
            }
        }
    }
}
