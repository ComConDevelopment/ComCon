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
    public class User
    {

        #region Deklaration

        private int mUserID;
        private string mUsername;        
        private string mEmail;
        private bool mIsAdmin;
        private DateTime mLastOnline;
        private IChatUser mCallback;

        public IChatUser Callback
        {
            get { return mCallback; }
            set { mCallback = value; }
        }



      
        #endregion


        #region Properties

        [DataMember]
        public int UserID
        {
            get { return mUserID; }
            set { mUserID = value; }
        }

        [DataMember]
        public string Username
        {
            get { return mUsername; }
            set { mUsername = value; }
        }

        [DataMember]
        public string Email
        {
            get { return mEmail; }
            set { mEmail = value; }
        }

        [DataMember]
        public bool IsAdmin
        {
            get { return mIsAdmin; }
            set { mIsAdmin = value; }
        }

        [DataMember]
        public DateTime LastOnline
        {
            get { return mLastOnline; }
            set { mLastOnline = value; }
        }

     
        #endregion   

        public override string ToString()
        {
            return this.Username;
        }
    }
}
