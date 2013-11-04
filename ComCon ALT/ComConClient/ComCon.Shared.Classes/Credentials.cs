using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace ComCon.Shared.Classes
{
    [DataContract]
    public class Credentials
    {
        private string mEMail;

        [DataMember]
        public string EMail
        {
            get { return mEMail; }
            set { mEMail = value; }
        }

        private string mPassword;

        [DataMember]
        public string Password
        {
            get { return mPassword; }
            set { mPassword = value; }
        }

    }
}
