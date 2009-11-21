<%@ WebHandler Language="C#" Class="LatestList" %>

using System;
using System.Web;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using Coal.BLL;
using Coal.Util;

public class LatestList : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {

        int coalType = EConvert.ToInt(context.Request.Form["coal_type"]);
        int tranType = EConvert.ToInt(context.Request.Form["tran_type"]);

        StringBuilder whereCluase = new StringBuilder();
        List<SqlParameter> paramList = new List<SqlParameter>();
        
        if (coalType > 0)
        {
            BuildWhereClause("CoalType", coalType, whereCluase, paramList);
        }

        if (tranType > 0)
        {
            BuildWhereClause("TransType", tranType, whereCluase, paramList);
        }
        
        TransListManager manager = new TransListManager();
        DataTable dt = manager.GetLastestList(whereCluase.ToString(), 6, " id desc ", paramList.ToArray());

        if (dt != null)
        {
            ResultObject ro = DataUtility.ConvertToResultObject(dt);
            context.Response.Clear();
            context.Response.Write(ro.ToJSONString());
            context.Response.End();
        }
    }

    private void BuildWhereClause(string fieldName, object value, StringBuilder whereClause, List<SqlParameter> paramList)
    {
        if (whereClause.Length > 0)
        {
            whereClause.Append(" and ");
        }

        whereClause.AppendFormat("{0} = @{1}", fieldName, fieldName);
        paramList.Add(new SqlParameter(fieldName, value));
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}