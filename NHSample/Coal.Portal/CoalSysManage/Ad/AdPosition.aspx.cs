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
using Coal.Entity;
using Coal.BLL;
using Coal.Util;

public partial class CoalSysManage_Ad_AdPosition : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            AdsBind();
            //Innit();
            ajax();
        }
    }
    private void Innit()
    { 
        
    }
    private void AdsBind()
    {
        string StrWhere = "PositionId>0";
        if (!string.IsNullOrEmpty(PositionName.Value))
        {
            StrWhere += " and PositionName like '%" + PositionName.Value.Trim() + "%'";
        }
        if (AdType.Value != "0")
        {
            StrWhere += " and AdType=" + AdType.Value;
        }
        AdPositionEntity.AdPositionDAO Dao = new AdPositionEntity.AdPositionDAO();
        ListPager.RecordCount = Dao.GetPagerRowsCount(StrWhere,null);
        DataTable dt = Dao.GetPager(StrWhere, null, "", false, ListPager.PageSize, ListPager.CurrentPageIndex);
        List.DataSource = dt;
        List.DataBind();
    }
    protected void ListPager_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
    {
        ListPager.CurrentPageIndex = e.NewPageIndex;
        AdsBind();
    }
    protected void BtnSearch_Click(object sender, EventArgs e)
    {
        AdsBind();
    }
    private void ajax()
    {
        if ((!string.IsNullOrEmpty(Request["is_ajax"])) && (Request["is_ajax"].ToString() == "1"))
        {
            string res = "";
            string act = Request["act"].ToString();
            string id = Request["id"].ToString();
            try
            {
                AdPositionEntity.AdPositionDAO Dao = new AdPositionEntity.AdPositionDAO();
                switch (act)
                {
                    case "edit position name":
                        string Val = Common.FiltrationMaliciousCode(Request["val"].ToString());
                        bool result = Dao.UpdateSet(EConvert.ToInt(id), "PositionName", Val);
                        res = "{\"error\":0,\"message\":\"\",\"content\":\"" + Val + "\"}";
                        break;
                    case "edit position width":
                        string WidthVal = Common.FiltrationMaliciousCode(Request["val"].ToString());
                        bool widthresult = Dao.UpdateSet(EConvert.ToInt(id), "AdWidth", WidthVal);
                        res = "{\"error\":0,\"message\":\"\",\"content\":\"" + WidthVal + "\"}";
                        break;
                    case "edit position height":
                        string HeightVal = Common.FiltrationMaliciousCode(Request["val"].ToString());
                        bool HeightResult = Dao.UpdateSet(EConvert.ToInt(id), "AdHeight", HeightVal);
                        res = "{\"error\":0,\"message\":\"\",\"content\":\"" + HeightVal + "\"}";
                        break;
                    case "remove":
                        bool RemoveResult = Dao.Delete(EConvert.ToInt(id));
                        if (!RemoveResult)
                        {
                            res = "{\"error\":0,\"message\":\"删除失败，该类型下存在广告列表！\",\"content\":\"0\"}";
                        }
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
    protected string GetType(string type)
    {
        switch (type)
        { 
            case "1":
                return "图片";
                break;
            case "2":
                return "Flash";
                break;
            case "3":
                return "文字";
                break;
            case "4":
                return "JavaScript代码";
                break;
            default:
                return "";
                break;
        }
    }
    protected void BtnDelete_Click(object sender, EventArgs e)
    {
        CheckBox chk;
        Label lab;
        string StrId = "";
        foreach (RepeaterItem Item in List.Items)
        {
            chk = (CheckBox)Item.FindControl("PositionId");
            lab = (Label)Item.FindControl("ID");
            if (chk.Checked)
            {
                AdPositionEntity.AdPositionDAO Dao = new AdPositionEntity.AdPositionDAO();
                bool result = Dao.Delete(EConvert.ToInt(lab.Text));
                if (!result)
                {
                    StrId += lab.Text + " ";
                }
            }
        }
        if (StrId != "")
        {
            Response.Write("<script>alert('编号为：" + StrId + "的信息与其他信息关联，不能删除！');</script>");
        }
        AdsBind();
    }
}
