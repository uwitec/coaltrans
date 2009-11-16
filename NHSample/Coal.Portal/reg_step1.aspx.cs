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
        string email = this.Email.Text;
        string password = this.Password.Text;
        string nickName = this.NickName.Text;

        UserManager.AddUser(email, nickName, password);

        string key = email + "," + password;
        string validKey = CryptoHelper.Encrypt(key, "renshiqi");
        string validUrl = "http://localhost:1615/NHSample.Portal/ValidateUser.ashx?key=" + Server.UrlEncode(validKey);
    }
}
