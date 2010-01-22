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
    public partial class CompanyIntegrityEntity
    {
        private SqlHelper sqlHelper;

        #region const fields
        public const string DBName = "cheese";
        public const string TableName = "CompanyIntegrity";
        public const string PrimaryKey = "PK_CompanyIntegrity";
        #endregion

        #region columns
        public struct Columns
        {
            public const string ID = "ID";
            public const string CompanyId = "CompanyId";
            public const string Integritynumber = "Integritynumber";
            public const string Content = "Content";
            public const string Discusser = "Discusser";
            public const string CreateTime = "CreateTime";
        }
        #endregion

        #region constructors
        public CompanyIntegrityEntity()
        {
            sqlHelper = new SqlHelper(DBName);
        }

        public CompanyIntegrityEntity(int id, int companyid, int integritynumber, string content, int discusser, DateTime createtime)
        {
            this.ID = id;

            this.CompanyId = companyid;

            this.Integritynumber = integritynumber;

            this.Content = content;

            this.Discusser = discusser;

            this.CreateTime = createtime;

        }
        #endregion

        #region Properties
        /// <summary>
        /// 主键
        /// </summary>
        public int? ID
        {
            get;
            set;
        }

        /// <summary>
        /// 所评论的公司ID
        /// </summary>
        public int? CompanyId
        {
            get;
            set;
        }

        /// <summary>
        /// 诚信分值
        /// </summary>
        public int? Integritynumber
        {
            get;
            set;
        }

        /// <summary>
        /// 评论内容
        /// </summary>
        public string Content
        {
            get;
            set;
        }

        /// <summary>
        /// 评论者ID
        /// </summary>
        public int? Discusser
        {
            get;
            set;
        }

        /// <summary>
        /// 评论时间
        /// </summary>
        public DateTime? CreateTime
        {
            get;
            set;
        }

        #endregion

        public class CompanyIntegrityDAO : SqlDAO<CompanyIntegrityEntity>
        {
            private SqlHelper sqlHelper;
            public const string DBName = "cheese";

            public CompanyIntegrityDAO()
            {
                sqlHelper = new SqlHelper(DBName);
            }

            public override void Add(CompanyIntegrityEntity entity)
            {

                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into CompanyIntegrity(");
                strSql.Append("CompanyId,Integritynumber,Content,Discusser,CreateTime)");
                strSql.Append(" values (");
                strSql.Append("@CompanyId,@Integritynumber,@Content,@Discusser,@CreateTime)");
                SqlParameter[] parameters = {
					new SqlParameter("@CompanyId",SqlDbType.Int),
					new SqlParameter("@Integritynumber",SqlDbType.Int),
					new SqlParameter("@Content",SqlDbType.Text),
					new SqlParameter("@Discusser",SqlDbType.Int),
					new SqlParameter("@CreateTime",SqlDbType.DateTime)
					};
                parameters[0].Value = entity.CompanyId;
                parameters[1].Value = entity.Integritynumber;
                parameters[2].Value = entity.Content;
                parameters[3].Value = entity.Discusser;
                parameters[4].Value = entity.CreateTime;

                sqlHelper.ExecuteSql(strSql.ToString(), parameters);
            }

            public override void Update(CompanyIntegrityEntity entity)
            {

                StringBuilder strSql = new StringBuilder();
                strSql.Append("update CompanyIntegrity set ");
                strSql.Append("CompanyId=@CompanyId,");
                strSql.Append("Integritynumber=@Integritynumber,");
                strSql.Append("Content=@Content,");
                strSql.Append("Discusser=@Discusser,");
                strSql.Append("CreateTime=@CreateTime");

                strSql.Append(" where ID=@ID");
                SqlParameter[] parameters = {
					new SqlParameter("@ID",SqlDbType.Int),
					new SqlParameter("@CompanyId",SqlDbType.Int),
					new SqlParameter("@Integritynumber",SqlDbType.Int),
					new SqlParameter("@Content",SqlDbType.Text),
					new SqlParameter("@Discusser",SqlDbType.Int),
					new SqlParameter("@CreateTime",SqlDbType.DateTime)
					};
                parameters[0].Value = entity.ID;
                parameters[1].Value = entity.CompanyId;
                parameters[2].Value = entity.Integritynumber;
                parameters[3].Value = entity.Content;
                parameters[4].Value = entity.Discusser;
                parameters[5].Value = entity.CreateTime;

                sqlHelper.ExecuteSql(strSql.ToString(), parameters);
            }

            public override void Delete(CompanyIntegrityEntity entity)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("delete from CompanyIntegrity ");
                strSql.Append(" where ID=@primaryKeyId");
                SqlParameter[] parameters = {
						new SqlParameter("@primaryKeyId", SqlDbType.Int)
					};
                parameters[0].Value = entity.ID;
                sqlHelper.ExecuteSql(strSql.ToString(), parameters);
            }

            public override CompanyIntegrityEntity FindById(long primaryKeyId)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select * from CompanyIntegrity ");
                strSql.Append(" where ID=@primaryKeyId");
                SqlParameter[] parameters = {
						new SqlParameter("@primaryKeyId", SqlDbType.Int)};
                parameters[0].Value = primaryKeyId;
                DataSet ds = sqlHelper.ExecuteDateSet(strSql.ToString(), parameters);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count == 1)
                {
                    DataRow row = ds.Tables[0].Rows[0];
                    CompanyIntegrityEntity entity = new CompanyIntegrityEntity();
                    if (!Convert.IsDBNull(row["ID"]))
                    {
                        entity.ID = (int)row["ID"];
                    }
                    if (!Convert.IsDBNull(row["CompanyId"]))
                    {
                        entity.CompanyId = (int)row["CompanyId"];
                    }
                    if (!Convert.IsDBNull(row["Integritynumber"]))
                    {
                        entity.Integritynumber = (int)row["Integritynumber"];
                    }
                    entity.Content = row["Content"].ToString();
                    if (!Convert.IsDBNull(row["Discusser"]))
                    {
                        entity.Discusser = (int)row["Discusser"];
                    }
                    if (!Convert.IsDBNull(row["CreateTime"]))
                    {
                        entity.CreateTime = (DateTime)row["CreateTime"];
                    }
                    return entity;
                }
                else
                {
                    return null;
                }
            }

            public override List<CompanyIntegrityEntity> Find(string strWhere, SqlParameter[] parameters)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select *");
                strSql.Append(" FROM CompanyIntegrity(nolock) ");
                if (strWhere.Trim() != "")
                {
                    strSql.Append(" where " + strWhere);
                }

                DataSet ds = sqlHelper.ExecuteDateSet(strSql.ToString(), parameters);
                if (ds != null && ds.Tables.Count > 0)
                {
                    List<CompanyIntegrityEntity> list = new List<CompanyIntegrityEntity>();
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        CompanyIntegrityEntity entity = new CompanyIntegrityEntity();
                        if (!Convert.IsDBNull(row["ID"]))
                        {
                            entity.ID = (int)row["ID"];
                        }
                        if (!Convert.IsDBNull(row["CompanyId"]))
                        {
                            entity.CompanyId = (int)row["CompanyId"];
                        }
                        if (!Convert.IsDBNull(row["Integritynumber"]))
                        {
                            entity.Integritynumber = (int)row["Integritynumber"];
                        }
                        entity.Content = row["Content"].ToString();
                        if (!Convert.IsDBNull(row["Discusser"]))
                        {
                            entity.Discusser = (int)row["Discusser"];
                        }
                        if (!Convert.IsDBNull(row["CreateTime"]))
                        {
                            entity.CreateTime = (DateTime)row["CreateTime"];
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
                strSql.Append(" FROM CompanyIntegrity(nolock)");
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
                string sql = "select count(*) from CompanyIntegrity ";
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

                    sql += " (ORDER BY ID " + method + ")";//默认按主键排序

                }

                sql += " AS RowNumber,* FROM CompanyIntegrity";

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

