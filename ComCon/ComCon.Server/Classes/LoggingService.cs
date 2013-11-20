using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComCon.Server.Classes
{
    public class LoggingService
    {
        public delegate void LogEventHandler(object sender, LoggingEventArgs data);
        public static event LogEventHandler LogEvent = delegate { };

        

        public static void Log(string pLog, LogStatus pStatus)
        {
            LogEvent(null, new LoggingEventArgs() { LogString = pLog, Status = pStatus });
        }
    }

    public class LoggingEventArgs : EventArgs
    {
        private string mLogString;

        public string LogString
        {
            get { return mLogString; }
            set { mLogString = value; }
        }


        private LogStatus mStatus;

        public LogStatus Status
        {
            get { return mStatus; }
            set { mStatus = value; }
        }

        
    }


}

public enum LogStatus
{
    INFO,
    WARNING,
    ERROR,
}
