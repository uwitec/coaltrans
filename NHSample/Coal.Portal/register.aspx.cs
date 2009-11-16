using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Coal.Util;
using Coal.BLL;

public partial class _Default : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void submit_Click(object sender, EventArgs e)
    {
        string loginName = this.login_name.Text;
        string email = this.email.Text;
        string password = this.password.Text;
        string nickName = this.nick_name.Text;

        UserManager.AddUser(email, nickName, password);

        string key = loginName + "," + password;
        string validKey = CryptoHelper.Encrypt(key, "renshiqi");
        this.valid.Text = "验证用户";
        this.valid.NavigateUrl = "http://localhost:1615/NHSample.Portal/ValidateUser.ashx?key=" + Server.UrlEncode(validKey);
    }
}
