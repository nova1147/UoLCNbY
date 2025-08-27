// 代码生成时间: 2025-08-27 19:29:43
using System;
using System.ComponentModel.DataAnnotations;

// 定义一个简单的用户数据模型
public class UserModel
{
    // 用户ID，主键
    [Key]
    public int UserId { get; set; }

    // 用户名，最大长度100，必须非空
    [Required]
    [MaxLength(100)]
    public string UserName { get; set; }

    // 密码，最大长度100，必须非空
    [Required]
    [MaxLength(100)]
    public string Password { get; set; }

    // 邮箱，最大长度255，必须非空
    [Required]
    [MaxLength(255)]
    [EmailAddress]
    public string Email { get; set; }

    // 注册日期，默认为创建对象时的日期和时间
    [Required]
    public DateTime RegistrationDate { get; set; } = DateTime.Now;

    // 构造函数
    public UserModel()
    {
    }

    // 构造函数，初始化用户数据模型
    public UserModel(string userName, string password, string email)
    {
        UserName = userName;
        Password = password;
        Email = email;
    }

    // 验证用户数据模型的有效性
    public bool IsValid()
    {
        // 这里可以添加更复杂的验证逻辑
        return !string.IsNullOrWhiteSpace(UserName) &&
               !string.IsNullOrWhiteSpace(Password) &&
               !string.IsNullOrWhiteSpace(Email);
    }
}
