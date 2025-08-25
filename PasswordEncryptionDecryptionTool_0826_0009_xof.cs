// 代码生成时间: 2025-08-26 00:09:15
using System;
using System.Security.Cryptography;
using System.Text;

// PasswordEncryptionDecryptionTool 提供密码加密和解密的功能
public class PasswordEncryptionDecryptionTool
{
    // 加密密码
    public static string EncryptPassword(string password, string secretKey)
    {
        // 使用SHA256加密算法进行密码加密
        using (SHA256 sha256 = SHA256.Create())
        {
            byte[] bytes = Encoding.UTF8.GetBytes(password);
            byte[] keyBytes = Encoding.UTF8.GetBytes(secretKey);
            byte[] encryptedPasswordBytes = sha256.ComputeHash(bytes);
            byte[] encryptedBytes = EncryptBytes(encryptedPasswordBytes, keyBytes);
            return Convert.ToBase64String(encryptedBytes);
        }
    }

    // 解密密码
    public static string DecryptPassword(string encryptedPassword, string secretKey)
    {
        // 将加密后的数据转换为字节数组
        byte[] encryptedBytes = Convert.FromBase64String(encryptedPassword);
        byte[] keyBytes = Encoding.UTF8.GetBytes(secretKey);
        byte[] decryptedBytes = DecryptBytes(encryptedBytes, keyBytes);
        return Encoding.UTF8.GetString(decryptedBytes);
    }

    // 使用AES算法加密字节数组
    private static byte[] EncryptBytes(byte[] bytesToBeEncrypted, byte[] secretBytes)
    {
        // 使用AES算法进行加密
        using (Aes aesAlg = Aes.Create())
        {
            aesAlg.Key = secretBytes;
            aesAlg.IV = secretBytes;
            ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);
            byte[] encryptedBytes = encryptor.TransformFinalBlock(bytesToBeEncrypted, 0, bytesToBeEncrypted.Length);
            return encryptedBytes;
        }
    }

    // 使用AES算法解密字节数组
    private static byte[] DecryptBytes(byte[] bytesToBeDecrypted, byte[] secretBytes)
    {
        // 使用AES算法进行解密
        using (Aes aesAlg = Aes.Create())
        {
            aesAlg.Key = secretBytes;
            aesAlg.IV = secretBytes;
            ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);
            byte[] decryptedBytes = decryptor.TransformFinalBlock(bytesToBeDecrypted, 0, bytesToBeDecrypted.Length);
            return decryptedBytes;
        }
    }
}
