// 代码生成时间: 2025-09-20 08:52:28
 * Follows C# best practices for readability, error handling, comments, and maintainability.
 */
using System;
using System.IO;
using System.Text.RegularExpressions;

namespace TextFileAnalysis
{
    public class TextFileAnalyzer
    {
        // The path to the text file to be analyzed.
        private string filePath;

        public TextFileAnalyzer(string filePath)
        {
            this.filePath = filePath;
        }

        /// <summary>
        /// Analyzes the text file and prints the results to the console.
        /// </summary>
        public void Analyze()
        {
            try
            {
                string[] lines = File.ReadAllLines(filePath);
                int wordCount = 0;
                int characterCount = 0;

                foreach (string line in lines)
                {
                    wordCount += CountWords(line);
                    characterCount += CountCharacters(line);
                }

                Console.WriteLine($"File: {Path.GetFileName(filePath)}");
                Console.WriteLine($"Total lines: {lines.Length}");
                Console.WriteLine($"Total words: {wordCount}");
                Console.WriteLine($"Total characters: {characterCount}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        /// <summary>
        /// Counts the number of words in a given line.
        /// </summary>
        /// <param name="line">The line to count words in.</param>
        /// <returns>The number of words in the line.</returns>
        private int CountWords(string line)
        {
            return Regex.Matches(line, @"\w+").Count;
        }

        /// <summary>
        /// Counts the number of characters in a given line.
        /// </summary>
        /// <param name="line">The line to count characters in.</param>
        /// <returns>The number of characters in the line.</returns>
        private int CountCharacters(string line)
        {
            return line.Length;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 1)
            {
                Console.WriteLine("Usage: TextFileAnalyzer <path-to-text-file>");
                return;
            }

            string filePath = args[0];
            TextFileAnalyzer analyzer = new TextFileAnalyzer(filePath);
            analyzer.Analyze();
        }
    }
}