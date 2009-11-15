<%@ WebHandler Language="C#" Class="GetFuncList" %>

using System;
using System.Web;
using Coal.Util;

public class GetFuncList : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {

        if (context.Request.Cookies["token"] != null)
        {
            string validKey = context.Request.Cookies["token"].Value;
            string keys = CryptoHelper.Decrypt(validKey, "renshiqi");

            string[] nameAndPassword = keys.Split(',');

            if (nameAndPassword.Length == 2)
            {
                string loginEmail = nameAndPassword[0];
                string password = nameAndPassword[1];

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
                context.Response.Write("{status:-1}");
            }
        }
        else
        {
            context.Response.Write("{status:-1}");
            
        }
    }
 
    public bool IsReusable {
        get {
            return true;
        }
    }

}