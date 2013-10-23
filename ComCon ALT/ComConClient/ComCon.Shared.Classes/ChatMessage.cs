using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.Runtime.Serialization;

namespace ComCon.Shared.Classes
{
    [DataContract]
    public class ChatMessage
    {
        #region Deklaration

        private string mMessage;
        private DateTime mTimeStamp;
        private string mUser;

        #endregion

        #region Properties

        [DataMember]
        public string Message
        {
            get { return mMessage; }
            set { mMessage = value; }
        }

        [DataMember]
        public DateTime TimeStamp
        {
            get { return mTimeStamp; }
            set { mTimeStamp = value; }
        }

        [DataMember]
        public string User
        {
            get { return mUser; }
            set { mUser = value; }
        }

        #endregion

        




    }
}
