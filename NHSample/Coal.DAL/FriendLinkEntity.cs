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
    public partial class FriendLinkEntity
    {
        private SqlHelper sqlHelper;

        #region const fields
        public const string DBName = "cheese";
        public const string TableName = "FriendLink";
        public const string PrimaryKey = "PK_FRIENDLINK";
        #endregion

        #region columns
        public struct Columns
        {
            public const string LinkId = "LinkId";
            public const string LinkName = "LinkName";
            public const string LinkUrl = "LinkUrl";
            public const string LinkLogo = "LinkLogo";
            public const string LinkDesc = "LinkDesc";
            public const string ShowOrder = "ShowOrder";
            public const string CategoryId = "CategoryId";
        }
        #endregion

        #region constructors
        public FriendLinkEntity()
        {
            sqlHelper = new SqlHelper(DBName);
        }

        public FriendLinkEntity(int linkid, string linkname, string linkurl, string linklogo, string linkdesc, int showorder, int categoryid)
        {
            this.LinkId = linkid;

            this.LinkName = linkname;

            this.LinkUrl = linkurl;

            this.LinkLogo = linklogo;

            this.LinkDesc = linkdesc;

            this.ShowOrder = showorder;

            this.CategoryId = categoryid;

        }
        #endregion

        #region Properties
        /// <summary>
        /// 标识ID
        /// </summary>
        public int? LinkId
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        public string LinkName
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        public string LinkUrl
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        public string LinkLogo
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        public string LinkDesc
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        public int? ShowOrder
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        public int? CategoryId
        {
            get;
            set;
        }

        #endregion

        public class FriendLinkDAO : SqlDAO<FriendLinkEntity>
        {
            private SqlHelper sqlHelper;
            public const string DBName = "cheese";

            public FriendLinkDAO()
            {
                sqlHelper = new SqlHelper(DBName);
            }

            public override void Add(FriendLinkEntity entity)
            {

                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into FriendLink(");
                strSql.Append("LinkName,LinkUrl,LinkLogo,LinkDesc,ShowOrder,CategoryId)");
                strSql.Append(" values (");
                strSql.Append("@LinkName,@LinkUrl,@LinkLogo,@LinkDesc,@ShowOrder,@CategoryId)");
                SqlParameter[] parameters = {
					new SqlParameter("@LinkName",SqlDbType.NVarChar),
					new SqlParameter("@LinkUrl",SqlDbType.NVarChar),
					new SqlParameter("@LinkLogo",SqlDbType.NVarChar),
					new SqlParameter("@LinkDesc",SqlDbType.NVarChar),
					new SqlParameter("@ShowOrder",SqlDbType.Int),
					new SqlParameter("@CategoryId",SqlDbType.Int)
					};
                parameters[0].Value = entity.LinkName;
                parameters[1].Value = entity.LinkUrl;
                parameters[2].Value = entity.LinkLogo;
                parameters[3].Value = entity.LinkDesc;
                parameters[4].Value = entity.ShowOrder;
                parameters[5].Value = entity.CategoryId;

                sqlHelper.ExecuteSql(strSql.ToString(), parameters);
            }

            public override void Update(FriendLinkEntity entity)
            {

                StringBuilder strSql = new StringBuilder();
                strSql.Append("update FriendLink set ");
                strSql.Append("LinkName=@LinkName,");
                strSql.Append("LinkUrl=@LinkUrl,");
                strSql.Append("LinkLogo=@LinkLogo,");
                strSql.Append("LinkDesc=@LinkDesc,");
                strSql.Append("ShowOrder=@ShowOrder,");
                strSql.Append("CategoryId=@CategoryId");

                strSql.Append(" where LinkId=@LinkId");
                SqlParameter[] parameters = {
					new SqlParameter("@LinkId",SqlDbType.Int),
					new SqlParameter("@LinkName",SqlDbType.NVarChar),
					new SqlParameter("@LinkUrl",SqlDbType.NVarChar),
					new SqlParameter("@LinkLogo",SqlDbType.NVarChar),
					new SqlParameter("@LinkDesc",SqlDbType.NVarChar),
					new SqlParameter("@ShowOrder",SqlDbType.Int),
					new SqlParameter("@CategoryId",SqlDbType.Int)
					};
                parameters[0].Value = entity.LinkId;
                parameters[1].Value = entity.LinkName;
                parameters[2].Value = entity.LinkUrl;
                parameters[3].Value = entity.LinkLogo;
                parameters[4].Value = entity.LinkDesc;
                parameters[5].Value = entity.ShowOrder;
                parameters[6].Value = entity.CategoryId;

                sqlHelper.ExecuteSql(strSql.ToString(), parameters);
            }

            public bool UpdateSet(int ID, string ColumnName, string Value)
            {
                try
                {
                    StringBuilder StrSql = new StringBuilder();
                    StrSql.Append("update FriendLink set ");
                    StrSql.Append(ColumnName + "='" + Value + "'");
                    StrSql.Append(" where LinkId=" + ID);
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
                string strSql = "delete from FriendLink where LinkId=" + ID;
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

            public override void Delete(FriendLinkEntity entity)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("delete from FriendLink ");
                strSql.Append(" where LinkId=@primaryKeyId");
                SqlParameter[] parameters = {
						new SqlParameter("@primaryKeyId", SqlDbType.Int)
					};
                parameters[0].Value = entity.LinkId;
                sqlHelper.ExecuteSql(strSql.ToString(), parameters);
            }

            public override FriendLinkEntity FindById(long primaryKeyId)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select * from FriendLink ");
                strSql.Append(" where LinkId=@primaryKeyId");
                SqlParameter[] parameters = {
						new SqlParameter("@primaryKeyId", SqlDbType.Int)};
                parameters[0].Value = primaryKeyId;
                DataSet ds = sqlHelper.ExecuteDateSet(strSql.ToString(), parameters);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count == 1)
                {
                    DataRow row = ds.Tables[0].Rows[0];
                    FriendLinkEntity entity = new FriendLinkEntity();
                    if (!Convert.IsDBNull(row["LinkId"]))
                    {
                        entity.LinkId = (int)row["LinkId"];
                    }
                    entity.LinkName = row["LinkName"].ToString();
                    entity.LinkUrl = row["LinkUrl"].ToString();
                    entity.LinkLogo = row["LinkLogo"].ToString();
                    entity.LinkDesc = row["LinkDesc"].ToString();
                    if (!Convert.IsDBNull(row["ShowOrder"]))
                    {
                        entity.ShowOrder = (int)row["ShowOrder"];
                    }
                    if (!Convert.IsDBNull(row["CategoryId"]))
                    {
                        entity.CategoryId = (int)row["CategoryId"];
                    }
                    return entity;
                }
                else
                {
                    return null;
                }
            }

            public override List<FriendLinkEntity> Find(string strWhere, SqlParameter[] parameters)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select *");
                strSql.Append(" FROM FriendLink(nolock) ");
                if (strWhere.Trim() != "")
                {
                    strSql.Append(" where " + strWhere);
                }

                DataSet ds = sqlHelper.ExecuteDateSet(strSql.ToString(), parameters);
                if (ds != null && ds.Tables.Count > 0)
                {
                    List<FriendLinkEntity> list = new List<FriendLinkEntity>();
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        FriendLinkEntity entity = new FriendLinkEntity();
                        if (!Convert.IsDBNull(row["LinkId"]))
                        {
                            entity.LinkId = (int)row["LinkId"];
                        }
                        entity.LinkName = row["LinkName"].ToString();
                        entity.LinkUrl = row["LinkUrl"].ToString();
                        entity.LinkLogo = row["LinkLogo"].ToString();
                        entity.LinkDesc = row["LinkDesc"].ToString();
                        if (!Convert.IsDBNull(row["ShowOrder"]))
                        {
                            entity.ShowOrder = (int)row["ShowOrder"];
                        }
                        if (!Convert.IsDBNull(row["CategoryId"]))
                        {
                            entity.CategoryId = (int)row["CategoryId"];
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
                strSql.Append(" FROM FriendLink(nolock)");
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
                string sql = "select count(*) from FriendLink ";
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
                    sql += "  LinkId )";
                }
                else
                {

                    sql += " (ORDER BY LinkId )";//默认按主键排序

                }

                sql += " AS RowNumber,* FROM FriendLink";

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

