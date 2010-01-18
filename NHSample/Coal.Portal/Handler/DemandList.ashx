<%@ WebHandler Language="C#" Class="DemandList" %>


using System;
using System.Web;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using Coal.BLL;
using Coal.Util;

public class DemandList : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {

        int PageIndex = EConvert.ToInt(context.Request.Form["page_index"]);
        int pageSize = EConvert.ToInt(context.Request.Form["page_size"]);
        int DeliveryPlace = EConvert.ToInt(context.Request.Form["DeliveryPlace"]);

        List<SqlParameter> paramList = new List<SqlParameter>();
        string StrWhere = "";
        if (DeliveryPlace > 0)
        {
            StrWhere = "DeliveryPlace like '" + DeliveryPlace.ToString() + "&%'";
        }

        TransListManager manager = new TransListManager();
        int rowcount = 0;
        DataTable dt = manager.GetDemandList(StrWhere, paramList.ToArray(), pageSize,PageIndex, ref rowcount);

        if ((dt != null) && (dt.Rows.Count > 0))
        {
            ResultObject ro = DataUtility.ConvertToResultObject(dt);
            ro["totalCount"] = rowcount;

            if (rowcount % pageSize == 0)
            {
                ro["pageCount"] = rowcount / pageSize;
            }
            else
            {
                ro["pageCount"] = rowcount / pageSize + 1;
            }

            System.Threading.Thread.Sleep(500);
            context.Response.Clear();
            context.Response.Write(ro.ToJSONString());
            context.Response.End();
        }
        else
        {
            ResultObject ro = new ResultObject();
            context.Response.Clear();
            context.Response.Write(ro.ToJSONString());
            context.Response.End();
        }
        
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}