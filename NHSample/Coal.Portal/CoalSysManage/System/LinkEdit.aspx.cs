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
using Coal.DAL;
using Coal.Util;
using System.IO;

public partial class CoalSysManage_System_LinkEdit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (!string.IsNullOrEmpty(Request["act"]) && Request["act"] == "add")
            {
                Innit("");
                BtnAdd.Visible = true;
            }
            if (!string.IsNullOrEmpty(Request["act"]) && Request["act"] == "edit")
            {
                int Id = EConvert.ToInt(Request["ID"]);
                Databind(Id);
            }
        }
    }
    private void Databind(int id)
    {
        FriendLinkEntity.FriendLinkDAO Dao = new FriendLinkEntity.FriendLinkDAO();
        FriendLinkEntity entity = Dao.FindById(EConvert.ToLong(id));
        Innit(entity.CategoryId.ToString());
        LinkName.Value = entity.LinkName;
        LinkUrl.Value = entity.LinkUrl;
        ExternalLogo.Value = entity.LinkLogo;
        LinkDesc.Value = entity.LinkDesc;
        ShowOrder.Value = entity.ShowOrder.ToString();
        BtnAdd.Visible = false;
    }
    private void Innit(string Id)
    {
        ListItem Litem = new ListItem("--请选择位置--", "0");
        CategoryId.Items.Add(Litem);
        LinkCategoryEntity.LinkCategoryDAO Dao = new LinkCategoryEntity.LinkCategoryDAO();
        List<LinkCategoryEntity> list = Dao.Find("", null);
        foreach (LinkCategoryEntity obj in list)
        {
            ListItem item = new ListItem(obj.CategoryName, obj.CategoryId.ToString());
            CategoryId.Items.Add(item);
        }
        if (!string.IsNullOrEmpty(Id))
        {
            CategoryId.Value = Id;
        }
    }
    protected void BtnSubmit_Click(object sender, EventArgs e)
    {
        string act = Request["act"];
        if (!string.IsNullOrEmpty(act) && act == "add")
        {
            FriendLinkEntity.FriendLinkDAO Dao = new FriendLinkEntity.FriendLinkDAO();
            FriendLinkEntity entity = new FriendLinkEntity();
            entity.CategoryId = EConvert.ToInt(CategoryId.Value);
            entity.LinkName = LinkName.Value;
            entity.LinkUrl = LinkUrl.Value;
            entity.LinkDesc = LinkDesc.Value;
            entity.ShowOrder = EConvert.ToInt(ShowOrder.Value);
            if (!string.IsNullOrEmpty(ExternalLogo.Value))
            {
                entity.LinkLogo = ExternalLogo.Value;
            }
            else
            {
                entity.LinkLogo = UploadFile(LinkLogo);
            }
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
            string ID = Request["ID"];
            FriendLinkEntity.FriendLinkDAO Dao = new FriendLinkEntity.FriendLinkDAO();
            FriendLinkEntity entity = Dao.FindById(EConvert.ToLong(ID));
            entity.CategoryId = EConvert.ToInt(CategoryId.Value);
            entity.LinkName = LinkName.Value;
            entity.LinkUrl = LinkUrl.Value;
            entity.LinkDesc = LinkDesc.Value;
            entity.ShowOrder = EConvert.ToInt(ShowOrder.Value);
            if (!string.IsNullOrEmpty(ExternalLogo.Value))
            {                
                entity.LinkLogo = ExternalLogo.Value;
            }
            else
            {
                if (!string.IsNullOrEmpty(entity.LinkLogo))
                {
                    IOFile.DeleteFile("", entity.LinkLogo);
                }
                entity.LinkLogo = UploadFile(LinkLogo);
            }
            try
            {
                Dao.Update(entity);
                MessageBox.ShowAndRedirect("修改成功！", "FriendLink.aspx");
            }
            catch
            {
                message.InnerHtml = "修改失败！";
            }
        }
    }
    protected void BtnAdd_Click(object sender, EventArgs e)
    {
        Innit("");
        LinkName.Value = "";
        LinkUrl.Value = "";
        ExternalLogo.Value = "";
        LinkDesc.Value = "";
        ShowOrder.Value = "0";
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
            path = path + "Link";
            IOFile.UploadFile(FileUpLoad, strFile, path);
            strFile = path + "/" + strFile;
        }
        return strFile;
    }
}
