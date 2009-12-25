using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Coal.Util;

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
            if (HttpContext.Current.Request.Cookies["login_info"] != null)
            {
                string ticket = HttpContext.Current.Request.Cookies["login_info"].Value;
                UserInfo userInfo =  new UserInfo();
                string deTicket = Coal.Util.CryptoHelper.Decrypt(ticket, "coalchina");
                string[] userInfoValues = deTicket.Split('|');

                if (userInfoValues.Length == 3)
                {
                    userInfo.NickName = userInfoValues[0];
                    userInfo.UserEmail = userInfoValues[1];
                    userInfo.UserId = EConvert.ToInt(userInfoValues[2]);
                    return userInfo;
                }
                else
                {
                    return null;
                }
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
        public int UserId { get; set; }
        public string NickName { get; set; }
    }
}
