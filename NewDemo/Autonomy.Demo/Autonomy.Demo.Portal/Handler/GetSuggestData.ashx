<%@ WebHandler Language="C#" Class="GetSuggestData" %>

using System;
using System.Xml;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Net;
using System.IO;
using System.Text;
using System.Configuration;

public class GetSuggestData : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) 
    {
        string _DocId = context.Request["DocId"];
        string GetSuggestUrl = string.Empty;
        string GetContentUrl = string.Empty;

        if (!string.IsNullOrEmpty(_DocId))
        {
            GetSuggestUrl = ConfigurationManager.AppSettings["IdolACIPort"].ToString() + "/action=Suggest&ID=" + _DocId;
            GetContentUrl = ConfigurationManager.AppSettings["IdolACIPort"].ToString() + "/action=Query&Text=*&MatchId=" + _DocId;
        }
        else
        {
            context.Response.Write("无效的参数");
            context.Response.End();
        }
        
        //获取Requst
        XmlDocument contentDoc = GetXmlDocument(GetSuggestUrl);
        XmlDocument ImgCenterDoc = GetXmlDocument(GetContentUrl);
        //获取XML文档
        StringBuilder XmlStr = new StringBuilder();
        StringBuilder XmlImgcenter = new StringBuilder();
        XmlStr.Append("<?xml version=\"1.0\" encoding=\"utf-8\" ?>");
        XmlStr.Append("<root>");
        //获取其他节点数据
        XmlNodeList NodeHits = contentDoc.SelectNodes("autnresponse/responsedata")[0].ChildNodes;
        if (NodeHits.Count > 1)
        {
            XmlStr.Append("<imgs>");
            foreach (XmlNode hit in NodeHits)
            {
                if (hit.ChildNodes.Count > 2)
                {
                    XmlStr.Append("<pic name=\"pic/9180244_m.jpg\" DocId=\"" + hit.ChildNodes[1].InnerText + "\"");
                    XmlStr.Append(" url=\"" + hit.ChildNodes[0].InnerText + "\"");
                    XmlStr.Append(" title=\"" + hit.ChildNodes[6].InnerText + "\"/>");
                }
            }
            XmlStr.Append("</imgs>");
        }
        //获取中心节点数据
        XmlNodeList ContentNodeHits = ImgCenterDoc.SelectNodes("autnresponse/responsedata")[0].ChildNodes;
        if (ContentNodeHits.Count > 1)
        {
            foreach (XmlNode hit in ContentNodeHits)
            {
                if (hit.ChildNodes.Count > 2)
                {
                    XmlImgcenter.Append("<imgcenter url=\"" + hit.ChildNodes[0].InnerText + "\" src=\"pic/200.jpg\"");
                    XmlImgcenter.Append(" picname=\"每的加湿器\"  pingfen=\"5\"  content=\"加湿器，净化空气，味道好极了，加油欧文，目标就能实现...\"");
                    XmlImgcenter.Append(" discount=\"折扣：55折 节省：￥13.00\" buyURL=\"http://product.dangdang.com/product.aspx?product_id=9170628\"");
                    XmlImgcenter.Append(" zanURL=\"http://product.dangdang.com/product.aspx?product_id=20195309\" sale=\"28.80\" ddsale=\"15.80\"></imgcenter>");
                }
            }
        }
        //拼接Xml字符串         
        XmlStr.Append(XmlImgcenter.ToString());
        XmlStr.Append("</root>");
        context.Response.Write(XmlStr.ToString());
    }
 
    public bool IsReusable 
    {
        get {
            return false;
        }
    }

    /// <summary>
    /// 获取XmlDocument
    /// </summary>
    /// <param name="Url">网页请求连接</param>
    /// <returns></returns>
    private XmlDocument GetXmlDocument(string Url)
    {
        HttpWebRequest Request = (HttpWebRequest)HttpWebRequest.Create(Url);
        Request.Method = "GET";
        Request.ContentType = "application/x-www-form-urlencoded";
        //获取Response
        HttpWebResponse Response = (HttpWebResponse)Request.GetResponse();
        StreamReader reader = new StreamReader(Response.GetResponseStream(), Encoding.UTF8);
        string content = reader.ReadToEnd();
        XmlDocument contentDoc = new XmlDocument();
        contentDoc.LoadXml(content);
        return contentDoc;
    }

}