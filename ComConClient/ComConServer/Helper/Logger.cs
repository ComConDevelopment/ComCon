using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ComConServer.Helper
{
    public class Logger
    {
        private const string BaseLogPath = @"C:\ComCon\Log\";

        public static void Log(Exception e)
        {

            StringBuilder sb = new StringBuilder();
            sb.AppendLine(String.Format("{0:dd.MM.yyyy HH:mm:ss} ERROR", DateTime.Now));
            sb.AppendLine("DATA");
            sb.AppendLine(e.Data.ToString());
            sb.AppendLine("MESSAGE");
            sb.AppendLine(e.Message);
            sb.AppendLine("STACKTRACE");
            sb.AppendLine(e.StackTrace);
            if (e.InnerException != null)
            {
                sb.AppendLine("\tINNER EXCEPTION");
                sb.AppendLine("\tDATA");
                sb.AppendLine("\t" + e.InnerException.Data.ToString());
                sb.AppendLine("\tMESSAGE");
                sb.AppendLine("\t" + e.InnerException.Message);
                sb.AppendLine("\tSTACKTRACE");
                sb.AppendLine("\t" + e.InnerException.StackTrace);
            }

            if (!Directory.Exists(BaseLogPath + DateTime.Now.ToShortDateString()))
            {
                Directory.CreateDirectory(BaseLogPath + DateTime.Now.ToShortDateString());
            }

            using (StreamWriter writer = File.CreateText(BaseLogPath + DateTime.Now.ToShortDateString() + "\\Log.txt"))
            {
                writer.Write(sb.ToString());
                writer.Flush();
                writer.Close();
            }
            
           
        }

        public static void Log(string e)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine(String.Format("{0:dd.MM.yyyy HH:mm:ss} INFO", DateTime.Now));
                sb.AppendLine(e);


                using (StreamWriter writer = File.CreateText(BaseLogPath + DateTime.Now.ToShortDateString() + "\\Log.txt"))
                {
                    writer.Write(sb.ToString());
                    writer.Flush();
                    writer.Close();
                }
            }
            catch (Exception)
            {
                
                
            }



        }
    }
}
