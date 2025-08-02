// 代码生成时间: 2025-08-02 12:44:22
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

// 简单的用户身份认证服务
public class UserAuthenticationService
{
    private readonly CookieAuthenticationOptions _cookieOptions;

    // 构造函数，注入Cookie认证选项配置
    public UserAuthenticationService(IOptions<CookieAuthenticationOptions> options)
    {
        _cookieOptions = options.Value;
    }

    // 认证用户方法
    public async Task AuthenticateUserAsync(HttpContext context, string username, string password)
    {
        // 这里应该添加实际的用户验证逻辑，例如查询数据库
        if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
        {
            throw new ArgumentException("Username or password cannot be empty.");
        }

        // 假设用户验证成功
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, username)
        };

        var claimsIdentity = new ClaimsIdentity(
            claims,
            CookieAuthenticationDefaults.AuthenticationScheme);

        var authProperties = new AuthenticationProperties
        {
            // 允许刷新标识
            IsPersistent = true
        };

        await context.SignInAsync(
            CookieAuthenticationDefaults.AuthenticationScheme,
            new ClaimsPrincipal(claimsIdentity),
            authProperties);
    }

    // 注销用户方法
    public async Task SignOutUserAsync(HttpContext context)
    {
        await context.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
    }
}
