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
            Encoding encoding = Encoding.Default;
            byte[] array = encoding.GetBytes(pInput);
            sha.ComputeHash(array);
            return encoding.GetString(sha.Hash);

        }
    }
}
