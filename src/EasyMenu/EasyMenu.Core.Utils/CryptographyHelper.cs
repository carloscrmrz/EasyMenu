using System.Security.Cryptography;
using System.Text;

namespace EasyMenu.Core.Utils;

public class CryptographyHelper
{
    public static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
    {
        using var hmac = new HMACSHA512();
        passwordSalt = hmac.Key;
        passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
    }

    public static bool VerifyPasswordHash(string psw, byte[] pswUser, byte[] pswSalt)
    {
        using var hmac = new HMACSHA512(pswSalt);
        var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(psw));
        return !computedHash.Where((t, i) => t != pswUser[i]).Any();
    }

    public static Stream DecryptStreamWithAes(Stream cipherStream, string key, string iv)
    {
        var aes = GetAesAlgorithm(key, iv);
        var base64Transform = new FromBase64Transform(FromBase64TransformMode.IgnoreWhiteSpaces);
        var base64DecodedStream = new CryptoStream(cipherStream, base64Transform, CryptoStreamMode.Read);
        var decrypted = aes.CreateDecryptor(aes.Key, aes.IV);
        var decryptedStream = new CryptoStream(base64DecodedStream, decrypted, CryptoStreamMode.Read);
        return decryptedStream;
    }

    public static string DecryptStringWithAes(string cipherText, string key, string iv)
    {
        var aes = GetAesAlgorithm(key, iv);
        var buffer = Convert.FromBase64String(cipherText);
        var memoryStream = new MemoryStream(buffer);
        var decrypted = aes.CreateDecryptor(aes.Key, aes.IV);
        var cryptoStream = new CryptoStream(memoryStream, decrypted, CryptoStreamMode.Read);
        var streamReader = new StreamReader(cryptoStream);
        return streamReader.ReadToEnd();
    }

    public static byte[] EncryptStringWithAes(string plainText, string key, string iv)
    {
        byte[] encrypted;
        var aes = GetAesAlgorithm(key, iv);
        aes.Padding = PaddingMode.PKCS7;
        var encryptor = aes.CreateEncryptor(aes.Key, aes.IV);
        using (var memStream = new MemoryStream())
        {
            using (var cryptoStream = new CryptoStream(memStream, encryptor, CryptoStreamMode.Write))
            {
                using var sw = new StreamWriter(cryptoStream);
                sw.Write(plainText);
            }

            encrypted = memStream.ToArray();
        }

        return encrypted;
    }

    private static Aes GetAesAlgorithm(string key, string iv)
    {
        var aes = Aes.Create();
        aes.Padding = PaddingMode.PKCS7;
        var secretKey = Convert.FromHexString(key);
        var initializationVector = Convert.FromHexString(iv);
        aes.Key = secretKey;
        aes.IV = initializationVector;
        return aes;
    }

    public static void CreateAesKeys(out byte[] key, out byte[] iv)
    {
        var aes = Aes.Create();
        aes.Padding = PaddingMode.PKCS7;
        aes.GenerateIV();
        aes.GenerateKey();
        key = aes.Key;
        iv = aes.IV;
    }
}