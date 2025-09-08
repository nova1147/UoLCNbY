// 代码生成时间: 2025-09-09 04:53:29
using System;
using System.Collections.Generic;

namespace Validation
{
    // Define an enumeration for common validation errors.
    public enum ValidationErrorType
    {
        RequiredFieldEmpty,
        InvalidEmail,
        InvalidDate,
        // Add more error types as needed.
    }

    // Define a class to represent a validation error.
    public class ValidationError
    {
        public ValidationErrorType ErrorType { get; set; }
        public string Message { get; set; }
    }

    // Define the FormValidator class.
    public class FormValidator
    {
        // This list will hold all validation errors.
        private List<ValidationError> _errors = new List<ValidationError>();

        // Method to add an error to the list.
        private void AddError(ValidationErrorType errorType, string message)
        {
            _errors.Add(new ValidationError { ErrorType = errorType, Message = message });
        }

        // Public method to validate required fields.
        public bool ValidateRequiredField(string fieldName, string fieldValue)
        {
            if (string.IsNullOrEmpty(fieldValue))
            {
                AddError(ValidationErrorType.RequiredFieldEmpty, $"The field '{fieldName}' is required.");
                return false;
            }
            return true;
        }

        // Public method to validate email fields.
        public bool ValidateEmail(string email)
        {
            if (!string.IsNullOrEmpty(email) && !IsValidEmail(email))
            {
                AddError(ValidationErrorType.InvalidEmail, $"'{email}' is not a valid email address.");
                return false;
            }
            return true;
        }

        // Helper method to check if an email is valid.
        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        // Public method to get all validation errors.
        public List<ValidationError> GetErrors()
        {
            return _errors;
        }

        // Public method to clear all validation errors.
        public void ClearErrors()
        {
            _errors.Clear();
        }

        // Public method to check if there are any validation errors.
        public bool HasErrors()
        {
            return _errors.Count > 0;
        }
    }
}
