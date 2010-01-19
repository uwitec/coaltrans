using System;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text.RegularExpressions;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Collections;
using System.Data;
using System.Xml;
using System.Collections.Generic;
using Microsoft.JScript;


namespace   Coal.Util
{
    public class Common
    {
        /// <summary>
        /// 过滤危险字符
        /// </summary>
        /// <param name="text">要过滤的字符串</param>
        /// <returns>字符串</returns>
        public static string FiltrationMaliciousCode(string text)
        {
            try
            {
                if (string.IsNullOrEmpty(text))
                {
                    return string.Empty;
                }
                Regex regex1 = new Regex(@"<script[^>]*?>[\s\S]*?</script>", RegexOptions.IgnoreCase);
                Regex regex2 = new Regex(@"<a.*href.*=.*script:.*</a>", RegexOptions.IgnoreCase);
                Regex regex3 = new Regex(@"on(blur|c(hange|lick)|dblclick|focus|keypress|(key|mouse)(down|up)|(un)?load|mouse(move|o(ut|ver))|reset|s(elect|ubmit))", RegexOptions.IgnoreCase);
                Regex regex4 = new Regex(@"<iframe.*</iframe>", RegexOptions.IgnoreCase);
                Regex regex5 = new Regex(@"<frameset.*</frameset>", RegexOptions.IgnoreCase);
                text = regex1.Replace(text, ""); //过滤<script></script>标记
                text = regex2.Replace(text, ""); //过滤href=javascript: (<A>) 属性
                text = regex3.Replace(text, ""); //过滤其它控件的on...事件
                text = regex4.Replace(text, ""); //过滤iframe
                text = regex5.Replace(text, ""); //过滤frameset
                return text;
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// 对字符串进行Escape编码
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string Escape(string str)
        {
            if (str == null)
                return String.Empty;

            StringBuilder sb = new StringBuilder();
            int len = str.Length;

            for (int i = 0; i < len; i++)
            {
                char c = str[i];

                //everything other than the optionally escaped chars _must_ be escaped 
                if (Char.IsLetterOrDigit(c) || c == '-' || c == '_' || c == '/' || c == '\\' || c == '.')
                    sb.Append(c);
                else
                    sb.Append(Uri.HexEscape(c));
            }

            return sb.ToString();
        }
        /// <summary>
        /// 对字符串进行UnEscape解码
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string UnEscape(string str)
        {
            string EncodeStr = Microsoft.JScript.GlobalObject.unescape(str);
            return EncodeStr.Replace("\n", "");
        }


    }
}
