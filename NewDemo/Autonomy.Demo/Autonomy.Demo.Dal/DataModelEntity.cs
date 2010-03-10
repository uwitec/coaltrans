using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using System.Reflection;
using System.Text;
using Autonomy.Demo.Dal;

namespace Autonomy.Demo.Dal
{
    [Serializable]
    public partial class DataModelEntity
    {
        private SqlHelper sqlHelper;

        #region const fields
        public const string DBName = "SentimentConnStr";
        public const string TableName = "DataModel";
        public const string PrimaryKey = "PK_DATAMODEL";
        #endregion

        #region columns
        public struct Columns
        {
            public const string ID = "ID";
            public const string SiteName = "SiteName";
            public const string URL = "URL";
            public const string Title = "Title";
            public const string BizDate = "BizDate";
            public const string Content = "Content";
            public const string HitCount = "HitCount";
            public const string RelayCount = "RelayCount";
            public const string SrcType = "SrcType";
            public const string KeyWord = "KeyWord";
            public const string DocID = "DocID";
            public const string Category1 = "Category1";
            public const string Category2 = "Category2";
            public const string Category3 = "Category3";
            public const string Leader = "Leader";
            public const string Incident = "Incident";
            public const string Sign = "Sign";
        }
        #endregion

        #region constructors
        public DataModelEntity()
        {
            sqlHelper = new SqlHelper(DBName);
        }

        public DataModelEntity(long id, string sitename, string url, string title, DateTime bizdate, string content, int hitcount, int relaycount, string srctype, string keyword, int docid, string category1, string category2, string category3, int leader, string incident, int sign)
        {
            this.ID = id;

            this.SiteName = sitename;

            this.URL = url;

            this.Title = title;

            this.BizDate = bizdate;

            this.Content = content;

            this.HitCount = hitcount;

            this.RelayCount = relaycount;

            this.SrcType = srctype;

            this.KeyWord = keyword;

            this.DocID = docid;

            this.Category1 = category1;

            this.Category2 = category2;

            this.Category3 = category3;

            this.Leader = leader;

            this.Incident = incident;

            this.Sign = sign;

        }
        #endregion

        #region Properties
        /// <summary>
        /// 主键ID
        /// </summary>
        public long? ID
        {
            get;
            set;
        }

        /// <summary>
        /// 来源站点
        /// </summary>
        public string SiteName
        {
            get;
            set;
        }

        /// <summary>
        /// 信息链接
        /// </summary>
        public string URL
        {
            get;
            set;
        }

        /// <summary>
        /// 信息标题
        /// </summary>
        public string Title
        {
            get;
            set;
        }

        /// <summary>
        /// 信息发布时间
        /// </summary>
        public DateTime? BizDate
        {
            get;
            set;
        }

        /// <summary>
        /// 正文内容
        /// </summary>
        public string Content
        {
            get;
            set;
        }

        /// <summary>
        /// HitCount
        /// </summary>
        public int? HitCount
        {
            get;
            set;
        }

        /// <summary>
        /// RelayCount
        /// </summary>
        public int? RelayCount
        {
            get;
            set;
        }

        /// <summary>
        /// 信息源分类
        /// </summary>
        public string SrcType
        {
            get;
            set;
        }

        /// <summary>
        /// 关键字（以,隔开）
        /// </summary>
        public string KeyWord
        {
            get;
            set;
        }

        /// <summary>
        /// DocID
        /// </summary>
        public int? DocID
        {
            get;
            set;
        }

        /// <summary>
        /// Category1
        /// </summary>
        public string Category1
        {
            get;
            set;
        }

        /// <summary>
        /// Category2
        /// </summary>
        public string Category2
        {
            get;
            set;
        }

        /// <summary>
        /// Category3
        /// </summary>
        public string Category3
        {
            get;
            set;
        }

        /// <summary>
        /// 领导人物ID
        /// </summary>
        public int? Leader
        {
            get;
            set;
        }

        /// <summary>
        /// 事件
        /// </summary>
        public string Incident
        {
            get;
            set;
        }

        /// <summary>
        /// 正负面（0为负面，1为正面）
        /// </summary>
        public int? Sign
        {
            get;
            set;
        }

        #endregion

        public class DataModelDAO : SqlDAO<DataModelEntity>
        {
            private SqlHelper sqlHelper;
            public const string DBName = "SentimentConnStr";

            public DataModelDAO()
            {
                sqlHelper = new SqlHelper(DBName);
            }

