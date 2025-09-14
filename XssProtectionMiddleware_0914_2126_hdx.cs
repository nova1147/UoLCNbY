// 代码生成时间: 2025-09-14 21:26:50
// <copyright file="XssProtectionMiddleware.cs" company="YourCompanyName">
//   Copyright (c) YourCompanyName. All rights reserved.
# FIXME: 处理边界情况
// </copyright>

using Microsoft.AspNetCore.Http;
using System.IO;
using System.Text.RegularExpressions;

namespace YourNamespace
{
    /// <summary>
    /// Middleware for preventing XSS (Cross-Site Scripting) attacks.
    /// </summary>
    public class XssProtectionMiddleware
# FIXME: 处理边界情况
    {
        private readonly RequestDelegate _next;

        /// <summary>
        /// Initializes a new instance of the XssProtectionMiddleware class.
        /// </summary>
        /// <param name="next">The next middleware in the pipeline.</param>
        public XssProtectionMiddleware(RequestDelegate next)
        {
            _next = next ?? throw new ArgumentNullException(nameof(next));
        }

        /// <summary>
# 扩展功能模块
        /// Invokes the middleware.
        /// </summary>
        /// <param name="context