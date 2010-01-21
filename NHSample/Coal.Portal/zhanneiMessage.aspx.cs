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
            LbGreetings.Text = GetTimeStage();
            LbDateTime.Text = GetDateTime();
        }
        else
        {
            Response.Redirect("login.aspx");
        }

    }
    private string GetTimeStage()
    {
        int Hour =Convert.ToInt32(DateTime.Now.ToString("HH"));
        if (Hour < 12)
        {
            return "早上好，" + LoginContext.CurrentUser.NickName;
        }
        else if (Hour >= 12 && Hour < 13)
        {
            return "中午好，" + LoginContext.CurrentUser.NickName;
        }
        else if (Hour >= 13 && Hour < 18)
        {
            return "下午好，" + LoginContext.CurrentUser.NickName;
        }
        else
        {
            return "晚上好，" + LoginContext.CurrentUser.NickName;
        }        
    }
    private string GetDateTime()
    {
        string Mounth = DateTime.Now.ToString("MM月dd日");
        string week = WeekDays(DateTime.Now.DayOfWeek.ToString());
        return Mounth +"，"+ week;
    }
    private string WeekDays(string weekName)
    {
        string week="";
        switch (weekName)
        {
            case "Sunday":
                week = "星期日";
                break;
            case "Monday":
                week = "星期一";
                break;
            case "Tuesday":
                week = "星期二";
                break;
            case "Wednesday":
                week = "星期三";
                break;
            case "Thursday":
                week = "星期四";
                break;
            case "Friday":
                week = "星期五";
                break;
            case "Saturday":
                week = "星期五";
                break;
                
        }
        return week;
    }
}
