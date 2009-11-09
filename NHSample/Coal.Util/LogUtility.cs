using System;
using System.IO;
using System.Text;
using System.Reflection;
using System.Diagnostics;

namespace Coal.Util
{
    public static class LogUtility
    {
        private static string m_LogDirPath = null;
        private const string LOG_FORMAT = "{0:T}\t{1}:{2}";

        static LogUtility()
        {
            m_LogDirPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"log\");
            if (!Directory.Exists(m_LogDirPath))
                Directory.CreateDirectory(m_LogDirPath);
        }

        private static string getLogFilePath(string type)
        {
            StringBuilder sb = new StringBuilder(m_LogDirPath);
            sb.Append(DateTime.Now.ToString("yyyyMMdd"));
            sb.Append("_");
            sb.Append(type);
            sb.Append(".txt");
            return sb.ToString();
        }


        public static void WriteAccessLog(string causer, string msg)
        {
            StreamWriter sw = new StreamWriter(getLogFilePath("access"), true, Encoding.Default);
            sw.WriteLine(LOG_FORMAT, DateTime.Now, causer, msg);
            sw.Close();
        }

        public static void WriteAccessLog(string msg)
        {
            WriteAccessLog(string.Empty, msg);
        }

        public static void WriteErrLog(string causer, string msg)
        {
            StreamWriter sw = new StreamWriter(getLogFilePath("error"), true, Encoding.Default);
            sw.WriteLine(LOG_FORMAT, DateTime.Now, causer, msg);
            sw.Close();
        }

        public static void WriteErrLog(string msg)
        {
            StackFrame sf = new StackFrame(3);
            MethodBase mb = sf.GetMethod();
            WriteErrLog(String.Format("{0}.{1}", mb.ReflectedType, mb.Name), msg);
        }

        public static void WriteErrLog(Exception ex)
        {
            StackFrame sf = new StackFrame(3);
            MethodBase mb = sf.GetMethod();
            StreamWriter sw = new StreamWriter(getLogFilePath("error"), true, Encoding.Default);
            sw.WriteLine(System.DateTime.Now.ToString());
            sw.WriteLine(string.Format("causer:{0}.{1}", mb.ReflectedType, mb.Name));
            sw.WriteLine("Message:" + ex.Message);
            sw.WriteLine("Source:" + ex.Source);
            sw.WriteLine("StackTrace:" + ex.StackTrace);
            sw.WriteLine("*****************************************************");
            sw.WriteLine("");
            sw.Close();
            
        }

        public static void WriteSysErrLog(string msg)
        {
            StreamWriter sw = new StreamWriter(getLogFilePath("SysError"), true, Encoding.Default);
            sw.WriteLine(msg);
            sw.Close();
        }

    }
}
