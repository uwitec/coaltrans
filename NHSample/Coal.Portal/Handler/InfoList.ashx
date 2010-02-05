<%@ WebHandler Language="C#" Class="InfoList" %>

using System;
using System.Web;
using System.Collections;
using System.Collections.Generic;
using Coal.DAL;
using Coal.Util;
using System.Data;

public class InfoList : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        int top = EConvert.ToInt(context.Request.Form["top"]);
        string TableName = context.Request.Form["TableName"];
        string StrWhere = context.Request.Form["StrWhere"];
        string OrderBy = context.Request.Form["OrderBy"];
        SqlHelper sqlhelp = new SqlHelper("cheese");
        DataTable dt = sqlhelp.GetTableByTop(top, TableName, StrWhere, OrderBy);
        ResultObject ro = new ResultObject();
        if (dt != null && dt.Rows.Count > 0)
        {            
            ro = DataUtility.ConvertToResultObject(dt);            
        }
        context.Response.Clear();
        context.Response.Write(ro.ToJSONString());
        context.Response.End();
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}