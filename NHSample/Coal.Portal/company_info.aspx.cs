using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Coal.BLL;
using Coal.ViewModel;
using Coal.Util;

public partial class company_info : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (LoginContext.CurrentUser == null)
            {
                Response.Redirect("login.aspx");
            }
        }

        //这个文件只区分 加载还是修改。
        if (Request.Form["action"] == "1")
        {
            SavaOrUpdate();
        }
    }

   
    private void SavaOrUpdate()
    {
        CompanyInfoModel corpInfoModel = new CompanyInfoModel();
        corpInfoModel.Address = Request.Form["txtAddress"];
        corpInfoModel.BusinessScope = Request.Form["txtBusinessScope"];
        corpInfoModel.CompanyName = Request.Form["txtTrueName"];
        corpInfoModel.CompanyType = EConvert.ToInt(Request.Form["selCorpType"]);
        corpInfoModel.EstablishDate = EConvert.ToDateTime(Request.Form["txtEstablishDate"]);
        corpInfoModel.Introduction = Request.Form["txtIntro"];
        corpInfoModel.LegalPerson = Request.Form["txtLegalPerson"];
        corpInfoModel.OperateType = EConvert.ToInt(Request.Form["selOperType"]);
        corpInfoModel.RegisteredCapital = EConvert.ToInt(Request.Form["txtRegisteredCapital"]);
        corpInfoModel.UserId = LoginContext.CurrentUser.UserId;
        corpInfoModel.ID = EConvert.ToInt(Request.Form["hdfCorpInfoId"]);
        corpInfoModel.Province = EConvert.ToInt(Request.Form["selProvince"]);
        corpInfoModel.City = EConvert.ToInt(Request.Form["selCity"]);
        //corpInfoModel.ZipCode = Request.Form[""];
        //txtWebSite
        ResultObject ro = new ResultObject();
        if (UserManager.AddOrUpdateCorpInfo(corpInfoModel))
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
}
