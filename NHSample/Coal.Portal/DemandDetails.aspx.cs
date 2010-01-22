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
using Coal.Entity;
using Coal.BLL;
using Coal.ViewModel;

public partial class DemandDetails : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (LoginContext.CurrentUser != null)
            {
                long ID =EConvert.ToLong(Request.QueryString["ID"]);
                DataInnit(ID);
                
            }
            else
            {
                Response.Redirect("login.aspx");
            }
        }
    }
    private void DataInnit(long ID)
    {
        DemandInfoEntity entity = new DemandInfoEntity();
        DemandInfoEntity.DemandInfoDAO Dao = new DemandInfoEntity.DemandInfoDAO();
        entity = Dao.FindById(ID);
        txtDemandTitle.Text = entity.DemandTitle.ToString();//给标题赋值
        txtCoalType.Text = entity.CoalType;//给煤种赋值
        txtDemandQuantity.Text = entity.DemandQuantity+"吨";
        txtDeliveryPlace.Text = GetArea(entity.DeliveryPlace);
        txtCalorificPower.Text = entity.CalorificPower;
        txtGranularity.Text = entity.Granularity;
        txtAsh.Text = entity.Ash;
        txtSulphur.Text = entity.Sulphur;
        txtWater.Text = entity.Water;
        txtHotStability.Text = entity.HotStability;
        txtAshFusing.Text = entity.AshFusing;
        txtWearproof.Text = entity.Wearproof;
        txtCarbon.Text = entity.Carbon;
        txtMaStrength.Text = entity.MaStrength;
        txtBinderMark.Text = entity.BinderMark;
        txtVolatilize.Text = entity.Volatilize;
        txtIsTransport.Text = GetStr(entity.IsTransport.Value);
        txtTransportPrice.Text = entity.TransportPrice;
        txtEstimateStyle.Text =entity.EstimateStyle;
        UserId.Value = entity.UserId.ToString();
        txtfbdate.Text = entity.CreateTime.Value.ToString("yyyy年MM月dd日");
        txtEnddate.Text = entity.InfoIndate.Value.ToString("yyyy年MM月dd日");
        contactInfoInnit(entity.UserId.Value);
    }

    private void contactInfoInnit(int UserId)
    {
        UserInfoModel model = new UserInfoModel();
        UserManager.GetUserInfo(UserId, model);
        lblLianXiRen.Text = model.TrueName;
        lblPhone.Text = model.FixedTel;
        lblMobile.Text = model.MobileTel;
        lblFax.Text = model.Fax;
        lblMail.Text = model.BizEmail;
        //lblPostCode.Text=model.

    }

    private string GetArea(string Str)
    {
        string[] list = Str.Split('&');
        string province = GetStr(list[0]);
        string City = GetStr(list[1]);
        return province +"   "+ City;
    }
    private string GetStr(string ID)
    {
        RegionEntity.RegionDAO Dao = new RegionEntity.RegionDAO();
        RegionEntity entity = Dao.FindById(EConvert.ToLong(ID));
        return entity.Name;
    }
    private string GetStr(int num)
    {
        string str = "不需要";
        if (num == 1)
        {
            str= "需要";
        }
        return str;
    }
}
