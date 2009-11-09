using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Coal.Util;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void submit_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(this.email.Text) && !string.IsNullOrEmpty(this.password.Text))
        {
            if (this.email.Text == "cheese1@sina.com" && this.password.Text == "windows")
            { 
                //写cookies
                string key = this.email.Text + "," + this.password.Text;
                string validKey = CryptoHelper.Encrypt(key, "renshiqi");

                if (Request.Cookies["token"] != null)
                {
                    HttpCookie oldCookie = Request.Cookies["token"];
                    oldCookie.Expires = DateTime.Now.AddDays(-1);
                    Response.SetCookie(oldCookie);
                }

                HttpCookie cookie = new HttpCookie("token");
                cookie.Value = validKey;
                cookie.Expires = DateTime.Now.AddDays(1);
                Response.SetCookie(cookie);
                Response.Redirect("Default.aspx");
            }
        }
    }
}
