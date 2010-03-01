<%@ WebHandler Language="C#" Class="GetMapData" %>

using System;
using System.Web;
using System.Net;
using System.IO;
using System.Text;
using System.Xml;
using System.Configuration;
using log4net;

public class GetMapData : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) 
    {
        ILog m_log = LogManager.GetLogger("GetMapData");       
        string actUrl = ConfigurationManager.AppSettings["IdolACIPort"] + "/action=ClusterResults&SourceJobname=myjob_clusters";
        HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(actUrl);
        myRequest.Method = "GET";
        myRequest.ContentType = "application/x-www-form-urlencoded";


        HttpWebResponse myResponse = (HttpWebResponse)myRequest.GetResponse();
        m_log.Info("get response end");
        StreamReader reader = new StreamReader(myResponse.GetResponseStream(), Encoding.UTF8);
        string content = reader.ReadToEnd();
        m_log.Info("read response end");
        XmlDocument contentDoc = new XmlDocument();
        contentDoc.LoadXml(content);
        m_log.Info("load response xml end");
   
        //Create an XmlNamespaceManager for resolving namespaces.
        XmlNamespaceManager nsmgr = new XmlNamespaceManager(contentDoc.NameTable);
        nsmgr.AddNamespace("autn", "http://schemas.autonomy.com/aci/");

        //Select the book node with the matching attribute value.
        XmlNodeList clusters = contentDoc.SelectNodes("autnresponse/responsedata/autn:clusters/autn:cluster", nsmgr);

        string nodeId;
        int nodeTop;
        int nodeLeft;
        string nodeTitleId;
        string nodeTitle;
        
        int clusterNum = 0;
        StringBuilder html = new StringBuilder();

        foreach (XmlNode cluster in clusters)
        {
            nodeId = "clusternode_" + clusterNum.ToString();
            nodeTitleId = "clustertitle_" + clusterNum.ToString();
            nodeTitle = cluster.SelectSingleNode("autn:title", nsmgr).InnerText;
            nodeLeft = (int)Math.Ceiling(int.Parse(cluster.SelectSingleNode("autn:x_coord", nsmgr).InnerText) * 0.47) + 515;
            nodeTop = (int)Math.Ceiling(int.Parse(cluster.SelectSingleNode("autn:y_coord", nsmgr).InnerText) * 0.47) + 45;

            html.AppendFormat("<div class=\"node\" id=\"{0}\" style=\"border: 1px solid rgb(0, 0, 0); position: absolute; z-index: 2; background-color: rgb(255, 0, 0); font-size: 1px; width: 4px; height: 4px; visibility: visible; top: {1}px; left: {2}px;\" ></div>", nodeId, nodeTop, nodeLeft);
            html.AppendFormat("<div class=\"node_text\" id=\"{0}\" style=\"position: absolute; z-index: 3; top: {1}px; left: {2}px;\" >", nodeTitleId, nodeTop - 5, nodeLeft + 10);
            html.Append("<table cellpadding=\"3\"><tr>");
            html.Append("<td nowrap=\"nowrap\" style=\"background-color:#FFFF00;color:#000000;border:solid #000000 1px;font-size:9pt;font-family:sans-serif\">");
            html.AppendFormat("<b>{0}</b><br/>50 documents</td></tr></table></div>", nodeTitle);
            
            clusterNum++;
        }
        m_log.Info("get hotpoint end");
        context.Response.Write(html);
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}