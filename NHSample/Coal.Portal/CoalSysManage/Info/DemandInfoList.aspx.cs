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
using Coal.Entity;
using Coal.Util;

public partial class CoalSysManage_Info_DemandInfoList : System.Web.UI.Page
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
        RegionEntity.RegionDAO Dao = new RegionEntity.RegionDAO();
        string StrWhere = " Parent=9000";
        List<RegionEntity> list = Dao.Find(StrWhere, null);
        ListItem Litem = new ListItem("--请选择省份--", "0");
        Province.Items.Add(Litem);
        if (list != null && list.Count > 0)
        {
            foreach (RegionEntity entity in list)
            {
                ListItem item = new ListItem(entity.Name, entity.Id.ToString());
                Province.Items.Add(item);
            }
        }
    }    
    protected void Province_SelectedIndexChanged(object sender, EventArgs e)
    {
        string Parent = Province.SelectedValue;
        RegionEntity.RegionDAO Dao = new RegionEntity.RegionDAO();
        string StrWhere = " Parent=" + Parent;
        List<RegionEntity> list = Dao.Find(StrWhere, null);
        city.Items.Clear();
        if (list != null && list.Count > 0)
        {
            foreach (RegionEntity entity in list)
            {
                ListItem item = new ListItem(entity.Name, entity.Id.ToString());
                city.Items.Add(item);
            }
        }
    }
    private void DataBinds()
    {
        string StrWhere = "ID>0";
        if (!string.IsNullOrEmpty(DemandTitle.Value))
        {
            StrWhere += " and DemandTitle like '%";
            string[] Str = DemandTitle.Value.Split(' ');
            foreach (string obj in Str)
            {
                StrWhere += obj + "%";
            }
            StrWhere += "'";
        }
        if (CoalType.Value != "0")
        {
            StrWhere += " and CoalType='" + CoalType.Value+"'";
        }
        if (Province.SelectedValue != "0")
        {
            StrWhere += " and DeliveryPlace='" + Province.SelectedValue + "&" + city.Value + "'";
        }
        DemandInfoEntity.DemandInfoDAO Dao = new DemandInfoEntity.DemandInfoDAO();
        PagerList.RecordCount = Dao.GetPagerRowsCount(StrWhere, null);
        Hashtable ht = new Hashtable();
        ht.Add("Sequence", "ASC");
        ht.Add("CreateTime", "DESC");
        DataTable dt = Dao.GetPager(StrWhere, null, ht , PagerList.PageSize, PagerList.CurrentPageIndex);
        List.DataSource = dt;
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
            string[] list = Area.Split('&');
            RegionEntity.RegionDAO Dao = new RegionEntity.RegionDAO();

            foreach (string obj in list)
            {
                RegionEntity entity = Dao.FindById(EConvert.ToLong(obj));
                if (entity != null)
                {
                    Str += entity.Name + "  ";
                }
            }
        }
        return Str;
    }
    #region AJAX处理
    private void Ajax()
    {
        if (!string.IsNullOrEmpty(Request["is_ajax"]) && Request["is_ajax"] == "1")
        {
            string res = "";
            string act = Request["act"].ToString();
            string id = Request["id"].ToString();
            try
            {
                DemandInfoEntity.DemandInfoDAO Dao = new DemandInfoEntity.DemandInfoDAO();
                string Val = Common.FiltrationMaliciousCode(Request["val"].ToString());
                switch (act)
                {
                    case "edit status":
                        string status = (Val == "0" ? "0" : "1");
                        bool result = Dao.UpdateSet(EConvert.ToInt(id), "IsAudit", status);
                        res = "{\"error\":0,\"message\":\"\",\"content\":\"" + Val + "\"}";
                        break;
                    case "edit Sequence":
                        bool SeqResult = Dao.UpdateSet(EConvert.ToInt(id), "Sequence", Val);
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
    #endregion
    protected void BtnDelete_Click(object sender, EventArgs e)
    {
        CheckBox chk;
        Label lab;
        foreach (RepeaterItem Item in List.Items)
        {
            chk = (CheckBox)Item.FindControl("DemandID");
            lab = (Label)Item.FindControl("ID");
            if (chk.Checked)
            {
                DemandInfoEntity.DemandInfoDAO Dao = new DemandInfoEntity.DemandInfoDAO();
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
            chk = (CheckBox)Item.FindControl("DemandID");
            lab = (Label)Item.FindControl("ID");
            if (chk.Checked)
            {
                DemandInfoEntity.DemandInfoDAO Dao = new DemandInfoEntity.DemandInfoDAO();
                bool result = Dao.UpdateSet(EConvert.ToInt(lab.Text), "IsAudit","1");
            }
        }
        DataBinds();
    }
}
