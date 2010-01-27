using System;
using System.Collections;
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
using Coal.DAL;
using Coal.Util;

public partial class CoalSysManage_Public_Menu : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            innit();    
        }
    }
    private void innit()
    {
        if (Request.Cookies["admin_login"] != null)
        {
            string validKey = Request.Cookies["admin_login"].Value;
            string[] AdminInfo = CryptoHelper.Decrypt(validKey, "coaladmin").Split('|');
            string AdminName = AdminInfo[0];//获取用户名
            int AdminId = EConvert.ToInt(AdminInfo[1]);//获取用户Id
            int RoleId = EConvert.ToInt(AdminInfo[2]);//获取角色Id
            MenuListInnit(RoleId);
        }
        else
        {
            MessageBox.ShowAndScript("对不起，您还没有登录。", "top.location.href='Coal_Login.aspx'");
        }
    }
    private void MenuListInnit(int RoleId)
    {
        string SearchStr=string.Empty;
        SearchStr+="SELECT A.* FROM PowerAssign as p,AdminModules as A ";
        SearchStr += "WHERE p.ModuleId=A.ModuleId and p.RoleId=" + RoleId + " and A.ParentId=1";
        string InnerHtml = "";
        DataSet ds = AdminManage.GetAdminDs(SearchStr);
        if (ds != null && ds.Tables[0].Rows.Count>0)
        {
            DataTable dt = ds.Tables[0];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow row = dt.Rows[i];
                int ModeleId = EConvert.ToInt(row["ModuleId"]);
                string ModuleName = row["ModuleName"].ToString();
                string ActionLink = row["ActionLink"].ToString();
                if (GetChildCount(RoleId, ModeleId) > 0)
                {
                    InnerHtml += "<div class='Menulist1'><a ";
                }
                else
                {
                    InnerHtml += "<div class='NoMenulist1'><a ";
                }
                if (!string.IsNullOrEmpty(ActionLink))
                {
                    InnerHtml += "href='javascript:void(null);' pid='" + ActionLink + "'";
                }
                else
                {
                    InnerHtml += "href='javascript:void(null);'";
                }
                InnerHtml += ">" + ModuleName + "</a>";
                InnerHtml += GetChildList(RoleId, ModeleId, 0);
                InnerHtml += "</div>";
            }
        }
        MenuList.InnerHtml = InnerHtml;        
    }
    private string GetChildList(int RoleId, int ParentId, int level)
    {
        level++;
        string Str = "";
        for (int j = 1; j < level; j++)
        {
            Str += "&nbsp;&nbsp;&nbsp;&nbsp;";
        }
        string SearchStr = string.Empty;
        SearchStr += "SELECT A.* FROM PowerAssign as p,AdminModules as A ";
        SearchStr += "WHERE p.ModuleId=A.ModuleId and p.RoleId=" + RoleId + " and A.ParentId="+ParentId;
        string InnerHtml = "";
        DataSet ds = AdminManage.GetAdminDs(SearchStr);
        if (ds != null && ds.Tables[0].Rows.Count > 0)
        {
            DataTable dt = ds.Tables[0];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow row = dt.Rows[i];
                int ModeleId = EConvert.ToInt(row["ModuleId"]);
                string ModuleName = row["ModuleName"].ToString();
                string ActionLink = row["ActionLink"].ToString();
                if (GetChildCount(RoleId, ModeleId) > 0)
                {
                    InnerHtml += Str + "<div class='Menulist1' style='display:none;'><a ";
                }
                else
                {
                    InnerHtml += Str + "<div class='NoMenulist1' style='display:none;'><a ";
                }
                if (!string.IsNullOrEmpty(ActionLink))
                {
                    InnerHtml += "href='javascript:void(null);' pid='"+ActionLink+"'";
                }
                else
                {
                    InnerHtml += "href='javascript:void(null);'";
                }
                InnerHtml += ">" + ModuleName + "</a>";
                InnerHtml += GetChildList(RoleId, ModeleId, level);
                InnerHtml += "</div>";
                
            }
            return InnerHtml;
        }
        else
        {
            return "";
        }
    }
    private int GetChildCount(int RoleId, int ParentId)
    {
        string SearchStr = string.Empty;
        SearchStr += "SELECT A.* FROM PowerAssign as p,AdminModules as A ";
        SearchStr += "WHERE p.ModuleId=A.ModuleId and p.RoleId=" + RoleId + " and A.ParentId=" + ParentId;
        DataSet ds = AdminManage.GetAdminDs(SearchStr);
        return ds.Tables[0].Rows.Count;
    }
}
