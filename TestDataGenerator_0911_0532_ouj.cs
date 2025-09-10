// 代码生成时间: 2025-09-11 05:32:20
using System;
using System.Collections.Generic;
using System.Linq;

namespace TestDataGeneratorApp
{
    /// <summary>
    /// A simple test data generator class that creates mock data for testing purposes.
    /// </summary>
    public class TestDataGenerator
    {
        private static readonly Random random = new Random();

        /// <summary>
        /// Generates a list of random names.
        /// </summary>
        /// <param name="count">The number of names to generate.</param>
        /// <returns>A list of names.</returns>
        public List<string> GenerateNames(int count)
        {
            var names = new List<string>();
            for (int i = 0; i < count; i++)
            {
                names.Add(GenerateRandomName());
            }
            return names;
        }

        /// <summary>
        /// Generates a random name.
        /// </summary>
        /// <returns>A random name.</returns>
        private string GenerateRandomName()
        {
            var firstNames = new List<string> { "John", "Jane", "Bob", "Alice" };
            var lastNames = new List<string> { "Doe", "Smith", "Johnson", "Williams" };
            return firstNames[random.Next(firstNames.Count)] + " " + lastNames[random.Next(lastNames.Count)];
        }

        /// <summary>
        /// Generates a list of random email addresses.
        /// </summary>
        /// <param name="count">The number of email addresses to generate.</param>
        /// <returns>A list of email addresses.</returns>
        public List<string> GenerateEmails(int count)
        {
            var emails = new List<string>();
            for (int i = 0; i < count; i++)
            {
                emails.Add(GenerateRandomEmail());
            }
            return emails;
        }

        /// <summary>
        /// Generates a random email address.
        /// </summary>
        /// <returns>A random email address.</returns>
        private string GenerateRandomEmail()
        {
            var domains = new List<string> { "@example.com", "@sample.org", "@test.net" };
            return GenerateRandomName().ToLower().Replace(" ", ".") + domains[random.Next(domains.Count)];
        }

        /// <summary>
        /// Generates a list of random integers.
        /// </summary>
        /// <param name="count">The number of integers to generate.</param>
        /// <param name="min">The minimum value of the integers.</param>
        /// <param name="max">The maximum value of the integers.</param>
        /// <returns>A list of random integers.</returns>
        public List<int> GenerateRandomIntegers(int count, int min, int max)
        {
            var numbers = new List<int>();
            for (int i = 0; i < count; i++)
            {
                numbers.Add(random.Next(min, max + 1));
            }
            return numbers;
        }

        // Additional methods for generating other types of test data can be added here.
    }
}
