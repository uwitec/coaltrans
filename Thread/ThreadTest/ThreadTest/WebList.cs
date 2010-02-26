using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;

namespace ThreadTest
{
    public class WebList
    {
        private string WebUrl;
        public WebList(string Url)
        {
            WebUrl = Url;
        }
        public string ListStart()
        {
            if (!string.IsNullOrEmpty(WebUrl))
            {
                string Str = null;
                WebRequest request = WebRequest.Create(WebUrl);//调用帖子表

                request.Method = "GET";//采用提交方式
                request.ContentType = "application/x-www-form-urlencoded";//同上           
                WebResponse response = request.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding("gb2312"));//中文编码 

                string result = reader.ReadToEnd();
                result = result.Replace("\r\n", "");//删除结果的所有换行回车
                result = result.Replace("\t", "");//删除Tab 
                string ListUrl = GetList(result); //这里有可能返回null，注意判断
                DateTime ComPairTime = Convert.ToDateTime("0001-1-01");
                string DateStr = "";
                if (!string.IsNullOrEmpty(ListUrl))
                {
                    int StartIndex = ListUrl.IndexOf("&NextArticle=");
                    int EndIndex = ListUrl.IndexOf("&strSubItem");
                    DateStr = ListUrl.Substring(StartIndex + 13, EndIndex - StartIndex);
                    if (!string.IsNullOrEmpty(DateStr))
                    {
                        DateStr = DateStr.Split('+')[0];
                    }
                    ComPairTime = Convert.ToDateTime(DateStr);                    
                }
                DateTime NowTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));
                if (!string.IsNullOrEmpty(ListUrl) && !string.IsNullOrEmpty(DateStr) && ComPairTime == NowTime)
                {
                    Str = ListUrl;
                }
                reader.Close();
                reader.Dispose();
                response.Close();
                return Str;
            }
            else
            {
                return null;
            }
        }
        public String GetList(string result)
        {
            MatchCollection jg = Regex.Matches(result, "<table width=\"640\"  border=\"0\" cellspacing=\"3\" cellpadding=\"0\">.+?.</table>", RegexOptions.IgnoreCase);//匹配结果
            if (jg.Count > 0)
            {
                string Url = "";
                string Str = jg[0].ToString();
                MatchCollection StrList = Regex.Matches(Str, "<a href=.+?.</a>", RegexOptions.IgnoreCase);
                for (int i = 0; i < StrList.Count; i++)
                {
                    if (StrList[i].ToString().IndexOf("下一页") > 0)
                    {
                        Url = StrList[i].ToString();
                    }
                }
                Url = Url.Replace("<a href=", "");
                Url = Url.Replace(">下一页</a>", "");
                return UnEscape(Url);
            }
            else
            {
                return null;
            }
        }

        private string Escape(string str)
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

        private string UnEscape(string str)
        {
            if (str == null)
                return String.Empty;

            StringBuilder sb = new StringBuilder();
            int len = str.Length;
            int i = 0;
            while (i != len)
            {
                if (Uri.IsHexEncoding(str, i))
                    sb.Append(Uri.HexUnescape(str, ref i));
                else
                    sb.Append(str[i++]);
            }

            return sb.ToString();
        }
    }
}
