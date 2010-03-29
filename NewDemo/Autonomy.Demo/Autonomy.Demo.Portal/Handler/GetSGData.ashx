<%@ WebHandler Language="C#" Class="GetSGData" %>

using System;
using System.Web;
using System.Net;
using System.IO;
using System.Text;
using System.Xml;
using System.Configuration;
using log4net;
using Autonomy.Demo.Dal;

public class GetSGData : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) 
    {
        ILog m_log = LogManager.GetLogger("GetMapData");
        string actUrl = ConfigurationManager.AppSettings["IdolACIPort"] + "/action=ClusterSGDataServe&SourceJobname=myjob_sg&StructuredXML=true";
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
        XmlNodeList clusters = contentDoc.SelectNodes("autnresponse/responsedata/autn:clusters/autn:cluster", nsmgr);

        string nodeId;
        int nodeOneTop;
        int nodeOneLeft;
        int nodeTwoTop;
        int nodeTwoLeft;
        string nodeTitleId;
        string nodeTitle;
        string pointId;

        int clusterNum = 0;
        StringBuilder html = new StringBuilder();

        foreach (XmlNode cluster in clusters)
        {
            float radius = float.Parse(cluster.SelectSingleNode("autn:radius_from", nsmgr).InnerText);
        
            //radius 实际代表数据的密度，密度大于4，才显示
            if (radius > 4f)
            {
                nodeId = "clusternode_" + clusterNum.ToString();
                nodeTitleId = "clustertitle_" + clusterNum.ToString();
                nodeTitle = cluster.SelectSingleNode("autn:title", nsmgr).InnerText;
                int numDocs = int.Parse(cluster.SelectSingleNode("autn:numdocs", nsmgr).InnerText);
                pointId = cluster.ChildNodes[0].InnerText + "※" + cluster.SelectSingleNode("autn:fromdate", nsmgr).InnerText + "※" + cluster.SelectSingleNode("autn:todate", nsmgr).InnerText;
                //TO DO: 换算成日期格式
                long fromDate = long.Parse(cluster.SelectSingleNode("autn:fromdate", nsmgr).InnerText);
                long toDate = long.Parse(cluster.SelectSingleNode("autn:todate", nsmgr).InnerText);
                
                nodeOneLeft = (int)Math.Ceiling(int.Parse(cluster.SelectSingleNode("autn:x1", nsmgr).InnerText) * 0.66) + 165;
                nodeOneTop = (int)Math.Ceiling(int.Parse(cluster.SelectSingleNode("autn:y1", nsmgr).InnerText) * 0.68) + 250;
                nodeTwoLeft = (int)Math.Ceiling(int.Parse(cluster.SelectSingleNode("autn:x2", nsmgr).InnerText) * 0.66) + 165;
                nodeTwoTop = (int)Math.Ceiling(int.Parse(cluster.SelectSingleNode("autn:y2", nsmgr).InnerText) * 0.68) + 250;
                int width = nodeTwoLeft - nodeOneLeft;

                html.AppendFormat("<div class=\"node\" id=\"{0}\"  style=\"position: absolute; z-index: 2; font-size: 1px; width: {3}px; height: 10px; top: {1}px; left: {2}px; cursor:pointer;\" pid=\"{4}\" ></div>", nodeId, nodeOneTop, nodeOneLeft, width, pointId);
                html.AppendFormat("<div class=\"node_text\" id=\"{0}\" style=\"position: absolute; z-index: 3; top: {1}px; left: {2}px;\" >", nodeTitleId, nodeOneTop - 5, nodeOneLeft + 30);
                html.Append("<table cellpadding=\"3\"><tr>");
                html.Append("<td nowrap=\"nowrap\" style=\"background-color:#FFFF00;color:#000000;border:solid #000000 1px;font-size:9pt;font-family:sans-serif\">");
                html.AppendFormat("<b>{0}</b><br/>{1} 篇文章 日期：从{2}到{3}</td></tr></table></div>", nodeTitle, numDocs,fromDate,toDate);

                clusterNum++;
            }
        }

        context.Response.Write(html);   
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}