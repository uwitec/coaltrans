using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Detail : System.Web.UI.Page
{
    int DetailID = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["ID"] != null)
            {
                DetailID = int.Parse(Request.QueryString["ID"].ToString());
                InitData(DetailID);
            }
        }
    }
    private bool AddClick(int id)
    {
        return false;// BusFacade.MeiTanBusFacade.AddClick(id);

    }
    private void InitData(int id)
    {
        //BusEntity.MeiTanBusEntity obj = BusFacade.MeiTanBusFacade.GetEntity(id);

        //lblGongXu.Text = obj.GongXu;
        //lblFaBuRiQi.Text = obj.FaBuRiQi.ToString("yyyy-MM-dd") == "1900-01-01" ? "----" : obj.FaBuRiQi.ToString("yyyy-MM-dd");
        //lblXinXiYouXiaoQi.Text = obj.XinXiYouXiaoQi.ToString("yyyy-MM-dd") == "1900-01-01" ? "----" : obj.XinXiYouXiaoQi.ToString("yyyy-MM-dd");
        //lblMeiZhong.Text = obj.MeiZhong;
        //lblPinZhong.Text = obj.PinZhong;
        //lblTHSheng.Text = obj.THSheng;
        //lblTHShi.Text = obj.THShi;
        //lblJHSheng.Text = obj.JHSheng;
        //lblJHShi.Text = obj.JHShi;
        //lblShuLiang.Text = obj.ShuLiang.ToString();
        //lblJiaGe.Text = obj.JiaGe.ToString();
        //lblBaoJiaFangShi.Text = obj.BaoJiaFangShi;
        //lblJieSuanFangShi.Text = obj.JieSuanFangShi;
        //lblFaReLiang.Text = obj.FaReLiang.ToString();
        //lblLiDu.Text = obj.LiDu.ToString();
        //lblHanLiuLiang.Text = obj.HanLiuLiang.ToString();
        //lblHuiFen.Text = obj.HuiFen.ToString();
        //lblShuiFen.Text = obj.ShuiFen.ToString();
        //lblHuiFa.Text = obj.HuiFa.ToString();
        //lblGuDingTan.Text = obj.GuDingTan.ToString();
        //lblJiXieQiangDu.Text = obj.JiXieQiangDu.ToString();
        //lblGuiGe.Text = obj.GuiGe.ToString();
        //lblKangSuiQiangDu.Text = obj.KangSuiQiangDu.ToString();
        //lblLaiMoQianDu.Text = obj.LaiMoQianDu.ToString();
        //lblFanYingXing.Text = obj.FanYingXing.ToString();
        //lblQiKongLv.Text = obj.QiKongLv.ToString();
        //lblJiaoMoHanLiang.Text = obj.JiaoMoHanLiang.ToString();
        //lblLianJieZhiShu.Text = obj.LianJieZhiShu.ToString();
        //lblReWenDingXing.Text = obj.ReWenDingXing.ToString();
        //lblHuiRongRongXing.Text = obj.HuiRongRongXing.ToString();
        //lblKeMoXing.Text = obj.KeMoXing.ToString();
        //lblXiangXiLeiRong.Text = obj.XiangXiLeiRong;
        //lblIsTiGongYunShu.Text = obj.IsTiGongYunShu;
        //lblYunshuFangShi.Text = obj.YunshuFangShi;
        //lblYunShuShuoMing.Text = obj.YunShuShuoMing;
        //lblDianJiLiang.Text = obj.DianJiLiang.ToString();
        //lblLianXiRen.Text = obj.LianXiRen;
        //lblPhone.Text = obj.Phone;
        //lblMail.Text = obj.Mail;
        //lblFax.Text = obj.Fax;
        //lblMobile.Text = obj.Mobile;
        //lblProvince.Text = obj.Province;
        //lblCity.Text = obj.City;
        //lblAddress.Text = obj.Address;
        //lblPostCode.Text = obj.PostCode;
        //AddClick(id);

    }
}
