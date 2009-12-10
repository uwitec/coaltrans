<%@ WebHandler Language="C#" Class="ValidateCode" %>

using System;
using System.Web;

public class ValidateCode : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) 
    {
        if (context.Request.Cookies["valid_code"].Value == context.Request.Form["code"].ToUpper())
        {
            context.Response.ContentType = "text/plain";
            context.Response.Write("true");
        }
        else
        {
            context.Response.ContentType = "text/plain";
            context.Response.Write("false");
        }
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}