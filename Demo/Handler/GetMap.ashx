<%@ WebHandler Language="C#" Class="GetMap" %>

using System;
using System.Web;
using System.Net;
using System.IO;
using System.Text;
using System.Configuration;

public class GetMap : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) 
    {
        string get2DMapUrl = ConfigurationManager.AppSettings["IdolACIPort"] + "/action=clusterserve2dmap&sourcejobname=myjob_clusters";

        HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(get2DMapUrl);
        myRequest.Method = "GET";
        myRequest.ContentType = "image/gif";

        // Get response
        HttpWebResponse myResponse = (HttpWebResponse)myRequest.GetResponse();
        StreamReader reader = new StreamReader(myResponse.GetResponseStream(), Encoding.UTF8);

        System.Collections.Generic.List<byte> result = new System.Collections.Generic.List<byte>();
        while (reader.Peek() >= 0)
        {
            result.Add((byte)reader.Read());
        }
        
        using (MemoryStream ms = new MemoryStream())
        {
            context.Response.ClearContent();//清楚缓冲区的流
            context.Response.ContentType = "image/gif";//配置输出类型
            context.Response.BinaryWrite(result.ToArray());//输出内容 
        }
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}