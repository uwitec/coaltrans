<%@ WebHandler Language="C#" Class="GetMapData" %>

using System;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Net;
using System.IO;
using System.Text;
using System.Xml;
using System.Configuration;
using log4net;
using Autonomy.Demo.Dal;

public class GetMapData : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) 
    {       

        string mapTimeId = string.Empty;
        string selectIndex = string.Empty;
        string dateTimeStr = System.DateTime.Now.ToString("yyyy-MM-dd");
        string strWhere = " MapTimeId in ( select top(1) ClusterTimeId from Cluster2DMap order by MapId DESC )";

        if (!string.IsNullOrEmpty(context.Request["date_time"]))
        {
            dateTimeStr = context.Request["date_time"];
        }
        
        if (!string.IsNullOrEmpty(context.Request["map_time_id"]))
        {
            mapTimeId = context.Request["map_time_id"];
            if (!string.IsNullOrEmpty(context.Request["select_index"]))
            {
                selectIndex = context.Request["select_index"];
            }
            switch (selectIndex)
            {
                case "self":
                    strWhere = " MapTimeId=" + mapTimeId;
                    break;
                case "prev":
                    strWhere = " MapTimeId=(select PreClusterTimeId from Cluster2DMap where ClusterTimeId=" + mapTimeId + ")";
                    dateTimeStr = Convert.ToDateTime(dateTimeStr).AddDays(-1).ToString("yyyy-MM-dd");
                    break;
                case "next":
                    strWhere = " MapTimeId=(select ClusterTimeId from Cluster2DMap where PreClusterTimeId=" + mapTimeId + ")";
                    dateTimeStr = Convert.ToDateTime(dateTimeStr).AddDays(1).ToString("yyyy-MM-dd");
                    break;
                default:
                    break;
            }        
        }        
     
        Cluster2DPointEntity.Cluster2DPointDAO Dao = new Cluster2DPointEntity.Cluster2DPointDAO();
        IList<Cluster2DPointEntity> clusterEntityList = Dao.Find(strWhere, null);

        string nodeId;
        int nodeTop;
        int nodeLeft;
        string nodeTitleId;
        string nodeTitle;
        
        int clusterNum = 0;
        StringBuilder html = new StringBuilder();
        if (clusterEntityList.Count > 0)
        {
            foreach (Cluster2DPointEntity entity in clusterEntityList)
            {
                nodeId = "clusternode_" + clusterNum.ToString();
                nodeTitleId = "clustertitle_" + clusterNum.ToString();
                nodeTitle = entity.ClusterTitle;
                nodeLeft = (int)Math.Ceiling(entity.ClusterX.Value * 0.68) + 165;
                nodeTop = (int)Math.Ceiling(entity.ClusterY.Value * 0.68) + 250;

                html.AppendFormat("<div class=\"node\" id=\"{0}\" style=\"border: 1px solid rgb(0, 0, 0); position: absolute; z-index: 2; background-color: rgb(255, 0, 0); font-size: 1px; width: 8px; height: 8px; visibility: visible; top: {1}px; left: {2}px; cursor:pointer;\" ></div>", nodeId, nodeTop, nodeLeft);
                html.AppendFormat("<div class=\"node_text\" id=\"{0}\" style=\"position: absolute; z-index: 3; top: {1}px; left: {2}px;\" >", nodeTitleId, nodeTop - 5, nodeLeft + 10);
                html.Append("<table cellpadding=\"3\"><tr>");
                html.Append("<td nowrap=\"nowrap\" style=\"background-color:#FFFF00;color:#000000;border:solid #000000 1px;font-size:9pt;font-family:sans-serif\">");
                html.AppendFormat("<b>{0}</b><br/>50 documents</td></tr></table></div>", nodeTitle);

                if (clusterNum == clusterEntityList.Count - 1)
                {
                    html.Append("※" + entity.MapTimeId.Value);
                }
                clusterNum++;

            }
        }
        else
        {
            html.Append("※" + mapTimeId);
        }
        html.Append("※" + dateTimeStr);
        context.Response.Write(html);

        #region "以前的代码"
        //ILog m_log = LogManager.GetLogger("GetMapData");
        //string actUrl = ConfigurationManager.AppSettings["IdolACIPort"] + "/action=ClusterResults&SourceJobname=myjob_clusters&MaxTerms=0&NumResults=0";
        //HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(actUrl);
        //myRequest.Method = "GET";
        //myRequest.ContentType = "application/x-www-form-urlencoded";

        //m_log.Error("0");
        //HttpWebResponse myResponse = (HttpWebResponse)myRequest.GetResponse();
        //m_log.Error("1");
        //StreamReader reader = new StreamReader(myResponse.GetResponseStream(), Encoding.UTF8);
        //m_log.Error("2");
        //string content = reader.ReadToEnd();
        //m_log.Error("3");
        //XmlDocument contentDoc = new XmlDocument();
        //contentDoc.LoadXml(content);
        //m_log.Error("4");
   
        //Create an XmlNamespaceManager for resolving namespaces.
        //XmlNamespaceManager nsmgr = new XmlNamespaceManager(contentDoc.NameTable);
        //nsmgr.AddNamespace("autn", "http://schemas.autonomy.com/aci/");

        
        ////Select the book node with the matching attribute value.
        //XmlNodeList clusters = contentDoc.SelectNodes("autnresponse/responsedata/autn:clusters/autn:cluster", nsmgr);

        //string nodeId;
        //int nodeTop;
        //int nodeLeft;
        //string nodeTitleId;
        //string nodeTitle;
        
        //int clusterNum = 0;
        //StringBuilder html = new StringBuilder();

        //foreach (XmlNode cluster in clusters)
        //{
        //    nodeId = "clusternode_" + clusterNum.ToString();
        //    nodeTitleId = "clustertitle_" + clusterNum.ToString();
        //    nodeTitle = cluster.SelectSingleNode("autn:title", nsmgr).InnerText;
        //    nodeLeft = (int)Math.Ceiling(int.Parse(cluster.SelectSingleNode("autn:x_coord", nsmgr).InnerText) * 0.68) + 165;
        //    nodeTop = (int)Math.Ceiling(int.Parse(cluster.SelectSingleNode("autn:y_coord", nsmgr).InnerText) * 0.68) + 250;

        //    html.AppendFormat("<div class=\"node\" id=\"{0}\" style=\"border: 1px solid rgb(0, 0, 0); position: absolute; z-index: 2; background-color: rgb(255, 0, 0); font-size: 1px; width: 8px; height: 8px; visibility: visible; top: {1}px; left: {2}px; cursor:pointer;\" ></div>", nodeId, nodeTop, nodeLeft);
        //    html.AppendFormat("<div class=\"node_text\" id=\"{0}\" style=\"position: absolute; z-index: 3; top: {1}px; left: {2}px;\" >", nodeTitleId, nodeTop - 5, nodeLeft + 10);
        //    html.Append("<table cellpadding=\"3\"><tr>");
        //    html.Append("<td nowrap=\"nowrap\" style=\"background-color:#FFFF00;color:#000000;border:solid #000000 1px;font-size:9pt;font-family:sans-serif\">");
        //    html.AppendFormat("<b>{0}</b><br/>50 documents</td></tr></table></div>", nodeTitle);
            
        //    clusterNum++;
        //}
        //m_log.Info("get hotpoint end");
        //context.Response.Write(html);
        #endregion

    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }
}