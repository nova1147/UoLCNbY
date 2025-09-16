// 代码生成时间: 2025-09-16 19:37:48
// <copyright file="LogParserTool.cs" company="YourCompany">
//     Copyright (c) YourCompany. All rights reserved.
// </copyright>

using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace LogParser
{
    /// <summary>
    /// A utility class for parsing log files.
    /// </summary>
    public class LogParserTool
    {
        private const string LogFilePattern = @"^(\d{4}-\d{2}-\d{2} \d{2}:\d{2}:\d{2}) (\w+) (.*)$";

        /// <summary>
        /// Parses a log file and extracts entries into a dictionary.
        /// </summary>
        /// <param name="filePath">The path to the log file to parse.</param>
        /// <returns>A dictionary containing log entries with a DateTime key and a LogEntry value.</returns>
        public Dictionary<DateTime, LogEntry> ParseLogFile(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
            {
                throw new ArgumentException("File path cannot be null or empty.", nameof(filePath));
            }

            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException("Log file not found.", filePath);
            }

            var logEntries = new Dictionary<DateTime, LogEntry>();
            var regex = new Regex(LogFilePattern);

            try
            {
                using (var reader = new StreamReader(filePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        var match = regex.Match(line);
                        if (match.Success)
                        {
                            var timestamp = DateTime.ParseExact(match.Groups[1].Value, "yyyy-MM-dd HH:mm:ss", null);
                            var level = match.Groups[2].Value;
                            var message = match.Groups[3].Value;

                            logEntries[timestamp] = new LogEntry { Level = level, Message = message };
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occur during file reading or parsing.
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

            return logEntries;
        }
    }

    /// <summary>
    /// Represents a log entry with a level and a message.
    /// </summary>
    public class LogEntry
    {
        public string Level { get; set; }
        public string Message { get; set; }
    }
}