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
            string StrWhere = " embracer="+GetUserId(context.Request.Cookies["login_info"].Value.ToString()).ToString();
            int see = Convert.ToInt32(context.Request.Form["see"]);
            if (see == 0 || see == 1)
            {
                StrWhere += " and IsSee=" + see;
            }

            CompanyMessageEntity.CompanyMessageInfoDao Dao = new CompanyMessageEntity.CompanyMessageInfoDao();
            DataTable dt = Dao.GetMessageTable(StrWhere, null);
            if (dt != null && dt.Rows.Count > 0)
            {
                ResultObject ro = DataUtility.ConvertToResultObject(dt);
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

}