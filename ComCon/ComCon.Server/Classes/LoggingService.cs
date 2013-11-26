using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ComCon.Server.Classes
{
    public class LoggingService
    {
        public delegate void LogEventHandler(object sender, LoggingEventArgs data);
        public static event LogEventHandler LogEvent = delegate { };
        private const string Line = "---------------------------------";

        

        public static void Log(string pLog, LogStatus pStatus)
        {
            LogEvent(null, new LoggingEventArgs() { LogString = pLog, Status = pStatus });
        }

        public static void LogToFile(Exception ex)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(ex.Message);
            sb.AppendLine(Line);
            sb.AppendLine("\n\nSTACKTRACE");
            sb.AppendLine(Line);
            sb.AppendLine(ex.StackTrace);
            LogToFile(sb.ToString(), LogStatus.ERROR);
        }


        private static void LogToFile(string pLog, LogStatus pStatus)
        {
            string LogPath = @"C:\ComCon\Log\Log_" + DateTime.Today.Date + ".txt";
            TextWriter tw = new StreamWriter(LogPath, true);
            tw.Write("[" + pStatus.ToString("G") + "]" + pLog);
            tw.Close();
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
