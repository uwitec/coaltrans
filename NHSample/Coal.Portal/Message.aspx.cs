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
using Coal.BLL;
using Coal.Util;

public partial class Message : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void BtnSubmit_Click(object sender, EventArgs e)
    {
        //int Sender = 1;
        //int embracer = 2;
        //int IsSee = 0;
        //string MessageTitle = "测试";
        //string MessageContent = "测试内容";
        //int ParentId = 0;
        CompanyMessageEntity Entity = new CompanyMessageEntity();
        Entity.Sender = 1;
        Entity.embracer =Convert.ToInt32(Request["ID"]);
        Entity.IsSee = 0;
        Entity.MessageTitle = Common.FiltrationMaliciousCode(MessageTitle.Value);
        Entity.MessageContent = Common.FiltrationMaliciousCode(MessageContent.Value);
        Entity.ParentId = 0;
        AddMessage(Entity);        
    }
    private bool AddMessage(CompanyMessageEntity Entity)
    {
        try
        {
            CompanyMessageEntity.CompanyMessageInfoDao MessageInfoDao = new CompanyMessageEntity.CompanyMessageInfoDao();
            MessageInfoDao.Add(Entity);
            return true;
        }
        catch
        {
            return false;
        }        
    }
}
