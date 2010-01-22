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

public partial class IntegrityList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Request.Form["action"] == "search"&& (!string.IsNullOrEmpty(Request.QueryString["ID"])))
            {
                innit();
            }
        }
    }
    private void innit()
    {
        int userid = EConvert.ToInt(Request.QueryString["ID"]);
        int PageSize = EConvert.ToInt(Request.Form["page_size"]);
        int PageIndex = EConvert.ToInt(Request.Form["page_index"]);
        CompanyIntegrityEntity.CompanyIntegrityDAO Dao = new CompanyIntegrityEntity.CompanyIntegrityDAO();
        int rowCount = Dao.GetPagerRowsCount(" CompanyId=" + userid, null);
        DataTable dt = Dao.GetPager(" CompanyId=" + userid, null, "CreateTime", true, PageSize, PageIndex);
        if (dt != null && dt.Rows.Count > 0)
        {
            ResultObject ro = DataUtility.ConvertToResultObject(dt);
            ro["totalCount"] = rowCount;
            if (rowCount % PageSize == 0)
            {
                ro["pageCount"] = rowCount / PageSize;
            }
            else
            {
                ro["pageCount"] = rowCount / PageSize + 1;
            }
            Context.Response.Clear();
            Context.Response.Write(ro.ToJSONString());
            Context.Response.End();
        }
        else
        {

            ResultObject ro = new ResultObject();
            Context.Response.Clear();
            Context.Response.Write(ro.ToJSONString());
            Context.Response.End();
        }
    }
}
