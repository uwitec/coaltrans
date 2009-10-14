using System;
using System.Text;
using System.Text.RegularExpressions;

namespace CoalTrans.Util
{
    public static class StringUtil
    {
        public static string FilterHTML(object o)
        {
           if (o == null) return null;
           string s = EConvert.ToString(o);
           bool flag = true;
           StringBuilder sb = new StringBuilder();
           foreach (char c in s)
           {
               if (c == '<')
               {
                   flag = false;
                   continue;
               }
               else if (c == '>')
               {
                   flag = true;
                   continue;
               }

               if (flag) sb.Append(c);
           }

           return sb.ToString();
        }

        public static string Truncate(object o, int l)
        {
            return Truncate(o, l, "...");
        }
        public static string Truncate(object o, int l, string ellipsis)
        {
            if (o == null || l==0) return null;
            string s = EConvert.ToString(o);
            int len = s.Length;
            if (len <= l) return s;

            return new StringBuilder(s.Substring(0, l)).Append(ellipsis).ToString();
        }

        public static string NTruncate(object o, int l)
        { 
            return NTruncate(o,l,"...");
        }
        public static string NTruncate(object o, int l, string ellipsis)
        {
            if (o == null || l==0) return null;

            string s = EConvert.ToString(o);

            StringBuilder sb = new StringBuilder();
            int i = 0;
            foreach (char c in s)
            {
                if (c > 127) i++; i++;
                if ((i % 2 == 0 ? i : i + 1) > l * 2)
                    return sb.Append(ellipsis).ToString();
                sb.Append(c);
            }

            return sb.ToString();
        }
 
        private static Regex intFormatReg = new Regex(@"^\d+$",RegexOptions.Compiled);
        public static bool IsInteger(string num)
        {
            if (num == null) return false;
            return intFormatReg.IsMatch(num.Trim());
        }

        public static string Format(string format,params object[] args)
        {
            if (format == null)
                return string.Empty;
            if (args == null)
                return string.Format(format, string.Empty);

            return string.Format(format, args);
        }

    }
}
