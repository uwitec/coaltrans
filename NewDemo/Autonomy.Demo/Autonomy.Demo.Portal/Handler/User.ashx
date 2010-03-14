<%@ WebHandler Language="C#" Class="User" %>

using System;
using System.Web;
using System.Text;
using Autonomy.Demo.Util;

public class User : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        string userName = context.Request.Form["User_Name"];
        string passWord = context.Request.Form["Pass_Word"];
        string action = context.Request.Form["action"];
        if (!string.IsNullOrEmpty(action)&&action=="clear_cookie")
        {
            HttpCookie userLogin =context.Request.Cookies["user_login"];
            if (userLogin != null)
            {
                userLogin.Expires = DateTime.Now.AddDays(-10);
                userLogin.Value = "";
                context.Response.SetCookie(userLogin);
                context.Response.Write("{'SuccessCode':1}");
            }
        }
        else
        {
            StringBuilder jsonStr = new StringBuilder();
            if (!string.IsNullOrEmpty(userName) && !string.IsNullOrEmpty(passWord))
            {
                if (userName == "gkax" && passWord == "gkax")
                {
                    string key = "gkax|gkax";
                    string validkey = DESEncrypt.Encrypt(key, "autonomy");
                    HttpCookie userCookie = new HttpCookie("user_login");
                    userCookie.Value = validkey;
                    context.Response.SetCookie(userCookie);
                    jsonStr.Append("{'SuccessCode':1}");
                }
                else
                {
                    jsonStr.Append("{'SuccessCode':0}");
                }
            }
            else
            {
                jsonStr.Append("{'SuccessCode':0}");
            }
            context.Response.Write(jsonStr.ToString());
        }
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}