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
    public partial class UsersEntity
    {
        private SqlHelper sqlHelper;

        #region const fields
        public const string DBName = "Cheese";
        public const string TableName = "Users";
        public const string PrimaryKey = "PK_User";
        #endregion

        #region columns
        public struct Columns
        {
            public const string ID = "ID";
            public const string Email = "Email";
            public const string Password = "Password";
            public const string NickName = "NickName";
            public const string ValidStatus = "ValidStatus";
            public const string CreateDate = "CreateDate";
        }
        #endregion

        #region constructors
        public UsersEntity()
        {
            sqlHelper = new SqlHelper(DBName);
        }

        public UsersEntity(int id, string email, string password, string nickname, int validstatus, DateTime createdate)
        {
            this.ID = id;

            this.Email = email;

            this.Password = password;

            this.NickName = nickname;

            this.ValidStatus = validstatus;

            this.CreateDate = createdate;

        }
        #endregion

        #region Properties

        public int? ID
        {
            get;
            set;
        }


        public string Email
        {
            get;
            set;
        }


        public string Password
        {
            get;
            set;
        }


        public string NickName
        {
            get;
            set;
        }


        public int? ValidStatus
        {
            get;
            set;
        }


        public DateTime? CreateDate
        {
            get;
            set;
        }

        #endregion

        #region CUD Method

        public void Add()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Users(");
            strSql.Append("ID,Email,Password,NickName,ValidStatus,CreateDate)");
            strSql.Append(" values (");
            strSql.Append("@ID,@Email,@Password,@NickName,@ValidStatus,@CreateDate)");
            SqlParameter[] parameters = {
					new SqlParameter("@ID",SqlDbType.Int),
					new SqlParameter("@Email",SqlDbType.VarChar),
					new SqlParameter("@Password",SqlDbType.VarChar),
					new SqlParameter("@NickName",SqlDbType.NVarChar),
					new SqlParameter("@ValidStatus",SqlDbType.Int),
					new SqlParameter("@CreateDate",SqlDbType.DateTime)
					};
            parameters[0].Value = this.ID;
            parameters[1].Value = this.Email;
            parameters[2].Value = this.Password;
            parameters[3].Value = this.NickName;
            parameters[4].Value = this.ValidStatus;
            parameters[5].Value = this.CreateDate;

            sqlHelper.ExecuteSql(strSql.ToString(), parameters);
        }

        public void Update()
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Users set ");
            strSql.Append("Email=@Email,");
            strSql.Append("Password=@Password,");
            strSql.Append("NickName=@NickName,");
            strSql.Append("ValidStatus=@ValidStatus,");
            strSql.Append("CreateDate=@CreateDate");

            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID",SqlDbType.Int),
					new SqlParameter("@Email",SqlDbType.VarChar),
					new SqlParameter("@Password",SqlDbType.VarChar),
					new SqlParameter("@NickName",SqlDbType.NVarChar),
					new SqlParameter("@ValidStatus",SqlDbType.Int),
					new SqlParameter("@CreateDate",SqlDbType.DateTime)
					};
            parameters[0].Value = this.ID;
            parameters[1].Value = this.Email;
            parameters[2].Value = this.Password;
            parameters[3].Value = this.NickName;
            parameters[4].Value = this.ValidStatus;
            parameters[5].Value = this.CreateDate;

            sqlHelper.ExecuteSql(strSql.ToString(), parameters);
        }

        public void Delete(int primaryKeyId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Users ");
            strSql.Append(" where ID=@primaryKeyId");
            SqlParameter[] parameters = {
					new SqlParameter("@primaryKeyId", SqlDbType.Int)
				};
            parameters[0].Value = primaryKeyId;
            sqlHelper.ExecuteSql(strSql.ToString(), parameters);
        }

        #endregion

        public class UsersEntityFinder
        {
            private SqlHelper sqlHelper;
            public const string DBName = "Cheese";

            public UsersEntityFinder()
            {
                sqlHelper = new SqlHelper(DBName);
            }

            public UsersEntity FindById(int primaryKeyId)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select * from Users ");
                strSql.Append(" where ID=@primaryKeyId");
                SqlParameter[] parameters = {
						new SqlParameter("@primaryKeyId", SqlDbType.Int)};
                parameters[0].Value = primaryKeyId;
                DataSet ds = sqlHelper.ExecuteDateSet(strSql.ToString(), parameters);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count == 1)
                {
                    DataRow row = ds.Tables[0].Rows[0];
                    UsersEntity entity = new UsersEntity();
                    if (!Convert.IsDBNull(row["ID"]))
                    {
                        entity.ID = (int)row["ID"];
                    }
                    entity.Email = row["Email"].ToString();
                    entity.Password = row["Password"].ToString();
                    entity.NickName = row["NickName"].ToString();
                    if (!Convert.IsDBNull(row["ValidStatus"]))
                    {
                        entity.ValidStatus = (int)row["ValidStatus"];
                    }
                    if (!Convert.IsDBNull(row["CreateDate"]))
                    {
                        entity.CreateDate = (DateTime)row["CreateDate"];
                    }
                    return entity;
                }
                else
                {
                    return null;
                }
            }

            public List<UsersEntity> Find(string strWhere)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select *");
                strSql.Append(" FROM Users(nolock) ");
                if (strWhere.Trim() != "")
                {
                    strSql.Append(" where " + strWhere);
                }
                SqlDataReader dr = sqlHelper.ExecuteReader(strSql.ToString());
                List<UsersEntity> list = new List<UsersEntity>();
                while (dr.Read())
                {
                    UsersEntity entity = new UsersEntity();
                    if (!Convert.IsDBNull(dr["ID"]))
                    {
                        entity.ID = (int)dr["ID"];
                    }
                    entity.Email = dr["Email"].ToString();
                    entity.Password = dr["Password"].ToString();
                    entity.NickName = dr["NickName"].ToString();
                    if (!Convert.IsDBNull(dr["ValidStatus"]))
                    {
                        entity.ValidStatus = (int)dr["ValidStatus"];
                    }
                    if (!Convert.IsDBNull(dr["CreateDate"]))
                    {
                        entity.CreateDate = (DateTime)dr["CreateDate"];
                    }
                    list.Add(entity);
                }

                dr.Close();
                dr.Dispose();

                return list;
            }

            public DataSet GetDataSet(string strWhere, SqlParameter[] param)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select *");
                strSql.Append(" FROM Users(nolock)");
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
                string sql = "select count(*) from Users ";
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

                sql += " AS RowNumber,* FROM Users";

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