using System;
using System.Collections;
using System.Collections.Generic;
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
using System.IO;
using Coal.DAL;
using Coal.Util;

public partial class CoalSysManage_Ad_AdEdit : System.Web.UI.Page
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
        if (!string.IsNullOrEmpty(Request["act"]))
        {
            string act = Request["act"].ToString();
            string Id = Request["ID"].ToString();
            if (!string.IsNullOrEmpty(act) && act == "add")
            {
                positionInnit("");
                BtnAdd.Visible = true;
            }
            if (!string.IsNullOrEmpty(act) && act == "edit")
            {
                AdListEntity.AdListDAO Dao = new AdListEntity.AdListDAO();
                AdListEntity entity = Dao.FindById(EConvert.ToInt(Id));
                positionInnit(entity.PositionId.ToString());
                AdName.Value = entity.AdName;
                AdLink.Value = entity.AdLink;
                ExternalAdUrl.Value = entity.AdUrl;
                AdDesc.Value = entity.AdDesc;
                StartTime.Value = entity.StartTime.Value.ToString("yyyy-MM-dd");
                EndTime.Value = entity.EndTime.Value.ToString("yyyy-MM-dd");
                LinkMan.Value = entity.LinkMan;
                LinkPhone.Value = entity.LinkPhone;
                LinkEmail.Value = entity.LinkEmail;
                IsOpen.Value = entity.IsOpen.ToString();
                RankNum.Value = entity.RankNum.Value.ToString();
                BtnAdd.Visible = false;
            }
        }
        else
        {
            MessageBox.ShowAndBack("参数错误！");
        }
    }
    private void positionInnit(string id)
    {
        AdPositionEntity.AdPositionDAO Dao = new AdPositionEntity.AdPositionDAO();
        List<AdPositionEntity> list = Dao.Find("", null);
        ListItem FItem = new ListItem("--请选择广告位置--", "0");
        PositionId.Items.Add(FItem);
        if (list != null && list.Count > 0)
        {
            foreach (AdPositionEntity entity in list)
            {
                ListItem item = new ListItem(entity.PositionName, entity.PositionId.ToString());
                PositionId.Items.Add(item);
            }
        }
        if(id!="")
        {
            PositionId.Value=id;
        }
    }

    protected void BtnAdd_Click(object sender, EventArgs e)
    {
        positionInnit("");
        AdName.Value = "";
        AdLink.Value = "";
        AdDesc.Value = "";
        StartTime.Value = "";
        EndTime.Value = "";
        LinkMan.Value = "";
        LinkPhone.Value = "";
        LinkEmail.Value = "";
        IsOpen.Value = "0";
        RankNum.Value = "0";
    }
    protected void BtnSubmit_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(Request["act"]))
        {
            string act = Request["act"].ToString();
            string Id = Request["ID"].ToString();
            if (!string.IsNullOrEmpty(act) && act == "add")
            {
                AdListEntity.AdListDAO Dao = new AdListEntity.AdListDAO();
                AdListEntity entity = new AdListEntity();
                entity.PositionId = EConvert.ToInt(PositionId.Value);
                entity.AdName = Common.FiltrationMaliciousCode(AdName.Value);
                entity.AdLink = Common.FiltrationMaliciousCode(AdLink.Value);
                entity.AdDesc = Common.FiltrationMaliciousCode(AdDesc.Value);
                entity.StartTime = Convert.ToDateTime(StartTime.Value);
                entity.EndTime = Convert.ToDateTime(EndTime.Value);
                entity.LinkMan = Common.FiltrationMaliciousCode(LinkMan.Value);
                entity.LinkPhone = Common.FiltrationMaliciousCode(LinkPhone.Value);
                entity.LinkEmail = Common.FiltrationMaliciousCode(LinkEmail.Value);
                entity.IsOpen = EConvert.ToInt(IsOpen.Value);
                entity.RankNum = EConvert.ToInt(RankNum.Value);
                if (!string.IsNullOrEmpty(ExternalAdUrl.Value))
                {
                    entity.AdUrl = ExternalAdUrl.Value;
                }
                else
                {
                    entity.AdUrl = UploadFile(AdUrl);
                }
                entity.ClickNum = 0;
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
            if (!string.IsNullOrEmpty(act) && act == "edit")
            {
                AdListEntity.AdListDAO Dao = new AdListEntity.AdListDAO();
                AdListEntity entity = Dao.FindById(EConvert.ToInt(Id));
                entity.PositionId = EConvert.ToInt(PositionId.Value);
                entity.AdName = Common.FiltrationMaliciousCode(AdName.Value);
                entity.AdLink = Common.FiltrationMaliciousCode(AdLink.Value);
                entity.AdDesc = Common.FiltrationMaliciousCode(AdDesc.Value);
                if (!string.IsNullOrEmpty(ExternalAdUrl.Value))
                {
                    if (!string.IsNullOrEmpty(entity.AdUrl))
                    {
                        IOFile.DeleteFile("", entity.AdUrl);
                    }
                    entity.AdUrl = ExternalAdUrl.Value;
                }
                else
                {
                    if (!string.IsNullOrEmpty(entity.AdUrl))
                    {
                        IOFile.DeleteFile("", entity.AdUrl);
                    }
                    entity.AdUrl = UploadFile(AdUrl);
                }
                entity.StartTime = Convert.ToDateTime(StartTime.Value);
                entity.EndTime = Convert.ToDateTime(EndTime.Value);
                entity.LinkMan = Common.FiltrationMaliciousCode(LinkMan.Value);
                entity.LinkPhone = Common.FiltrationMaliciousCode(LinkPhone.Value);
                entity.LinkEmail = Common.FiltrationMaliciousCode(LinkEmail.Value);
                entity.IsOpen = EConvert.ToInt(IsOpen.Value);
                entity.RankNum = EConvert.ToInt(RankNum.Value);
                try
                {
                    Dao.Update(entity);
                    MessageBox.ShowAndRedirect("修改成功！", "AdList.aspx");
                }
                catch
                {
                    message.InnerHtml = "修改失败！";
                }
            }
        }
        else
        {
            MessageBox.ShowAndBack("参数错误！");
        }
    }

    private string UploadFile(HtmlInputFile FileUpLoad)
    {

        string strFile = "";
        string Filepath = FileUpLoad.PostedFile.FileName;
        if (!string.IsNullOrEmpty(Filepath))
        {
            FileInfo file = new FileInfo(Filepath);
            string extension = file.Extension.ToUpper();
            strFile = Common.RandNumber() + extension.ToLower();
            string path = ConfigurationManager.AppSettings["FCKeditor:UserFilesPath"].ToString();
            path = path + "Ad";
            IOFile.UploadFile(FileUpLoad, strFile, path);
            strFile = path + "/" + strFile;
        }
        return strFile;
    }
}
