<%@ WebHandler Language="C#" Class="Login" %>

using System;
using System.Web;

public class Login : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        //线程休眠500毫秒，为了看ajax的效果
        System.Threading.Thread.Sleep(300);
        context.Response.ContentType = "text/plain";
        context.Response.Write("Hello World");
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}