using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;

namespace ThreadTest
{
    public class GetContent
    {
        public string ArticleTitle;
        public string SiteName;
        public string ArticleContent;
        public GetContent(string url)
        {
            string Str = GetPagerList(url);
            if (!string.IsNullOrEmpty(Str))
            {
                string Title = GetTitle(Str.Split('※')[1]);
                string[] TitleList = Title.Split('_');
                ArticleTitle = TitleList[0];
                if (TitleList.Length >= 3)
                {
                    SiteName = TitleList[1] + "  " + TitleList[2];
                }
                ArticleContent = GetArticleContent(Str.Split('※')[1]);
            }
        }
        /// <summary>
        /// 获取文章的分页数
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        private static string GetPagerList(string url)
        {
            WebRequest request = WebRequest.Create(url);//调用帖子表

            request.Method = "GET";//采用提交方式
            request.ContentType = "application/x-www-form-urlencoded";//同上           
            using (WebResponse response = request.GetResponse())
            {
                using (StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding("gb2312")))//中文编码 
                {
                    string result = reader.ReadToEnd();
                    result = result.Replace("\r\n", "");//删除结果的所有换行回车
                    result = result.Replace("\t", "");//删除Tab 
                    MatchCollection jg = Regex.Matches(result, "<input type='hidden' name='idArticleslist'.+?.>", RegexOptions.IgnoreCase);//匹配结果
                    if (jg.Count > 0)
                    {
                        string zzjg = jg[0].ToString();
                        string Str = zzjg.Replace("<input type='hidden' name='idArticleslist' value='", "");
                        Str = Str.Replace("'>", "");
                        return Str + "※" + result;
                    }
                    else
                    {
                        return " ※" + result;
                    }
                }
            }
        }
        /// <summary>
        /// 获取标题及信息来源
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        private static string GetTitle(string result)
        {
            MatchCollection jg = Regex.Matches(result, "<TITLE>.+?.</TITLE>", RegexOptions.IgnoreCase);//匹配结果
            if (jg.Count > 0)
            {
                string zzjg = jg[0].ToString();
                string Str = zzjg.Replace("<TITLE>", "");
                Str = Str.Replace("</TITLE>", "");
                return Str;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 获取作者名称
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        private static string GetAuthor(string result)
        {
            string ArticleInfo = string.Empty;
            MatchCollection jg = Regex.Matches(result, "<TABLE id=\"firstAuthor\" align=center border=0 cellSpacing=0 width=\'100%\'>.+?.</TABLE>", RegexOptions.IgnoreCase);//匹配结果
            if (jg.Count > 0)
            {
                string zzjg = jg[0].ToString();
                ArticleInfo += GetAuthorName(zzjg);
                ArticleInfo += GetArticleTime(zzjg);
            }
            return ArticleInfo;
        }
        /// <summary>
        /// 获取作者名称
        /// </summary>
        /// <param name="zzjg"></param>
        /// <returns></returns>
        private static string GetAuthorName(string zzjg)
        {
            MatchCollection Str = Regex.Matches(zzjg, "作者：<a href.+?.</a>", RegexOptions.IgnoreCase);

            if (Str.Count > 0)
            {
                string Author = "";
                foreach (Match s in Regex.Matches(Str[0].ToString(), "作者：<[a|A] href.+?>"))
                {
                    Author = Str[0].ToString().Replace(s.Value, "");
                }
                return Author.Replace("</a>", "");
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 获取提交日期
        /// </summary>
        /// <param name="zzjg"></param>
        /// <returns></returns>
        private static string GetArticleTime(string zzjg)
        {
            MatchCollection Str = Regex.Matches(zzjg, "提交日期：.+?.访问：", RegexOptions.IgnoreCase);

            if (Str.Count > 0)
            {
                string Author = "";
                Author = Str[0].ToString().Replace("提交日期：", "");
                return Author.Replace("访问：", "");
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 获取文章内容
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        private static string GetArticleContent(string result)
        {
            MatchCollection jg = Regex.Matches(result, "<DIV class=content style=\"WORD-WRAP:break-word;\">.+?.</DIV>", RegexOptions.IgnoreCase);//匹配结果
            if (jg.Count > 0)
            {
                string zzjg = jg[0].ToString();
                string Str = zzjg.Replace("<DIV class=content style=\"WORD-WRAP:break-word;\">", "");
                Str = Str.Replace("<TABLE cellspacing=0 border=0 width=100% ><TR><TD><font size=-1 color=green><br><center><div id=\"tianyaBrandSpan1\"></div>", "");
                return Str;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 获取评论回复
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        private static string[] GetcommentList(string result)
        {
            if (result.Length > 0)
            {
                string Author = result;
                foreach (Match s in Regex.Matches(Author, "<TABLE cellspacing=0 border=0 bgcolor=#f5f9fa width=100% >.+?.</table>"))
                {
                    Author = Author.Replace(s.Value, "※");
                }
                Author = Author.Replace("</DIV></div><!-- google_ad_section_end -->", "※");

                return Author.Split('※');
            }
            else
            {
                return null;
            }
        }
    }
   
}
