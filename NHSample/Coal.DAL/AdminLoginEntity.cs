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
    public partial class AdminLoginEntity
    {
        private SqlHelper sqlHelper;

        #region const fields
        public const string DBName = "cheese";
        public const string TableName = "AdminLogin";
        public const string PrimaryKey = "PK_ADMINLOGIN";
        #endregion

        #region columns
        public struct Columns
        {
            public const string AdminId = "AdminId";
            public const string AdminName = "AdminName";
            public const string PassWord = "PassWord";
            public const string AddTime = "AddTime";
            public const string LastLogin = "LastLogin";
            public const string Email = "Email";
            public const string RoleId = "RoleId";
            public const string IsAudit = "IsAudit";
            public const string LastIP = "LastIP";
        }
        #endregion

        #region constructors
        public AdminLoginEntity()
        {
            sqlHelper = new SqlHelper(DBName);
        }

        public AdminLoginEntity(int adminid, string adminname, string password, DateTime addtime, DateTime lastlogin, string email, int roleid, int isaudit, string lastip)
        {
            this.AdminId = adminid;

            this.AdminName = adminname;

            this.PassWord = password;

            this.AddTime = addtime;

            this.LastLogin = lastlogin;

            this.Email = email;

            this.RoleId = roleid;

            this.IsAudit = isaudit;

            this.LastIP = lastip;

        }
        #endregion

        #region Properties
        /// <summary>
        /// 管理员ID
        /// </summary>
        public int? AdminId
        {
            get;
            set;
        }

        /// <summary>
        /// 管理员用户名
        /// </summary>
        public string AdminName
        {
            get;
            set;
        }

        /// <summary>
        /// 登录密码
        /// </summary>
        public string PassWord
        {
            get;
            set;
        }

        /// <summary>
        /// 申请时间
        /// </summary>
        public DateTime? AddTime
        {
            get;
            set;
        }

        /// <summary>
        /// 最后登陆时间
        /// </summary>
        public DateTime? LastLogin
        {
            get;
            set;
        }

        /// <summary>
        /// 邮箱地址
        /// </summary>
        public string Email
        {
            get;
            set;
        }

        /// <summary>
        /// 角色ID
        /// </summary>
        public int? RoleId
        {
            get;
            set;
        }

        /// <summary>
        /// 是否通过审核(0:否1:是)
        /// </summary>
        public int? IsAudit
        {
            get;
            set;
        }

        /// <summary>
        /// 最后登陆IP地址
        /// </summary>
        public string LastIP
        {
            get;
            set;
        }

        #endregion

        public class AdminLoginDAO : SqlDAO<AdminLoginEntity>
        {
            private SqlHelper sqlHelper;
            public const string DBName = "cheese";

            public AdminLoginDAO()
            {
                sqlHelper = new SqlHelper(DBName);
            }

            public override void Add(AdminLoginEntity entity)
            {

                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into AdminLogin(");
                strSql.Append("AdminName,PassWord,AddTime,LastLogin,Email,RoleId,IsAudit,LastIP)");
                strSql.Append(" values (");
                strSql.Append("@AdminName,@PassWord,@AddTime,@LastLogin,@Email,@RoleId,@IsAudit,@LastIP)");
                SqlParameter[] parameters = {
					new SqlParameter("@AdminName",SqlDbType.VarChar),
					new SqlParameter("@PassWord",SqlDbType.VarChar),
					new SqlParameter("@AddTime",SqlDbType.DateTime),
					new SqlParameter("@LastLogin",SqlDbType.DateTime),
					new SqlParameter("@Email",SqlDbType.VarChar),
					new SqlParameter("@RoleId",SqlDbType.Int),
					new SqlParameter("@IsAudit",SqlDbType.Int),
					new SqlParameter("@LastIP",SqlDbType.VarChar)
					};
                parameters[0].Value = entity.AdminName;
                parameters[1].Value = entity.PassWord;
                parameters[2].Value = entity.AddTime;
                parameters[3].Value = entity.LastLogin;
                parameters[4].Value = entity.Email;
                parameters[5].Value = entity.RoleId;
                parameters[6].Value = entity.IsAudit;
                parameters[7].Value = entity.LastIP;

                sqlHelper.ExecuteSql(strSql.ToString(), parameters);
            }

            public override void Update(AdminLoginEntity entity)
            {

                StringBuilder strSql = new StringBuilder();
                strSql.Append("update AdminLogin set ");
                strSql.Append("AdminName=@AdminName,");
                strSql.Append("PassWord=@PassWord,");
                strSql.Append("AddTime=@AddTime,");
                strSql.Append("LastLogin=@LastLogin,");
                strSql.Append("Email=@Email,");
                strSql.Append("RoleId=@RoleId,");
                strSql.Append("IsAudit=@IsAudit,");
                strSql.Append("LastIP=@LastIP");

                strSql.Append(" where AdminId=@AdminId");
                SqlParameter[] parameters = {
					new SqlParameter("@AdminId",SqlDbType.Int),
					new SqlParameter("@AdminName",SqlDbType.VarChar),
					new SqlParameter("@PassWord",SqlDbType.VarChar),
					new SqlParameter("@AddTime",SqlDbType.DateTime),
					new SqlParameter("@LastLogin",SqlDbType.DateTime),
					new SqlParameter("@Email",SqlDbType.VarChar),
					new SqlParameter("@RoleId",SqlDbType.Int),
					new SqlParameter("@IsAudit",SqlDbType.Int),
					new SqlParameter("@LastIP",SqlDbType.VarChar)
					};
                parameters[0].Value = entity.AdminId;
                parameters[1].Value = entity.AdminName;
                parameters[2].Value = entity.PassWord;
                parameters[3].Value = entity.AddTime;
                parameters[4].Value = entity.LastLogin;
                parameters[5].Value = entity.Email;
                parameters[6].Value = entity.RoleId;
                parameters[7].Value = entity.IsAudit;
                parameters[8].Value = entity.LastIP;

                sqlHelper.ExecuteSql(strSql.ToString(), parameters);
            }

            public override void Delete(AdminLoginEntity entity)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("delete from AdminLogin ");
                strSql.Append(" where AdminId=@primaryKeyId");
                SqlParameter[] parameters = {
						new SqlParameter("@primaryKeyId", SqlDbType.Int)
					};
                parameters[0].Value = entity.AdminId;
                sqlHelper.ExecuteSql(strSql.ToString(), parameters);
            }

            public override AdminLoginEntity FindById(long primaryKeyId)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select * from AdminLogin ");
                strSql.Append(" where AdminId=@primaryKeyId");
                SqlParameter[] parameters = {
						new SqlParameter("@primaryKeyId", SqlDbType.Int)};
                parameters[0].Value = primaryKeyId;
                DataSet ds = sqlHelper.ExecuteDateSet(strSql.ToString(), parameters);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count == 1)
                {
                    DataRow row = ds.Tables[0].Rows[0];
                    AdminLoginEntity entity = new AdminLoginEntity();
                    if (!Convert.IsDBNull(row["AdminId"]))
                    {
                        entity.AdminId = (int)row["AdminId"];
                    }
                    entity.AdminName = row["AdminName"].ToString();
                    entity.PassWord = row["PassWord"].ToString();
                    if (!Convert.IsDBNull(row["AddTime"]))
                    {
                        entity.AddTime = (DateTime)row["AddTime"];
                    }
                    if (!Convert.IsDBNull(row["LastLogin"]))
                    {
                        entity.LastLogin = (DateTime)row["LastLogin"];
                    }
                    entity.Email = row["Email"].ToString();
                    if (!Convert.IsDBNull(row["RoleId"]))
                    {
                        entity.RoleId = (int)row["RoleId"];
                    }
                    if (!Convert.IsDBNull(row["IsAudit"]))
                    {
                        entity.IsAudit = (int)row["IsAudit"];
                    }
                    entity.LastIP = row["LastIP"].ToString();
                    return entity;
                }
                else
                {
                    return null;
                }
            }

            public override List<AdminLoginEntity> Find(string strWhere, SqlParameter[] parameters)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select *");
                strSql.Append(" FROM AdminLogin(nolock) ");
                if (strWhere.Trim() != "")
                {
                    strSql.Append(" where " + strWhere);
                }

                DataSet ds = sqlHelper.ExecuteDateSet(strSql.ToString(), parameters);
                if (ds != null && ds.Tables.Count > 0)
                {
                    List<AdminLoginEntity> list = new List<AdminLoginEntity>();
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        AdminLoginEntity entity = new AdminLoginEntity();
                        if (!Convert.IsDBNull(row["AdminId"]))
                        {
                            entity.AdminId = (int)row["AdminId"];
                        }
                        entity.AdminName = row["AdminName"].ToString();
                        entity.PassWord = row["PassWord"].ToString();
                        if (!Convert.IsDBNull(row["AddTime"]))
                        {
                            entity.AddTime = (DateTime)row["AddTime"];
                        }
                        if (!Convert.IsDBNull(row["LastLogin"]))
                        {
                            entity.LastLogin = (DateTime)row["LastLogin"];
                        }
                        entity.Email = row["Email"].ToString();
                        if (!Convert.IsDBNull(row["RoleId"]))
                        {
                            entity.RoleId = (int)row["RoleId"];
                        }
                        if (!Convert.IsDBNull(row["IsAudit"]))
                        {
                            entity.IsAudit = (int)row["IsAudit"];
                        }
                        entity.LastIP = row["LastIP"].ToString();

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
                strSql.Append(" FROM AdminLogin(nolock)");
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
                string sql = "select count(*) from AdminLogin ";
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

                    sql += " (ORDER BY AdminId " + method + ")";//默认按主键排序

                }

                sql += " AS RowNumber,* FROM AdminLogin";

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

