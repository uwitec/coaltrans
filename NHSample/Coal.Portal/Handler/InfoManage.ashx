<%@ WebHandler Language="C#" Class="InfoManage" %>

using System;
using System.Web;
using Coal.Util;
using Coal.DAL;

public class InfoManage : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {

        if (LoginContext.CurrentUser != null)
        {
            string action = context.Request.Form["action"];
            switch (action)
            {
                case "InviteInfo":
                    break;
                case "TenderInfo":
                    AddOrUpdateTenderInfo(context);
                    break;
                default:
                    break;
            }            
        }
        else
        {
            context.Response.Redirect("../login.aspx");
        }
    }
    /// <summary>
    /// 对投标信息就行增添或修改
    /// </summary>
    private void AddOrUpdateTenderInfo(HttpContext context)
    {
        TenderInfoEntity entity = new TenderInfoEntity();        
        entity.TenderTitle = Common.FiltrationMaliciousCode(context.Request.Form["txtTenderTitle"]);
        entity.StartTime = Convert.ToDateTime(context.Request.Form["txtStartTime"]);
        entity.EndTime = Convert.ToDateTime(context.Request.Form["txtEndTime"]);
        entity.Details =Common.UnEscape(context.Request.Form["txtDetails"]);
        entity.ViewCount = 0;
        entity.IsAudit = 0;
        entity.RankNum = 9999;
        entity.CreateTime = DateTime.Now;
        entity.UserId = LoginContext.CurrentUser.UserId;
        entity.AdjunctUrl = Common.UploadFile(Common.UnEscape(context.Request.Form["txtAdjunctUrl"]));        
        ResultObject ro=new ResultObject();
        if (AddOrUpdateTender(entity))
        {
            ro.StatusCode = 1;
        }
        else
        {
            ro.StatusCode = -1;
            ro.ErrorCode = 1;
        }

        context.Response.Write(ro.ToJSONString());
        context.Response.End();
    }
    public bool IsReusable {
        get {
            return false;
        }
    }
    private bool AddOrUpdateTender(TenderInfoEntity entity)
    {
        bool Flag = true;
        TenderInfoEntity.TenderInfoDAO DAO = new TenderInfoEntity.TenderInfoDAO();
        if (entity.ID > 0)
        {
            try
            {
                DAO.Update(entity);
            }
            catch
            {
                Flag = false;
            }
        }
        else
        {
            try
            {
                DAO.Add(entity);
            }
            catch
            {
                Flag = false;
            }
        }
        return Flag;
    }
}