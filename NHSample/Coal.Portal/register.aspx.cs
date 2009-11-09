using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NHibernate;
using NHSample.Domain;
using Coal.Util;

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

        if (this.validCode.Text.Trim().ToUpper() == Request.Cookies["valid_code"].Value)
        {
            //插入数据库
            using (ISession session = NHSample.Domain.Session.Open())
            {
                NHSample.Domain.Entities.User u = new NHSample.Domain.Entities.User();
                u.Email = email;
                u.LoginName = loginName;
                u.NickName = nickName;
                u.Password = password;
                u.ValidStatus = 0;
                session.Save(u);
                session.Flush();
            }

            string key = loginName + "," + password;
            string validKey = CryptoHelper.Encrypt(key, "renshiqi");

            this.valid.Text = "验证用户";
            this.valid.NavigateUrl = "http://localhost:1615/NHSample.Portal/ValidateUser.ashx?key=" + Server.UrlEncode(validKey);

            //对loginName 和 password 加密后作为参数 发信给用户。
            //Validate.ashx?key= 加密（loginName&password）
        }
        else
        {
            Response.Write("验证码错误");
        }
    }
}
