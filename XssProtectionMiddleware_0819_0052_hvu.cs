// 代码生成时间: 2025-08-19 00:52:52
using Microsoft.AspNetCore.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace XssProtection
{
    /// <summary>
    /// Middleware for preventing Cross-Site Scripting (XSS) attacks.
    /// </summary>
    public class XssProtectionMiddleware
    {
        private readonly RequestDelegate _next;

        /// <summary>
        /// Initializes a new instance of the XssProtectionMiddleware class.
        /// </summary>
        /// <param name="next">The next delegate in the HTTP request pipeline.</param>
        public XssProtectionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        /// <summary>
        /// Invokes the middleware.
        /// </summary>
        /// <param name="context">The HTTP context.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                // Define a regular expression pattern to identify script tags and other XSS vectors
                string scriptPattern = @"<script.*?>.*?</script>|<.*?javascript:.*?>|<.*?\s+on.*?=";

                // Check if the request contains a body and is of a type that could be XSS vulnerable
                if (context.Request.ContentLength != null && context.Request.ContentType != null &&
                    context.Request.ContentType.Contains("text/") || context.Request.ContentType.Contains("application/x-www-form-urlencoded"))
                {
                    // Read the request body as a string
                    string body = await new StreamReader(context.Request.Body).ReadToEndAsync();

                    // Reset the request body stream position to the beginning
                    context.Request.Body.Position = 0;

                    // Sanitize the input to remove potential XSS attacks
                    string sanitizedBody = SanitizeInput(body, scriptPattern);

                    // Replace the original body with the sanitized body
                    context.Request.Body = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(sanitizedBody));
                }

                // Call the next delegate/middleware in the pipeline
                await _next(context);
            }
            catch (System.Exception ex)
            {
                // Handle any exceptions that occur during the middleware execution
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                await context.Response.WriteAsync(ex.Message);
            }
        }

        /// <summary>
        /// Sanitizes the input to remove potential XSS attacks.
        /// </summary>
        /// <param name="input">The input string to sanitize.</param>
        /// <param name="pattern">The regular expression pattern to match.</param>
        /// <returns>The sanitized string.</returns>
        private string SanitizeInput(string input, string pattern)
        {
            // Use Regex to replace all matches of the pattern with an empty string
            return Regex.Replace(input, pattern, "", RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.Multiline);
        }
    }
}
