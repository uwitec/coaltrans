using System;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using System.Collections.Generic;
using System.Reflection;
using Coal.DAL;

namespace Coal.Entity
{
    [Serializable]
    public class FunctionsEntity
    {
        private SqlHelper sqlHelper;

        #region const fields

        public const string DBName = "Cheese";
        public const string TableName = "Functions";
        public const string PrimaryKey = "PK_Functions";

        #endregion

        #region columns
        public struct Columns
        {
            public const string ID = "ID";
            public const string Name = "Name";
            public const string Url = "Url";
            public const string ParentId = "ParentId";
            public const string HasSub = "HasSub";
            public const string Level = "Level";
        }
        #endregion

        #region constructors
        public FunctionsEntity()
        {
            sqlHelper = new SqlHelper(DBName);
        }

        public FunctionsEntity(int id, string name, string url, int parentid, bool hassub, int level)
        {
            this.ID = id;

            this.Name = name;

            this.Url = url;

            this.ParentId = parentid;

            this.HasSub = hassub;

            this.Level = level;

        }
        #endregion

        #region Properties

        public int? ID
        {
            get;
            set;
        }


        public string Name
        {
            get;
            set;
        }


        public string Url
        {
            get;
            set;
        }


        public int? ParentId
        {
            get;
            set;
        }


        public bool? HasSub
        {
            get;
            set;
        }


        public int? Level
        {
            get;
            set;
        }

        #endregion

        #region CRUD Method

        //Exists
        public bool Exists(int primaryKeyId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Functions");
            strSql.Append(" where ID= @primaryKeyId");
            SqlParameter[] parameters = {
					new SqlParameter("@primaryKeyId", SqlDbType.Int)
				};
            parameters[0].Value = primaryKeyId;
            object obj = sqlHelper.GetSingle(strSql.ToString(), parameters);

            if (obj != null && obj.ToString() != string.Empty)
            {
                return int.Parse(obj.ToString()) > 0;
            }
            else
            {
                return false;
            }
        }

        //add
        public void Add(FunctionsEntity entity)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Functions(");
            strSql.Append("ID,Name,Url,ParentId,HasSub,Level)");
            strSql.Append(" values (");
            strSql.Append("@ID,@Name,@Url,@ParentId,@HasSub,@Level)");
            SqlParameter[] parameters = {
					new SqlParameter("@ID",SqlDbType.Int),
					new SqlParameter("@Name",SqlDbType.NVarChar),
					new SqlParameter("@Url",SqlDbType.NVarChar),
					new SqlParameter("@ParentId",SqlDbType.Int),
					new SqlParameter("@HasSub",SqlDbType.Bit),
					new SqlParameter("@Level",SqlDbType.Int)
					};
            parameters[0].Value = entity.ID;
            parameters[1].Value = entity.Name;
            parameters[2].Value = entity.Url;
            parameters[3].Value = entity.ParentId;
            parameters[4].Value = entity.HasSub;
            parameters[5].Value = entity.Level;

            sqlHelper.ExecuteSql(strSql.ToString(), parameters);
        }

        //update
        public void Update(FunctionsEntity entity)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Functions set ");
            strSql.Append("Name=@Name,");
            strSql.Append("Url=@Url,");
            strSql.Append("ParentId=@ParentId,");
            strSql.Append("HasSub=@HasSub,");
            strSql.Append("Level=@Level");

            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID",SqlDbType.Int),
					new SqlParameter("@Name",SqlDbType.NVarChar),
					new SqlParameter("@Url",SqlDbType.NVarChar),
					new SqlParameter("@ParentId",SqlDbType.Int),
					new SqlParameter("@HasSub",SqlDbType.Bit),
					new SqlParameter("@Level",SqlDbType.Int)
					};
            parameters[0].Value = entity.ID;
            parameters[1].Value = entity.Name;
            parameters[2].Value = entity.Url;
            parameters[3].Value = entity.ParentId;
            parameters[4].Value = entity.HasSub;
            parameters[5].Value = entity.Level;

