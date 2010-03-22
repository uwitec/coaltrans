<%@ WebHandler Language="C#" Class="getSubjectMenu" %>

using System;
using System.Web;
using System.Text;
using System.Xml;
using System.Net;
using System.IO;
using System.Configuration;

public class getSubjectMenu : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(ConfigurationManager.AppSettings["IdolACIPort"] + "/action=CategoryGetHierDetails&expand=all&Category = 0");
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
        XmlNodeList childs = contentDoc.SelectNodes("autnresponse/responsedata/autn:category/autn:children/autn:child", nsmgr);

        StringBuilder categoryList = new StringBuilder();
        categoryList.Append("[");
        int count = 1;
        foreach (XmlNode node in childs)
        {
            categoryList.Append("{");
            categoryList.Append("\"CategoryId\":");
            categoryList.Append("\"" + node.ChildNodes[0].InnerText + "\",");
            categoryList.Append("\"CategoryName\":");
            categoryList.Append("\"" + node.ChildNodes[1].InnerText + "\"");
            categoryList.Append("}");
            if (count < childs.Count)
                categoryList.Append(",");
            count++;
        }
        categoryList.Append("]");
        context.Response.Write(categoryList.ToString());
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}