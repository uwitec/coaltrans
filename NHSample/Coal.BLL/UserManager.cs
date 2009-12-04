using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Coal.Entity;
using System.Data.SqlClient;
using Coal.Util;

namespace Coal.BLL
{
    public class UserManager
    {
        public static bool AddUser(string email, string nickName, string password)
        {
            try
            {
                UsersEntity user = new UsersEntity();
                user.Email = email;
                user.NickName = nickName;
                user.Password = password;
                user.ValidStatus = 0;
                user.CreateDate = DateTime.Now;
                UsersEntity.UsersDAO userDao = new UsersEntity.UsersDAO();
                userDao.Add(user);
                return true;
            }
            catch(Exception ex)
            {
                LogUtility.WriteErrLog(ex);
                return false;
            }
        }

        public static bool ValidLogin(string email, string password)
        {
            string name = string.Empty;
            return ValidLogin(email, password, ref name);
        }

        public static bool ValidLogin(string email, string password, ref string nickName)
        {
            UsersEntity.UsersDAO userDao = new UsersEntity.UsersDAO();
            string sql = "email = @email and password = @password";
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("email", email));
            parameters.Add(new SqlParameter("password", password));
            List<UsersEntity> users = userDao.Find(sql, parameters.ToArray());

            if (users!= null && users.Count == 1)
            {
                nickName = users[0].NickName;
                return true;
            }
            else
            {
                return false;  
            }
        }
    }
}
