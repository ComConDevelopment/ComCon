using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace ComCon.Shared.Classes
{
    [DataContract]
    public class DashboardMessage
    {
        private string mHeader;

        [DataMember]
        public string Header
        {
            get { return mHeader; }
            set { mHeader = value; }
        }

        private string mBody;

        [DataMember]
        public string Body
        {
            get { return mBody; }
            set { mBody = value; }
        }

        private Priortiy mPriority;

        [DataMember]
        public Priortiy MessagePriority
        {
            get { return mPriority; }
            set { mPriority = value; }
        }


    }

    [DataContract]
    public enum Priortiy
    {
        HIGH,
        MEDIUM,
        LOW
    }
}
