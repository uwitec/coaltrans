using System;
using System.Collections;
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
    public partial class LinkCategoryEntity
    {
        private SqlHelper sqlHelper;

        #region const fields
        public const string DBName = "cheese";
        public const string TableName = "LinkCategory";
        public const string PrimaryKey = "PK_LINKCATEGORY";
        #endregion

        #region columns
        public struct Columns
        {
            public const string CategoryId = "CategoryId";
            public const string CategoryName = "CategoryName";
        }
        #endregion

        #region constructors
        public LinkCategoryEntity()
        {
            sqlHelper = new SqlHelper(DBName);
        }

        public LinkCategoryEntity(int categoryid, string categoryname)
        {
            this.CategoryId = categoryid;

            this.CategoryName = categoryname;

        }
        #endregion

        #region Properties
        /// <summary>
        /// 标识ID
        /// </summary>
        public int? CategoryId
        {
            get;
            set;
        }

        /// <summary>
        /// 分布地址名
        /// </summary>
        public string CategoryName
        {
            get;
            set;
        }

        #endregion

        public class LinkCategoryDAO : SqlDAO<LinkCategoryEntity>
        {
            private SqlHelper sqlHelper;
            public const string DBName = "cheese";

            public LinkCategoryDAO()
            {
                sqlHelper = new SqlHelper(DBName);
            }

            public override void Add(LinkCategoryEntity entity)
            {

                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into LinkCategory(");
                strSql.Append("CategoryName)");
                strSql.Append(" values (");
                strSql.Append("@CategoryName)");
                SqlParameter[] parameters = {
					new SqlParameter("@CategoryName",SqlDbType.VarChar)
					};
                parameters[0].Value = entity.CategoryName;

                sqlHelper.ExecuteSql(strSql.ToString(), parameters);
            }

            public override void Update(LinkCategoryEntity entity)
            {

                StringBuilder strSql = new StringBuilder();
                strSql.Append("update LinkCategory set ");
                strSql.Append("CategoryName=@CategoryName");

                strSql.Append(" where CategoryId=@CategoryId");
                SqlParameter[] parameters = {
					new SqlParameter("@CategoryId",SqlDbType.Int),
					new SqlParameter("@CategoryName",SqlDbType.VarChar)
					};
                parameters[0].Value = entity.CategoryId;
                parameters[1].Value = entity.CategoryName;

                sqlHelper.ExecuteSql(strSql.ToString(), parameters);
            }

            public bool UpdateSet(int ID, string ColumnName, string Value)
            {
                try
                {
                    StringBuilder StrSql = new StringBuilder();
                    StrSql.Append("update LinkCategory set ");
                    StrSql.Append(ColumnName + "='" + Value + "'");
                    StrSql.Append(" where CategoryId=" + ID);
                    sqlHelper.ExecuteSql(StrSql.ToString(), null);
                    return true;
                }
                catch
                {
                    return false;
                }
            }

            public bool Delete(int ID)
            {
                string strSql = "delete from LinkCategory where CategoryId=" + ID;
                try
                {
                    sqlHelper.ExecuteSql(strSql, null);
                    return true;
                }
                catch
                {
                    return false;
                }
            }

            public override void Delete(LinkCategoryEntity entity)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("delete from LinkCategory ");
                strSql.Append(" where CategoryId=@primaryKeyId");
                SqlParameter[] parameters = {
						new SqlParameter("@primaryKeyId", SqlDbType.Int)
					};
                parameters[0].Value = entity.CategoryId;
                sqlHelper.ExecuteSql(strSql.ToString(), parameters);
            }

            public override LinkCategoryEntity FindById(long primaryKeyId)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select * from LinkCategory ");
                strSql.Append(" where CategoryId=@primaryKeyId");
                SqlParameter[] parameters = {
						new SqlParameter("@primaryKeyId", SqlDbType.Int)};
                parameters[0].Value = primaryKeyId;
                DataSet ds = sqlHelper.ExecuteDateSet(strSql.ToString(), parameters);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count == 1)
                {
                    DataRow row = ds.Tables[0].Rows[0];
                    LinkCategoryEntity entity = new LinkCategoryEntity();
                    if (!Convert.IsDBNull(row["CategoryId"]))
                    {
                        entity.CategoryId = (int)row["CategoryId"];
                    }
                    entity.CategoryName = row["CategoryName"].ToString();
                    return entity;
                }
                else
                {
                    return null;
                }
            }

            public override List<LinkCategoryEntity> Find(string strWhere, SqlParameter[] parameters)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select *");
                strSql.Append(" FROM LinkCategory(nolock) ");
                if (strWhere.Trim() != "")
                {
                    strSql.Append(" where " + strWhere);
                }

                DataSet ds = sqlHelper.ExecuteDateSet(strSql.ToString(), parameters);
                if (ds != null && ds.Tables.Count > 0)
                {
                    List<LinkCategoryEntity> list = new List<LinkCategoryEntity>();
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        LinkCategoryEntity entity = new LinkCategoryEntity();
                        if (!Convert.IsDBNull(row["CategoryId"]))
                        {
                            entity.CategoryId = (int)row["CategoryId"];
                        }
                        entity.CategoryName = row["CategoryName"].ToString();

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
                strSql.Append(" FROM LinkCategory(nolock)");
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
                string sql = "select count(*) from LinkCategory ";
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
            public DataTable GetPager(string where, SqlParameter[] param, Hashtable ht, int pageSize, int pageNumber)
            {
                int startNumber = pageSize * (pageNumber - 1);

                string sql = string.Format("SELECT TOP {0} * FROM (SELECT ROW_NUMBER() OVER", pageSize);

                if (ht != null && ht.Count > 0)
                {
                    sql += " (ORDER BY";
                    foreach (string key in ht.Keys)
                    {
                        sql += string.Format(" {0} {1},", key, ht[key].ToString());
                    }
                    sql += "  CategoryId )";
                }
                else
                {

                    sql += " (ORDER BY CategoryId )";//默认按主键排序

                }

                sql += " AS RowNumber,* FROM LinkCategory";

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

