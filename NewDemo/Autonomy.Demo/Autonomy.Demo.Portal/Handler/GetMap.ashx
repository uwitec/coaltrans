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
        string connectionString = @"data source=.;database=Coal;User ID=sa;Password=lib";

        using (System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(connectionString))
        {
            connection.Open();
            using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand())
            {
                cmd.CommandText = "select top 1 map_image from map_image";
                cmd.Connection = connection;
                byte[] barrImg = (byte[])cmd.ExecuteScalar();

                string strfn = Convert.ToString(DateTime.Now.ToFileTime());
                FileStream fs = new FileStream(@"E:\music",FileMode.CreateNew,FileAccess.Write);
                fs.Write(barrImg, 0, barrImg.Length);
                fs.Flush();
                fs.Close();

                //context.Response.ClearContent();//清楚缓冲区的流
                //context.Response.ContentType = "image/gif";//配置输出类型
                //context.Response.BinaryWrite(barrImg);//输出内容 
            }
        }
        
        //string get2DMapUrl = ConfigurationManager.AppSettings["IdolACIPort"] + "/action=clusterserve2dmap&sourcejobname=myjob_clusters";

        //HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(get2DMapUrl);
        //myRequest.Method = "GET";
        //myRequest.ContentType = "image/gif";

        //// Get response
        //HttpWebResponse myResponse = (HttpWebResponse)myRequest.GetResponse();
        //StreamReader reader = new StreamReader(myResponse.GetResponseStream(), Encoding.UTF8);

        //System.Collections.Generic.List<byte> result = new System.Collections.Generic.List<byte>();
        //while (reader.Peek() >= 0)
        //{
        //    result.Add((byte)reader.Read());
        //}
        
        //using (MemoryStream ms = new MemoryStream())
        //{
        //    context.Response.ClearContent();//清楚缓冲区的流
        //    context.Response.ContentType = "image/gif";//配置输出类型
        //    context.Response.BinaryWrite(result.ToArray());//输出内容 
        //}
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}