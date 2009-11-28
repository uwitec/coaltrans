<%@ WebHandler Language="C#" Class="Login" %>

using System;
using System.Web;
using Coal.Util;
using Coal.BLL;

public class Login : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        ResultObject ro = new ResultObject();
        string loginName = context.Request.Form["login_name"];
        string password = context.Request.Form["password"];

        if (!string.IsNullOrEmpty(loginName) && !string.IsNullOrEmpty(password))
        {
            if (loginName == "cheese" && password == "windows")
            {
                //写cookies
                string key = loginName + "," + password;
                string validKey = CryptoHelper.Encrypt(key, "renshiqi");

                if (context.Request.Cookies["token"] != null)
                {
                    HttpCookie oldCookie = context.Request.Cookies["token"];
                    oldCookie.Expires = DateTime.Now.AddDays(-1);
                    context.Response.SetCookie(oldCookie);
                }

                LoginContext.CurrentUser = new LoginContext.User();
                LoginContext.CurrentUser.UserId = 0;

                HttpCookie cookie = new HttpCookie("token");
                cookie.Value = validKey;
                cookie.Expires = DateTime.Now.AddDays(1);
                context.Response.SetCookie(cookie);

                ro["nick_name"] = "奇子";
                ro["status"] = 1;
            }
            else
            {
                ro["status"] = -1;
                ro["error_code"] = 1;
            }
        }

        //线程休眠500毫秒，为了看ajax的效果
        System.Threading.Thread.Sleep(1000);
        context.Response.Clear();
        context.Response.Write(ro.ToJSONString());
        context.Response.End();
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}