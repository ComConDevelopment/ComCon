using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Npgsql;
using System.Data;
using ComCon.Shared.Classes;

namespace ComCon.Server.Classes
{   
    public class LoginService
    {
        public static User AuthenticateUser(Credentials pCredentials)
        {
            return SQLStatements.GetChatUser(pCredentials.Email, pCredentials.Password);
        }

        internal static bool RegisterUser(Credentials pCredentials)
        {
            string key = GetRandomString();
            if (SQLStatements.InsertNewUser(pCredentials.Email, pCredentials.Password, pCredentials.Username, key))
            {
                ComConMail.Mail mMail = new ComConMail.Mail();
                return mMail.SendRegistrationMail(pCredentials.Username, key, pCredentials.Email);
            }
            return false;
        }


        private static string GetRandomString()
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789abcdefghijklmnopqrstuvwxyz";
            var random = new Random();
            return new string(
                Enumerable.Repeat(chars, 20)
                          .Select(s => s[random.Next(s.Length)])
                          .ToArray());
        }
    }
}
