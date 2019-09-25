using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace LapSimBackend.MongoDb.Services
{

    //see:  https://janaks.com.np/password-hashing-in-csharp/
    internal static class HashHelper
    {
        // 24 = 192 bits
        private const int SaltByteSize = 24;
        private const int HashByteSize = 24;
        private const int HasingIterationsCount = 10101;


        internal static byte[] GenerateSalt(int saltByteSize = SaltByteSize)
        {
            using RNGCryptoServiceProvider saltGenerator = new RNGCryptoServiceProvider();
            byte[] salt = new byte[saltByteSize];
            saltGenerator.GetBytes(salt);
            return salt;
        }

        internal static byte[] ComputeHash(string password, byte[] salt, int iterations = HasingIterationsCount, int hashByteSize = HashByteSize)
        {
            using Rfc2898DeriveBytes hashGenerator = new Rfc2898DeriveBytes(password, salt)
            {
                IterationCount = iterations
            };
            return hashGenerator.GetBytes(hashByteSize);
        }
    }

}
