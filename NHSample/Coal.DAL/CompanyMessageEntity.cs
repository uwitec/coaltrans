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
    public partial class CompanyMessageEntity
    {
        private SqlHelper sqlHelper;

        #region const fields
        public const string DBName = "cheese";
        public const string TableName = "CompanyMessage";
        public const string PrimaryKey = "PK_CompanyMessage";
        #endregion

        #region columns
        public struct Columns
        {
            public const string ID = "ID";
            public const string Sender = "Sender";
            public const string embracer = "embracer";
            public const string MessageTitle = "MessageTitle";
            public const string MessageContent = "MessageContent";
            public const string ParentId = "ParentId";
            public const string IsSee = "IsSee";
        }
        #endregion

        #region constructors
        public CompanyMessageEntity()
        {
            sqlHelper = new SqlHelper(DBName);
        }

        public CompanyMessageEntity(int id, int sender, int embracer, string messagetitle, string messagecontent, int parentid, int issee)
        {
            this.ID = id;

            this.Sender = sender;

            this.embracer = embracer;

            this.MessageTitle = messagetitle;

            this.MessageContent = messagecontent;

            this.ParentId = parentid;

            this.IsSee = issee;

        }
        #endregion

        #region Properties
        /// <summary>
        /// 公司留言表ID
        /// </summary>
        public int? ID
        {
            get;
            set;
        }

        /// <summary>
        /// 留言者UserId
        /// </summary>
        public int? Sender
        {
            get;
            set;
        }

        /// <summary>
        /// 接收者UserId
        /// </summary>
        public int? embracer
        {
            get;
            set;
        }

        /// <summary>
        /// 留言信息标题
        /// </summary>
        public string MessageTitle
        {
            get;
            set;
        }

        /// <summary>
        /// 留言信息内容
        /// </summary>
        public string MessageContent
        {
            get;
            set;
        }

        /// <summary>
        /// 留言父级ID
        /// </summary>
        public int? ParentId
        {
            get;
            set;
        }

        /// <summary>
        /// 留言是否查看
        /// </summary>
        public int? IsSee
        {
            get;
            set;
        }

        #endregion

        public class CompanyMessageDAO : SqlDAO<CompanyMessageEntity>
        {
            private SqlHelper sqlHelper;
            public const string DBName = "cheese";

            public CompanyMessageDAO()
            {
                sqlHelper = new SqlHelper(DBName);
            }

            public override void Add(CompanyMessageEntity entity)
            {

                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into CompanyMessage(");
                strSql.Append("Sender,embracer,MessageTitle,MessageContent,ParentId,IsSee)");
                strSql.Append(" values (");
                strSql.Append("@Sender,@embracer,@MessageTitle,@MessageContent,@ParentId,@IsSee)");
                SqlParameter[] parameters = {
					new SqlParameter("@Sender",SqlDbType.Int),
					new SqlParameter("@embracer",SqlDbType.Int),
					new SqlParameter("@MessageTitle",SqlDbType.NVarChar),
					new SqlParameter("@MessageContent",SqlDbType.VarChar),
					new SqlParameter("@ParentId",SqlDbType.Int),
					new SqlParameter("@IsSee",SqlDbType.Int)
					};
                parameters[0].Value = entity.Sender;
                parameters[1].Value = entity.embracer;
                parameters[2].Value = entity.MessageTitle;
                parameters[3].Value = entity.MessageContent;
                parameters[4].Value = entity.ParentId;
                parameters[5].Value = entity.IsSee;

                sqlHelper.ExecuteSql(strSql.ToString(), parameters);
            }

            public override void Update(CompanyMessageEntity entity)
            {

                StringBuilder strSql = new StringBuilder();
                strSql.Append("update CompanyMessage set ");
                strSql.Append("Sender=@Sender,");
                strSql.Append("embracer=@embracer,");
                strSql.Append("MessageTitle=@MessageTitle,");
                strSql.Append("MessageContent=@MessageContent,");
                strSql.Append("ParentId=@ParentId,");
                strSql.Append("IsSee=@IsSee");

                strSql.Append(" where ID=@ID");
                SqlParameter[] parameters = {
					new SqlParameter("@ID",SqlDbType.Int),
					new SqlParameter("@Sender",SqlDbType.Int),
					new SqlParameter("@embracer",SqlDbType.Int),
					new SqlParameter("@MessageTitle",SqlDbType.NVarChar),
					new SqlParameter("@MessageContent",SqlDbType.VarChar),
					new SqlParameter("@ParentId",SqlDbType.Int),
					new SqlParameter("@IsSee",SqlDbType.Int)
					};
                parameters[0].Value = entity.ID;
                parameters[1].Value = entity.Sender;
                parameters[2].Value = entity.embracer;
                parameters[3].Value = entity.MessageTitle;
                parameters[4].Value = entity.MessageContent;
                parameters[5].Value = entity.ParentId;
                parameters[6].Value = entity.IsSee;

                sqlHelper.ExecuteSql(strSql.ToString(), parameters);
            }

            public override void Delete(CompanyMessageEntity entity)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("delete from CompanyMessage ");
                strSql.Append(" where ID=@primaryKeyId");
                SqlParameter[] parameters = {
						new SqlParameter("@primaryKeyId", SqlDbType.Int)
					};
                parameters[0].Value = entity.ID;
                sqlHelper.ExecuteSql(strSql.ToString(), parameters);
            }

            public override CompanyMessageEntity FindById(long primaryKeyId)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select * from CompanyMessage ");
                strSql.Append(" where ID=@primaryKeyId");
                SqlParameter[] parameters = {
						new SqlParameter("@primaryKeyId", SqlDbType.Int)};
                parameters[0].Value = primaryKeyId;
                DataSet ds = sqlHelper.ExecuteDateSet(strSql.ToString(), parameters);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count == 1)
                {
                    DataRow row = ds.Tables[0].Rows[0];
                    CompanyMessageEntity entity = new CompanyMessageEntity();
                    if (!Convert.IsDBNull(row["ID"]))
                    {
                        entity.ID = (int)row["ID"];
                    }
                    if (!Convert.IsDBNull(row["Sender"]))
                    {
                        entity.Sender = (int)row["Sender"];
                    }
                    if (!Convert.IsDBNull(row["embracer"]))
                    {
                        entity.embracer = (int)row["embracer"];
                    }
                    entity.MessageTitle = row["MessageTitle"].ToString();
                    entity.MessageContent = row["MessageContent"].ToString();
                    if (!Convert.IsDBNull(row["ParentId"]))
                    {
                        entity.ParentId = (int)row["ParentId"];
                    }
                    if (!Convert.IsDBNull(row["IsSee"]))
                    {
                        entity.IsSee = (int)row["IsSee"];
                    }
                    return entity;
                }
                else
                {
                    return null;
                }
            }

            public override List<CompanyMessageEntity> Find(string strWhere, SqlParameter[] parameters)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select *");
                strSql.Append(" FROM CompanyMessage(nolock) ");
                if (strWhere.Trim() != "")
                {
                    strSql.Append(" where " + strWhere);
                }

                DataSet ds = sqlHelper.ExecuteDateSet(strSql.ToString(), parameters);
                if (ds != null && ds.Tables.Count > 0)
                {
                    List<CompanyMessageEntity> list = new List<CompanyMessageEntity>();
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        CompanyMessageEntity entity = new CompanyMessageEntity();
                        if (!Convert.IsDBNull(row["ID"]))
                        {
                            entity.ID = (int)row["ID"];
                        }
                        if (!Convert.IsDBNull(row["Sender"]))
                        {
                            entity.Sender = (int)row["Sender"];
                        }
                        if (!Convert.IsDBNull(row["embracer"]))
                        {
                            entity.embracer = (int)row["embracer"];
                        }
                        entity.MessageTitle = row["MessageTitle"].ToString();
                        entity.MessageContent = row["MessageContent"].ToString();
                        if (!Convert.IsDBNull(row["ParentId"]))
                        {
                            entity.ParentId = (int)row["ParentId"];
                        }
                        if (!Convert.IsDBNull(row["IsSee"]))
                        {
                            entity.IsSee = (int)row["IsSee"];
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
                strSql.Append(" FROM CompanyMessage(nolock)");
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
                string sql = "select count(*) from CompanyMessage ";
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

                sql += " AS RowNumber,* FROM CompanyMessage";

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

