using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for LoginContext
/// </summary>
public class LoginContext
{
    public LoginContext()
    {
        
    }

    public static UserInfo CurrentUser
    {
        get
        {
            if (HttpContext.Current.Request.Cookies["token"] != null)
            {
                string ticket = HttpContext.Current.Request.Cookies["token"].Value;
                UserInfo userInfo =  new UserInfo();
                userInfo.UserEmail = Coal.Util.CryptoHelper.Decrypt(ticket, "coalchina");
                return userInfo;
            }
            else
            {
                return null;
            }
        }
    }

    public class UserInfo
    {
        public string UserEmail { get; set; }
    }
}
