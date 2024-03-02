using System;
using System.Security.Cryptography;
using System.Text;

namespace SiteMVC.Helper
{
    public static class Hash
    {

        public static string GerarHash(this string input)
        {
            using (SHA1 sha1 = SHA1.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(input);
                byte[] hashBytes = sha1.ComputeHash(inputBytes);

                string hash = BitConverter.ToString(hashBytes).Replace("-", "");

                return hash;
            }

            
        }

    }
}
