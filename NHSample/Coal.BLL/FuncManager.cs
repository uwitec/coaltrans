using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Coal.Entity;
using System.Data.SqlClient;
using Coal.DAL;
using System.Data;
using Coal.Util;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.IO;

namespace Coal.BLL
{
    public class FuncManager
    {
        public string GetFunctionList(string userEmail)
        {
            string sql = @"select f.[Name],f.url,f.ParentId from Users u 
inner join UserGroupMap ugm on u.id = ugm.userid 
inner join FuncGroupMap fgm on ugm.groupid = fgm.groupid
inner join Functions f on f.id = fgm.funcid
where u.email = @email";

            DbInstance db = new DbInstance();
            db.Open();
            db.CommandText = sql;
            db.SetString("email",userEmail);
            DataTable dt = db.ExecuteTable();

            List<Menu> menus = new List<Menu>();

            foreach (DataRow row in dt.Rows)
            {
                Menu menu = new Menu();
                menu.Name = row["Name"].ToString();
                menu.Url = row["Url"].ToString();
                menu.Parent = int.Parse(row["ParentId"].ToString());
                menus.Add(menu);
            }

            string jsonStr = string.Empty;
            using (MemoryStream ms2 = new MemoryStream())
            {
                DataContractJsonSerializer ds = new DataContractJsonSerializer(typeof(List<Menu>));
                ds.WriteObject(ms2, menus);
                jsonStr = Encoding.UTF8.GetString(ms2.ToArray());
            }

            return jsonStr;
        }
    }

    [DataContractAttribute] 
    public class Menu
    {
        [DataMember] 
        public string Name { get; set; }

        [DataMember] 
        public string Url { get; set; }

        [DataMember] 
        public int Parent { get; set; }
    }
}
