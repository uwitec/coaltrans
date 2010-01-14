using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Coal.BLL;
using Coal.ViewModel;
using Coal.Util;


public partial class coal_supply_publish : System.Web.UI.Page
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
        if (Request.Form["action"] == "1")
        {
            SaveSupplyInfo();
        }
    }
    private void SaveSupplyInfo()
    {
        CoalTransModel CoalTrans = new CoalTransModel();
        CoalTrans.Title = Common.FiltrationMaliciousCode(Request.Form["txtTitle"]);
        CoalTrans.Price = Convert.ToDecimal(Common.FiltrationMaliciousCode(Request.Form["txtPrice"]));
        CoalTrans.UserId = GetUserId(Context.Request.Cookies["login_info"].Value);
        CoalTrans.County=101001;
        CoalTrans.CountyName = "中国";
        CoalTrans.Province = Convert.ToInt32(Common.FiltrationMaliciousCode(Request.Form["selProvince"]));
        CoalTrans.ProvinceName = GetRegionName(Request.Form["selProvince"]);
        CoalTrans.City = Convert.ToInt32(Common.FiltrationMaliciousCode(Request.Form["selCity"]));
        CoalTrans.CityName = GetRegionName(Request.Form["selCity"]);
        CoalTrans.ZipCode = "";
        CoalTrans.CoalType = 1;
        CoalTrans.CoalTypeName = Common.FiltrationMaliciousCode(Request.Form["selCoalType"]);
        CoalTrans.Category = 1;
        CoalTrans.CategoryName = Common.FiltrationMaliciousCode(Request.Form["selCoalCategory"]);
        CoalTrans.CreatedOn = DateTime.Now;
        CoalTrans.ValidDate = Convert.ToDateTime(Request["txtValidDate"]);
        CoalTrans.WholesaleDes = null;
        CoalTrans.ShipDes = null;
        CoalTrans.Volatility = 1.00F;
        CoalTrans.GrainSize = 1.00F;
        CoalTrans.GrainSizeDes = "";
        CoalTrans.AshContent = 1.00F;
        CoalTrans.SurfurContent = 1.00F;
        CoalTrans.WaterContent = 1.00F;
        CoalTrans.CalorificPower = 1.00F;
        CoalTrans.TransType = 1;
        ResultObject ro = new ResultObject();
        if (UserManager.AddOrUpdataCoalTransInfo(CoalTrans))
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

    /// <summary>
    /// 获取用户ID
    /// </summary>
    /// <param name="Str">Coocie信息</param>
    /// <returns></returns>
    private int GetUserId(string Str)
    {
        if (Str == "")
        {
            return 0;
        }
        else
        {
            string[] userInfo = CryptoHelper.Decrypt(Str, "coalchina").Split('|');
            return Convert.ToInt32(userInfo[2]);
        }
    }

    /// <summary>
    /// 获取省份名称
    /// </summary>
    /// <param name="ID">省份对应ID</param>
    /// <returns></returns>
    private string GetRegionName(string ID)
    {
        if (ID == "-1")
        {
            return null;
        }
        else
        {
            RegionManager.Region Region = RegionManager.RegionMap.GetRegion(Convert.ToInt32(ID));
            return Region.Name;
        }
    }
}
