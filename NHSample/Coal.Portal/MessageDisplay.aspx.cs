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

public partial class MessageDisplay : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        { 
            if(!string.IsNullOrEmpty(Request.QueryString["ID"]))
            {
                long ID = EConvert.ToLong(Request.QueryString["ID"]);
                CompanyMessageEntity.CompanyMessageDAO Dao = new CompanyMessageEntity.CompanyMessageDAO();
                CompanyMessageEntity entity = Dao.FindById(ID);
                lbtitle.Text = entity.MessageTitle;
                lbcontent.Text = "<br/>"+entity.MessageContent;
                if (entity.IsSee.Value == 0)
                {
                    entity.IsSee = 1;
                    Dao.Update(entity);
                }
            }
        }
    }
}
