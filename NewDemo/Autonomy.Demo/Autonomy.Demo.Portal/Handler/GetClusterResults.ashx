<%@ WebHandler Language="C#" Class="GetClusterResults" %>

using System;
using System.Web;
using System.Net;
using System.IO;
using System.Text;
using System.Xml;
using System.Configuration;
using System.Collections.Generic;
using Autonomy.Demo.Dal;

public class GetClusterResults : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) 
    {
        string pointId = context.Request.QueryString["point_id"];

        Autonomy.Demo.Dal.Cluster2DDocEntity.Cluster2DDocDAO docDao = new Autonomy.Demo.Dal.Cluster2DDocEntity.Cluster2DDocDAO();
        System.Data.SqlClient.SqlParameter[] parameters = new System.Data.SqlClient.SqlParameter[1];
        parameters[0] = new System.Data.SqlClient.SqlParameter("@pointId", long.Parse(pointId));
        IList<Autonomy.Demo.Dal.Cluster2DDocEntity> clusterDocList = docDao.Find(" PointId = @pointId", parameters);

        if (clusterDocList != null && clusterDocList.Count > 0)
        {
            StringBuilder html = new StringBuilder();

            for (int index = 0; index < 10; index++)
            {
                Autonomy.Demo.Dal.Cluster2DDocEntity clusterDoc = clusterDocList[index];
                html.Append("<li>");
                html.Append("<h2><a href=\"").Append(clusterDoc.DocRef).Append("\">").Append(clusterDoc.DocTitle).Append("</a></h2>");
                html.Append("</li>");
            }

            context.Response.Write(html.ToString());
        }
        else
        {
            context.Response.Write("该聚类没有数据");
        }
        
        //======old
        //string actionUrl = ConfigurationManager.AppSettings["IdolACIPort"] + "/action=ClusterResults&SourceJobName=myjob_clusters&Cluster=" + clusterId + "&DREOutputEncoding=utf8&NumResults=50&MaxTerms=0";

        //HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(actionUrl);
        //myRequest.Method = "GET";
        //myRequest.ContentType = "application/x-www-form-urlencoded";

        //// Get response
        //HttpWebResponse myResponse = (HttpWebResponse)myRequest.GetResponse();
        //StreamReader reader = new StreamReader(myResponse.GetResponseStream(), Encoding.UTF8);
        //string content = reader.ReadToEnd();
        //XmlDocument contentDoc = new XmlDocument();
        //contentDoc.LoadXml(content);


        ////Create an XmlNamespaceManager for resolving namespaces.
        //XmlNamespaceManager nsmgr = new XmlNamespaceManager(contentDoc.NameTable);
        //nsmgr.AddNamespace("autn", "http://schemas.autonomy.com/aci/");

        ////Select the book node with the matching attribute value.
        //XmlNodeList clusterDocs = contentDoc.SelectNodes("autnresponse/responsedata/autn:clusters/autn:cluster/autn:docs/autn:doc", nsmgr);

        //StringBuilder html = new StringBuilder();
        //string title;
        //string reference;

        ////   foreach (XmlNode clusterDoc in clusterDocs)
        //for (int index = 0; index < 10; index++)
        //{
        //    XmlNode clusterDoc = clusterDocs[index];
        //    title = clusterDoc.SelectSingleNode("autn:title", nsmgr).InnerText;
        //    reference = clusterDoc.SelectSingleNode("autn:ref", nsmgr).InnerText;
        //    html.Append("<li>");
        //    html.Append("<h2><a href=\"").Append(reference).Append("\">").Append(title).Append("</a></h2>");
        //    html.Append("</li>");
        //}
        //=====old
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}