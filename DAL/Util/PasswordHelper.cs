using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Util
{
    public class PasswordHelper
    {
        /// <summary>
        /// Compute hash for string encoded as UTF8
        /// </summary>
        /// <param name="stringToHash">String to be hashed</param>
        /// <returns>40-character hex string</returns>
        public static string GetStringHash(string stringToHash)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(stringToHash);

            var sha1 = SHA1.Create();
            byte[] hashBytes = sha1.ComputeHash(bytes);

            return getHexStringFromByteArray(hashBytes);
        }

        public static string GeneratePassword()
        {
            return Guid.NewGuid().ToString("n");
        }



        /// <summary>
        /// Convert an array of bytes to a string of hex digits
        /// </summary>
        /// <param name="bytes">array of bytes</param>
        /// <returns>String of hex digits</returns>
        private static string getHexStringFromByteArray(byte[] bytes)
        {
            
            var sb = new StringBuilder();
            foreach (byte b in bytes)
            {
                var hex = b.ToString("x2");
                sb.Append(hex);
            }
            return sb.ToString();
        }
    }
}
