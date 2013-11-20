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
    }
}
