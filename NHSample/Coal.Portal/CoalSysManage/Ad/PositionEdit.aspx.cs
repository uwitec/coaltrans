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

public partial class CoalSysManage_Ad_PositionEdit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Innit();    
        }

    }
    private void Innit()
    {
        string Id = Request["ID"].ToString();
        string act = Request["act"].ToString();
        if (!string.IsNullOrEmpty(Id) && act == "edit")
        {
            AdPositionEntity.AdPositionDAO Dao = new AdPositionEntity.AdPositionDAO();
            AdPositionEntity entity = Dao.FindById(EConvert.ToLong(Id));
            if (entity != null)
            {
                PositionName.Value = entity.PositionName.ToString();
                AdWidth.Value = entity.AdWidth.ToString();
                AdHeight.Value = entity.AdHeight.ToString();
                AdDetails.Value = entity.AdDetails;
                AdType.Value = entity.AdType.ToString();
            }
            BtnAdd.Visible = false;
        }
        if (act == "add")
        {
            BtnAdd.Visible = true;
        }
    }
    protected void BtnSubmit_Click(object sender, EventArgs e)
    {
        string Id = Request["ID"].ToString();
        string act = Request["act"].ToString();
        if (!string.IsNullOrEmpty(Id) && act == "edit")
        {
            AdPositionEntity.AdPositionDAO Dao = new AdPositionEntity.AdPositionDAO();
            AdPositionEntity entity = Dao.FindById(EConvert.ToLong(Id));
            entity.PositionName = Common.FiltrationMaliciousCode(PositionName.Value);
            entity.AdWidth = EConvert.ToInt(AdWidth.Value);
            entity.AdHeight = EConvert.ToInt(AdHeight.Value);
            entity.AdDetails = Common.FiltrationMaliciousCode(AdDetails.Value);
            entity.AdType = EConvert.ToInt(AdType.Value);
            try
            {
                Dao.Update(entity);
                MessageBox.ShowAndBack("修改成功！");
            }
            catch
            {
                message.InnerHtml = "修改失败！";
            }
        }
        if (Request["act"] == "add")
        {
            AdPositionEntity.AdPositionDAO Dao = new AdPositionEntity.AdPositionDAO();
            AdPositionEntity entity = new AdPositionEntity();
            entity.PositionName = Common.FiltrationMaliciousCode(PositionName.Value);
            entity.AdWidth = EConvert.ToInt(AdWidth.Value);
            entity.AdHeight = EConvert.ToInt(AdHeight.Value);
            entity.AdDetails = Common.FiltrationMaliciousCode(AdDetails.Value);
            entity.AdType = EConvert.ToInt(AdType.Value);
            try
            {
                Dao.Add(entity);
                message.InnerHtml = "添加成功！";
            }
            catch
            {
                message.InnerHtml = "添加失败！";
            }
        }
    }
    protected void BtnAdd_Click(object sender, EventArgs e)
    {
        PositionName.Value = "";
        AdWidth.Value = "";
        AdHeight.Value = "";
        AdDetails.Value = "";
        AdType.Value = "0";
    }
}
