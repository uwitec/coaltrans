using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Security.Principal;
namespace Common
{
    public class BasePage : System.Web.UI.Page
    {
        public BasePage()
        { }
        protected static int UserID()
        {
            int userID = 0;            
            if (HttpContext.Current.User != null)
            {
                if (HttpContext.Current.User.Identity.IsAuthenticated == true) //验证过的一般用户才能进行角色验证  
                {
                    System.Web.Security.FormsIdentity fi = (System.Web.Security.FormsIdentity)HttpContext.Current.User.Identity;
                    System.Web.Security.FormsAuthenticationTicket ticket = fi.Ticket; //取得身份验证票  
                    userID =  int.Parse(ticket.Name);
                }
            }
            //return userID;
            //程序调试阶段默认userid=3
            return 3;
        }
        protected static string UserRoles()
        {
            string roles = null;
            if (HttpContext.Current.User != null)
            {
                if (HttpContext.Current.User.Identity.IsAuthenticated == true) //验证过的一般用户才能进行角色验证  
                {
                    System.Web.Security.FormsIdentity fi = (System.Web.Security.FormsIdentity)HttpContext.Current.User.Identity;
                    System.Web.Security.FormsAuthenticationTicket ticket = fi.Ticket; //取得身份验证票  
                    string userData = ticket.UserData;//从UserData中恢复role信息
                    roles = userData;//userData.Split(','); //将角色数据转成字符串数组,得到相关的角色信息 
                    
                }
            }
            return roles;
        }
        //根据值确定选择项
        protected static void SelectDropDownListItemByText(System.Web.UI.WebControls.DropDownList ddlist, string selecttext)
        {

            foreach (System.Web.UI.WebControls.ListItem item in ddlist.Items)
            {
                if (item.Text == selecttext)
                {
                    item.Selected = true;
                }
                else
                {
                    item.Selected = false;
                }
            }
        }
        protected static void SelectDropDownListItemByValue(System.Web.UI.WebControls.DropDownList ddlist, string selectvalue)
        {

            foreach (System.Web.UI.WebControls.ListItem item in ddlist.Items)
            {
                if (item.Value == selectvalue)
                {
                    item.Selected = true;
                }
                else
                {
                    item.Selected = false;
                }
            }
        }
    }
}
