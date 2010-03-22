<%@ WebHandler Language="C#" Class="GetInfo" %>

using System;
using System.Web;
using Autonomy.Demo.Dal;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Text;

public class GetInfo : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        string Type = context.Request["type"];
        //获取分类类型
        string cateType = context.Request["cate_type"];
        //获取当前分类ID
        string cateId = context.Request["cate_id"];
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
                StaticInfoEntity.StaticInfoDAO eventStaticDao = new StaticInfoEntity.StaticInfoDAO();                
                string StrWhere1 = "CateType=1";
                IList<StaticInfoEntity> StaticInfoList1 = eventStaticDao.Find(StrWhere1, null, 6, OrderByStr1);
                context.Response.Write(JavaScriptConvert.SerializeObject(StaticInfoList1).ToString());
                break;
            case "Society":
                StaticInfoEntity.StaticInfoDAO societyStaticDao = new StaticInfoEntity.StaticInfoDAO();
                string StrWhere2 = "CateType=2";
                string StrWhere3 = StrWhere + " and CateType=2";
                IList<StaticInfoEntity> StaticInfoList2 = societyStaticDao.Find(StrWhere2, null, 6, OrderByStr1);
                IList<StaticInfoEntity> StaticInfoList3 = societyStaticDao.Find(StrWhere3, null, 6, OrderByStr2);
                context.Response.Write("{\"Society\":" + JavaScriptConvert.SerializeObject(StaticInfoList2).ToString() + ",\"SocietySpeed\":" + JavaScriptConvert.SerializeObject(StaticInfoList3).ToString() + "}");
                break;
            case "LegalCase":
                StaticInfoEntity.StaticInfoDAO legalCaseStaticDao = new StaticInfoEntity.StaticInfoDAO();
                string StrWhere4 = "CateType=3";
                string StrWhere5 = StrWhere + " and CateType=3";
                IList<StaticInfoEntity> StaticInfoList4 = legalCaseStaticDao.Find(StrWhere4, null, 6, OrderByStr1);
                IList<StaticInfoEntity> StaticInfoList5 = legalCaseStaticDao.Find(StrWhere5, null, 6, OrderByStr2);
                context.Response.Write("{\"LegalCase\":" + JavaScriptConvert.SerializeObject(StaticInfoList4).ToString() + ",\"LegalCaseSpeed\":" + JavaScriptConvert.SerializeObject(StaticInfoList5).ToString() + "}");
                break;  
            case "Menu":
                Hashtable ht=new Hashtable();
                string correOrderStr = "TotalHitCount DESC";
                StaticInfoEntity.StaticInfoDAO menuStaticDao = new StaticInfoEntity.StaticInfoDAO();
                //获取当前主题分类
                string correStrwhere = " CateType=" + cateType;                
                IList<StaticInfoEntity> correList = menuStaticDao.Find(correStrwhere, null, 0, correOrderStr);
                ht.Add("relevanceList", correList);
                //获取其他主题
                
                //拼接json字符串
                StringBuilder menuContent = new StringBuilder();
                menuContent.Append("{");
                int count = 1;
                foreach (string key in ht.Keys)
                {
                    menuContent.Append("\"" + key + "\":");
                    menuContent.Append(JavaScriptConvert.SerializeObject(ht[key]).ToString());
                    if (count < ht.Count)
                        menuContent.Append(",");
                    count++;
                }                
                menuContent.Append("}");
                context.Response.Write(menuContent.ToString());
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