            public override void Add(DataModelEntity entity)
            {

                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into DataModel(");
                strSql.Append("SiteName,URL,Title,BizDate,Content,HitCount,RelayCount,SrcType,KeyWord,DocID,Category1,Category2,Category3,Leader,Incident,Sign)");
                strSql.Append(" values (");
                strSql.Append("@SiteName,@URL,@Title,@BizDate,@Content,@HitCount,@RelayCount,@SrcType,@KeyWord,@DocID,@Category1,@Category2,@Category3,@Leader,@Incident,@Sign)");
                SqlParameter[] parameters = {
					new SqlParameter("@SiteName",SqlDbType.VarChar),
					new SqlParameter("@URL",SqlDbType.VarChar),
					new SqlParameter("@Title",SqlDbType.VarChar),
					new SqlParameter("@BizDate",SqlDbType.DateTime),
					new SqlParameter("@Content",SqlDbType.VarChar),
					new SqlParameter("@HitCount",SqlDbType.Int),
					new SqlParameter("@RelayCount",SqlDbType.Int),
					new SqlParameter("@SrcType",SqlDbType.VarChar),
					new SqlParameter("@KeyWord",SqlDbType.VarChar),
					new SqlParameter("@DocID",SqlDbType.Int),
					new SqlParameter("@Category1",SqlDbType.VarChar),
					new SqlParameter("@Category2",SqlDbType.VarChar),
					new SqlParameter("@Category3",SqlDbType.VarChar),
					new SqlParameter("@Leader",SqlDbType.Int),
					new SqlParameter("@Incident",SqlDbType.VarChar),
					new SqlParameter("@Sign",SqlDbType.Int)
					};
                parameters[0].Value = entity.SiteName;
                parameters[1].Value = entity.URL;
                parameters[2].Value = entity.Title;
                parameters[3].Value = entity.BizDate;
                parameters[4].Value = entity.Content;
                parameters[5].Value = entity.HitCount;
                parameters[6].Value = entity.RelayCount;
                parameters[7].Value = entity.SrcType;
                parameters[8].Value = entity.KeyWord;
                parameters[9].Value = entity.DocID;
                parameters[10].Value = entity.Category1;
                parameters[11].Value = entity.Category2;
                parameters[12].Value = entity.Category3;
                parameters[13].Value = entity.Leader;
                parameters[14].Value = entity.Incident;
                parameters[15].Value = entity.Sign;

                sqlHelper.ExecuteSql(strSql.ToString(), parameters);
            }

            public override void Update(DataModelEntity entity)
            {

                StringBuilder strSql = new StringBuilder();
                strSql.Append("update DataModel set ");
                strSql.Append("SiteName=@SiteName,");
                strSql.Append("URL=@URL,");
                strSql.Append("Title=@Title,");
                strSql.Append("BizDate=@BizDate,");
                strSql.Append("Content=@Content,");
                strSql.Append("HitCount=@HitCount,");
                strSql.Append("RelayCount=@RelayCount,");
                strSql.Append("SrcType=@SrcType,");
                strSql.Append("KeyWord=@KeyWord,");
                strSql.Append("DocID=@DocID,");
                strSql.Append("Category1=@Category1,");
                strSql.Append("Category2=@Category2,");
                strSql.Append("Category3=@Category3,");
                strSql.Append("Leader=@Leader,");
                strSql.Append("Incident=@Incident,");
                strSql.Append("Sign=@Sign");

                strSql.Append(" where ID=@ID");
                SqlParameter[] parameters = {
					new SqlParameter("@ID",SqlDbType.BigInt),
					new SqlParameter("@SiteName",SqlDbType.VarChar),
					new SqlParameter("@URL",SqlDbType.VarChar),
					new SqlParameter("@Title",SqlDbType.VarChar),
					new SqlParameter("@BizDate",SqlDbType.DateTime),
					new SqlParameter("@Content",SqlDbType.VarChar),
					new SqlParameter("@HitCount",SqlDbType.Int),
					new SqlParameter("@RelayCount",SqlDbType.Int),
					new SqlParameter("@SrcType",SqlDbType.VarChar),
					new SqlParameter("@KeyWord",SqlDbType.VarChar),
					new SqlParameter("@DocID",SqlDbType.Int),
					new SqlParameter("@Category1",SqlDbType.VarChar),
					new SqlParameter("@Category2",SqlDbType.VarChar),
					new SqlParameter("@Category3",SqlDbType.VarChar),
					new SqlParameter("@Leader",SqlDbType.Int),
					new SqlParameter("@Incident",SqlDbType.VarChar),
					new SqlParameter("@Sign",SqlDbType.Int)
					};
                parameters[0].Value = entity.ID;
                parameters[1].Value = entity.SiteName;
                parameters[2].Value = entity.URL;
                parameters[3].Value = entity.Title;
                parameters[4].Value = entity.BizDate;
                parameters[5].Value = entity.Content;
                parameters[6].Value = entity.HitCount;
                parameters[7].Value = entity.RelayCount;
                parameters[8].Value = entity.SrcType;
                parameters[9].Value = entity.KeyWord;
                parameters[10].Value = entity.DocID;
                parameters[11].Value = entity.Category1;
                parameters[12].Value = entity.Category2;
                parameters[13].Value = entity.Category3;
                parameters[14].Value = entity.Leader;
                parameters[15].Value = entity.Incident;
                parameters[16].Value = entity.Sign;

                sqlHelper.ExecuteSql(strSql.ToString(), parameters);
            }

            public bool UpdateSet(int ID, string ColumnName, string Value)
            {
                try
                {
                    StringBuilder StrSql = new StringBuilder();
                    StrSql.Append("update DataModel set ");
                    StrSql.Append(ColumnName + "='" + Value + "'");
                    StrSql.Append(" where ID=" + ID);
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
                string strSql = "delete from DataModel where ID=" + ID;
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

            public override void Delete(DataModelEntity entity)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("delete from DataModel ");
                strSql.Append(" where ID=@primaryKeyId");
                SqlParameter[] parameters = {
						new SqlParameter("@primaryKeyId", SqlDbType.Int)
					};
                parameters[0].Value = entity.ID;
                sqlHelper.ExecuteSql(strSql.ToString(), parameters);
            }

            public override DataModelEntity FindById(long primaryKeyId)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select * from DataModel ");
                strSql.Append(" where ID=@primaryKeyId");
                SqlParameter[] parameters = {
						new SqlParameter("@primaryKeyId", SqlDbType.Int)};
                parameters[0].Value = primaryKeyId;
                DataSet ds = sqlHelper.ExecuteDateSet(strSql.ToString(), parameters);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count == 1)
                {
                    DataRow row = ds.Tables[0].Rows[0];
                    DataModelEntity entity = new DataModelEntity();
                    if (!Convert.IsDBNull(row["ID"]))
                    {
                        entity.ID = (long)row["ID"];
                    }
                    entity.SiteName = row["SiteName"].ToString();
                    entity.URL = row["URL"].ToString();
                    entity.Title = row["Title"].ToString();
                    if (!Convert.IsDBNull(row["BizDate"]))
                    {
                        entity.BizDate = (DateTime)row["BizDate"];
                    }
                    entity.Content = row["Content"].ToString();
                    if (!Convert.IsDBNull(row["HitCount"]))
                    {
                        entity.HitCount = (int)row["HitCount"];
                    }
                    if (!Convert.IsDBNull(row["RelayCount"]))
                    {
                        entity.RelayCount = (int)row["RelayCount"];
                    }
                    entity.SrcType = row["SrcType"].ToString();
                    entity.KeyWord = row["KeyWord"].ToString();
                    if (!Convert.IsDBNull(row["DocID"]))
                    {
                        entity.DocID = (int)row["DocID"];
                    }
                    entity.Category1 = row["Category1"].ToString();
                    entity.Category2 = row["Category2"].ToString();
                    entity.Category3 = row["Category3"].ToString();
                    if (!Convert.IsDBNull(row["Leader"]))
                    {
                        entity.Leader = (int)row["Leader"];
                    }
                    entity.Incident = row["Incident"].ToString();
                    if (!Convert.IsDBNull(row["Sign"]))
                    {
                        entity.Sign = (int)row["Sign"];
                    }
                    return entity;
                }
                else
                {
                    return null;
                }
            }

