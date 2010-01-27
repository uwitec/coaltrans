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

public partial class CoalSysManage_Top : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            GetInfo();
        }
    }
    private void GetInfo()
    {
        
    }
    protected void BtnLoginOut_Click(object sender, EventArgs e)
    {
        HttpCookie AdminLogin = Request.Cookies["admin_login"];
        if (AdminLogin != null)
        {
            AdminLogin.Expires = DateTime.Now.AddDays(-10);
            AdminLogin.Value = "";
            Response.SetCookie(AdminLogin);
            Response.Write("<script type='text/javascript'>top.location.href='Coal_Login.aspx';</script>");
        }
    }
}
