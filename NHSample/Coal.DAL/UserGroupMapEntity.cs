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
    public partial class UserGroupMapEntity
    {
        private SqlHelper sqlHelper;

        #region const fields
        public const string DBName = "Cheese";
        public const string TableName = "UserGroupMap";
        public const string PrimaryKey = "PK_UserGroupMap";
        #endregion

        #region columns
        public struct Columns
        {
            public const string ID = "ID";
            public const string UserId = "UserId";
            public const string GroupId = "GroupId";
        }
        #endregion

        #region constructors
        public UserGroupMapEntity()
        {
            sqlHelper = new SqlHelper(DBName);
        }

        public UserGroupMapEntity(int id, int userid, int groupid)
        {
            this.ID = id;

            this.UserId = userid;

            this.GroupId = groupid;

        }
        #endregion

        #region Properties

        public int? ID
        {
            get;
            set;
        }


        public int? UserId
        {
            get;
            set;
        }


        public int? GroupId
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
            strSql.Append("select count(1) from UserGroupMap");
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
        public void Add(UserGroupMapEntity entity)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into UserGroupMap(");
            strSql.Append("UserId,GroupId)");
            strSql.Append(" values (");
            strSql.Append("@UserId,@GroupId)");
            SqlParameter[] parameters = {
					new SqlParameter("@UserId",SqlDbType.Int),
					new SqlParameter("@GroupId",SqlDbType.Int)
					};
            parameters[0].Value = entity.UserId;
            parameters[1].Value = entity.GroupId;

            sqlHelper.ExecuteSql(strSql.ToString(), parameters);
        }

        //update
        public void Update(UserGroupMapEntity entity)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("update UserGroupMap set ");
            strSql.Append("UserId=@UserId,");
            strSql.Append("GroupId=@GroupId");

            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID",SqlDbType.Int),
					new SqlParameter("@UserId",SqlDbType.Int),
					new SqlParameter("@GroupId",SqlDbType.Int)
					};
            parameters[0].Value = entity.ID;
            parameters[1].Value = entity.UserId;
            parameters[2].Value = entity.GroupId;

            sqlHelper.ExecuteSql(strSql.ToString(), parameters);
        }

        //delete
        public void Delete(int primaryKeyId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from UserGroupMap ");
            strSql.Append(" where ID=@primaryKeyId");
            SqlParameter[] parameters = {
					new SqlParameter("@primaryKeyId", SqlDbType.Int)
				};
            parameters[0].Value = primaryKeyId;
            sqlHelper.ExecuteSql(strSql.ToString(), parameters);
        }

        //Get entity
        public UserGroupMapEntity GetEntity(int primaryKeyId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from UserGroupMap ");
            strSql.Append(" where ID=@primaryKeyId");
            SqlParameter[] parameters = {
					new SqlParameter("@primaryKeyId", SqlDbType.Int)};
            parameters[0].Value = primaryKeyId;
            SqlDataReader dr = sqlHelper.ExecuteReader(strSql.ToString(), parameters);
            if (dr.HasRows)
            {
                dr.Read();
                UserGroupMapEntity entity = new UserGroupMapEntity();
                if (!Convert.IsDBNull(dr["ID"]))
                {
                    entity.ID = (int)dr["ID"];
                }
                if (!Convert.IsDBNull(dr["UserId"]))
                {
                    entity.UserId = (int)dr["UserId"];
                }
                if (!Convert.IsDBNull(dr["GroupId"]))
                {
                    entity.GroupId = (int)dr["GroupId"];
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
            strSql.Append(" FROM UserGroupMap(nolock)");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return sqlHelper.ExecuteDateSet(strSql.ToString(), param);
        }

        //getlist
        public List<UserGroupMapEntity> GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select *");
            strSql.Append(" FROM UserGroupMap(nolock) ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            SqlDataReader dr = sqlHelper.ExecuteReader(strSql.ToString());
            List<UserGroupMapEntity> list = new List<UserGroupMapEntity>();
            while (dr.Read())
            {
                UserGroupMapEntity entity = new UserGroupMapEntity();
                if (!Convert.IsDBNull(dr["ID"]))
                {
                    entity.ID = (int)dr["ID"];
                }
                if (!Convert.IsDBNull(dr["UserId"]))
                {
                    entity.UserId = (int)dr["UserId"];
                }
                if (!Convert.IsDBNull(dr["GroupId"]))
                {
                    entity.GroupId = (int)dr["GroupId"];
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
            string sql = "select count(*) from UserGroupMap ";
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

            sql += " AS RowNumber,* FROM UserGroupMap";

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