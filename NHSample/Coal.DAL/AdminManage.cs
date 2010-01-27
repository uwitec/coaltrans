using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using System.Reflection;
using System.Text;
using Coal.DAL;
using System.Text;

namespace Coal.DAL
{
    public class AdminManage
    {
        public AdminManage()
        { }
        public static DataSet GetAdminDs(string Strwhere)
        {
            SqlHelper sqlhelp = new SqlHelper("cheese");
            return sqlhelp.ExecuteDateSet(Strwhere, null);
        }
    }
}
