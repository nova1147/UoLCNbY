// 代码生成时间: 2025-08-29 15:14:15
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace TextFileAnalyzer
{
    public class TextFileAnalyzer
    {
        private const int BUFFER_SIZE = 1024;

        // Constructor to specify the file path
        public TextFileAnalyzer(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
            {
                throw new ArgumentException("File path cannot be null or empty.", nameof(filePath));
            }

            this.FilePath = filePath;
        }

        // Read-only property for the file path
        public string FilePath { get; private set; }

        // Method to analyze the file content
        public void AnalyzeFileContent()
        {
            try
            {
                using (StreamReader reader = new StreamReader(FilePath, Encoding.UTF8, true, BUFFER_SIZE))
                {
# 改进用户体验
                    this.Lines = 0;
# NOTE: 重要实现细节
                    this.Words = 0;
                    this.Characters = 0;
                    this.WordOccurrences = new Dictionary<string, int>();

                    // Read the file line by line
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
# 改进用户体验
                        this.Lines++;
                        ProcessLine(line);
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle any I/O exceptions
                throw new IOException("An error occurred while analyzing the file.", ex);
            }
        }

        // Property to get the analysis results
        public int Lines { get; private set; }
        public int Words { get; private set; }
        public int Characters { get; private set; }
        public Dictionary<string, int> WordOccurrences { get; private set; }

        // Method to process a single line of text
# FIXME: 处理边界情况
        private void ProcessLine(string line)
# FIXME: 处理边界情况
        {
            this.Characters += line.Length + 1; // Including the newline character

            // Split the line into words using regular expression for word boundary
            string[] words = Regex.Split(line, @"\b(?=\w)").Where(w => !string.IsNullOrWhiteSpace(w)).ToArray();

            this.Words += words.Length;

            // Count occurrences of each word
            foreach (string word in words)
            {
                if (WordOccurrences.ContainsKey(word))
                {
# 增强安全性
                    WordOccurrences[word]++;
                }
                else
                {
# 添加错误处理
                    WordOccurrences[word] = 1;
                }
            }
        }

        // Method to display the analysis results
        public void DisplayResults()
        {
            Console.WriteLine($"Lines: {Lines}
Words: {Words}
Characters (including spaces and newlines): {Characters}
");
            foreach (var entry in WordOccurrences)
            {
                Console.WriteLine($"'{entry.Key}' occurs {entry.Value} times");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the path to the text file: ");
            string filePath = Console.ReadLine();

            TextFileAnalyzer analyzer = new TextFileAnalyzer(filePath);
            analyzer.AnalyzeFileContent();
# 增强安全性
            analyzer.DisplayResults();
        }
    }
}