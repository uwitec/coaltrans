using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Coal.Util;
using Coal.DAL;
using Coal.BLL;

public partial class coal_demand_publish : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
             if (LoginContext.CurrentUser == null)
                 Response.Redirect("login.aspx");
        }
        if (Request.Form["action"] == "1")
        {
            innit();
        }
    }
    private void innit()
    {
        DemandInfoEntity Model = new DemandInfoEntity();

        Model.UserId = LoginContext.CurrentUser.UserId;
        Model.DemandTitle = Common.FiltrationMaliciousCode(Request.Form["txtDemandTitle"]);
        Model.InfoIndate = Convert.ToDateTime(Common.FiltrationMaliciousCode(Request.Form["txtInfoIndate"]));
        Model.CoalType = Common.FiltrationMaliciousCode(Request.Form["selCoalType"]);
        Model.Granularity = Common.FiltrationMaliciousCode(Request.Form["selGranularity"]);
        Model.DemandQuantity = Common.FiltrationMaliciousCode(Request.Form["txtDemandQuantity"]);
        Model.DeliveryPlace = Request.Form["selProvince"] + "&" + Request.Form["selCity"];
        Model.CalorificPower = Common.FiltrationMaliciousCode(Request.Form["selCalorificPower"]);
        Model.Volatilize = Common.FiltrationMaliciousCode(Request.Form["txtVolatilize"]);
        Model.Ash = Common.FiltrationMaliciousCode(Request.Form["txtAsh"]);
        Model.Sulphur = Common.FiltrationMaliciousCode(Request.Form["txtSulphur"]);
        Model.Water = Common.FiltrationMaliciousCode(Request.Form["txtWater"]);
        Model.HotStability = Common.FiltrationMaliciousCode(Request.Form["txtHotStability"]);
        Model.AshFusing = Common.FiltrationMaliciousCode(Request.Form["txtAshFusing"]);
        Model.Wearproof = Common.FiltrationMaliciousCode(Request.Form["txtWearproof"]);
        Model.Carbon = Common.FiltrationMaliciousCode(Request.Form["selCarbon"]);
        Model.MaStrength = Common.FiltrationMaliciousCode(Request.Form["txtMaStrength"]);
        Model.BinderMark = Common.FiltrationMaliciousCode(Request.Form["txtBinderMark"]);
        Model.IsTransport = Convert.ToInt32(Request.Form["selIsTransport"]);
        Model.TransportPrice = Common.FiltrationMaliciousCode(Request.Form["txtTransportPrice"]);
        Model.EstimateStyle = Common.FiltrationMaliciousCode(Request.Form["txtEstimateStyle"]);
        Model.CreateTime = DateTime.Now;
        Model.IsAudit = 0;
        Model.Sequence = 9999;
        Model.ViewCount = 0;
        ResultObject ro = new ResultObject();
        if (UserManager.AddDemandInfo(Model))
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
