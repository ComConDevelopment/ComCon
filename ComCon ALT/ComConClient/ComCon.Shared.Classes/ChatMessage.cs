using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.Runtime.Serialization;
using System.Windows.Media;

namespace ComCon.Shared.Classes
{
    [DataContract]
    public class ChatMessage
    {
        #region Deklaration

        private string mMessage;
        private DateTime mTimeStamp;
        private ChatUser mUser;

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
        public ChatUser User
        {
            get { return mUser; }
            set { mUser = value; }
        }

        private Color mColor;
        [DataMember]
        public Color Color
        {
            get { return mColor; }
            set { mColor = value; }
        }


        #endregion

        




    }
}
