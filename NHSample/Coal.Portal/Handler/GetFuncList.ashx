<%@ WebHandler Language="C#" Class="GetFuncList" %>

using System;
using System.Web;
using Coal.Util;

public class GetFuncList : IHttpHandler 
{
    public void ProcessRequest (HttpContext context) 
    {
        if (context.Request.Cookies["login_info"] != null)
        {
            string validKey = context.Request.Cookies["login_info"].Value;
            string loginEmail = CryptoHelper.Decrypt(validKey, "coalchina").Split('|')[1];

            Coal.BLL.FuncManager func = new Coal.BLL.FuncManager();
            string str = string.Empty;
            if (func.GetFunctionList(loginEmail, ref str))
            {
                context.Response.Write(str);
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