using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Helpers
{
    public class PasswordHelper
    {
        public static byte[] GetSecureSalt()
        {
            return RandomNumberGenerator.GetBytes(32);
        }
        public static string HashUsingPbkdf2(string password, byte[] salt)
        {
            const int iterationCount = 100000;
            const int numBytesRequested = 32;
            using (var pbkdf2 = new Rfc2898DeriveBytes(password, salt, iterationCount, HashAlgorithmName.SHA256))
            {
                byte[] derivedKey = pbkdf2.GetBytes(numBytesRequested);
                return Convert.ToBase64String(derivedKey);
            }
        }
    }
}
