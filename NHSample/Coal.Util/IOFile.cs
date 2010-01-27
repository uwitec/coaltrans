using System;
using System.Web;
using System.Data;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Net;

namespace Coal.Util
{
    /// <summary>
    /// 文件读写类
    /// </summary>
    public class IOFile
    {
        /// <summary>
        /// 保存文件
        /// </summary>
        /// <param name="strPath">输出路径</param>
        /// <param name="strFileName">输出的文件名</param>
        /// <param name="strHtml">文件内容</param>
        /// <param name="coding">字符编码</param>
        /// <returns>是否成功</returns>
        public static bool SaveFile(string strPath, string strFileName, string strHtml, Encoding coding)
        {
            try
            {
                CheckDir(strPath);//检测路径
                string path = Path.Combine(strPath, strFileName);
                StreamWriter sw = new StreamWriter(path, false, coding);
                sw.Write(strHtml);
                sw.Flush();
                sw.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 检测路径存不存在，不存在即创建
        /// </summary>
        /// <param name="strPath"></param>
        public static void CheckDir(string strPath)
        {
            if (!Directory.Exists(strPath))
            {
                Directory.CreateDirectory(strPath);
            }
        }

        /// <summary>
        /// 读取文件
        /// </summary>
        /// <param name="strFilePath">需要读的html文件的路径</param>
        /// <param name="strFileName">文件名</param>
        /// <param name="coding">编码</param>
        /// <returns>读取出来的字符</returns>
        public static string GetFile(string strFilePath, string strFileName, Encoding coding)
        {
            StringBuilder strHtml = new StringBuilder();
            try
            {
                string file = Path.Combine(strFilePath, strFileName);
                if (System.IO.File.Exists(file))
                {
                    using (StreamReader sr = new StreamReader(file, coding))
                    {
                        strHtml.Append(sr.ReadToEnd());
                        sr.Close();
                        //while ((strlLine = sr.ReadLine()) != null)
                        //{
                        //    strHtml.Append(strlLine);
                        //}
                        //sr.Close();
                    }
                    return strHtml.ToString();
                }
                else
                {
                    return "";
                }
            }
            catch
            {
                return "";
            }
        }

        /// <summary>
        /// 检查文件扩展名
        /// </summary>
        /// <param name="path">文件路径</param>
        /// <returns></returns>
        public static string Extension(string path)
        {
            try
            {
                if (string.IsNullOrEmpty(path))
                {
                    return string.Empty;
                }

                return System.IO.Path.GetExtension(path);
            }
            catch
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// 上传文件
        /// </summary>
        /// <param name="uploadFile">上传控件</param>
        public static void UploadFile(System.Web.UI.WebControls.FileUpload uploadFile, string fileName, string savePath)
        {
            try
            {
                string path = HttpContext.Current.Server.MapPath(savePath);
                if (Directory.Exists(path) == false)
                {
                    Directory.CreateDirectory(path);
                }
                if (uploadFile.PostedFile.ContentLength > 0)
                {
                    string file = HttpContext.Current.Server.MapPath(savePath + "\\" + fileName);

                    if (File.Exists(file) == false)///检查是否存在同名文件
                    {
                        uploadFile.PostedFile.SaveAs(file);
                    }
                }
            }
            catch
            {
            }
        }

        /// <summary>
        /// 上传文件
        /// </summary>
        /// <param name="uploadFile">上传控件</param>
        public static void UploadFile(System.Web.UI.HtmlControls.HtmlInputFile uploadFile, string fileName, string savePath)
        {
            try
            {
                string path = HttpContext.Current.Server.MapPath(savePath);
                if (Directory.Exists(path) == false)
                {
                    Directory.CreateDirectory(path);
                    
                }
                if (uploadFile.PostedFile.ContentLength > 0)
                {
                    string file = HttpContext.Current.Server.MapPath(savePath + "\\" + fileName);

                    if (File.Exists(file) == false)///检查是否存在同名文件
                    {
                        uploadFile.PostedFile.SaveAs(file);
                    }
                }
            }
            catch
            {
            }
        }

        public static void UpLoadFileByPath(string FilePath,string FileName, string SavaPath)
        {
            try
            {
                string path = HttpContext.Current.Server.MapPath(SavaPath);
                if (Directory.Exists(path) == false)
                {
                    Directory.CreateDirectory(path);
                }
                FileInfo file = new FileInfo(FilePath);
                if (file.Length > 0)
                {
                    string ToPath=HttpContext.Current.Server.MapPath(SavaPath + "\\" + FileName);
                    //建立WebClient实例
                    WebClient MywebClient = new WebClient();
                    //建立WebClient实例的windows网络认证方法
                    MywebClient.Credentials = CredentialCache.DefaultCredentials;
                    //建立要上传文件的文件流
                    FileStream fs = new FileStream(FilePath, FileMode.Open, FileAccess.Read);
                    //对上传文件流进行二进制编码
                    BinaryReader r = new BinaryReader(fs);
                    //将BinaryReader的内容存入到byte[]中去
                    byte[] PostArry = r.ReadBytes((int)fs.Length);
                    //通过PUT方法，向ToPath这个新文件上传最新内容
                    Stream postStream = MywebClient.OpenWrite(ToPath, "PUT");
                    if (postStream.CanWrite)
                    {
                        postStream.Write(PostArry, 0, PostArry.Length);
                    }                    
                    postStream.Close();
                }                
            }
            catch(Exception e)
            {
                LogUtility.WriteErrLog(e);
            }
        }
        /// <summary>
        /// 删除文件
        /// </summary>
        /// <param name="sFileName">文件名</param>
        public static void DeleteFile(string fileName, string filePath)
        {
            try
            {
                DirectoryInfo Path = new DirectoryInfo(HttpContext.Current.Server.MapPath(filePath).ToString());
                string delfile = Path + fileName;
                if (File.Exists(delfile))
                {
                    File.Delete(delfile);
                }
            }
            catch
            {
            }
        }

        /// <summary>
        /// 获取文件信息，返回DataTable类型
        /// </summary>
        /// <returns></returns>
        public static DataTable GetFile(string filePath)
        {
            try
            {
                DataTable DTFileInfo = new DataTable();
                DTFileInfo.Columns.Add(new DataColumn("FileName", typeof(String)));
                DTFileInfo.Columns.Add(new DataColumn("FileSize", typeof(Int32)));
                DTFileInfo.Columns.Add(new DataColumn("FileType", typeof(String)));
                DTFileInfo.Columns.Add(new DataColumn("FileCreateTime", typeof(String)));
                DataRow FileRow;

                DirectoryInfo FilePath = new DirectoryInfo(HttpContext.Current.Server.MapPath(filePath));

                foreach (FileInfo FileInfomation in FilePath.GetFiles())
                {
                    FileRow = DTFileInfo.NewRow();
                    FileRow["FileName"] = FileInfomation.Name.ToString();
                    FileRow["FileSize"] = Int32.Parse(FileInfomation.Length.ToString());
                    FileRow["FileType"] = FileInfomation.Extension.ToString();
                    FileRow["FileCreateTime"] = FileInfomation.CreationTime.ToString();

                    DTFileInfo.Rows.Add(FileRow);
                }

                return DTFileInfo;
            }
            catch
            {
                return null;
            }
        }

       

        /// <summary>
        /// 将文件加载到DropDownList
        /// </summary>
        /// <param name="list"></param>
        /// <param name="hasFirst"></param>
        /// <param name="firstValue"></param>
        /// <param name="firstText"></param>
        /// <param name="filePath"></param>
        //public static void DropDownListFileList(DropDownList list, bool hasFirst, string firstValue, string firstText, string filePath)
        //{
        //    try
        //    {
        //        list.Items.Clear();
        //        if (hasFirst)
        //        {
        //            ListItem item = new ListItem();
        //            item.Value = firstValue;
        //            item.Text = firstText;
        //            list.Items.Add(item);
        //        }
        //        DataTable dt = GetFile(filePath);
        //        if ((dt != null) && (dt.Rows.Count > 0))
        //        {
        //            for (int i = 0; i < dt.Rows.Count; i++)
        //            {
        //                ListItem item = new ListItem(dt.Rows[i]["FileName"].ToString(), filePath + "/" + dt.Rows[i]["FileName"].ToString());
        //                list.Items.Add(item);
        //            }
        //        }
        //    }
        //    catch
        //    { }
        //}
    }
}
