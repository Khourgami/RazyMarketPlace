using System.Security.Cryptography;
using System.Text;

namespace RazySoft.MarketSync.Core.Utils
{
    public static class HashUtil
    {
        /// <summary>
        /// Compute SHA256 hex string for given input (UTF8).
        /// </summary>
        public static string ComputeSha256(string input)
        {
            if (input == null) input = string.Empty;
            using var sha = SHA256.Create();
            var bytes = Encoding.UTF8.GetBytes(input);
            var hash = sha.ComputeHash(bytes);
            var sb = new StringBuilder(hash.Length * 2);
            foreach (var b in hash) sb.Append(b.ToString("x2"));
            return sb.ToString();
        }
    }
}
