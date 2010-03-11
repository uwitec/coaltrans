<%@ WebHandler Language="C#" Class="GetClusterResults" %>

using System;
using System.Web;
using System.Net;
using System.IO;
using System.Text;
using System.Xml;
using System.Configuration;

public class GetClusterResults : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) 
    {
        string clusterId = context.Request.QueryString["cluster_id"];
        string actionUrl = ConfigurationManager.AppSettings["IdolACIPort"] + "/action=ClusterResults&SourceJobName=myjob_clusters&Cluster=" + clusterId + "&DREOutputEncoding=utf8&NumResults=50&MaxTerms=0";

        HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(actionUrl);
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
        XmlNodeList clusterDocs = contentDoc.SelectNodes("autnresponse/responsedata/autn:clusters/autn:cluster/autn:docs/autn:doc", nsmgr);

        StringBuilder html = new StringBuilder();
        string title;
        string reference;

        //   foreach (XmlNode clusterDoc in clusterDocs)
        for (int index = 0; index < 10; index++)
        {
            XmlNode clusterDoc = clusterDocs[index];
            title = clusterDoc.SelectSingleNode("autn:title", nsmgr).InnerText;
            reference = clusterDoc.SelectSingleNode("autn:ref", nsmgr).InnerText;
            html.Append("<li>");
            html.Append("<h2><a href=\"").Append(reference).Append("\">").Append(title).Append("</a></h2>");
			html.Append("<div class=\"d\"><span>千龙网</span> - 47分钟前</div>");
			html.Append("<p>医生圈论坛—医学社区2008年，礼来的销售业绩继续保持了前两年快速增长的态势，尤其是在胰岛素领域的增长远远高于市场平均水平；勃林格殷格翰<b>...</b></p>");
			html.Append("</li>");
        }

        context.Response.Write(html.ToString());
        
        //context.Response.ContentType = "text/plain";
        //context.Response.Write("Hello World");
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}