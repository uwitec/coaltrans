using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using Coal.BLL;
using Coal.ViewModel;
using Coal.Util;
using Coal.DAL;

public partial class zhanneiMessage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            innit();
        }
    }
    private void innit()
    {
        if (LoginContext.CurrentUser != null)
        {
            string StrWhere = " embracer=" + LoginContext.CurrentUser.UserId;
            string StrWhere1 = " embracer=" + LoginContext.CurrentUser.UserId + " and IsSee=0";
            string StrWhere2 = " embracer=" + LoginContext.CurrentUser.UserId + " and IsSee=1";
            CompanyMessageEntity.CompanyMessageDAO Dao = new CompanyMessageEntity.CompanyMessageDAO();
            Total.Text = Dao.GetPagerRowsCount(StrWhere, null).ToString();
            Nosee.Text = Dao.GetPagerRowsCount(StrWhere1, null).ToString();
            Issee.Text = Dao.GetPagerRowsCount(StrWhere2, null).ToString();
        }
        else
        {
            Response.Redirect("login.aspx");
        }

    }
   
}
