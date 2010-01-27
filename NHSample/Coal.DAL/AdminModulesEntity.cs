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
    public partial class AdminModulesEntity
    {
        private SqlHelper sqlHelper;

        #region const fields
        public const string DBName = "cheese";
        public const string TableName = "AdminModules";
        public const string PrimaryKey = "PK_ADMINMODULES";
        #endregion

        #region columns
        public struct Columns
        {
            public const string ModuleId = "ModuleId";
            public const string ModuleName = "ModuleName";
            public const string ActionLink = "ActionLink";
            public const string ParentId = "ParentId";
        }
        #endregion

        #region constructors
        public AdminModulesEntity()
        {
            sqlHelper = new SqlHelper(DBName);
        }

        public AdminModulesEntity(int moduleid, string modulename, string actionlink, int parentid)
        {
            this.ModuleId = moduleid;

            this.ModuleName = modulename;

            this.ActionLink = actionlink;

            this.ParentId = parentid;

        }
        #endregion

        #region Properties
        /// <summary>
        /// 模块ID
        /// </summary>
        public int? ModuleId
        {
            get;
            set;
        }

        /// <summary>
        /// 模块名称
        /// </summary>
        public string ModuleName
        {
            get;
            set;
        }

        /// <summary>
        /// 模块的Url
        /// </summary>
        public string ActionLink
        {
            get;
            set;
        }

        /// <summary>
        /// 模块的父级ID
        /// </summary>
        public int? ParentId
        {
            get;
            set;
        }

        #endregion

        public class AdminModulesDAO : SqlDAO<AdminModulesEntity>
        {
            private SqlHelper sqlHelper;
            public const string DBName = "cheese";

            public AdminModulesDAO()
            {
                sqlHelper = new SqlHelper(DBName);
            }

            public override void Add(AdminModulesEntity entity)
            {

                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into AdminModules(");
                strSql.Append("ModuleName,ActionLink,ParentId)");
                strSql.Append(" values (");
                strSql.Append("@ModuleName,@ActionLink,@ParentId)");
                SqlParameter[] parameters = {
					new SqlParameter("@ModuleName",SqlDbType.VarChar),
					new SqlParameter("@ActionLink",SqlDbType.VarChar),
					new SqlParameter("@ParentId",SqlDbType.Int)
					};
                parameters[0].Value = entity.ModuleName;
                parameters[1].Value = entity.ActionLink;
                parameters[2].Value = entity.ParentId;

                sqlHelper.ExecuteSql(strSql.ToString(), parameters);
            }

            public override void Update(AdminModulesEntity entity)
            {

                StringBuilder strSql = new StringBuilder();
                strSql.Append("update AdminModules set ");
                strSql.Append("ModuleName=@ModuleName,");
                strSql.Append("ActionLink=@ActionLink,");
                strSql.Append("ParentId=@ParentId");

                strSql.Append(" where ModuleId=@ModuleId");
                SqlParameter[] parameters = {
					new SqlParameter("@ModuleId",SqlDbType.Int),
					new SqlParameter("@ModuleName",SqlDbType.VarChar),
					new SqlParameter("@ActionLink",SqlDbType.VarChar),
					new SqlParameter("@ParentId",SqlDbType.Int)
					};
                parameters[0].Value = entity.ModuleId;
                parameters[1].Value = entity.ModuleName;
                parameters[2].Value = entity.ActionLink;
                parameters[3].Value = entity.ParentId;

                sqlHelper.ExecuteSql(strSql.ToString(), parameters);
            }

            public override void Delete(AdminModulesEntity entity)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("delete from AdminModules ");
                strSql.Append(" where ModuleId=@primaryKeyId");
                SqlParameter[] parameters = {
						new SqlParameter("@primaryKeyId", SqlDbType.Int)
					};
                parameters[0].Value = entity.ModuleId;
                sqlHelper.ExecuteSql(strSql.ToString(), parameters);
            }

            public override AdminModulesEntity FindById(long primaryKeyId)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select * from AdminModules ");
                strSql.Append(" where ModuleId=@primaryKeyId");
                SqlParameter[] parameters = {
						new SqlParameter("@primaryKeyId", SqlDbType.Int)};
                parameters[0].Value = primaryKeyId;
                DataSet ds = sqlHelper.ExecuteDateSet(strSql.ToString(), parameters);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count == 1)
                {
                    DataRow row = ds.Tables[0].Rows[0];
                    AdminModulesEntity entity = new AdminModulesEntity();
                    if (!Convert.IsDBNull(row["ModuleId"]))
                    {
                        entity.ModuleId = (int)row["ModuleId"];
                    }
                    entity.ModuleName = row["ModuleName"].ToString();
                    entity.ActionLink = row["ActionLink"].ToString();
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

            public override List<AdminModulesEntity> Find(string strWhere, SqlParameter[] parameters)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select *");
                strSql.Append(" FROM AdminModules(nolock) ");
                if (strWhere.Trim() != "")
                {
                    strSql.Append(" where " + strWhere);
                }

                DataSet ds = sqlHelper.ExecuteDateSet(strSql.ToString(), parameters);
                if (ds != null && ds.Tables.Count > 0)
                {
                    List<AdminModulesEntity> list = new List<AdminModulesEntity>();
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        AdminModulesEntity entity = new AdminModulesEntity();
                        if (!Convert.IsDBNull(row["ModuleId"]))
                        {
                            entity.ModuleId = (int)row["ModuleId"];
                        }
                        entity.ModuleName = row["ModuleName"].ToString();
                        entity.ActionLink = row["ActionLink"].ToString();
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
                strSql.Append(" FROM AdminModules(nolock)");
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
                string sql = "select count(*) from AdminModules ";
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

                    sql += " (ORDER BY ModuleId " + method + ")";//默认按主键排序

                }

                sql += " AS RowNumber,* FROM AdminModules";

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

