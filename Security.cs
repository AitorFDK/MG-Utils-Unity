using System.Security.Cryptography;
using System.Text;

namespace MendiGames.Utils
{
    public class Security
    {
        public static byte[] Hash(string value, byte[] salt)
        {
            return GenerateSaltedHash(Encoding.UTF8.GetBytes(value), salt);
        }

        public static byte[] GenerateRandomSalt()
        {
            byte[] salt = new byte[32];
            RandomNumberGenerator.Fill(salt);
            return salt;
        }

        private static byte[] GenerateSaltedHash(byte[] plainText, byte[] salt)
        {
            HashAlgorithm crypto = new SHA256Managed();

            byte[] plainTextWithSaltBytes = new byte[plainText.Length + salt.Length];

            for (int i = 0; i < salt.Length; i++)
            {
                plainTextWithSaltBytes[i] = salt[i];
            }
            for (int i = 0; i < plainText.Length; i++)
            {
                plainTextWithSaltBytes[salt.Length + i] = plainText[i];
            }

            return crypto.ComputeHash(plainTextWithSaltBytes);
        }

        public static bool CompareByteArrays(byte[] array1, byte[] array2)
        {
            if (array1.Length != array2.Length)
            {
                return false;
            }

            for (int i = 0; i < array1.Length; i++)
            {
                if (array1[i] != array2[i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}