            sqlHelper.ExecuteSql(strSql.ToString(), parameters);
        }

        //delete
        public void Delete(int primaryKeyId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Functions ");
            strSql.Append(" where ID=@primaryKeyId");
            SqlParameter[] parameters = {
					new SqlParameter("@primaryKeyId", SqlDbType.Int)
				};
            parameters[0].Value = primaryKeyId;
            sqlHelper.ExecuteSql(strSql.ToString(), parameters);
        }

        //Get entity
        public FunctionsEntity GetEntity(int primaryKeyId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from Functions ");
            strSql.Append(" where ID=@primaryKeyId");
            SqlParameter[] parameters = {
					new SqlParameter("@primaryKeyId", SqlDbType.Int)};
            parameters[0].Value = primaryKeyId;
            SqlDataReader dr = sqlHelper.ExecuteReader(strSql.ToString(), parameters);
            if (dr.HasRows)
            {
                dr.Read();
                FunctionsEntity entity = new FunctionsEntity();
                if (!Convert.IsDBNull(dr["ID"]))
                {
                    entity.ID = (int)dr["ID"];
                }
                entity.Name = dr["Name"].ToString();
                entity.Url = dr["Url"].ToString();
                if (!Convert.IsDBNull(dr["ParentId"]))
                {
                    entity.ParentId = (int)dr["ParentId"];
                }
                if (!Convert.IsDBNull(dr["HasSub"]))
                {
                    entity.HasSub = (bool)dr["HasSub"];
                }
                if (!Convert.IsDBNull(dr["Level"]))
                {
                    entity.Level = (int)dr["Level"];
                }
                dr.Close();
                dr.Dispose();
                return entity;
            }
            else
            {
                dr.Close();
                dr.Dispose();
                return null;
            }
        }

        //batch methods
        //getDateSet
        public DataSet GetDataSet(string strWhere, SqlParameter[] param)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select *");
            strSql.Append(" FROM Functions(nolock)");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return sqlHelper.ExecuteDateSet(strSql.ToString(), param);
        }

        //getlist
        public List<FunctionsEntity> GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select *");
            strSql.Append(" FROM Functions(nolock) ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            SqlDataReader dr = sqlHelper.ExecuteReader(strSql.ToString());
            List<FunctionsEntity> list = new List<FunctionsEntity>();
            while (dr.Read())
            {
                FunctionsEntity entity = new FunctionsEntity();
                if (!Convert.IsDBNull(dr["ID"]))
                {
                    entity.ID = (int)dr["ID"];
                }
                entity.Name = dr["Name"].ToString();
                entity.Url = dr["Url"].ToString();
                if (!Convert.IsDBNull(dr["ParentId"]))
                {
                    entity.ParentId = (int)dr["ParentId"];
                }
                if (!Convert.IsDBNull(dr["HasSub"]))
                {
                    entity.HasSub = (bool)dr["HasSub"];
                }
                if (!Convert.IsDBNull(dr["Level"]))
                {
                    entity.Level = (int)dr["Level"];
                }
                list.Add(entity);
            }

            dr.Close();
            dr.Dispose();

            return list;
        }

        #endregion


        #region paging methods

        /// <summary>
        /// 获取分页记录总数
        /// </summary>
        /// <param name="where">条件，等同于GetPaer()方法的where</param>
        /// <returns>返回记录总数</returns>
        public int GetPagerRowsCount(string where, SqlParameter[] param)
        {
            string sql = "select count(*) from Functions ";
            if (!string.IsNullOrEmpty(where))
            {
                sql += "where " + where;
            }

            object obj = sqlHelper.GetSingle(sql, param);

            return obj == null ? 0 : Convert.ToInt32(obj);
        }

        /// <summary>
        /// 查询分页信息，返回当前页码的记录集
        /// </summary>
        /// <param name="where">查询条件，可为empty</param>
        /// <param name="orderBy">排序条件，可为empty</param>
        /// <param name="pageSize">每页显示记录数</param>
        /// <param name="pageNumber">当前页码</param>
        /// <returns>datatable</returns>
        public DataTable GetPager(string where, SqlParameter[] param, string orderBy, int pageSize, int pageNumber)
        {
            int startNumber = pageSize * (pageNumber - 1);

            string sql = string.Format("SELECT TOP {0} * FROM (SELECT ROW_NUMBER() OVER", pageSize);

            if (!string.IsNullOrEmpty(orderBy))
            {
                sql += string.Format(" (ORDER BY {0})", orderBy);
            }
            else
            {

                sql += " (ORDER BY ID)";//默认按主键排序

            }

            sql += " AS RowNumber,* FROM Functions";

            if (!string.IsNullOrEmpty(where))
            {
                sql += " where " + where;
            }

            sql += " ) _myResults WHERE RowNumber>" + startNumber.ToString();

            return sqlHelper.ExecuteDateSet(sql, param).Tables[0];
        }

        #endregion
    }
}

