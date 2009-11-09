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
    public partial class FuncGroupMapEntity
    {
        private SqlHelper sqlHelper;

        #region const fields
        public const string DBName = "Cheese";
        public const string TableName = "FuncGroupMap";
        public const string PrimaryKey = "PK_FuncGroupMap";
        #endregion

        #region columns
        public struct Columns
        {
            public const string ID = "ID";
            public const string FuncId = "FuncId";
            public const string GroupId = "GroupId";
        }
        #endregion

        #region constructors
        public FuncGroupMapEntity()
        {
            sqlHelper = new SqlHelper(DBName);
        }

        public FuncGroupMapEntity(int id, int funcid, int groupid)
        {
            this.ID = id;

            this.FuncId = funcid;

            this.GroupId = groupid;

        }
        #endregion

        #region Properties

        public int? ID
        {
            get;
            set;
        }


        public int? FuncId
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
            strSql.Append("select count(1) from FuncGroupMap");
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
        public void Add(FuncGroupMapEntity entity)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into FuncGroupMap(");
            strSql.Append("FuncId,GroupId)");
            strSql.Append(" values (");
            strSql.Append("@FuncId,@GroupId)");
            SqlParameter[] parameters = {
					new SqlParameter("@FuncId",SqlDbType.Int),
					new SqlParameter("@GroupId",SqlDbType.Int)
					};
            parameters[0].Value = entity.FuncId;
            parameters[1].Value = entity.GroupId;

            sqlHelper.ExecuteSql(strSql.ToString(), parameters);
        }

        //update
        public void Update(FuncGroupMapEntity entity)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("update FuncGroupMap set ");
            strSql.Append("FuncId=@FuncId,");
            strSql.Append("GroupId=@GroupId");

            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID",SqlDbType.Int),
					new SqlParameter("@FuncId",SqlDbType.Int),
					new SqlParameter("@GroupId",SqlDbType.Int)
					};
            parameters[0].Value = entity.ID;
            parameters[1].Value = entity.FuncId;
            parameters[2].Value = entity.GroupId;

            sqlHelper.ExecuteSql(strSql.ToString(), parameters);
        }

        //delete
        public void Delete(int primaryKeyId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from FuncGroupMap ");
            strSql.Append(" where ID=@primaryKeyId");
            SqlParameter[] parameters = {
					new SqlParameter("@primaryKeyId", SqlDbType.Int)
				};
            parameters[0].Value = primaryKeyId;
            sqlHelper.ExecuteSql(strSql.ToString(), parameters);
        }

        //Get entity
        public FuncGroupMapEntity GetEntity(int primaryKeyId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from FuncGroupMap ");
            strSql.Append(" where ID=@primaryKeyId");
            SqlParameter[] parameters = {
					new SqlParameter("@primaryKeyId", SqlDbType.Int)};
            parameters[0].Value = primaryKeyId;
            SqlDataReader dr = sqlHelper.ExecuteReader(strSql.ToString(), parameters);
            if (dr.HasRows)
            {
                dr.Read();
                FuncGroupMapEntity entity = new FuncGroupMapEntity();
                if (!Convert.IsDBNull(dr["ID"]))
                {
                    entity.ID = (int)dr["ID"];
                }
                if (!Convert.IsDBNull(dr["FuncId"]))
                {
                    entity.FuncId = (int)dr["FuncId"];
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
            strSql.Append(" FROM FuncGroupMap(nolock)");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return sqlHelper.ExecuteDateSet(strSql.ToString(), param);
        }

        //getlist
        public List<FuncGroupMapEntity> GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select *");
            strSql.Append(" FROM FuncGroupMap(nolock) ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            SqlDataReader dr = sqlHelper.ExecuteReader(strSql.ToString());
            List<FuncGroupMapEntity> list = new List<FuncGroupMapEntity>();
            while (dr.Read())
            {
                FuncGroupMapEntity entity = new FuncGroupMapEntity();
                if (!Convert.IsDBNull(dr["ID"]))
                {
                    entity.ID = (int)dr["ID"];
                }
                if (!Convert.IsDBNull(dr["FuncId"]))
                {
                    entity.FuncId = (int)dr["FuncId"];
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
            string sql = "select count(*) from FuncGroupMap ";
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

            sql += " AS RowNumber,* FROM FuncGroupMap";

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

