<%@ WebHandler Language="C#" Class="SearchResult" %>

using System;
using System.Web;
using System.Net;
using System.IO;
using System.Xml;
using System.Text;
using System.Configuration;
using Newtonsoft.Json;
using Autonomy.Demo.Bll;

public class SearchResult : IHttpHandler 
{
    public void ProcessRequest (HttpContext context) 
    {
        string actUrl = string.Empty;
        string keyword = context.Request.QueryString["keyword"];
        int start;
        int queryType;
        if (context.Request.QueryString["start"] != null && int.TryParse(context.Request.QueryString["start"].ToString(), out start)
            && context.Request.QueryString["query_type"] != null && int.TryParse(context.Request.QueryString["query_type"].ToString(), out queryType))
        {
            Query query = QueryFactory.GetQuery((QueryType)Enum.Parse(typeof(QueryType), queryType.ToString()));
            query.QueryParam = keyword;
            query.Start = start;
            string queryResult = query.DoQuery();
            context.Response.ContentType = "text/plain";
            context.Response.Write(queryResult);
        }
    }
 
    public bool IsReusable 
    {
        get {
            return false;
        }
    }
}
