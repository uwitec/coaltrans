using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using System.Reflection;
using System.Text;
using Coal.DAL;

namespace Coal.Entity
{
    [Serializable]
    public partial class GroupsEntity
    {
        private SqlHelper sqlHelper;

        #region const fields
        public const string DBName = "Cheese";
        public const string TableName = "Groups";
        public const string PrimaryKey = "PK_Groups";
        #endregion

        #region columns
        public struct Columns
        {
            public const string ID = "ID";
            public const string Name = "Name";
        }
        #endregion

        #region constructors
        public GroupsEntity()
        {
            sqlHelper = new SqlHelper(DBName);
        }

        public GroupsEntity(int id, string name)
        {
            this.ID = id;

            this.Name = name;

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

        #endregion

        #region CRUD Method

        //Exists
        public bool Exists(int primaryKeyId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Groups");
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
        public void Add(GroupsEntity entity)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Groups(");
            strSql.Append("ID,Name)");
            strSql.Append(" values (");
            strSql.Append("@ID,@Name)");
            SqlParameter[] parameters = {
					new SqlParameter("@ID",SqlDbType.Int),
					new SqlParameter("@Name",SqlDbType.NVarChar)
					};
            parameters[0].Value = entity.ID;
            parameters[1].Value = entity.Name;

            sqlHelper.ExecuteSql(strSql.ToString(), parameters);
        }

        //update
        public void Update(GroupsEntity entity)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Groups set ");
            strSql.Append("Name=@Name");

            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID",SqlDbType.Int),
					new SqlParameter("@Name",SqlDbType.NVarChar)
					};
            parameters[0].Value = entity.ID;
            parameters[1].Value = entity.Name;

            sqlHelper.ExecuteSql(strSql.ToString(), parameters);
        }

        //delete
        public void Delete(int primaryKeyId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Groups ");
            strSql.Append(" where ID=@primaryKeyId");
            SqlParameter[] parameters = {
					new SqlParameter("@primaryKeyId", SqlDbType.Int)
				};
            parameters[0].Value = primaryKeyId;
            sqlHelper.ExecuteSql(strSql.ToString(), parameters);
        }

        //Get entity
        public GroupsEntity GetEntity(int primaryKeyId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from Groups ");
            strSql.Append(" where ID=@primaryKeyId");
            SqlParameter[] parameters = {
					new SqlParameter("@primaryKeyId", SqlDbType.Int)};
            parameters[0].Value = primaryKeyId;
            SqlDataReader dr = sqlHelper.ExecuteReader(strSql.ToString(), parameters);
            if (dr.HasRows)
            {
                dr.Read();
                GroupsEntity entity = new GroupsEntity();
                if (!Convert.IsDBNull(dr["ID"]))
                {
                    entity.ID = (int)dr["ID"];
                }
                entity.Name = dr["Name"].ToString();
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
            strSql.Append(" FROM Groups(nolock)");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return sqlHelper.ExecuteDateSet(strSql.ToString(), param);
        }

        //getlist
        public List<GroupsEntity> GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select *");
            strSql.Append(" FROM Groups(nolock) ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            SqlDataReader dr = sqlHelper.ExecuteReader(strSql.ToString());
            List<GroupsEntity> list = new List<GroupsEntity>();
            while (dr.Read())
            {
                GroupsEntity entity = new GroupsEntity();
                if (!Convert.IsDBNull(dr["ID"]))
                {
                    entity.ID = (int)dr["ID"];
                }
                entity.Name = dr["Name"].ToString();
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
            string sql = "select count(*) from Groups ";
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

            sql += " AS RowNumber,* FROM Groups";

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