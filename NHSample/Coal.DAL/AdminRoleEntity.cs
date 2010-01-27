using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using System.Reflection;
using System.Text;
using Coal.DAL;

namespace Coal.DAL
{
    [Serializable]
    public partial class AdminRoleEntity
    {
        private SqlHelper sqlHelper;

        #region const fields
        public const string DBName = "cheese";
        public const string TableName = "AdminRole";
        public const string PrimaryKey = "PK_ADMINROLE";
        #endregion

        #region columns
        public struct Columns
        {
            public const string RoleId = "RoleId";
            public const string RoleName = "RoleName";
            public const string ParentId = "ParentId";
        }
        #endregion

        #region constructors
        public AdminRoleEntity()
        {
            sqlHelper = new SqlHelper(DBName);
        }

        public AdminRoleEntity(int roleid, string rolename, int parentid)
        {
            this.RoleId = roleid;

            this.RoleName = rolename;

            this.ParentId = parentid;

        }
        #endregion

        #region Properties
        /// <summary>
        /// 角色ID
        /// </summary>
        public int? RoleId
        {
            get;
            set;
        }

        /// <summary>
        /// 角色名称
        /// </summary>
        public string RoleName
        {
            get;
            set;
        }

        /// <summary>
        /// 角色的上级ID
        /// </summary>
        public int? ParentId
        {
            get;
            set;
        }

        #endregion

        public class AdminRoleDAO : SqlDAO<AdminRoleEntity>
        {
            private SqlHelper sqlHelper;
            public const string DBName = "cheese";

            public AdminRoleDAO()
            {
                sqlHelper = new SqlHelper(DBName);
            }

            public override void Add(AdminRoleEntity entity)
            {

                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into AdminRole(");
                strSql.Append("RoleName,ParentId)");
                strSql.Append(" values (");
                strSql.Append("@RoleName,@ParentId)");
                SqlParameter[] parameters = {
					new SqlParameter("@RoleName",SqlDbType.VarChar),
					new SqlParameter("@ParentId",SqlDbType.Int)
					};
                parameters[0].Value = entity.RoleName;
                parameters[1].Value = entity.ParentId;

                sqlHelper.ExecuteSql(strSql.ToString(), parameters);
            }

            public override void Update(AdminRoleEntity entity)
            {

                StringBuilder strSql = new StringBuilder();
                strSql.Append("update AdminRole set ");
                strSql.Append("RoleName=@RoleName,");
                strSql.Append("ParentId=@ParentId");

                strSql.Append(" where RoleId=@RoleId");
                SqlParameter[] parameters = {
					new SqlParameter("@RoleId",SqlDbType.Int),
					new SqlParameter("@RoleName",SqlDbType.VarChar),
					new SqlParameter("@ParentId",SqlDbType.Int)
					};
                parameters[0].Value = entity.RoleId;
                parameters[1].Value = entity.RoleName;
                parameters[2].Value = entity.ParentId;

                sqlHelper.ExecuteSql(strSql.ToString(), parameters);
            }

            public override void Delete(AdminRoleEntity entity)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("delete from AdminRole ");
                strSql.Append(" where RoleId=@primaryKeyId");
                SqlParameter[] parameters = {
						new SqlParameter("@primaryKeyId", SqlDbType.Int)
					};
                parameters[0].Value = entity.RoleId;
                sqlHelper.ExecuteSql(strSql.ToString(), parameters);
            }

            public override AdminRoleEntity FindById(long primaryKeyId)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select * from AdminRole ");
                strSql.Append(" where RoleId=@primaryKeyId");
                SqlParameter[] parameters = {
						new SqlParameter("@primaryKeyId", SqlDbType.Int)};
                parameters[0].Value = primaryKeyId;
                DataSet ds = sqlHelper.ExecuteDateSet(strSql.ToString(), parameters);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count == 1)
                {
                    DataRow row = ds.Tables[0].Rows[0];
                    AdminRoleEntity entity = new AdminRoleEntity();
                    if (!Convert.IsDBNull(row["RoleId"]))
                    {
                        entity.RoleId = (int)row["RoleId"];
                    }
                    entity.RoleName = row["RoleName"].ToString();
                    if (!Convert.IsDBNull(row["ParentId"]))
                    {
                        entity.ParentId = (int)row["ParentId"];
                    }
                    return entity;
                }
                else
                {
                    return null;
                }
            }

            public override List<AdminRoleEntity> Find(string strWhere, SqlParameter[] parameters)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select *");
                strSql.Append(" FROM AdminRole(nolock) ");
                if (strWhere.Trim() != "")
                {
                    strSql.Append(" where " + strWhere);
                }

                DataSet ds = sqlHelper.ExecuteDateSet(strSql.ToString(), parameters);
                if (ds != null && ds.Tables.Count > 0)
                {
                    List<AdminRoleEntity> list = new List<AdminRoleEntity>();
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        AdminRoleEntity entity = new AdminRoleEntity();
                        if (!Convert.IsDBNull(row["RoleId"]))
                        {
                            entity.RoleId = (int)row["RoleId"];
                        }
                        entity.RoleName = row["RoleName"].ToString();
                        if (!Convert.IsDBNull(row["ParentId"]))
                        {
                            entity.ParentId = (int)row["ParentId"];
                        }

                        list.Add(entity);
                    }

                    return list;
                }
                else
                {
                    return null;
                }
            }

            public DataSet GetDataSet(string strWhere, SqlParameter[] param)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select *");
                strSql.Append(" FROM AdminRole(nolock)");
                if (strWhere.Trim() != "")
                {
                    strSql.Append(" where " + strWhere);
                }
                return sqlHelper.ExecuteDateSet(strSql.ToString(), param);
            }

            #region paging methods

            /// <summary>
            /// 获取分页记录总数
            /// </summary>
            /// <param name="where">条件，等同于GetPaer()方法的where</param>
            /// <returns>返回记录总数</returns>
            public int GetPagerRowsCount(string where, SqlParameter[] param)
            {
                string sql = "select count(*) from AdminRole ";
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
            public DataTable GetPager(string where, SqlParameter[] param, string orderBy, bool OrderMethod, int pageSize, int pageNumber)
            {
                int startNumber = pageSize * (pageNumber - 1);

                string method = "ASC";
                if (OrderMethod)
                    method = "DESC";


                string sql = string.Format("SELECT TOP {0} * FROM (SELECT ROW_NUMBER() OVER", pageSize);

                if (!string.IsNullOrEmpty(orderBy))
                {
                    sql += string.Format(" (ORDER BY {0} {1})", orderBy, method);
                }
                else
                {

                    sql += " (ORDER BY RoleId " + method + ")";//默认按主键排序

                }

                sql += " AS RowNumber,* FROM AdminRole";

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
}

