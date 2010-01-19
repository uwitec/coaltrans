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
                    InviteInfoAdd(context);
                    break;
                case "TenderInfo":
                    TenderInfoAdd(context);
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
    /// 对招标信息就行添加
    /// </summary>
    /// <param name="context"></param>
    private void InviteInfoAdd(HttpContext context)
    {
        InviteInfoEntity entity = new InviteInfoEntity();
        entity.InviteTitle = Common.FiltrationMaliciousCode(context.Request.Form["txtInviteTitle"]);
        entity.Region = Convert.ToInt32(context.Request.Form["selRegion"]);
        entity.StartTime = Convert.ToDateTime(context.Request.Form["txtStartTime"]);
        entity.EndTime = Convert.ToDateTime(context.Request.Form["txtEndTime"]);
        entity.Details = Common.UnEscape(context.Request.Form["txtDetails"]);
        entity.ViewCount = 0;
        entity.IsAudit = 0;
        entity.RankNum = 9999;
        entity.CreateTime = DateTime.Now;
        entity.UserId = LoginContext.CurrentUser.UserId;
        entity.AdjunctUrl = Common.UploadFile(Common.UnEscape(context.Request.Form["txtAdjunctUrl"]));
        ResultObject ro = new ResultObject();
        if (AddOrUpdateInvite(entity))
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
    /// <summary>
    /// 对投标信息就行增添
    /// </summary>
    private void TenderInfoAdd(HttpContext context)
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
    /// <summary>
    /// 对投标信息进行增添或修改
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    
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

    private bool AddOrUpdateInvite(InviteInfoEntity entity)
    {
        bool Flag = true;
        InviteInfoEntity.InviteInfoDAO DAO = new InviteInfoEntity.InviteInfoDAO();
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