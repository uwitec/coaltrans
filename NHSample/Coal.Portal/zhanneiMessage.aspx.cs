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
            init();        
        }
    }
    private void init()
    {
        if (Context.Request.Cookies["login_info"] != null)
        {
            int UserId = GetUserId(Context.Request.Cookies["login_info"].Value);
            string StrWhere1 = " Where embracer=" + UserId.ToString();
            string StrWhere2 = StrWhere1 + " and IsSee=0";
            string StrWhere3 = StrWhere1 + " and IsSee=1";
            CompanyMessageEntity.CompanyMessageInfoDao DTO = new CompanyMessageEntity.CompanyMessageInfoDao();
            object val1 = DTO.FindByWhere(StrWhere1);
            object val2 = DTO.FindByWhere(StrWhere2);
            object val3 = DTO.FindByWhere(StrWhere3);
            MessageCount.Text = Convert.ToInt32(val1).ToString();
            SeeCount.Text = Convert.ToInt32(val3).ToString();
            NoSeeCount.Text = Convert.ToInt32(val2).ToString();
        }
        else
        {
            Context.Response.Redirect("login.aspx");
        }
    }
    /// <summary>
    /// 获取用户ID
    /// </summary>
    /// <param name="Str">Coocie信息</param>
    /// <returns></returns>
    private int GetUserId(string Str)
    {
        if (Str == "")
        {
            return 0;
        }
        else
        {
            string[] userInfo = CryptoHelper.Decrypt(Str, "coalchina").Split('|');
            return Convert.ToInt32(userInfo[2]);
        }
    }
}
