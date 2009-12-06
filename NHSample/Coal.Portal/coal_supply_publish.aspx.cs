using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class coal_supply_publish : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    protected void submit_Click(object sender, EventArgs e)
    {
        if (int.Parse(this.lidu.SelectedValue) > 0)
        {
            this.msg.Visible = false;
        }
        else
        {
            this.msg.Visible = true;
        }
    }
}
