using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Net;

namespace ComCon.Shared.Classes
{
    [DataContract]
    public class ChatUser
    {

        #region Deklaration

        private string mUsername;
        private DateTime mLastLoggedIn;
        private IPAddress mIP;

        #endregion


        #region Properties

        [DataMember]
        public string Username
        {
            get { return mUsername; }
            set { mUsername = value; }
        }

        [DataMember]
        public DateTime LastLoggedIn
        {
            get { return mLastLoggedIn; }
            set { mLastLoggedIn = value; }
        }        

        [DataMember]
        public IPAddress IP
        {
            get { return mIP; }
            set { mIP = value; }
        }        

        #endregion   

    }
}