            public override List<DataModelEntity> Find(string strWhere, SqlParameter[] parameters)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select *");
                strSql.Append(" FROM DataModel(nolock) ");
                if (strWhere.Trim() != "")
                {
                    strSql.Append(" where " + strWhere);
                }

                DataSet ds = sqlHelper.ExecuteDateSet(strSql.ToString(), parameters);
                if (ds != null && ds.Tables.Count > 0)
                {
                    List<DataModelEntity> list = new List<DataModelEntity>();
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        DataModelEntity entity = new DataModelEntity();
                        if (!Convert.IsDBNull(row["ID"]))
                        {
                            entity.ID = (long)row["ID"];
                        }
                        entity.SiteName = row["SiteName"].ToString();
                        entity.URL = row["URL"].ToString();
                        entity.Title = row["Title"].ToString();
                        if (!Convert.IsDBNull(row["BizDate"]))
                        {
                            entity.BizDate = (DateTime)row["BizDate"];
                        }
                        entity.Content = row["Content"].ToString();
                        if (!Convert.IsDBNull(row["HitCount"]))
                        {
                            entity.HitCount = (int)row["HitCount"];
                        }
                        if (!Convert.IsDBNull(row["RelayCount"]))
                        {
                            entity.RelayCount = (int)row["RelayCount"];
                        }
                        entity.SrcType = row["SrcType"].ToString();
                        entity.KeyWord = row["KeyWord"].ToString();
                        if (!Convert.IsDBNull(row["DocID"]))
                        {
                            entity.DocID = (int)row["DocID"];
                        }
                        entity.Category1 = row["Category1"].ToString();
                        entity.Category2 = row["Category2"].ToString();
                        entity.Category3 = row["Category3"].ToString();
                        if (!Convert.IsDBNull(row["Leader"]))
                        {
                            entity.Leader = (int)row["Leader"];
                        }
                        entity.Incident = row["Incident"].ToString();
                        if (!Convert.IsDBNull(row["Sign"]))
                        {
                            entity.Sign = (int)row["Sign"];
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

            public override DataSet GetDataSet(string strWhere, SqlParameter[] param)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select *");
                strSql.Append(" FROM DataModel(nolock)");
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
                string sql = "select count(*) from DataModel ";
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
                    sql += "  ID )";
                }
                else
                {

                    sql += " (ORDER BY ID )";//默认按主键排序

                }

                sql += " AS RowNumber,* FROM DataModel";

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

