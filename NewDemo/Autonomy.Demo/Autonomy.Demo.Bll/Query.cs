using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using Autonomy.Demo.Util;
using System.Text;
using System.Xml;
using System.Net;
using System.IO;

namespace Autonomy.Demo.Bll
{
    public abstract class Query
    {
        public string QueryParam { get; set; }
        public int Start { get; set; }
        public string dateStr { get; set; }
        public string sortStr { get; set; }

        public abstract string GetQueryCommand();
        public abstract string GetResult(XmlDocument contentDoc);

        public string DoQuery()
        {
            string actUrl = GetQueryCommand();

            if (actUrl != string.Empty)
            {
                HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(actUrl);
                myRequest.Method = "GET";
                myRequest.ContentType = "application/x-www-form-urlencoded";

                // Get response
                HttpWebResponse myResponse = (HttpWebResponse)myRequest.GetResponse();
                StreamReader reader = new StreamReader(myResponse.GetResponseStream(), Encoding.UTF8);
                string content = reader.ReadToEnd();
                XmlDocument contentDoc = new XmlDocument();
                contentDoc.LoadXml(content);
                return  GetResult(contentDoc);
            }
            else
            {
                return string.Empty;
            }
        }
    }

    public class SearchQuery : Query
    {
        public override string GetQueryCommand()
        {
            int end = Start + 9;
            string actUrl = ConfigUtil.GetAppSetting("IdolACIPort") + "/action=query&text=" + QueryParam
                          + "&print=all&MinDate=" + dateStr + "&Sort=" + sortStr + "&LanguageType=chineseUTF8&start="
                          + Start.ToString() + "&maxresults=" + end.ToString() + "&totalresults=true&minscore=60&Highlight=Terms&outputencoding=utf8";
            return actUrl;
        }

        public override string GetResult(XmlDocument contentDoc)
        {
            //Create an XmlNamespaceManager for resolving namespaces.
            XmlNamespaceManager nsmgr = new XmlNamespaceManager(contentDoc.NameTable);
            nsmgr.AddNamespace("autn", "http://schemas.autonomy.com/aci/");

            //Select the book node with the matching attribute value.
            XmlNodeList hits = contentDoc.SelectNodes("autnresponse/responsedata/autn:hit", nsmgr);
            XmlNode TotalNode = contentDoc.SelectSingleNode("autnresponse/responsedata/autn:totalhits", nsmgr);

            int totalCount = 0;
            int pageCount = 0;
            int pageSize = 10;

            if (TotalNode != null && !string.IsNullOrEmpty(TotalNode.InnerText))
            {
                totalCount = int.Parse(TotalNode.InnerText);
                int remainder;
                pageCount = Math.DivRem(totalCount, pageSize, out remainder);
                if (remainder > 0)
                {
                    pageCount++;
                }
            }

            StringBuilder html = new StringBuilder();
            foreach (XmlNode hit in hits)
            {
                XmlNode document = hit.ChildNodes[7].SelectSingleNode("DOCUMENT");
                html.AppendFormat("<li><h2><a href=\"{0}\" target=\"_blank\">", document.SelectSingleNode("DREREFERENCE").InnerText);
                html.AppendFormat("{0}</a></h2>", document.SelectSingleNode("DRETITLE").InnerText);
                html.Append("<div class=\"d\"><span>" + document.SelectSingleNode("MYSITENAME").InnerText + "</span> - " + document.SelectSingleNode("MYDATE").InnerText + "</div>");
                html.AppendFormat("<p>{0}<b>...</b></p>", document.SelectSingleNode("DRECONTENT").InnerText);
                html.Append("</li>");
            }

            html.Append("※").Append(totalCount).Append("※").Append(pageCount);

            return html.ToString();
        }
    }

    public class CategoryQuery : Query
    {
        public override string GetQueryCommand()
        {
            int end = 10;
            string actUrl = ConfigUtil.GetAppSetting("IdolACIPort") + "/action=CategoryQuery&category="
                          + QueryParam + "&start=" + Start + "&totalresults=true&numresults=" + end + "&Params=Print,Sort,MinDate&Values=all," + sortStr + "," + dateStr;
            return actUrl;
        }

