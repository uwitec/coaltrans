<%@ WebHandler Language="C#" Class="GetInfo" %>

using System;
using System.Web;
using Autonomy.Demo.Dal;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;

public class GetInfo : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        LeaderEntity.LeaderDAO Dao = new LeaderEntity.LeaderDAO();
        IList<LeaderEntity> entityList = Dao.Find("", null);
        context.Response.Write(JavaScriptConvert.SerializeObject(entityList).ToString());
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}