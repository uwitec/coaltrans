<%@ WebHandler Language="C#" Class="Login" %>

using System;
using System.Web;
using Coal.Util;
using Coal.BLL;

public class Login : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) 
    {
        ResultObject ro = new ResultObject();
        string loginEmail = context.Request.Form["e"];
        string password = context.Request.Form["p"];

        if (!string.IsNullOrEmpty(loginEmail) && !string.IsNullOrEmpty(password))
        {
            string nickName = string.Empty;
            int userId = -1;
            if (UserManager.ValidLogin(loginEmail, password, ref nickName,ref userId))
            {
                //写cookies
                string key = nickName + "|" + loginEmail + "|" + userId.ToString();
                string validKey = CryptoHelper.Encrypt(key, "coalchina");

                if (context.Request.Cookies["login_info"] != null)
                {
                    HttpCookie oldCookie = context.Request.Cookies["login_info"];
                    oldCookie.Expires = DateTime.Now.AddDays(-1);
                    context.Response.SetCookie(oldCookie);
                }

                //LoginContext.CurrentUser = new LoginContext.User();
                //LoginContext.CurrentUser.UserId = 0;

                HttpCookie cookie = new HttpCookie("login_info");
                cookie.Value = validKey;
                //cookie.Expires = DateTime.Now.AddDays(1);
                context.Response.SetCookie(cookie);

                ro["nick_name"] = nickName;
                ro["status"] = 1;
            }
            else
            {
                ro["status"] = -1;
                ro["error_code"] = 1;
            }
        }
        else
        {
            if (context.Request.Cookies["login_info"] != null)
            {
                string key = CryptoHelper.Decrypt(context.Request.Cookies["login_info"].Value,"coalchina");
                ro["nick_name"] = key.Split('|')[0];
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