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
using Coal.DAL;
using Coal.Util;

public partial class CoalSysManage_Info_TenderInfoList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DataBinds();
            Ajax();
        }
    }
    private void DataBinds()
    {
        string StrWhere = " ID>0";
        if (!string.IsNullOrEmpty(TenderTitle.Value))
        {
            StrWhere += " and TenderTitle like '%";
            string[] Str = TenderTitle.Value.Split(' ');
            foreach (string obj in Str)
            {
                StrWhere += obj + "%";
            }
            StrWhere += "'";
        }
        if (!string.IsNullOrEmpty(StartTime.Value))
        {
            StrWhere += " and StartTime>='" + StartTime.Value + "'";
        }
        if (!string.IsNullOrEmpty(EndTime.Value))
        {
            StrWhere += " and EndTime<='" + EndTime.Value + "'";
        }
        TenderInfoEntity.TenderInfoDAO Dao = new TenderInfoEntity.TenderInfoDAO();
        PagerList.RecordCount = Dao.GetPagerRowsCount(StrWhere, null);
        Hashtable ht = new Hashtable();
        ht.Add("RankNum", "ASC");
        ht.Add("CreateTime", "DESC");
        List.DataSource = Dao.GetPager(StrWhere, null, ht, PagerList.PageSize, PagerList.CurrentPageIndex);
        List.DataBind();
    }
    protected void BtnSearch_Click(object sender, EventArgs e)
    {
        DataBinds();
    }
    protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
    {
        PagerList.CurrentPageIndex = e.NewPageIndex;
        DataBinds();
    }
    protected string GetImgUrl(string Status)
    {
        string url = "";
        url = (Status == "0" ? "../images/no.gif" : "../images/yes.gif");
        return url;
    }
    private void Ajax()
    {
        if (!string.IsNullOrEmpty(Request["is_ajax"]) && Request["is_ajax"] == "1")
        {
            string res = "";
            string act = Request["act"].ToString();
            string id = Request["id"].ToString();
            try
            {
                TenderInfoEntity.TenderInfoDAO Dao = new TenderInfoEntity.TenderInfoDAO();
                string Val = Common.FiltrationMaliciousCode(Request["val"].ToString());
                switch (act)
                {
                    case "edit status":
                        string status = (Val == "0" ? "0" : "1");
                        bool result = Dao.UpdateSet(EConvert.ToInt(id), "IsAudit", status);
                        res = "{\"error\":0,\"message\":\"\",\"content\":\"" + Val + "\"}";
                        break;
                    case "edit RankNum":
                        bool Upresult = Dao.UpdateSet(EConvert.ToInt(id), "RankNum", Val);
                        res = "{\"error\":0,\"message\":\"\",\"content\":\"" + Val + "\"}";
                        break;
                    case "remove":
                        bool DelResult = Dao.Delete(EConvert.ToInt(id));
                        break;
                    default:
                        break;
                }
            }
            catch
            {
                res = "{\"error\":1,\"message\":\"操作失败！\",\"content\":0}";
            }
            finally
            {
                Response.Write(res);
                Response.End();
            }
        }
    }
    protected void BtnDelete_Click(object sender, EventArgs e)
    {
        CheckBox chk;
        Label lab;
        foreach (RepeaterItem Item in List.Items)
        {
            chk = (CheckBox)Item.FindControl("TenderID");
            lab = (Label)Item.FindControl("ID");
            if (chk.Checked)
            {
                TenderInfoEntity.TenderInfoDAO Dao = new TenderInfoEntity.TenderInfoDAO();
                bool result = Dao.Delete(EConvert.ToInt(lab.Text));
            }
        }
        DataBinds();
    }
    protected void BtnAudit_Click(object sender, EventArgs e)
    {
        CheckBox chk;
        Label lab;
        foreach (RepeaterItem Item in List.Items)
        {
            chk = (CheckBox)Item.FindControl("TenderID");
            lab = (Label)Item.FindControl("ID");
            if (chk.Checked)
            {
                TenderInfoEntity.TenderInfoDAO Dao = new TenderInfoEntity.TenderInfoDAO();
                bool result = Dao.UpdateSet(EConvert.ToInt(lab.Text), "IsAudit", "1");
            }
        }
        DataBinds();
    }
}
