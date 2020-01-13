using System;
using System.Security.Cryptography;
using System.Text;

namespace Blockchain.Data
{
    public class ShaService
    {
        private static SHA256 _sha = SHA256.Create();

        public static string GetSha(string data)
        {
            var bytes = Encoding.UTF8.GetBytes(data);
            var shaBytes = _sha.ComputeHash(bytes);
            return BitConverter.ToString(shaBytes).Replace("-", string.Empty).ToLower();
        }
    }
}