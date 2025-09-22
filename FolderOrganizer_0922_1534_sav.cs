// 代码生成时间: 2025-09-22 15:34:37
using System;
using System.IO;
using System.Linq;

namespace FolderOrganizerApp
{
    /// <summary>
    /// A utility class for organizing files and folders.
    /// </summary>
    public class FolderOrganizer
    {
        private readonly string _sourcePath;
        private readonly string _destinationPath;

        /// <summary>
        /// Initializes a new instance of the FolderOrganizer class.
        /// </summary>
        /// <param name="sourcePath">The path to the source directory.</param>
        /// <param name="destinationPath">The path to the destination directory.</param>
        public FolderOrganizer(string sourcePath, string destinationPath)
        {
            _sourcePath = sourcePath;
            _destinationPath = destinationPath;
        }

        /// <summary>
        /// Organizes files from the source directory to the destination directory.
        /// </summary>
        public void OrganizeFiles()
        {
            try
            {
                if (!Directory.Exists(_sourcePath))
                {
                    throw new DirectoryNotFoundException($"Source directory not found: {_sourcePath}");
                }

                if (!Directory.Exists(_destinationPath))
                {
                    Directory.CreateDirectory(_destinationPath);
                }

                // Get all files from the source directory.
                var files = Directory.GetFiles(_sourcePath);

                foreach (var file in files)
                {
                    var fileInfo = new FileInfo(file);
                    var targetPath = Path.Combine(_destinationPath, fileInfo.Name);

                    // Copy file to the destination directory.
                    File.Copy(file, targetPath, true);
                }
            }
            catch (Exception ex)
            {
                // Log the exception and handle it as needed.
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string sourcePath = @"C:\SourceFolder";
                string destinationPath = @"C:\DestinationFolder";

                FolderOrganizer organizer = new FolderOrganizer(sourcePath, destinationPath);
                organizer.OrganizeFiles();

                Console.WriteLine("Files have been organized successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}