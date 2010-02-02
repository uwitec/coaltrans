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
using Coal.BLL;
using Coal.DAL;
using Coal.Util;

public partial class CoalSysManage_Ad_AdList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            innit();
            DataBinds();
            Ajax();
        }
    }
    private void innit()
    {
        AdPositionEntity.AdPositionDAO Dao = new AdPositionEntity.AdPositionDAO();
        List<AdPositionEntity> list = Dao.Find("", null);
        ListItem Litem = new ListItem("--请选择广告位置--", "0");
        PositionId.Items.Add(Litem);
        if (list != null && list.Count > 0)
        {
            foreach (AdPositionEntity entity in list)
            {
                ListItem item = new ListItem(entity.PositionName, entity.PositionId.ToString());
                PositionId.Items.Add(item);
            }
        }
    }
    private void DataBinds()
    {
        string StrWhere = " AdId>0";
        if (!string.IsNullOrEmpty(AdName.Value))
        {
            StrWhere += " and AdName like '%" + AdName.Value.ToString()+"%'";
        }
        if (PositionId.Value != "0")
        {
            StrWhere += " and PositionId=" + PositionId.Value;
        }
        if (!string.IsNullOrEmpty(StartTime.Value))
        {
            StrWhere += " and StartTime>='" + StartTime.Value+"'";
        }
        if (!string.IsNullOrEmpty(EndTime.Value))
        {
            StrWhere += " and EndTime<='" + EndTime.Value+"'";
        }
        
        Hashtable ht = new Hashtable();
        ht.Add("PositionId", "ASC");
        ht.Add("RankNum", "ASC");
        AdListEntity.AdListDAO Dao=new AdListEntity.AdListDAO();
        PagerList.RecordCount = Dao.GetPagerRowsCount(StrWhere, null);
        DataTable dt = Dao.GetPager(StrWhere, null, ht, 10, 1);
        if (dt != null && dt.Rows.Count > 0)
        {
            List.DataSource = dt;
        }
        List.DataBind();

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
    protected string GetPositinName(string Id)
    {
        AdPositionEntity.AdPositionDAO Dao = new AdPositionEntity.AdPositionDAO();
        AdPositionEntity entity = Dao.FindById(EConvert.ToLong(Id));
        return entity.PositionName;
    }
    protected void BtnSearch_Click(object sender, EventArgs e)
    {
        DataBinds();
    }
    private void Ajax()
    {
        if ((!string.IsNullOrEmpty(Request["is_ajax"])) && (Request["is_ajax"].ToString() == "1"))
        {
            string res = "";
            string act = Request["act"].ToString();
            string id = Request["id"].ToString();
            try
            {
                AdListEntity.AdListDAO Dao = new AdListEntity.AdListDAO();
                string Val = Common.FiltrationMaliciousCode(Request["val"].ToString());
                switch (act)
                {
                    case "edit open status":                        
                        string status = (Val == "0" ? "0" : "1");
                        bool result = Dao.UpdateSet(EConvert.ToInt(id), "IsOpen", status);
                        res = "{\"error\":0,\"message\":\"\",\"content\":\""+Val+"\"}";
                        break;
                    case "edit AdName":
                        bool NameResult = Dao.UpdateSet(EConvert.ToInt(id), "AdName", Val);
                        res = "{\"error\":0,\"message\":\"\",\"content\":\"" + Val + "\"}";
                        break;
                    case "edit AdLink":
                        bool LinkResult = Dao.UpdateSet(EConvert.ToInt(id), "AdLink", Val);
                        res = "{\"error\":0,\"message\":\"\",\"content\":\"" + Val + "\"}";
                        break;
                    case "edit RankNum":
                        bool RankResult = Dao.UpdateSet(EConvert.ToInt(id), "RankNum", Val);
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
            chk = (CheckBox)Item.FindControl("AdId");
            lab = (Label)Item.FindControl("ID");
            if (chk.Checked)
            {
                AdListEntity.AdListDAO Dao = new AdListEntity.AdListDAO();
                bool result = Dao.Delete(EConvert.ToInt(lab.Text));               
            }
        }
        DataBinds();
    }
}
