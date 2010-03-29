<%@ WebHandler Language="C#" Class="GetSGDataResults" %>

using System;
using System.Web;
using System.Net;
using System.IO;
using System.Text;
using System.Xml;
using System.Configuration;
using log4net;

public class GetSGDataResults : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        
        string pointId = context.Request.QueryString["point_id"];
        string fromTimeId = context.Request.QueryString["from_time_id"];
        string endTimeId = context.Request.QueryString["end_time_id"];
        if (!string.IsNullOrEmpty(pointId) & !string.IsNullOrEmpty(fromTimeId) & !string.IsNullOrEmpty(endTimeId))
        {
            ILog m_log = LogManager.GetLogger("GetSGData");
            string actUrl = ConfigurationManager.AppSettings["IdolACIPort"] + "/action=ClusterSGDocsServe&SourceJobname=myjob_sg&Cluster=" + pointId + "&StartDate=" + fromTimeId + "&EndDate=" + endTimeId + "&NumResults=10";
            HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(actUrl);
            myRequest.Method = "GET";
            myRequest.ContentType = "application/x-www-form-urlencoded";

            HttpWebResponse myResponse = (HttpWebResponse)myRequest.GetResponse();
            StreamReader reader = new StreamReader(myResponse.GetResponseStream(), Encoding.UTF8);
            string content = reader.ReadToEnd();
            XmlDocument contentDoc = new XmlDocument();
            contentDoc.LoadXml(content);

            //Create an XmlNamespaceManager for resolving namespaces.
            XmlNamespaceManager nsmgr = new XmlNamespaceManager(contentDoc.NameTable);
            nsmgr.AddNamespace("autn", "http://schemas.autonomy.com/aci/");


            //Select the book node with the matching attribute value.
            XmlNodeList docsList = contentDoc.SelectNodes("autnresponse/responsedata/autn:clusters/autn:cluster/autn:docs/autn:doc", nsmgr);

            StringBuilder html = new StringBuilder();

            foreach (XmlNode doc in docsList)
            {
                html.Append("<li>");
                html.Append("<h2><a href=\"" + doc.ChildNodes[1].InnerText + "\" target=\"_blank\">" + doc.ChildNodes[0].InnerText + "</a></h2>");
                html.Append("</li>");
            }
            
            context.Response.Write(html);  
        }
        else
        {
            context.Response.Write("没有数据！");
        }
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}