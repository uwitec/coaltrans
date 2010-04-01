<%@ WebHandler Language="C#" Class="getCategoryMenu" %>

using System;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Text;
using Autonomy.Demo.Dal;

public class getCategoryMenu : IHttpHandler {

    private CategoryEntity.CategoryDAO Dao = new CategoryEntity.CategoryDAO();
    
    public void ProcessRequest (HttpContext context) {
        StringBuilder htmlStr = new StringBuilder();
        MenuInit(ref htmlStr);
        context.Response.Write(htmlStr.ToString());
    }
    private void MenuInit(ref StringBuilder htmlStr)
    {
        string strWhere = " ParentCate=0";        
        IList<CategoryEntity> entityList = Dao.Find(strWhere, null);
        if (entityList.Count > 0)
        {
            foreach (CategoryEntity entity in entityList)
            {
                MenuChildList(ref htmlStr, entity.ID.Value, 1, entity.CategoryName, entity.CategoryID.Value.ToString());
            }
        }
    }

    private void MenuChildList(ref StringBuilder htmlStr, int parentId, int level, string CategoryName, string CategoryID)
    {
        level++;
        string strWhere = " ParentCate=" + parentId;        
        IList<CategoryEntity> entityList = Dao.Find(strWhere, null);
        string str = string.Empty;        
        string style = "display:none;";
        if (level == 2)
            style = "display:block";
        if (entityList.Count > 0)
        {
            htmlStr.Append("<div class=\"Menulist1\" id=\"menulist_" + parentId + "\" style=\"" + style + "\"><a href=\"javascript:void(null);\" id=\"menulist_" + parentId + "\">" + CategoryName + "</a>");
            foreach (CategoryEntity entity in entityList)
            {
                MenuChildList(ref htmlStr, entity.ID.Value, level, entity.CategoryName, entity.CategoryID.Value.ToString());
            }
            htmlStr.Append("</div>");
        }
        else
        {
            htmlStr.Append("<div class=\"NoMenulist1\"  style=\"" + style + "\"><a href=\"javascript:void(null);\" pid=\"" + CategoryID + "\" id=\"menulist_" + parentId + "\">" + CategoryName + "</a></div>");
        }
    }
    public bool IsReusable {
        get {
            return false;
        }
    }

}