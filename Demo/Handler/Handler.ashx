<%@ WebHandler Language="C#" Class="Handler" %>

using System;
using System.Web;
using System.Net;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.XPath;
using System.Configuration;

public class Handler : IHttpHandler 
{
    public void ProcessRequest (HttpContext context) 
    {   
        string actUrl = string.Empty;
        string keyword = context.Request.QueryString["keyword"];
        string category = context.Request.QueryString["category"];

        if (!string.IsNullOrEmpty(category))
        {
            string categoryId;

            switch (category)
            { 
                case "feiwen":
                    categoryId = "797992763887997774";
                    break;
                case "sanqiang":
                    categoryId = "930729723204723645";
                    break;
                default:
                    categoryId = "";
                    break;
            }

            actUrl = ConfigurationManager.AppSettings["IdolACIPort"] + "/action=CategoryQuery&category=" + categoryId + "&Databases=" + ConfigurationManager.AppSettings["DATABASE"] + "&numresults=10&Params=print&Values=all";
        }
        else if (!string.IsNullOrEmpty(keyword))
        {
            actUrl = ConfigurationManager.AppSettings["IdolACIPort"] + "/action=query&text=" + keyword + "&databasematch=" + ConfigurationManager.AppSettings["DATABASE"] + "&print=all";
        }


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

            //XmlNamespaceManager nsMgr = new XmlNamespaceManager(contentDoc.NameTable);
            //nsMgr.AddNamespace("autn", "urn:schemas-microsoft-com:xml-diffgram-v1");
            //XmlNodeList hits = contentDoc.SelectNodes("autn:hit", nsMgr);

            XmlNodeList hits = contentDoc.SelectNodes("autnresponse/responsedata")[0].ChildNodes;

            //<li><a href="#">负面</a><span>香港文汇报 2009-12-17</span></li>
            StringBuilder html = new StringBuilder();

            html.Append("<ul>");
            foreach (XmlNode hit in hits)
            {
                if (hit.ChildNodes.Count == 11)
                {
                    html.Append("<li>");
                    html.AppendFormat("<a href='{0}'>{1}</a>", hit.ChildNodes[1].InnerText, hit.ChildNodes[0].InnerText);
                    html.AppendFormat("<span>{0}</span>", hit.ChildNodes[10].ChildNodes[0].ChildNodes[10].InnerText);
                    html.AppendFormat("<span>{0}</span>", hit.ChildNodes[10].ChildNodes[0].ChildNodes[12].InnerText);
                    html.Append("</li>");
                }
                else if (hit.ChildNodes.Count == 8)
                {
                    html.Append("<li>");
                    html.AppendFormat("<a href='{0}'>{1}</a>", hit.ChildNodes[1].InnerText, hit.ChildNodes[0].InnerText);
                    html.AppendFormat("<span>{0}</span>", DateTime.Now);
                    html.Append("</li>");
                }
            }
            html.Append("</ul>");
            context.Response.Write(html);
        }
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}