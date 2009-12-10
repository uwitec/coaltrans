using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class log_out : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        HttpCookie loginInfo = Request.Cookies["login_info"];
        if (loginInfo != null)
        {
            loginInfo.Expires = DateTime.Today.AddDays(-10);
            Response.Cookies.Add(loginInfo);
            Response.Redirect("index.html");
        }
    }
}
