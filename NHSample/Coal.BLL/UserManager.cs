using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Coal.Entity;

namespace Coal.BLL
{
    public class UserManager
    {
        public static void AddUser(string email, string nickName, string password)
        {
            UsersEntity user = new UsersEntity();
            user.Email = email;
            user.NickName = nickName;
            user.Password = password;
            user.ValidStatus = 0;
            user.CreateDate = DateTime.Now;
            user.Add();
        }
    }
}
