<%@ WebHandler Language="C#" Class="GetTrainMenu" %>

using System;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Text;
using Autonomy.Demo.Dal;   

public class GetTrainMenu : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        StringBuilder ItemList = new StringBuilder();
        ItemList.Append("<option value=\"0\">根目录</option>");
        ParentCateInnit(0, 1, ref ItemList);
        context.Response.Write(ItemList.ToString());
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

    private void ParentCateInnit(int ParentCateId, int level,ref StringBuilder ItemList)
    {
        string str = string.Empty;
        for (int i = 1; i < level; i++)
            str += "&nbsp;";
        level++;
        CategoryEntity.CategoryDAO Dao = new CategoryEntity.CategoryDAO();
        IList<CategoryEntity> entityList = Dao.Find(" ParentCate=" + ParentCateId, null);
        foreach (CategoryEntity entity in entityList)
        {
            ItemList.Append("<option value=\"" + entity.ID.Value.ToString() + "\">" + HttpUtility.HtmlDecode(str) + entity.CategoryName + "</option>");
            ParentCateInnit(entity.ID.Value, level, ref ItemList);
        }
    }
}