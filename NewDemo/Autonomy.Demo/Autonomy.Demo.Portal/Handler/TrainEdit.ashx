<%@ WebHandler Language="C#" Class="TrainEdit" %>

using System;
using System.Web;
using Autonomy.Demo.Dal;
using System.Text;
using Newtonsoft.Json;

public class TrainEdit : IHttpHandler {

    public void ProcessRequest(HttpContext context)
    {
        string act = context.Request["act"];
        string categoryId = context.Request["category_id"];
        string categoryName = context.Request["category_name"];
        string catePath = context.Request["cate_path"];
        string cateTraininfo = context.Request["cate_train_info"];
        string parentCate = context.Request["parent_cate"];
        CategoryEntity.CategoryDAO Dao = new CategoryEntity.CategoryDAO();        
        string jsonStr = string.Empty;
        switch (act)
        {
            case "remove":
                if (Dao.Delete(Convert.ToInt32(categoryId)))
                    jsonStr = "{\"act\":\"remove\",\"errorCode\":0}";                 
                break;
            case "add":
                if (!string.IsNullOrEmpty(categoryName))
                {
                    CategoryEntity Addentity = new CategoryEntity();
                    Addentity.CategoryID = 2;
                    Addentity.CategoryName = categoryName;
                    Addentity.DataBaseId = "0";
                    Addentity.CatePath = catePath;
                    Addentity.CateTrainInfo = cateTraininfo;
                    Addentity.ParentCate = Convert.ToInt32(parentCate);
                    Dao.Add(Addentity);
                    jsonStr = "{\"act\":\"add\",\"errorCode\":0}";
                }                  
                break;
            case "innit_edit":                    
                CategoryEntity entity = Dao.FindById(Convert.ToInt64(categoryId));
                jsonStr = JavaScriptConvert.SerializeObject(entity).ToString();
                break;
            case "edit":
                CategoryEntity Editentity = Dao.FindById(Convert.ToInt64(categoryId));
                Editentity.CategoryName = categoryName;
                Editentity.CatePath = catePath;
                Editentity.CateTrainInfo = cateTraininfo;
                Editentity.ParentCate = Convert.ToInt32(parentCate);
                Dao.Update(Editentity);
                jsonStr = "{\"act\":\"edit\",\"errorCode\":0}";
                break;
            default:
                break;
        }
        context.Response.Write(jsonStr);        
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}