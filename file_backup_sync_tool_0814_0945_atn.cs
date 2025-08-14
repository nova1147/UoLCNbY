// 代码生成时间: 2025-08-14 09:45:06
using System;
using System.IO;
using System.Linq;

namespace FileBackupSyncTool
{
    /// <summary>
    /// 文件备份和同步工具类
    /// </summary>
    public class FileBackupSyncTool
    {
        private string sourceDirectory;
        private string backupDirectory;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="sourceDirectory">源目录</param>
        /// <param name="backupDirectory">备份目录</param>
        public FileBackupSyncTool(string sourceDirectory, string backupDirectory)
        {
            this.sourceDirectory = sourceDirectory;
            this.backupDirectory = backupDirectory;
        }

        /// <summary>
        /// 同步文件
        /// </summary>
        public void SyncFiles()
        {
            try
            {
                // 获取源目录和备份目录的文件列表
                var sourceFiles = Directory.GetFiles(sourceDirectory);
                var backupFiles = Directory.GetFiles(backupDirectory);

                // 获取源目录文件列表中不存在的文件
                var missingFiles = backupFiles.Except(sourceFiles);

                // 删除不存在的备份文件
                foreach (var file in missingFiles)
                {
                    File.Delete(file);
                }

                // 复制新文件到备份目录
                foreach (var file in sourceFiles)
                {
                    var backupFile = Path.Combine(backupDirectory, Path.GetFileName(file));
                    if (!File.Exists(backupFile))
                    {
                        File.Copy(file, backupFile);
                    }
                }
            }
            catch (Exception ex)
            {
                // 错误处理
                Console.WriteLine($"Error syncing files: {ex.Message}");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // 设置源目录和备份目录
                string sourceDir = "C:\SourceDirectory";
                string backupDir = "C:\BackupDirectory";

                // 创建文件备份同步工具实例
                FileBackupSyncTool tool = new FileBackupSyncTool(sourceDir, backupDir);

                // 执行文件同步操作
                tool.SyncFiles();

                Console.WriteLine("Files synced successfully.");
            }
            catch (Exception ex)
            {
                // 错误处理
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}