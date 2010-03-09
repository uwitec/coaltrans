using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using Autonomy.Demo.Util;

public partial class _Default : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string Str = DESEncrypt.Encrypt(ConfigurationManager.ConnectionStrings["SentimentConnStr"].ToString());
    }
}