        public override string GetResult(XmlDocument contentDoc)
        {
              //Create an XmlNamespaceManager for resolving namespaces.
            XmlNamespaceManager nsmgr = new XmlNamespaceManager(contentDoc.NameTable);
            nsmgr.AddNamespace("autn", "http://schemas.autonomy.com/aci/");

            //Select the book node with the matching attribute value.
            XmlNodeList hits = contentDoc.SelectNodes("autnresponse/responsedata/autn:hit", nsmgr);
            XmlNode TotalNode = contentDoc.SelectSingleNode("autnresponse/responsedata/autn:totalhits", nsmgr);

            int totalCount = 0;
            int pageCount = 0;
            int pageSize = 10;

            if (TotalNode != null && !string.IsNullOrEmpty(TotalNode.InnerText))
            {
                totalCount = int.Parse(TotalNode.InnerText);
                int remainder;
                pageCount = Math.DivRem(totalCount, pageSize, out remainder);
                if (remainder > 0)
                {
                    pageCount++;
                }
            }

            StringBuilder html = new StringBuilder();
            foreach (XmlNode hit in hits)
            {
                XmlNode document = hit.ChildNodes[9].SelectSingleNode("DOCUMENT");
                html.AppendFormat("<li><h2><a href=\"{0}\" target=\"_blank\">", document.SelectSingleNode("DREREFERENCE").InnerText);
                html.AppendFormat("{0}</a></h2>", document.SelectSingleNode("DRETITLE").InnerText);
                html.Append("<div class=\"d\"><span>" + document.SelectSingleNode("MYSITENAME").InnerText + "</span> - " + document.SelectSingleNode("MYDATE").InnerText + "</div>");
                html.AppendFormat("<p>{0}<b>...</b></p>", document.SelectSingleNode("DRECONTENT").InnerText);
                html.Append("</li>");
            }

            html.Append("※").Append(totalCount).Append("※").Append(pageCount);

            return html.ToString();
        }
    }

    public class QueryforCategory : Query
    {
        public override string GetQueryCommand()
        {
            int end = Start + 9;
            string actUrl = ConfigUtil.GetAppSetting("IdolACIPort") + "/action=query&text=" + QueryParam
                          + "&print=all&MinDate=" + dateStr + "&Sort=" + sortStr + "&LanguageType=chineseUTF8&start="
                          + Start.ToString() + "&maxresults=" + end.ToString() + "&totalresults=true&minscore=60&Highlight=Terms&outputencoding=utf8";
            return actUrl;
        }

        public override string GetResult(XmlDocument contentDoc)
        {
            //Create an XmlNamespaceManager for resolving namespaces.
            XmlNamespaceManager nsmgr = new XmlNamespaceManager(contentDoc.NameTable);
            nsmgr.AddNamespace("autn", "http://schemas.autonomy.com/aci/");

            //Select the book node with the matching attribute value.
            XmlNodeList hits = contentDoc.SelectNodes("autnresponse/responsedata/autn:hit", nsmgr);
            XmlNode TotalNode = contentDoc.SelectSingleNode("autnresponse/responsedata/autn:totalhits", nsmgr);

            int totalCount = 0;
            int pageCount = 0;
            int pageSize = 10;

            if (TotalNode != null && !string.IsNullOrEmpty(TotalNode.InnerText))
            {
                totalCount = int.Parse(TotalNode.InnerText);
                int remainder;
                pageCount = Math.DivRem(totalCount, pageSize, out remainder);
                if (remainder > 0)
                {
                    pageCount++;
                }
            }

            StringBuilder html = new StringBuilder();
            foreach (XmlNode hit in hits)
            {
                string weight = hit.ChildNodes[3].InnerText;
                string docId = hit.ChildNodes[1].InnerText;
                html.Append("<li><div class=\"trainSelect\"><input  type=\"checkbox\" name=\"train_article_list\" id=\"article_" + docId + "\"/>" + weight + "%</div>");                
                XmlNode document = hit.ChildNodes[7].SelectSingleNode("DOCUMENT");
                html.AppendFormat("<h2><a href=\"{0}\" target=\"_blank\">", document.SelectSingleNode("DREREFERENCE").InnerText);
                html.AppendFormat("{0}</a></h2>", document.SelectSingleNode("DRETITLE").InnerText);
                html.AppendFormat("<div class=\"d\"><span>{0}</span> - {1}</div>", document.SelectSingleNode("MYSITENAME").InnerText, document.SelectSingleNode("MYDATE").InnerText);
                html.AppendFormat("<p>{0}<b>...</b></p>", document.SelectSingleNode("DRECONTENT").InnerText);                
                html.Append("</li>");
            }

            html.Append("※").Append(totalCount).Append("※").Append(pageCount);

            return html.ToString();
        }
    }

    public class QueryFactory
    {
        public static Query GetQuery(QueryType queryType)
        {
            switch (queryType)
            {
                case QueryType.Search:
                    return new SearchQuery();
                case QueryType.Category:
                    return new CategoryQuery();
                case QueryType.QueryforCategory:
                    return new QueryforCategory();
                default:
                    return null;
            }
        }
    }

    public enum QueryType
    {
        Search = 1,
        Category = 2,
        QueryforCategory=3
    }
}

