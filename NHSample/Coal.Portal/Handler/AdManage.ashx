<%@ WebHandler Language="C#" Class="AdManage" %>

using System;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using Coal.DAL;
using Coal.Util;

public class AdManage : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        string action = context.Request.Form["action"];
        if (!string.IsNullOrEmpty(action) && action == "Search")
        {
            string PositionId = context.Request.Form["PositionId"]; 
            ResultObject ro = new ResultObject();
            if (!string.IsNullOrEmpty(PositionId))
            {
                SqlHelper sqlhelp = new SqlHelper("cheese");
                string StrSql = "select * from AdList as A, AdPosition as B where A.PositionId=" + PositionId + " and A.PositionId=B.PositionId";
                StrSql += " and A.IsOpen=1 and A.StartTime<='" + DateTime.Now.ToString() + "' and A.EndTime>='" + DateTime.Now.ToString() + "'";
                DataSet ds = sqlhelp.ExecuteDateSet(StrSql, null);
                if (ds != null && ds.Tables.Count > 0)
                {
                    DataTable dt = ds.Tables[0];                    
                    ro = DataUtility.ConvertToResultObject(dt);
                }
            }
            context.Response.Write(ro.ToJSONString());
            context.Response.End();
        }
        if (!string.IsNullOrEmpty(action) && action == "Browse")
        {
            string AdId = context.Request.Form["AdId"];
            AdListEntity.AdListDAO Dao = new AdListEntity.AdListDAO();
            AdListEntity entity = Dao.FindById(EConvert.ToLong(AdId));
            Dao.UpdateSet(EConvert.ToInt(AdId), "ClickNum", (entity.ClickNum.Value + 1).ToString());
        }
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}