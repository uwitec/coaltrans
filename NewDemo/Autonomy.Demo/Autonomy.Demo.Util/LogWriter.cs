using System;
using System.IO;
using System.Text;
using System.Reflection;
using System.Diagnostics;

namespace Autonomy.Demo.Util
{
    public static class LogWriter
    {
        private static string m_LogDirPath = null;
        private const string LOG_FORMAT = "{0:T}\t{1}:{2}";

        static LogWriter()
        {
            m_LogDirPath = Path.Combine(System.Environment.CurrentDirectory, @"log\");
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
    }
}
