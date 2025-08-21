// 代码生成时间: 2025-08-21 22:55:56
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// 定义用户实体
# 添加错误处理
public class User
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public List<Role> Roles { get; set; }
}

// 定义角色实体
# 添加错误处理
public class Role
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<User> Users { get; set; }
# NOTE: 重要实现细节
}

// 用户权限管理控制器
[ApiController]
[Route("api/[controller]/[action]")]
public class UserPermissionController : ControllerBase
# 优化算法效率
{
    private readonly UserPermissionContext _context;

    // 依赖注入数据库上下文
# 添加错误处理
    public UserPermissionController(UserPermissionContext context)
    {
# 添加错误处理
        _context = context;
    }

    // 获取所有用户及其角色
    [HttpGet]
    public IActionResult GetAllUsersWithRoles()
# 优化算法效率
    {
        var users = _context.Users.Include(u => u.Roles).ToList();
        return Ok(users);
    }

    // 添加新用户
    [HttpPost]
    public IActionResult AddUser([FromBody] User user)
    {
        if (user == null)
            return BadRequest("User data is missing");

        _context.Users.Add(user);
        _context.SaveChanges();
        return Ok(user);
    }

    // 更新用户角色
    [HttpPut]
# 添加错误处理
    public IActionResult UpdateUserRoles(int userId, [FromBody] List<int> roleIds)
    {
# 添加错误处理
        var user = _context.Users.Include(u => u.Roles).FirstOrDefault(u => u.Id == userId);
        if (user == null)
            return NotFound("User not found");

        user.Roles.Clear();
        foreach (int roleId in roleIds)
        {
            var role = _context.Roles.FirstOrDefault(r => r.Id == roleId);
            if (role != null)
# 改进用户体验
                user.Roles.Add(role);
        }

        _context.SaveChanges();
        return Ok(user);
    }
}

// 数据库上下文
public class UserPermissionContext : DbContext
# 优化算法效率
{
    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("YourConnectionStringHere");
    }
}
