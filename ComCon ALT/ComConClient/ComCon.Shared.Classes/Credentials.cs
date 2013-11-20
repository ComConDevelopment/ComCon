using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComCon.Shared.Classes
{
    public class Credentials
    {

        private string mEmail;

        public string Email
        {
            get { return mEmail; }
            set { mEmail = value; }
        }



        private string mPassword;

        public string Password
        {
            get { return mPassword; }
            set { mPassword = value; }
        }

    }
}
