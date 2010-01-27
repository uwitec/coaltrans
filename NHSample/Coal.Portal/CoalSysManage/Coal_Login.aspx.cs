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

public partial class CoalSysManage_Coal_Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["admin_login"] != null)
        {
            MessageBox.ShowAndRedirect("您已经登录，请不要重复登录", "Coal_Default.htm");
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string key = "admin" + "|" + "1" + "|" + "1";
        string validkey = CryptoHelper.Encrypt(key, "coaladmin");
        HttpCookie AdminCookie = new HttpCookie("admin_login");
        AdminCookie.Value = validkey;
        Response.SetCookie(AdminCookie);
        Response.Redirect("Coal_Default.htm");
    }
}
