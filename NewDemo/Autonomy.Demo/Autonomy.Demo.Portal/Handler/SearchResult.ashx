<%@ WebHandler Language="C#" Class="SearchResult" %>

using System;
using System.Web;
using System.Net;
using System.IO;
using System.Xml;
using System.Text;
using System.Configuration;
using Newtonsoft.Json;

public class SearchResult : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {

        string actUrl = string.Empty;
        string keyword = context.Request.QueryString["keyword"];
        int start;
        if (context.Request.QueryString["Start"] != null && int.TryParse(context.Request.QueryString["Start"].ToString(), out start))
        {
            int end = start + 14;
            actUrl = ConfigurationManager.AppSettings["IdolACIPort"] + "/action=query&text=" + keyword + "&databasematch=" + ConfigurationManager.AppSettings["DATABASE"] + "&print=all&LanguageType=chineseUTF8&start=" 
                + start.ToString() + "&maxresults=" + end.ToString() + "&totalresults=true&minscore=60&outputencoding=utf8";

            //actUrl = "http://localhost:9000/action=Query&text=" + keyword + "&minscore=60&languagetype=chineseUTF8&sort=Relevance&querysummary=true&summary=context&sentences=3&characters=300&print=all&xmlmeta=true&combine=Simple&outputencoding=utf8&anylanguage=false&spellcheck=true&databasematch=" + ConfigurationManager.AppSettings["DATABASE"] + "&start=1&maxresults=10&totalresults=true";

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

                //Create an XmlNamespaceManager for resolving namespaces.
                XmlNamespaceManager nsmgr = new XmlNamespaceManager(contentDoc.NameTable);
                nsmgr.AddNamespace("autn", "http://schemas.autonomy.com/aci/");

                //Select the book node with the matching attribute value.
                XmlNodeList hits = contentDoc.SelectNodes("autnresponse/responsedata/autn:hit", nsmgr);
                XmlNode TotalNode = contentDoc.SelectSingleNode("autnresponse/responsedata/autn:totalhits", nsmgr);

                int totalCount = 0;
                int pageCount = 0;
                int pageSize = 15;

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
                    html.AppendFormat("<li><h2><a href=\"{0}\">", document.SelectSingleNode("DREREFERENCE").InnerText);
                    html.AppendFormat("{0}</a></h2>", document.SelectSingleNode("DRETITLE").InnerText);
                    html.Append("<div class=\"d\"><span>" + document.SelectSingleNode("MYSITENAME").InnerText + "</span> - " + document.SelectSingleNode("MYDATE").InnerText + "</div>");
                    html.AppendFormat("<p>{0}<b>...</b></p>", document.SelectSingleNode("DRECONTENT").InnerText);
                    html.Append("</li>");
                }

                context.Response.ContentType = "text/plain";
                context.Response.Write(html + "※" + totalCount + "※" + pageCount);
            }
        }
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}