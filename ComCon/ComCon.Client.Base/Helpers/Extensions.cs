using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;
using System.Windows.Controls;

namespace ComCon.Client.Base.Helpers
{
    public static class Extensions
    {
        static char[] hexDigits = {
         '0', '1', '2', '3', '4', '5', '6', '7',
         '8', '9', 'A', 'B', 'C', 'D', 'E', 'F'};

        /// <summary>
        /// Convert a .NET Color to a hex string.
        /// </summary>
        /// <returns>ex: "FFFFFF", "AB12E9"</returns>
        public static string ToHexString(this Color color)
        {
            byte[] bytes = new byte[3];
            bytes[0] = color.R;
            bytes[1] = color.G;
            bytes[2] = color.B;
            char[] chars = new char[bytes.Length * 2];
            for (int i = 0; i < bytes.Length; i++)
            {
                int b = bytes[i];
                chars[i * 2] = hexDigits[b >> 4];
                chars[i * 2 + 1] = hexDigits[b & 0xF];
            }
            return new string(chars);
        }

    }
}
