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
using System.Collections;

namespace Coal.BLL
{
    public class FuncManager
    {
        public bool GetFunctionList(string userEmail, ResultObject ro)
        {
            string sql = @"select f.id,f.[Name],f.url,f.ParentId,u.GroupId from Users u 
inner join FuncGroupMap fgm on u.GroupId = fgm.groupid
inner join Functions f on f.id = fgm.funcid
where u.email = @email order by [path]";

            DbInstance db = new DbInstance();
            db.Open();
            db.CommandText = sql;
            db.SetString("email",userEmail);
            DataTable dt = db.ExecuteTable();

            if (dt != null && dt.Rows.Count > 0)
            {
                ArrayList menus = new ArrayList();
                //List<Dictionary<string, object>> menus = new List<Dictionary<string, object>>();
                foreach (DataRow row in dt.Rows)
                {
                    int parent;
                    if (int.TryParse(row["ParentId"].ToString(), out parent))
                    {
                        if (parent == -1)
                        {
                            SortedList menu = new SortedList();
                            menu["id"] = int.Parse(row["id"].ToString());
                            menu["name"] = row["Name"].ToString();
                            menu["url"] = row["Url"].ToString();
                            menu["children"] = new ArrayList();
                            menus.Add(menu);
                        }
                        else
                        {
                            SortedList child = new SortedList();
                            child["id"] =  row["id"].ToString();
                            child["name"] = row["Name"].ToString();
                            child["url"] = row["Url"].ToString();
                            SortedList current = menus[menus.Count - 1] as SortedList;
                            if (current != null)
                            {
                                ArrayList children = current["children"] as ArrayList;
                                if (children != null)
                                {
                                    children.Add(child);
                                }
                            }
                        }
                    }
                }

                ro["menus"] = menus;
                ro["user_group"] = dt.Rows[0]["GroupId"].ToString();

                
                //string jsonStr = string.Empty;
                //using (MemoryStream ms2 = new MemoryStream())
                //{
                //    DataContractJsonSerializer ds = new DataContractJsonSerializer(typeof(List<Menu>));
                //    ds.WriteObject(ms2, menus);
                //    jsonStr = Encoding.UTF8.GetString(ms2.ToArray());
                //}

                return true;
            }
            else
            {
                return false;
            }
        }
    }


    public class Menu
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public List<Menu> children { get; set; }
    }

    //[DataContractAttribute]
    //public class Menu
    //{
    //    [DataMember]
    //    public string Name { get; set; }

    //    [DataMember]
    //    public string Url { get; set; }
    //}
}
