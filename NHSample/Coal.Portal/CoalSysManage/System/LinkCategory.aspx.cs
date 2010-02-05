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

public partial class CoalSysManage_System_LinkCategory : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DataBinds();
            ajax();
        }
    }
    private void DataBinds()
    {
        LinkCategoryEntity.LinkCategoryDAO Dao = new LinkCategoryEntity.LinkCategoryDAO();
        PagerList.RecordCount = Dao.GetPagerRowsCount("", null);
        DataTable dt = Dao.GetPager("", null, null, PagerList.PageSize, PagerList.CurrentPageIndex);
        List.DataSource = dt;
        List.DataBind();
    }
    private void ajax()
    {
        if (!string.IsNullOrEmpty(Request["is_ajax"]) && Request["is_ajax"] == "1")
        {
            string res = "";
            string act = Request["act"].ToString();
            string id = Request["id"].ToString();
            try
            {
                LinkCategoryEntity.LinkCategoryDAO Dao = new LinkCategoryEntity.LinkCategoryDAO();
                string Val = Common.FiltrationMaliciousCode(Request["val"].ToString());
                switch (act)
                {
                    case "edit CategoryName":
                        bool RankResult = Dao.UpdateSet(EConvert.ToInt(id), "CategoryName", Val);
                        res = "{\"error\":0,\"message\":\"\",\"content\":\"" + Val + "\"}";
                        break;
                    case "remove":                        
                        bool DelResult = Dao.Delete(EConvert.ToInt(id));
                        if (!DelResult)
                        {
                            res = "{\"error\":0,\"message\":\"该位置下存在列表，不能删除！\",\"content\":\"" + Val + "\"}";                           
                        }
                        break;
                    case "Add Record":
                        if (!string.IsNullOrEmpty(Val))
                        {                            
                            LinkCategoryEntity entity = new LinkCategoryEntity();
                            entity.CategoryName = Val;
                            Dao.Add(entity);
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
    protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
    {
        PagerList.CurrentPageIndex = e.NewPageIndex;
        DataBinds();
    }
    //protected void Button1_Click(object sender, EventArgs e)
    //{
    //    string Name = CategoryName.Value;
    //    if (!string.IsNullOrEmpty(Name))
    //    {
    //        LinkCategoryEntity.LinkCategoryDAO Dao = new LinkCategoryEntity.LinkCategoryDAO();
    //        LinkCategoryEntity entity = new LinkCategoryEntity();
    //        entity.CategoryName = Name;
    //        Dao.Add(entity);
    //    }
        
    //}
}
