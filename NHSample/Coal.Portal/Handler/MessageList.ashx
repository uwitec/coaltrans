<%@ WebHandler Language="C#" Class="MessageList" %>

using System;
using System.Web;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Coal.BLL;
using Coal.DAL;
using Coal.Util;

public class MessageList : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        if (context.Request.Cookies["login_info"]!= null)
        {
            if (context.Request.Form["action"] == "search")
            {
                seardeal(context);
            }
            else if (context.Request.Form["action"] == "delete")
            {
                DelDeal(context);
            }
        }
        else
        {
            context.Response.Redirect("../login.aspx");
        }
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }
    /// <summary>
    /// 获取用户ID
    /// </summary>
    /// <param name="Str">Coocie信息</param>
    /// <returns></returns>
    private int GetUserId(string Str)
    {
        if (Str == "")
        {
            return 0;
        }
        else
        {
            string[] userInfo = CryptoHelper.Decrypt(Str, "coalchina").Split('|');
            return Convert.ToInt32(userInfo[2]);
        }
    }
    private void seardeal(HttpContext context)
    {
        string StrWhere = " embracer=" + GetUserId(context.Request.Cookies["login_info"].Value.ToString()).ToString();
        int pageIndex = EConvert.ToInt(context.Request.Form["page_index"]);
        int pageSize = EConvert.ToInt(context.Request.Form["page_size"]);
        int see = Convert.ToInt32(context.Request.Form["see"]);
        if (see == 0 || see == 1)
        {
            StrWhere += " and IsSee=" + see;
        }
        string StrWhereOther = " embracer=" + GetUserId(context.Request.Cookies["login_info"].Value.ToString()).ToString();
        CompanyMessageEntity.CompanyMessageDAO Dao = new CompanyMessageEntity.CompanyMessageDAO();
        int rowCount = Dao.GetPagerRowsCount(StrWhere, null);
        int TotalCount = Dao.GetPagerRowsCount(StrWhereOther, null);
        int IsSeeCount = Dao.GetPagerRowsCount(StrWhereOther + " and IsSee=1", null);
        int NoSeeCount = Dao.GetPagerRowsCount(StrWhereOther + " and IsSee=0", null);
        DataTable dt = Dao.GetPager(StrWhere, null, "", pageSize, pageIndex);
        if (dt != null && dt.Rows.Count > 0)
        {
            ResultObject ro = DataUtility.ConvertToResultObject(dt);
            ro["totalCount"] = rowCount;
            ro["MsgTotalCount"] = TotalCount;
            ro["MsgIsSeeCount"] = IsSeeCount;
            ro["MsgNoSeeCount"] = NoSeeCount;
            if (rowCount % pageSize == 0)
            {
                ro["pageCount"] = rowCount / pageSize;
            }
            else
            {
                ro["pageCount"] = rowCount / pageSize + 1;
            }
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
    private void DelDeal(HttpContext context)
    {
        int ID = EConvert.ToInt(context.Request.QueryString["ID"]);
        CompanyMessageEntity.CompanyMessageDAO Dao = new CompanyMessageEntity.CompanyMessageDAO();
        CompanyMessageEntity entity = new CompanyMessageEntity();
        entity.ID = ID;
        try
        {
            Dao.Delete(entity);
            context.Response.Write("1");
        }
        catch 
        {
            context.Response.Write("0");
        }
        
    }
}