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

        private IChatUser mCallback;

        private bool mIsAdmin;

        private bool mIsVisible;

        #endregion


        #region Properties

        
        [DataMember]
        public bool IsVisible
        {
            get { return mIsVisible; }
            set { mIsVisible = value; }
        }

        
        [DataMember]
        public bool IsAdmin
        {
            get { return mIsAdmin; }
            set { mIsAdmin = value; }
        }


        public IChatUser Callback
        {
            get { return mCallback; }
            set { mCallback = value; }
        }

        private Credentials mCredentials;
        public Credentials Credentials
        {
            get { return mCredentials; }
            set { mCredentials = value; }
        }


        [DataMember]
        public string Username
        {
            get { return mUsername; }
            set { mUsername = value; }
        }  

        #endregion   

        public override string ToString()
        {
            return this.Username;
        }
    }
}
