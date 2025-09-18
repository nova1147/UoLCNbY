// 代码生成时间: 2025-09-18 10:09:04
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Mvc;

// Controller for handling user login operations
[ApiController]
[Route("[controller]/[action]"])
public class UserController : ControllerBase
{
    private readonly Dictionary<string, string> _users = new Dictionary<string, string>();
    private readonly HMACSHA512 _hasher = new HMACSHA512();

    // Constructor
    public UserController()
    {
        // Initialize with some dummy users
        _users.Add("user1", "password1");
        _users.Add("user2", "password2");
    }

    // Endpoint for user login
    [HttpPost]
    public IActionResult Login([FromBody] LoginModel loginModel)
    {
        try
        {
            if (string.IsNullOrEmpty(loginModel.Username) || string.IsNullOrEmpty(loginModel.Password))
            {
                return BadRequest("Username or password cannot be empty");
            }

            string storedPassword = _users.ContainsKey(loginModel.Username) ? _users[loginModel.Username] : null;

            if (storedPassword == null)
            {
                return Unauthorized("User not found");
            }

            if (!VerifyPasswordHash(loginModel.Password, storedPassword))
            {
                return Unauthorized("Invalid password");
            }

            return Ok("Login successful");
        }
        catch (Exception ex)
        {
            // Log the exception and return an error message
            return StatusCode(500, "Internal server error: " + ex.Message);
        }
    }

    // Method to hash a password
    private bool VerifyPasswordHash(string password, string storedHash)
    {
        // Hash the incoming password with the same salt and return the hash
        string computedHash = ComputeHash(password);
        return storedHash.Equals(computedHash);
    }

    // Method to compute the hash of a password
    private string ComputeHash(string rawData)
    {
        // Convert the raw data to bytes
        byte[] bytes = Encoding.UTF8.GetBytes(rawData);

        // Compute the hash
        byte[] hashBytes = _hasher.ComputeHash(bytes);
        return Convert.ToBase64String(hashBytes);
    }
}

// Model class for storing login information
public class LoginModel
{
    public string Username { get; set; }
    public string Password { get; set; }
}