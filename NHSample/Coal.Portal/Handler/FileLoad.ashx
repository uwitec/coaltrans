<%@ WebHandler Language="C#" Class="FileLoad" %>

using System;
using System.Web;
using System.IO;
using System.Configuration;
using Coal.Util;

public class FileLoad : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.Clear();
        string count = context.Request.Form["txtName"];     
        if (context.Request.Files.Count > 0)
        {
            HttpPostedFile file = context.Request.Files[0];
            string FileName = UploadFile(file);
            context.Response.Write("{'error':'',msg:'ok'}");
        }
        else
        {
            context.Response.Write("{'error':'error'}");
        }
        context.Response.End(); 
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }
    private string UploadFile(HttpPostedFile FileUpLoad)
    {

        string strFile = "";
        string Filepath = FileUpLoad.FileName;
        if (!string.IsNullOrEmpty(Filepath))
        {
            FileInfo file = new FileInfo(Filepath);
            string extension = file.Extension.ToUpper();
            strFile = Common.RandNumber() + extension.ToLower();
            string path = ConfigurationManager.AppSettings["FCKeditor:UserFilesPath"].ToString();
            path = path + "Info";
            IOFile.UploadFile(FileUpLoad, strFile, path);
            strFile = path + "/" + strFile;
        }
        return strFile;
    }

}