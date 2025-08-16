// 代码生成时间: 2025-08-17 00:06:41
using System;
using System.Security.Cryptography;
using System.Text;

namespace PasswordEncryptionDecryptionTool
{
    /*
     * 密码加密解密工具类的描述
     * 提供密码加密和解密功能，使用SHA256算法进行哈希加密
     */
    public class PasswordEncryptionDecryptionTool
    {
        private readonly HMACSHA256 _hashAlgorithm;

        public PasswordEncryptionDecryptionTool()
        {
            // 初始化SHA256哈希算法
            _hashAlgorithm = new HMACSHA256();
        }

        /*
         * 加密密码的描述
         * 将明文密码转换为SHA256加密后的哈希值
         * @param plainTextPassword 明文密码
         * @return 加密后的密码哈希值
         */
        public string EncryptPassword(string plainTextPassword)
        {
            if (string.IsNullOrEmpty(plainTextPassword))
            {
                throw new ArgumentException("Plain text password cannot be null or empty.");
            }

            byte[] passwordBytes = Encoding.UTF8.GetBytes(plainTextPassword);
            byte[] hashBytes = _hashAlgorithm.ComputeHash(passwordBytes);
            return Convert.ToBase64String(hashBytes);
        }

        /*
         * 解密密码的描述
         * 验证给定的密码哈希值与明文密码是否匹配
         * @param encryptedPassword 加密后的密码哈希值
         * @param plainTextPassword 明文密码
         * @return 验证结果，如果匹配返回true，否则返回false
         */
        public bool DecryptPassword(string encryptedPassword, string plainTextPassword)
        {
            if (string.IsNullOrEmpty(encryptedPassword) || string.IsNullOrEmpty(plainTextPassword))
            {
                throw new ArgumentException("Encrypted password and plain text password cannot be null or empty.");
            }

            byte[] encryptedPasswordBytes = Convert.FromBase64String(encryptedPassword);
            byte[] passwordBytes = Encoding.UTF8.GetBytes(plainTextPassword);
            byte[] hashBytes = _hashAlgorithm.ComputeHash(passwordBytes);
            return Convert.ToBase64String(hashBytes) == encryptedPassword;
        }
    }
}
