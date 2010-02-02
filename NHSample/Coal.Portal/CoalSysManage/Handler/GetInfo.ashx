<%@ WebHandler Language="C#" Class="GetInfo" %>

using System;
using System.Web;
using System.Data;
using Coal.DAL;
using Coal.Util;

public class GetInfo : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        string TableName1 = context.Request.Form["TableName1"];
        string TableName2 = context.Request.Form["TableName2"];
        string PrimaryKey = context.Request.Form["PrimaryKey"];
        string ForeignKey = context.Request.Form["foreignkey"];
        string value = context.Request.Form["value"];
        ResultObject ro = new ResultObject();
        if (!string.IsNullOrEmpty(TableName1) && !string.IsNullOrEmpty(PrimaryKey))
        {
            if (TableName2 != null && TableName2 != "")
            {
                SqlHelper sqlhelp = new SqlHelper("cheese");
                string StrSql = "select * from " + TableName1 + " as A,"+TableName2+" as B where A." + PrimaryKey + "=" + value+" and A."+ForeignKey+"=B."+ForeignKey;
                DataSet ds = sqlhelp.ExecuteDateSet(StrSql, null);
                if (ds != null && ds.Tables.Count > 0)
                {
                    DataTable dt = ds.Tables[0];
                    ro = DataUtility.ConvertToResultObject(dt);
                }
            }
            else
            {
                SqlHelper sqlhelp = new SqlHelper("cheese");
                string StrSql = "select * from " + TableName1 + " where " + PrimaryKey + "=" + value;
                DataSet ds = sqlhelp.ExecuteDateSet(StrSql, null);
                if (ds != null && ds.Tables.Count > 0)
                {
                    DataTable dt = ds.Tables[0];
                    ro = DataUtility.ConvertToResultObject(dt);
                }
            }        
        }
        context.Response.Write(ro.ToJSONString());
        context.Response.End();
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}