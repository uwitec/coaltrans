<%@ WebHandler Language="C#" Class="GetInfo" %>

using System;
using System.Web;
using Autonomy.Demo.Dal;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;

public class GetInfo : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        string Type = context.Request["type"];
        string OrderByStr1 = "TotalHitCount DESC";
        string OrderByStr2 = "(TodayHitCount-YestodayHitCount) DESC";
        string StrWhere = "(TodayHitCount-YestodayHitCount)>0";
        switch (Type)
        {
            case "Leader":
                LeaderEntity.LeaderDAO LeaderDao = new LeaderEntity.LeaderDAO();
                IList<LeaderEntity> entityList = LeaderDao.Find("", null);
                context.Response.Write(JavaScriptConvert.SerializeObject(entityList).ToString());
                break;
            case "Event":
                StaticInfoEntity.StaticInfoDAO StaticDao1 = new StaticInfoEntity.StaticInfoDAO();                
                string StrWhere1 = "CateType=1";
                IList<StaticInfoEntity> StaticInfoList1 = StaticDao1.Find(StrWhere1, null, 6, OrderByStr1);
                context.Response.Write(JavaScriptConvert.SerializeObject(StaticInfoList1).ToString());
                break;
            case "Society":
                StaticInfoEntity.StaticInfoDAO StaticDao2 = new StaticInfoEntity.StaticInfoDAO();
                string StrWhere2 = "CateType=2";
                IList<StaticInfoEntity> StaticInfoList2 = StaticDao2.Find(StrWhere2, null, 6, OrderByStr1);
                context.Response.Write(JavaScriptConvert.SerializeObject(StaticInfoList2).ToString());
                break;
            case "SocietySpeed":
                StaticInfoEntity.StaticInfoDAO StaticDao3 = new StaticInfoEntity.StaticInfoDAO();
                string StrWhere3 = StrWhere + " and CateType=2";
                IList<StaticInfoEntity> StaticInfoList3 = StaticDao3.Find(StrWhere3, null, 6, OrderByStr2);
                context.Response.Write(JavaScriptConvert.SerializeObject(StaticInfoList3).ToString());
                break;
            case "LegalCase":
                StaticInfoEntity.StaticInfoDAO StaticDao4 = new StaticInfoEntity.StaticInfoDAO();
                string StrWhere4 = "CateType=3";
                IList<StaticInfoEntity> StaticInfoList4 = StaticDao4.Find(StrWhere4, null, 6, OrderByStr1);
                context.Response.Write(JavaScriptConvert.SerializeObject(StaticInfoList4).ToString());
                break;
            case "LegalCaseSpeed":
                StaticInfoEntity.StaticInfoDAO StaticDao5 = new StaticInfoEntity.StaticInfoDAO();
                string StrWhere5 = StrWhere + "and CateType=3";
                IList<StaticInfoEntity> StaticInfoList5 = StaticDao5.Find(StrWhere5, null, 6, OrderByStr2);
                context.Response.Write(JavaScriptConvert.SerializeObject(StaticInfoList5).ToString());
                break;
            default:
                break;
        }
    }
        
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}