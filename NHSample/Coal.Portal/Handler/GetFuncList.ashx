<%@ WebHandler Language="C#" Class="GetFuncList" %>

using System;
using System.Web;
using Coal.Util;

public class GetFuncList : IHttpHandler 
{
    public void ProcessRequest (HttpContext context) 
    {
        //还需要返回 NickName 和 用户级别
        if (context.Request.Cookies["login_info"] != null)
        {
            string validKey = context.Request.Cookies["login_info"].Value;
            string[] userInfo = CryptoHelper.Decrypt(validKey, "coalchina").Split('|');
            string nickName = userInfo[0];
            string loginEmail = userInfo[1];

            Coal.BLL.FuncManager func = new Coal.BLL.FuncManager();
            ResultObject ro = new ResultObject();
            if (func.GetFunctionList(loginEmail, ro))
            {
                ro["nick_name"] = nickName;            
                context.Response.Write(ro.ToJSONString());
            }
            else
            {
                context.Response.Write("{status:-2,url:'http://localhost:2150/Coal.Portal/login.aspx'}");
            }
        }
        else
        {
            context.Response.Write("{status:-1,url:'http://localhost:2150/Coal.Portal/login.aspx'}");
        }

    }
 
    public bool IsReusable {
        get {
            return true;
        }
    }

}