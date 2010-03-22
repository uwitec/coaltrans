using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;

namespace IdxSource
{
    class GenIdxByWebEngine
    {


        private string GetContent()
        {
            HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(srcUrl);
            myRequest.Method = "GET";
            myRequest.ContentType = "application/x-www-form-urlencoded";

            // Get response
            HttpWebResponse myResponse = (HttpWebResponse)myRequest.GetResponse();
            StreamReader reader = new StreamReader(myResponse.GetResponseStream(), Encoding.Default);
            string content = reader.ReadToEnd();
        }

        private StringBuilder GenMatchXML(string srcReg, string content)
        {     
            Regex r = new Regex(srcReg, RegexOptions.IgnoreCase | RegexOptions.Compiled);
            Match m;

            StringBuilder xml = new StringBuilder("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
            xml.Append("<docs>");

            ArrayList list = new ArrayList();
            for (m = r.Match(content); m.Success; m = m.NextMatch())
            {
                xml.Append("<doc>");
                //http://money.msn.com.cn/finance/internal/87363.shtml
                xml.Append("<doc_url><![CDATA[").Append(m.Groups[1].Value).Append("]]></doc_url>");

                //xml.Append("<doc_mySrcType><![CDATA[news/blog/bbs/web]]></doc_mySrcType>");
                xml.Append("<doc_mySrcType><![CDATA[").Append(GetURLType(m.Groups[1].Value)).Append("]]></doc_mySrcType>");

                //反<font color=#cc0033>拆迁</font>点子人的江湖
                xml.Append("<doc_title><![CDATA[").Append(NoHTML(m.Groups[2].Value)).Append("]]></doc_title>");

                //人民网
                xml.Append("<doc_MySiteName><![CDATA[").Append(NoHTML(m.Groups[3].Value)).Append("]]></doc_MySiteName>");

                //2010-01-13
                xml.Append("<doc_MyDate><![CDATA[").Append(NoHTML(m.Groups[4].Value)).Append("]]></doc_MyDate>");

                //按照现有的<font color=#cc0033>拆迁</font>模式,政府部门根本不用与.........
                xml.Append("<doc_content><![CDATA[").Append(NoHTML(m.Groups[5].Value)).Append("]]></doc_content>");                
                

                xml.Append("</doc>");
            }
            xml.Append("</docs>");

            return xml;
        }

        private void GenOutFile(string fileName, StringBuilder xml)
        {
            FileStream nFile = new FileStream(fileName, FileMode.CreateNew);
            using (StreamWriter writer = new StreamWriter(nFile))
            {
                writer.Write(xml.ToString());
            }

        }

        /// <summary>
        ///DEMO，网页搜索时，根据结果的URL判断是 新闻，博客，BBS 还是一般网页
        ///特定的博客搜索，论坛搜索时，直接指定文章类别
        ///将来版本用其他方式实现
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static string GetURLType(string url)
        {
            //
            string lowerURL = url.ToLower();
            if (lowerURL.Contains("blog"))
                return "blog";
            if (lowerURL.Contains("bbs"))
                return "bbs";
            if (lowerURL.Contains("new"))
                return "news";
            return "web";
        }

        public static string NoHTML(string Htmlstring)
        {
            //删除HTML   
            Htmlstring = Regex.Replace(Htmlstring, @"<(.[^>]*)>", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"([\r\n])[\s]+", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"-->", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"<!--.*", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(quot|#34);", "\"", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(amp|#38);", "&", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(lt|#60);", "<", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(gt|#62);", ">", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(nbsp|#160);", "   ", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(iexcl|#161);", "\xa1", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(cent|#162);", "\xa2", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(pound|#163);", "\xa3", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(copy|#169);", "\xa9", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&#(\d+);", "", RegexOptions.IgnoreCase);
            Htmlstring.Replace("<", "");
            Htmlstring.Replace(">", "");
            Htmlstring.Replace("\r\n", "");
            return Htmlstring;
        }

    }

}
