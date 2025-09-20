// 代码生成时间: 2025-09-21 07:36:54
using System;
using System.Text.RegularExpressions;

namespace FormValidation
{
    /// <summary>
    /// Form data validator class.
    /// </summary>
    public class FormValidator
    {
        /// <summary>
        /// Validates the form data.
        /// </summary>
        /// <param name="formData">The form data to validate.</param>
        /// <returns>A string containing any validation errors.</returns>
        public string ValidateFormData(dynamic formData)
        {
            string errors = "";
            
            // Check for required fields
            if (string.IsNullOrEmpty(formData.Name))
            {
                errors += "Name is required. ";
            }
            
            if (string.IsNullOrEmpty(formData.Email))
            {
                errors += "Email is required. ";
            }
            else if (!IsValidEmail(formData.Email))
            {
                errors += "Invalid email address. ";
            }
            
            if (string.IsNullOrEmpty(formData.Password))
            {
                errors += "Password is required. ";
            }
            else if (!IsValidPassword(formData.Password))
            {
                errors += "Password must be at least 8 characters long and include a number and a symbol. ";
            }
            
            return errors;
        }

        /// <summary>
        /// Validates an email address.
        /// </summary>
        /// <param name="email">The email address to validate.</param>
        /// <returns>True if the email address is valid, otherwise false.</returns>
        private bool IsValidEmail(string email)
        {
            // Use a regular expression to validate the email address
            string pattern = @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$";
            return Regex.IsMatch(email, pattern);
        }

        /// <summary>
        /// Validates a password.
        /// </summary>
        /// <param name="password">The password to validate.</param>
        /// <returns>True if the password is valid, otherwise false.</returns>
        private bool IsValidPassword(string password)
        {
            // Check if the password meets the required criteria
            return password.Length >= 8 &&
                   !string.IsNullOrEmpty(password) &&
                   password.Any(char.IsDigit) &&
                   password.Any(char.IsSymbol);
        }
    }
}