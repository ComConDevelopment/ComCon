using ComCon.Shared.Classes;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComCon.Server.Classes
{
    public class Global
    {      
        public static List<User> Users;

        public Global()
        {
            Users = new List<User>();
        }
    }
}
