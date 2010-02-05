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

public partial class CoalSysManage_System_FriendLink : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Innit();
            DataBinds();
            ajax();
        }
    }
    private void Innit()
    {
        ListItem Litem = new ListItem("--请选择链接位置--", "0");
        CategoryId.Items.Add(Litem);
        LinkCategoryEntity.LinkCategoryDAO Dao = new LinkCategoryEntity.LinkCategoryDAO();
        List<LinkCategoryEntity> list = Dao.Find("", null);
        if (list != null && list.Count > 0)
        {
            foreach (LinkCategoryEntity entity in list)
            {
                ListItem item = new ListItem(entity.CategoryName, entity.CategoryId.ToString());
                CategoryId.Items.Add(item);
            }
        }
    }
    private void DataBinds()
    {
        string StrWhere = " LinkId>0";
        if (CategoryId.Value != "0")
        {
            StrWhere += " and CategoryId=" + CategoryId.Value;
        }
        FriendLinkEntity.FriendLinkDAO Dao = new FriendLinkEntity.FriendLinkDAO();
        PagerList.RecordCount = Dao.GetPagerRowsCount(StrWhere, null);
        Hashtable ht = new Hashtable();
        ht.Add("CategoryId", "ASC");
        ht.Add("ShowOrder", "ASC");
        List.DataSource = Dao.GetPager(StrWhere, null, ht, PagerList.PageSize, PagerList.CurrentPageIndex);
        List.DataBind();
    }
    /// <summary>
    /// 处理Ajax请求
    /// </summary>
    private void ajax()
    {
        if ((!string.IsNullOrEmpty(Request["is_ajax"])) && (Request["is_ajax"].ToString() == "1"))
        {
            string res = "";
            string act = Request["act"].ToString();
            string id = Request["id"].ToString();
            try
            {
                FriendLinkEntity.FriendLinkDAO Dao = new FriendLinkEntity.FriendLinkDAO();
                string Val = Common.FiltrationMaliciousCode(Request["val"].ToString());
                switch (act)
                {
                    case "edit LinkName":
                        bool result = Dao.UpdateSet(EConvert.ToInt(id), "LinkName", Val);
                        res = "{\"error\":0,\"message\":\"\",\"content\":\"" + Val + "\"}";
                        break;
                    case "edit LinkUrl":
                        bool NameResult = Dao.UpdateSet(EConvert.ToInt(id), "LinkUrl", Val);
                        res = "{\"error\":0,\"message\":\"\",\"content\":\"" + Val + "\"}";
                        break;
                    case "edit ShowOrder":
                        bool LinkResult = Dao.UpdateSet(EConvert.ToInt(id), "ShowOrder", Val);
                        res = "{\"error\":0,\"message\":\"\",\"content\":\"" + Val + "\"}";
                        break;                   
                    case "remove":
                        string url = Dao.FindById(EConvert.ToLong(id)).LinkLogo;
                        if (!string.IsNullOrEmpty(url))
                        {
                            IOFile.DeleteFile("", url);
                        }
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
    protected void BtnSearch_Click(object sender, EventArgs e)
    {
        DataBinds();
    }
    protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
    {
        PagerList.CurrentPageIndex = e.NewPageIndex;
        DataBinds();
    }
    protected string GetPositinName(string Id)
    {
        LinkCategoryEntity.LinkCategoryDAO Dao = new LinkCategoryEntity.LinkCategoryDAO();
        return Dao.FindById(EConvert.ToLong(Id)).CategoryName.ToString();
    }
    protected void BtnDelete_Click(object sender, EventArgs e)
    {
        CheckBox chk;
        Label lab;
        foreach (RepeaterItem Item in List.Items)
        {
            chk = (CheckBox)Item.FindControl("LinkId");
            lab = (Label)Item.FindControl("ID");
            if (chk.Checked)
            {
                FriendLinkEntity.FriendLinkDAO Dao = new FriendLinkEntity.FriendLinkDAO();
                string url = Dao.FindById(EConvert.ToLong(lab.Text)).LinkLogo;
                if (!string.IsNullOrEmpty(url))
                {
                    IOFile.DeleteFile("", url);
                }
                bool result = Dao.Delete(EConvert.ToInt(lab.Text));
            }
        }
        DataBinds();
    }
}
