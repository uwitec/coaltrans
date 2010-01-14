using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Coal.BLL;
using Coal.Entity;

public partial class Detail : System.Web.UI.Page
{
    long DetailID = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["ID"] != null)
            {
                DetailID = long.Parse(Request.QueryString["ID"].ToString());
                InitData(DetailID);
            }
        }
    }

    private bool AddClick(long id)
    {
        return false;// BusFacade.MeiTanBusFacade.AddClick(id);

    }

    private void InitData(long id)
    {
        TransListManager listManger = new TransListManager();
        CoalTransEntity entity = new CoalTransEntity();

        if (LoginContext.CurrentUser != null)
        {
            if (listManger.GetDetails(id, LoginContext.CurrentUser.UserEmail, ref entity))
            {
                if (entity != null)
                {
                    lblGongXu.Text = entity.Title;
                    lblFaBuRiQi.Text = entity.CreatedOn.Value.ToString("yyyy-MM-dd");
                    lblXinXiYouXiaoQi.Text = entity.ValidDate.Value.ToString("yyyy-MM-dd");
                    lblMeiZhong.Text = entity.CoalTypeName.ToString();
                    lblPinZhong.Text = entity.CategoryName.ToString();
                    lblTHSheng.Text = entity.ProvinceName.ToString();
                    lblTHShi.Text = entity.CityName.ToString();
                    
                    //lblShuLiang.Text = entity.ShuLiang.ToString();
                    lblJiaGe.Text = entity.Price.Value.ToString();
                    lblBaoJiaFangShi.Text = entity.WholesaleDes;
                    lblJieSuanFangShi.Text = entity.WholesaleDes;
                    lblFaReLiang.Text = entity.CalorificPower.ToString();
                    lblLiDu.Text = entity.GrainSize.ToString();
                    lblHanLiuLiang.Text = entity.SurfurContent.ToString();
                    lblHuiFen.Text = entity.AshContent.ToString();
                    lblShuiFen.Text = entity.WaterContent.ToString();
                    lblHuiFa.Text = entity.Volatility.ToString();
                    UserId.Value = entity.UserId.Value.ToString();
                    //lblGuDingTan.Text = entity.GuDingTan.ToString();
                    //lblJiXieQiangDu.Text = entity.JiXieQiangDu.ToString();
                    //lblGuiGe.Text = entity.GuiGe.ToString();
                    //lblKangSuiQiangDu.Text = entity.KangSuiQiangDu.ToString();
                    //lblLaiMoQianDu.Text = entity.LaiMoQianDu.ToString();
                    //lblFanYingXing.Text = entity.FanYingXing.ToString();
                    //lblQiKongLv.Text = entity.QiKongLv.ToString();
                    //lblJiaoMoHanLiang.Text = entity.JiaoMoHanLiang.ToString();
                    //lblLianJieZhiShu.Text = entity.LianJieZhiShu.ToString();
                    //lblReWenDingXing.Text = entity.ReWenDingXing.ToString();
                    //lblHuiRongRongXing.Text = entity.HuiRongRongXing.ToString();
                    //lblKeMoXing.Text = entity.KeMoXing.ToString();
                    //lblXiangXiLeiRong.Text = entity.XiangXiLeiRong;
                    //lblIsTiGongYunShu.Text = entity.IsTiGongYunShu;
                    //lblYunshuFangShi.Text = entity.YunshuFangShi;
                    //lblYunShuShuoMing.Text = entity.YunShuShuoMing;
                    //lblDianJiLiang.Text = entity.DianJiLiang.ToString();
                    //lblLianXiRen.Text = entity.LianXiRen;
                    //lblPhone.Text = entity.Phone;
                    //lblMail.Text = entity.Mail;
                    //lblFax.Text = entity.Fax;
                    //lblMobile.Text = entity.Mobile;
                    //lblProvince.Text = entity.Province;
                    //lblCity.Text = entity.City;
                    //lblAddress.Text = entity.Address;
                    //lblPostCode.Text = entity.PostCode;
                    //AddClick(id);
                }
            }
            else
            {
                Response.Redirect("login.aspx");
            }
        }
        else
        {
            Response.Redirect("login.aspx");
        }
    }
}
