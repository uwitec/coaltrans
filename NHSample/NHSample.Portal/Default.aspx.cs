using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Coal.Util;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.Cookies["token"] != null)
            {
                string validKey = Request.Cookies["token"].Value;
                string keys = CryptoHelper.Decrypt(validKey, "renshiqi");

                string[] nameAndPassword = keys.Split(',');

                if (nameAndPassword.Length == 2)
                {
                    string loginName = nameAndPassword[0];
                    string password = nameAndPassword[1];
                    Response.Write(loginName + " and " + password);
                }
            }
        }

    }
}
