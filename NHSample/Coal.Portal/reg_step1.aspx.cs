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
        if (Request.Cookies["valid_code"].Value == this.ValidCode.Text.ToUpper())
        {
            string email = this.Email.Text;
            string password = this.Password.Text;
            string nickName = this.NickName.Text;

            if (UserManager.AddUser(email, nickName, password))
            {
                string key = email + "," + password;
                string validKey = CryptoHelper.Encrypt(key, "coalchina");
                string validUrl = "http://localhost:2150/Coal.Portal/ValidateUser.ashx?key=" + Server.UrlEncode(validKey);
                Response.Redirect("reg_step2.aspx?email=" + email + "&test_url=" + validUrl);
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
