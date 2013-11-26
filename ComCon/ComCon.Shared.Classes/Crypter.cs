using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

namespace ComCon.Shared.Classes
{
    public class Crypter
    {
        public static string Crypt(string pInput)
        {
            return PrivateCrypt(pInput);
        }

        private static string PrivateCrypt(string pInput)
        {
            SHA256 sha = new SHA256Managed();
            byte[] array = Encoding.UTF8.GetBytes(pInput);
            byte[] hash = sha.ComputeHash(array);
            string hashString = string.Empty;
            foreach (byte x in hash)
            {
                hashString += String.Format("{0:x2}", x);
            }
            return hashString;

        }
    }
}
