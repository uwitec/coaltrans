using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;

namespace GetConcreteUrl
{
    public class ListUrl
    {
        private string _Url;
        public ListUrl(string UrlStr)
        {
            _Url = UrlStr;
        }
        public IList<string> Start()
        {
            IList<string> StringList = new List<string>();
            if (!string.IsNullOrEmpty(_Url))
            {
                WebRequest request = WebRequest.Create(_Url);//调用帖子表

                request.Method = "GET";//采用提交方式
                request.ContentType = "application/x-www-form-urlencoded";//同上           
                WebResponse response = request.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding("gb2312"));//中文编码 

                string result = reader.ReadToEnd();
                result = result.Replace("\r\n", "");//删除结果的所有换行回车
                result = result.Replace("\t", "");//删除Tab 
                StringList = GetArticleList(result);
                reader.Close();
                reader.Dispose();
                response.Close();
            }
            return StringList;
        }
        private IList<string> GetArticleList(string result)
        {
            MatchCollection jg = Regex.Matches(result, "<table width=640 border=0 cellspacing=0.+?.</table>", RegexOptions.IgnoreCase);//匹配结果
            if (jg.Count > 0)
            {
                IList<string> StrArray = new List<string>();
                for (int i = 0; i < jg.Count; i++)
                {
                    StrArray.Add(jg[i].ToString());
                }
                return StrArray;
            }
            else
            {
                return null;
            }
        }
    }
}
