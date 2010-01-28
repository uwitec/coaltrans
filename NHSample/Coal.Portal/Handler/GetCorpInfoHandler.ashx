<%@ WebHandler Language="C#" Class="GetCorpInfoHandler" %>

using System;
using System.Web;
using Coal.ViewModel;
using Coal.BLL;
using Coal.Util;

public class GetCorpInfoHandler : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        BindData(context);
    }

    private void BindData(HttpContext context)
    {
        CompanyInfoModel model = new CompanyInfoModel();
        UserManager.GetCorpInfo(LoginContext.CurrentUser.UserId, model);        
        ResultObject ro = new ResultObject();
        ro["txtAddress"] = model.Address;
        ro["txtBusinessScope"] = model.BusinessScope;
        ro["txtTrueName"] = model.CompanyName;
        ro["selCorpType"] = model.CompanyType;
        ro["txtEstablishDate"] = model.EstablishDate;
        ro["hdfCorpInfoId"] = model.ID;
        ro["txtIntro"] = model.Introduction;
        ro["txtLegalPerson"] = model.LegalPerson;
        ro["selOperType"] = model.OperateType;
        ro["txtRegisteredCapital"] = model.RegisteredCapital;
        ro["selProvince"] = model.Province;
        ro["selCity"] = model.City;
        ro["ID"] = model.ID;

        context.Response.Write(ro.ToJSONString());
    }

 
    public bool IsReusable {
        get {
            return false;
        }
    }

}