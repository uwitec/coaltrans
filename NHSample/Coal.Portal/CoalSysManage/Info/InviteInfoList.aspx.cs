using System;
using System.Collections;
using System.Collections.Generic;
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
using Coal.Entity;

public partial class CoalSysManage_Info_InviteInfoList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Innit();
            DataBinds();
            Ajax();
        }
    }
    private void Innit()
    {
        ListItem Litem = new ListItem("--请选择招标地区--", "0");
        Region.Items.Add(Litem);
        RegionEntity.RegionDAO Dao = new RegionEntity.RegionDAO();
        List<RegionEntity> list = Dao.Find(" parent=9000", null);
        if (list != null && list.Count > 0)
        {
            foreach (RegionEntity entity in list)
            {
                ListItem item = new ListItem(entity.Name, entity.Id.ToString());
                Region.Items.Add(item);
            }
        }
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
                InviteInfoEntity.InviteInfoDAO Dao = new InviteInfoEntity.InviteInfoDAO();
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

    private void DataBinds()
    {
        string StrWhere = " ID>0";
        if (!string.IsNullOrEmpty(InviteTitle.Value))
        {
            string[] Str = InviteTitle.Value.Split(' ');
            StrWhere += " and InviteTitle like '%";
            foreach (string obj in Str)
            {
                StrWhere += obj + "%";
            }
            StrWhere += "'";
        }
        if (Region.Value != "0")
        {
            StrWhere += " and Region=" + Region.Value;
        }
        if (!string.IsNullOrEmpty(StartTime.Value))
        {
            StrWhere += " and StartTime>='" + StartTime.Value + "'";
        }
        if (!string.IsNullOrEmpty(EndTime.Value))
        {
            StrWhere += " and EndTime<='" + EndTime.Value + "'";
        }
        InviteInfoEntity.InviteInfoDAO Dao = new InviteInfoEntity.InviteInfoDAO();
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
    protected string GetArea(string Area)
    {
        string Str = "";
        if (!string.IsNullOrEmpty(Area))
        {
            RegionEntity.RegionDAO Dao = new RegionEntity.RegionDAO();
            RegionEntity entity = Dao.FindById(EConvert.ToLong(Area));
            if (entity != null)
            {
                Str = entity.Name;
            }
        }
        return Str;
    }
    protected void BtnDelete_Click(object sender, EventArgs e)
    {
        CheckBox chk;
        Label lab;
        foreach (RepeaterItem Item in List.Items)
        {
            chk = (CheckBox)Item.FindControl("InviteID");
            lab = (Label)Item.FindControl("ID");
            if (chk.Checked)
            {
                InviteInfoEntity.InviteInfoDAO Dao = new InviteInfoEntity.InviteInfoDAO();
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
            chk = (CheckBox)Item.FindControl("InviteID");
            lab = (Label)Item.FindControl("ID");
            if (chk.Checked)
            {
                InviteInfoEntity.InviteInfoDAO Dao = new InviteInfoEntity.InviteInfoDAO();
                bool result = Dao.UpdateSet(EConvert.ToInt(lab.Text), "IsAudit", "1");
            }
        }
        DataBinds();
    }
}
