<%@ WebHandler Language="C#" Class="User" %>

using System;
using System.Web;
using System.Text;

public class User : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        string userName = context.Request.Form["User_Name"];
        string passWord = context.Request.Form["Pass_Word"];
        StringBuilder Json_Str = new StringBuilder();
        if (!string.IsNullOrEmpty(userName) && !string.IsNullOrEmpty(passWord))
        {
            if (userName == "gkax" && passWord == "gkax")
            {
                Json_Str.Append("{'SuccessCode':1}");
            }
            else
            {
                Json_Str.Append("{'SuccessCode':0}");
            }
        }
        else
        {
            Json_Str.Append("{'SuccessCode':0}");
        }
        context.Response.Write(Json_Str.ToString());
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}