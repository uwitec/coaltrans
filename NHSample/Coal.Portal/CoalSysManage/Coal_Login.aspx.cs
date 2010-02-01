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
using Coal.BLL;

public partial class CoalSysManage_Coal_Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["admin_login"] != null)
        {
            MessageBox.ShowAndRedirect("您已经登录，请不要重复登录", "Coal_Default.htm");
        }
    }
    protected void BtnSubmit_Click(object sender, EventArgs e)
    {
        bool Flag = true;
        string adminName = txtName.Value;
        string password = txtPassWord.Value;
        string Code = AuthCode.Value;
        if (string.IsNullOrEmpty(adminName))
        {
            Flag = false;
            MessageBox.ShowAndBack("用户名不能为空！");
        }
        if (string.IsNullOrEmpty(password))
        {
            Flag = false;
            MessageBox.ShowAndBack("密码不能为空！");
        }
        if ((string.IsNullOrEmpty(Code)) && (Request.Cookies["valid_code"].Value==Code))
        {
            Flag = false;
            MessageBox.ShowAndBack("验证码为空或验证码错误！");
        }
        if (Flag)
        {
            string StrWhere = " AdminName='" + adminName + "' and PassWord='" + CryptoHelper.Encrypt(password, "gkaxadmin") + "' and IsAudit=1";
            AdminLoginEntity entity = TestAdmin(StrWhere);
            if (entity != null)
            {
                string key = entity.AdminName + "|" + entity.RoleId + "|" + entity.AdminId;
                string validkey = CryptoHelper.Encrypt(key, "coaladmin");
                HttpCookie AdminCookie = new HttpCookie("admin_login");
                AdminCookie.Value = validkey;
                Response.SetCookie(AdminCookie);
                entity.LastLogin = DateTime.Now;
                entity.LastIP = GetRealIP();
                AdminLoginEntity.AdminLoginDAO DAO = new AdminLoginEntity.AdminLoginDAO();
                DAO.Update(entity);
                Response.Redirect("Coal_Default.htm");
            }
            else
            {
                MessageBox.ShowAndBack("用户信息错误或者没有通过管理员审核！");
            }
        }
    }
    private AdminLoginEntity TestAdmin(string StrWhere)
    {
        AdminLoginEntity.AdminLoginDAO Dao = new AdminLoginEntity.AdminLoginDAO();
        List<AdminLoginEntity> list = Dao.Find(StrWhere, null);
        if (list != null && list.Count > 0)
        {
            return list[0];
        }
        else
        {
            return null;
        }
    }
    public static string GetRealIP()
    {
        string ip;
        try
        {
            HttpRequest request = HttpContext.Current.Request;

            if (request.ServerVariables["HTTP_VIA"] != null)
            {
                ip = request.ServerVariables["HTTP_X_FORWARDED_FOR"].ToString().Split(',')[0].Trim();
            }
            else
            {
                ip = request.UserHostAddress;
            }
        }
        catch (Exception e)
        {
            throw e;
        }

        return ip;
    } 
}
