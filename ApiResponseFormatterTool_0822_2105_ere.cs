// 代码生成时间: 2025-08-22 21:05:22
 * It includes error handling and is designed to be easily maintained and extended.
 */
using System;
using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;

namespace ApiResponseFormatterTool
{
    /// <summary>
    /// Provides functionality to format API responses.
    /// </summary>
    public class ApiResponseFormatterTool
    {
        /// <summary>
        /// Creates a success response with a message and data.
        /// </summary>
        /// <param name="message">The success message to include in the response.</param>
        /// <param name="data">The data to include in the response.</param>
        /// <returns>A formatted success response.</returns>
        public IActionResult SuccessResponse(string message, object data = null)
        {
            // Create the response object
            var response = new
            {
                success = true,
                message = message,
                data = data
            };

            // Return the response as JSON
            return new OkObjectResult(response);
        }

        /// <summary>
        /// Creates an error response with a message and error details.
        /// </summary>
        /// <param name="message">The error message to include in the response.</param>
        /// <param name="errorCode">The error code associated with the error.</param>
        /// <param name="errorDetails">Additional details about the error.</param>
        /// <returns>A formatted error response.</returns>
        public IActionResult ErrorResponse(string message, int errorCode = 0, string errorDetails = null)
        {
            // Create the response object
            var response = new
            {
                success = false,
                message = message,
                errorCode = errorCode,
                errorDetails = errorDetails
            };

            // Determine the status code based on the error code
            var statusCode = errorCode switch
            {
                404 => (int)HttpStatusCode.NotFound,
                400 => (int)HttpStatusCode.BadRequest,
                500 => (int)HttpStatusCode.InternalServerError,
                _ => (int)HttpStatusCode.InternalServerError
            };

            // Return the response with the appropriate status code
            return new ObjectResult(response) { StatusCode = statusCode };
        }

        /// <summary>
        /// Creates an unauthorized response with a message.
        /// </summary>
        /// <param name="message">The message to include in the response.</param>
        /// <returns>A formatted unauthorized response.</returns>
        public IActionResult UnauthorizedResponse(string message)
        {
            // Create the response object
            var response = new
            {
                success = false,
                message = message
            };

            // Return the response with a 401 status code
            return new ObjectResult(response) { StatusCode = (int)HttpStatusCode.Unauthorized };
        }
    }
}
