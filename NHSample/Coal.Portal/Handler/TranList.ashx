<%@ WebHandler Language="C#" Class="TranList" %>

using System;
using System.Web;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using Coal.BLL;
using Coal.Util;

public class TranList : IHttpHandler 
{   
    public void ProcessRequest (HttpContext context) 
    {
        int pageIndex = EConvert.ToInt(context.Request.Form["page_index"]);
        int pageSize = EConvert.ToInt(context.Request.Form["page_size"]);
        int City = EConvert.ToInt(context.Request.Form["City"]);
        int coalType = EConvert.ToInt(context.Request.Form["coal_type"]);
        int grainSize = EConvert.ToInt(context.Request.Form["grain_size"]);
        int volatility = EConvert.ToInt(context.Request.Form["volatility"]);
        int ashContent = EConvert.ToInt(context.Request.Form["ash_content"]);
        int surfurContent = EConvert.ToInt(context.Request.Form["surfur_content"]);
        int waterContent = EConvert.ToInt(context.Request.Form["water_content"]);
        int calorificPower = EConvert.ToInt(context.Request.Form["calorific_power"]);
                
        StringBuilder whereCluase = new StringBuilder();
        List<SqlParameter> paramList = new List<SqlParameter>();

        if (City > 0)
        {
            BuildWhereClause("City", City, whereCluase, paramList);
        }

        if (coalType > 0)
        {
            BuildWhereClause("coalType", coalType, whereCluase, paramList);
        }

        if (grainSize > 0)
        {
            BuildWhereClause("grainSize", grainSize, whereCluase, paramList);
        }

        if (volatility > 0)
        {
            BuildWhereClause("volatility", volatility, whereCluase, paramList);
        }

        if (ashContent > 0)
        {
            BuildWhereClause("ashContent", ashContent, whereCluase, paramList);
        }

        if (surfurContent > 0)
        {
            BuildWhereClause("surfurContent", surfurContent, whereCluase, paramList);
        }

        if (waterContent > 0)
        {
            BuildWhereClause("waterContent", waterContent, whereCluase, paramList);
        }

        if (calorificPower > 0)
        {
            BuildWhereClause("calorificPower", calorificPower, whereCluase, paramList);
        }
        
        TransListManager manager = new TransListManager();
        int rowCount = 0;
        DataTable dt = manager.GetList(whereCluase.ToString(), paramList.ToArray(), pageSize, pageIndex, ref rowCount);

        if ((dt != null) && (dt.Rows.Count > 0))
        {
            ResultObject ro = DataUtility.ConvertToResultObject(dt);
            ro["totalCount"] = rowCount;

            if (rowCount % pageSize == 0)
            {
                ro["pageCount"] = rowCount / pageSize;
            }
            else
            {
                ro["pageCount"] = rowCount / pageSize + 1;
            }

            //线程休眠500毫秒，为了看ajax的效果
            System.Threading.Thread.Sleep(500);
            context.Response.Clear();
            context.Response.Write(ro.ToJSONString());
            context.Response.End();
        }
        else
        {
            ResultObject ro = new ResultObject();
            context.Response.Write(ro.ToJSONString());
            context.Response.End();
        }
    }
 
    public bool IsReusable 
    {
        get 
        {
            return false;
        }
    }
    
    private void BuildWhereClause(string fieldName, object value, StringBuilder whereClause, List<SqlParameter> paramList)
    {
        if (whereClause.Length > 0)
        {
            whereClause.Append(" and ");
        }

        whereClause.AppendFormat("{0} ="+value.ToString(),fieldName,fieldName);
        paramList.Add(new SqlParameter(fieldName, value));
    }
}