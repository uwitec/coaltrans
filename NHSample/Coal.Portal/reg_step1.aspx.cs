using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Coal.BLL;
using Coal.Util;

public partial class reg_step1 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Submit_Click(object sender, ImageClickEventArgs e)
    {
        if (Request.Cookies["valid_code"].Value == this.tbxValidCode.Text.ToUpper())
        {
            string email = this.tbxEmail.Text;
            string password = this.tbxPassword.Text;
            string nickName = this.tbxNickName.Text;

            if (UserManager.AddUser(email, nickName, password))
            {
                string key = nickName + "|" + email;
                string validKey = CryptoHelper.Encrypt(key, "coalchina");

                if (Request.Cookies["login_info"] != null)
                {
                    HttpCookie oldCookie = Request.Cookies["login_info"];
                    oldCookie.Expires = DateTime.Now.AddDays(-1);
                    Response.SetCookie(oldCookie);
                }

                HttpCookie cookie = new HttpCookie("login_info");
                cookie.Value = validKey;
                //cookie.Expires = DateTime.Now.AddDays(1);
                Response.SetCookie(cookie);
                Response.Redirect("uc_index.aspx");
            }
            else
            {
                ClientScript.RegisterClientScriptBlock(typeof(reg_step1), "alert", "<script>alert('add user failed');</script>");
            }
        }
        else
        {
            ClientScript.RegisterClientScriptBlock(typeof(reg_step1), "alert", "<script>alert('valid code is wrong');</script>");
        }
    }
}
