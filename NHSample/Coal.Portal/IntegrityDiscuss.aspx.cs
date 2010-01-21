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

public partial class IntegrityDiscuss : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Request.Form["action"] == "add")
            {
                addInnit();
            }
            
        }
    }
    private void addInnit()
    {
        CompanyIntegrityEntity entity = new CompanyIntegrityEntity();
        entity.CompanyId = EConvert.ToInt(Request.QueryString["UserId"]);
        entity.Integritynumber = EConvert.ToInt(Request.Form["txtIntegritynumber"]);
        entity.Content = Common.textareaUnEscape(Request.Form["txtContent"]);
        entity.Discusser = 0;
        if (LoginContext.CurrentUser != null)
        {
            entity.Discusser = LoginContext.CurrentUser.UserId;
        }
        ResultObject ro = new ResultObject();
        if (addorupdate(entity))
        {
            ro.StatusCode = 1;
        }
        else
        {
            ro.StatusCode = -1;
            ro.ErrorCode = 1;
        }
        Response.Write(ro.ToJSONString());
        Response.End();
    }
    private bool addorupdate(CompanyIntegrityEntity entity)
    {
        CompanyIntegrityEntity.CompanyIntegrityDAO Dao = new CompanyIntegrityEntity.CompanyIntegrityDAO();
        try
        {
            if (entity.ID > 0)
            {
                Dao.Update(entity);
            }
            else
            {
                Dao.Add(entity);
            }
            return true;
        }
        catch
        {
            return false;
        }
    }
}
