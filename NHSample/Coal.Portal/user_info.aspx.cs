using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Coal.ViewModel;
using Coal.BLL;
using Coal.Util;

public partial class user_info : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (LoginContext.CurrentUser == null)
            {
                Response.Redirect("login.aspx");
            }
            BindData();
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        UserInfoModel userInfo = new UserInfoModel();
        userInfo.BizEmail = this.tbxEmail.Text;
        //userInfo.CorpName;
        userInfo.Fax = this.tbxFax.Text;
        userInfo.FixedTel = this.tbxFixedTel.Text;
        userInfo.MobileTel = this.tbxMoblieTel.Text;
        userInfo.Occupation = this.ddlOccupation.SelectedValue;
        userInfo.TrueName = this.tbxTrueName.Text;
        userInfo.UserId = LoginContext.CurrentUser == null ? -1 : LoginContext.CurrentUser.UserId;
        userInfo.ID = EConvert.ToInt(this.hfInfoId.Value);

        if (UserManager.AddOrUpdateInfo(userInfo))
        {
            this.lblMsg.Text = "操作成功";
        }
        else
        {
            this.lblMsg.Text = "操作失败";
        }
    }

    private void BindData()
    {
        UserInfoModel model = new UserInfoModel();
        UserManager.GetUserInfo(LoginContext.CurrentUser.UserId, model);
        this.tbxEmail.Text = model.BizEmail;
        this.tbxFax.Text = model.Fax;
        this.tbxFixedTel.Text= model.FixedTel;
        this.tbxMoblieTel.Text= model.MobileTel;
        this.ddlOccupation.SelectedValue = model.Occupation;
        this.tbxTrueName.Text= model.TrueName;
        this.hfInfoId.Value = model.ID.ToString();
    }
}
