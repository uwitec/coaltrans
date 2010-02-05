<%@ WebHandler Language="C#" Class="DemandList" %>


using System;
using System.Web;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using Coal.BLL;
using Coal.DAL;
using Coal.Entity;
using Coal.Util;

public class DemandList : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {

        int PageIndex = EConvert.ToInt(context.Request.Form["page_index"]);
        int pageSize = EConvert.ToInt(context.Request.Form["page_size"]);
        int DeliveryPlace = EConvert.ToInt(context.Request.Form["DeliveryPlace"]);

        List<SqlParameter> paramList = new List<SqlParameter>();
        string StrWhere = "IsAudit=1";
        //string StrWhere = "IsAudit=1 and InfoIndate<=" + DateTime.Now.ToString("yyyy-MM-dd");
        if (DeliveryPlace > 0)
        {
            StrWhere = " and DeliveryPlace like '" + DeliveryPlace.ToString() + "&%'";
        }

        TransListManager manager = new TransListManager();
        int rowcount = 0;
        DataTable dt = manager.GetDemandList(StrWhere, paramList.ToArray(), pageSize,PageIndex, ref rowcount);

        if ((dt != null) && (dt.Rows.Count > 0))
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dt.Rows[i]["DeliveryPlace"] = GetArea(dt.Rows[i]["DeliveryPlace"].ToString());
            }
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
    protected string GetArea(string Area)
    {
        string Str = "";
        if (!string.IsNullOrEmpty(Area))
        {
            string[] list = Area.Split('&');
            RegionEntity.RegionDAO Dao = new RegionEntity.RegionDAO();

            foreach (string obj in list)
            {
                RegionEntity entity = Dao.FindById(EConvert.ToLong(obj));
                if (entity != null)
                {
                    Str += entity.Name + "  ";
                }
            }
        }
        return Str;
    }
    public bool IsReusable {
        get {
            return false;
        }
    }

}