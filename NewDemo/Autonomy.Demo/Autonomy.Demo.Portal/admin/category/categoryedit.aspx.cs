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
using Autonomy.Demo.Dal;

public partial class demo_admin_category_categoryedit : System.Web.UI.Page
{
    private CategoryEntity.CategoryDAO Dao = new CategoryEntity.CategoryDAO();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ParentCateInnit(0, 1);
            if (!string.IsNullOrEmpty(Request["act"]) && Request["act"] == "add")
            {
                Innit("", "");                
                ParentCate.Value = "-1";
                BtnAdd.Visible = true;
            }
            else if (!string.IsNullOrEmpty(Request["act"]) && Request["act"] == "edit")
            {
                long Id = Convert.ToInt64(Request["ID"]);
                BtnAdd.Visible = false;
                Databind(Id);
            }    
        }
    }
    private void Databind(long Id)
    {
        CategoryEntity entity = Dao.FindById(Id);
        CategoryID.Value = entity.CategoryID.Value.ToString();
        CategoryName.Value = entity.CategoryName;        
        if (!string.IsNullOrEmpty(entity.CateSource))
            CateSource.Value = entity.CateSource;        
        if (!string.IsNullOrEmpty(entity.CatePath))
            CatePath.Value = entity.CatePath;
        if (!string.IsNullOrEmpty(entity.CreateBy))
            CreateBy.Value = entity.CreateBy;
        if (!string.IsNullOrEmpty(entity.CateTrainInfo))
            CateTrainInfo.Value = entity.CateTrainInfo;
        Innit(entity.CateType.ToString(), entity.DataBaseId);
        ParentCate.Value = entity.ParentCate.Value.ToString();
    }
    private void Innit(string cateTypeID, string dataBeseId)
    {
        if (!string.IsNullOrEmpty(cateTypeID))
        {
            CateType.Value = cateTypeID.ToString();
        }
        if (!string.IsNullOrEmpty(dataBeseId))
        {
            DataBase.Value = dataBeseId.ToString();
        }
        
    }
    private void ParentCateInnit(int ParentCateId, int level)
    {
        string str = string.Empty;
        for (int i = 1; i < level; i++)
            str += "&nbsp;";
        level++;        
        IList<CategoryEntity> entityList = Dao.Find(" ParentCate=" + ParentCateId, null);
        foreach (CategoryEntity entity in entityList)
        {
            ListItem item = new ListItem(HttpUtility.HtmlDecode(str) + entity.CategoryName, entity.ID.ToString());
            ParentCate.Items.Add(item);
            ParentCateInnit(entity.ID.Value, level);
        }       
    }
    protected void BtnAdd_Click(object sender, EventArgs e)
    {
        CategoryID.Value = "";
        CategoryName.Value = "";
        DataBase.Value = "0";
        CateSource.Value = "";
        CateType.Value = "0";
        CatePath.Value = "";
        CateTrainInfo.Value = "";
        ParentCate.Value = "-1";
        CreateBy.Value = "";
    }
    protected void BtnSubmit_Click(object sender, EventArgs e)
    {
        string act = Request["act"];
        if (!string.IsNullOrEmpty(act) && act == "add")
        {
            CategoryEntity entity = new CategoryEntity();
            entity.CategoryID = Convert.ToInt32(CategoryID.Value);
            entity.CategoryName = CategoryName.Value;
            entity.DataBaseId = DataBase.Value;
            entity.CateSource = CateSource.Value;
            entity.CateType = Convert.ToInt32(CateType.Value);
            entity.CatePath = CatePath.Value;
            entity.CreateBy = CreateBy.Value;
            entity.CateTrainInfo = CateTrainInfo.Value;
            entity.ParentCate = Convert.ToInt32(ParentCate.Value);
            entity.CreateTime = DateTime.Now;
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
        else if (!string.IsNullOrEmpty(act) && act == "edit")
        {
            string ID = Request["ID"];
            CategoryEntity entity = Dao.FindById(Convert.ToInt64(ID));
            entity.CategoryID = Convert.ToInt32(CategoryID.Value);
            entity.CategoryName = CategoryName.Value;
            entity.DataBaseId = DataBase.Value;
            entity.CateSource = CateSource.Value;
            entity.CateType = Convert.ToInt32(CateType.Value);
            entity.CatePath = CatePath.Value;
            entity.CreateBy = CreateBy.Value;
            entity.CateTrainInfo = CateTrainInfo.Value;
            entity.ParentCate = Convert.ToInt32(ParentCate.Value);                       
            try
            {
                Dao.Update(entity);
                Response.Write("<script>alert('修改成功！');window.location.href='categoryList.aspx';</script>");
            }
            catch
            {
                message.InnerHtml = "修改失败！";
            }
        }
    }
}
