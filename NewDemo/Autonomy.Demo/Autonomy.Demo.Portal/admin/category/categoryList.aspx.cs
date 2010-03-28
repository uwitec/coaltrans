using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Text;
using Autonomy.Demo.Dal;

public partial class demo_admin_category_categoryList : System.Web.UI.Page
{
    private CategoryEntity.CategoryDAO Dao = new CategoryEntity.CategoryDAO();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ListInnit();
            ajax();
        }
    }

    private void ListInnit()
    {
        StringBuilder htmlStr = new StringBuilder();
        string strWhere = " ParentCate=0";
        IList<CategoryEntity> entityList = Dao.Find(strWhere, null);
        if (entityList.Count > 0)
        {
            foreach (CategoryEntity entity in entityList)
            {
                MenuChildList(ref htmlStr, entity.ID.Value, entity.CategoryName, entity.CategoryID.Value.ToString());
            }
        }
        MenuList.InnerHtml = htmlStr.ToString();
    }
    private void MenuChildList(ref StringBuilder htmlStr, int parentId, string CategoryName, string CategoryID)
    {
        string strWhere = " ParentCate=" + parentId;
        IList<CategoryEntity> entityList = Dao.Find(strWhere, null);        
        string style = "display:block;width:100%;";
        if (entityList.Count > 0)
        {
            htmlStr.Append("<div class=\"NoMenulist1\" style=\"" + style + "\"><a href=\"javascript:void(null);\">" + CategoryName + "</a><span style=\"margin-left:200px;\">");
            htmlStr.Append("<a href=\"javascript:void(null);\" title=\"查看\" onclick=\"\"><img src=\"../images/icon_view.gif\" alt=\"\" /></a>&nbsp;");
            htmlStr.Append("<a href=\"categoryedit.aspx?ID=" + parentId + "&act=edit\" title=\"编辑\" onclick=\"\"><img src=\"../images/icon_edit.gif\" alt=\"\" /></a>&nbsp;");
            htmlStr.Append("<a href=\"javascript:void(null);\" title=\"删除\" onclick=\"javascript:listTable.remove(" + parentId.ToString() + ",'您确定要删除该记录么？','remove');location.reload();\"><img src=\"../images/icon_drop.gif\" alt=\"\" /></a>&nbsp;");
            htmlStr.Append("</span>");
            foreach (CategoryEntity entity in entityList)
            {
                MenuChildList(ref htmlStr, entity.ID.Value, entity.CategoryName, entity.CategoryID.Value.ToString());
            }
            htmlStr.Append("</div>");
        }
        else
        {
            htmlStr.Append("<div class=\"NoMenulist1\" style=\"" + style + "\"><a href=\"javascript:void(null);\" pid=\"\">" + CategoryName + "</a><span style=\"margin-left:200px;\">");
            htmlStr.Append("<a href=\"javascript:void(null);\" title=\"查看\" onclick=\"\"><img src=\"../images/icon_view.gif\" alt=\"\" /></a>&nbsp;");
            htmlStr.Append("<a href=\"categoryedit.aspx?ID=" + parentId + "&act=edit\" title=\"编辑\" onclick=\"\"><img src=\"../images/icon_edit.gif\" alt=\"\" /></a>&nbsp;");
            htmlStr.Append("<a href=\"javascript:void(null);\" title=\"删除\" onclick=\"javascript:listTable.remove("+parentId.ToString()+",'您确定要删除该记录么？','remove');location.reload();\"><img src=\"../images/icon_drop.gif\" alt=\"\" /></a>&nbsp;");
            htmlStr.Append("</span></div>");
        }
    }
    /// <summary>
    /// 处理Ajax请求
    /// </summary>
    private void ajax()
    {
        if ((!string.IsNullOrEmpty(Request["is_ajax"])) && (Request["is_ajax"].ToString() == "1"))
        {
            string res = "";
            string act = Request["act"].ToString();
            string id = Request["id"].ToString();
            try
            {                               
                switch (act)
                {                   
                    case "remove":                                             
                        bool DelResult = Dao.Delete(Convert.ToInt32(id));
                        break;
                    default:
                        break;
                }
            }
            catch
            {
                res = "{\"error\":1,\"message\":\"操作失败！\",\"content\":0}";
            }
            finally
            {
                Response.Write(res);
                Response.End();
            }
        }
    }
}
