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
        string rangDate = context.Request.QueryString["RangeDate"];
        string sort = context.Request.QueryString["sort"];
        int start;
        int queryType;
        if (context.Request.QueryString["start"] != null && int.TryParse(context.Request.QueryString["start"].ToString(), out start)
            && context.Request.QueryString["query_type"] != null && int.TryParse(context.Request.QueryString["query_type"].ToString(), out queryType))
        {
            //定义时间宽度
            string rangStr = string.Empty;
            if (rangDate != "undefined")
            {
                int addDays = (-1) * Convert.ToInt32(rangDate);
                rangStr = DateTime.Now.AddDays(addDays).ToString("dd/MM/yyyy");
                rangStr = rangStr.Replace("-", "/");
            }
            //定义搜索条件
            string sortStr = getSortStr(sort);
            //获取查询分类query
            Query query = QueryFactory.GetQuery((QueryType)Enum.Parse(typeof(QueryType), queryType.ToString()));
            query.QueryParam = keyword;
            query.Start = start;
            query.dateStr = rangStr;
            query.sortStr = sortStr;
            string queryResult = query.DoQuery();
            context.Response.ContentType = "text/plain";
            context.Response.Write(queryResult);
        }
    }
    /// <summary>
    /// 获取排序字符串
    /// </summary>
    /// <param name="sort">筛选条件</param>
    /// <returns></returns>
    private string getSortStr(string sort)
    {
        string sortStr = string.Empty;
        switch (sort)
        { 
            case "1":
                sortStr = "Relevance";
                break;
            case "2":
                sortStr = "MYDATE:decreasing";
                break;
            default:
                sortStr = "Relevance";
                break;
        }
        return sortStr;
    }
    public bool IsReusable 
    {
        get {
            return false;
        }
    }
}
