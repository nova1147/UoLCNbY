// 代码生成时间: 2025-08-09 14:35:54
 * This class provides functionality to convert JSON data into a C# object and vice versa.
 * It includes error handling and follows C# best practices for maintainability and extensibility.
 */
using System;
using Newtonsoft.Json;
using System.IO;

namespace JsonFormatterApp
{
    /// <summary>
    ///     Provides functionality to convert JSON data into a C# object and vice versa.
    /// </summary>
    public class JsonDataFormatter
    {
        /// <summary>
        ///     Converts a JSON string into a C# object of specified type T.
        /// </summary>
        /// <typeparam name="T">The type of the object to convert to.</typeparam>
        /// <param name="json">The JSON string to convert.</param>
        /// <returns>An instance of type T populated from the JSON data.</returns>
        /// <exception cref="JsonException">Thrown when the JSON string is invalid.</exception>
        public T ConvertFromJson<T>(string json)
       {
            try
            {
                return JsonConvert.DeserializeObject<T>(json);
            }
            catch (JsonException ex)
            {
                throw new JsonException("An error occurred while converting JSON to object.", ex);
            }
        }

        /// <summary>
        ///     Converts a C# object into a JSON string.
        /// </summary>
        /// <param name="obj">The object to convert into JSON.</param>
        /// <returns>A JSON string representation of the object.</returns>
        /// <exception cref="JsonException">Thrown when the object cannot be serialized.</exception>
        public string ConvertToJson(object obj)
        {
            try
            {
                return JsonConvert.SerializeObject(obj);
            }
            catch (JsonException ex)
            {
                throw new JsonException("An error occurred while converting object to JSON.", ex);
            }
        }
    }

    /// <summary>
    ///     Demonstrates the usage of JsonDataFormatter.
    /// </summary>
    public class Program
    {
        public static void Main(string[] args)
        {
            JsonDataFormatter formatter = new JsonDataFormatter();

            // Example usage: Convert JSON string to C# object
            var jsonString = "{"name": "John Doe", "age": 30}";
            var person = formatter.ConvertFromJson<Person>(jsonString);
            Console.WriteLine($"Name: {person.Name}, Age: {person.Age}");

            // Example usage: Convert C# object to JSON string
            var personObject = new Person() { Name = "Jane Doe", Age = 25 };
            var jsonOutput = formatter.ConvertToJson(personObject);
            Console.WriteLine(jsonOutput);
        }
    }

    /// <summary>
    ///     A simple class to represent a person.
    /// </summary>
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
