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
    public partial class AdListEntity
    {
        private SqlHelper sqlHelper;

        #region const fields
        public const string DBName = "cheese";
        public const string TableName = "AdList";
        public const string PrimaryKey = "PK_ADLIST";
        #endregion

        #region columns
        public struct Columns
        {
            public const string AdId = "AdId";
            public const string PositionId = "PositionId";
            public const string AdName = "AdName";
            public const string AdLink = "AdLink";
            public const string AdDesc = "AdDesc";
            public const string StartTime = "StartTime";
            public const string EndTime = "EndTime";
            public const string ClickNum = "ClickNum";
            public const string LinkMan = "LinkMan";
            public const string LinkPhone = "LinkPhone";
            public const string LinkEmail = "LinkEmail";
            public const string IsOpen = "IsOpen";
            public const string RankNum = "RankNum";
            public const string AdUrl = "AdUrl";
        }
        #endregion

        #region constructors
        public AdListEntity()
        {
            sqlHelper = new SqlHelper(DBName);
        }

        public AdListEntity(int adid, int positionid, string adname, string adlink, string addesc, DateTime starttime, DateTime endtime, int clicknum, string linkman, string linkphone, string linkemail, int isopen, int ranknum, string adurl)
        {
            this.AdId = adid;

            this.PositionId = positionid;

            this.AdName = adname;

            this.AdLink = adlink;

            this.AdDesc = addesc;

            this.StartTime = starttime;

            this.EndTime = endtime;

            this.ClickNum = clicknum;

            this.LinkMan = linkman;

            this.LinkPhone = linkphone;

            this.LinkEmail = linkemail;

            this.IsOpen = isopen;

            this.RankNum = ranknum;

            this.AdUrl = adurl;

        }
        #endregion

        #region Properties
        /// <summary>
        /// 广告标识ID
        /// </summary>
        public int? AdId
        {
            get;
            set;
        }

        /// <summary>
        /// 广告位置ID
        /// </summary>
        public int? PositionId
        {
            get;
            set;
        }

        /// <summary>
        /// 广告名称
        /// </summary>
        public string AdName
        {
            get;
            set;
        }

        /// <summary>
        /// 广告连接
        /// </summary>
        public string AdLink
        {
            get;
            set;
        }

        /// <summary>
        /// 广告简介
        /// </summary>
        public string AdDesc
        {
            get;
            set;
        }

        /// <summary>
        /// 开启时间
        /// </summary>
        public DateTime? StartTime
        {
            get;
            set;
        }

        /// <summary>
        /// 关闭时间
        /// </summary>
        public DateTime? EndTime
        {
            get;
            set;
        }

        /// <summary>
        /// 广告点击次数
        /// </summary>
        public int? ClickNum
        {
            get;
            set;
        }

        /// <summary>
        /// 联系人
        /// </summary>
        public string LinkMan
        {
            get;
            set;
        }

        /// <summary>
        /// 联系电话
        /// </summary>
        public string LinkPhone
        {
            get;
            set;
        }

        /// <summary>
        /// 联系人EMAIL
        /// </summary>
        public string LinkEmail
        {
            get;
            set;
        }

        /// <summary>
        /// 是否开启
        /// </summary>
        public int? IsOpen
        {
            get;
            set;
        }

        /// <summary>
        /// 播放先后顺序
        /// </summary>
        public int? RankNum
        {
            get;
            set;
        }

        /// <summary>
        /// 广告文件地址
        /// </summary>
        public string AdUrl
        {
            get;
            set;
        }

        #endregion

        public class AdListDAO : SqlDAO<AdListEntity>
        {
            private SqlHelper sqlHelper;
            public const string DBName = "cheese";

            public AdListDAO()
            {
                sqlHelper = new SqlHelper(DBName);
            }

            public override void Add(AdListEntity entity)
            {

                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into AdList(");
                strSql.Append("PositionId,AdName,AdLink,AdDesc,StartTime,EndTime,ClickNum,LinkMan,LinkPhone,LinkEmail,IsOpen,RankNum,AdUrl)");
                strSql.Append(" values (");
                strSql.Append("@PositionId,@AdName,@AdLink,@AdDesc,@StartTime,@EndTime,@ClickNum,@LinkMan,@LinkPhone,@LinkEmail,@IsOpen,@RankNum,@AdUrl)");
                SqlParameter[] parameters = {
					new SqlParameter("@PositionId",SqlDbType.Int),
					new SqlParameter("@AdName",SqlDbType.VarChar),
					new SqlParameter("@AdLink",SqlDbType.VarChar),
					new SqlParameter("@AdDesc",SqlDbType.VarChar),
					new SqlParameter("@StartTime",SqlDbType.DateTime),
					new SqlParameter("@EndTime",SqlDbType.DateTime),
					new SqlParameter("@ClickNum",SqlDbType.Int),
					new SqlParameter("@LinkMan",SqlDbType.VarChar),
					new SqlParameter("@LinkPhone",SqlDbType.VarChar),
					new SqlParameter("@LinkEmail",SqlDbType.VarChar),
					new SqlParameter("@IsOpen",SqlDbType.Int),
					new SqlParameter("@RankNum",SqlDbType.Int),
					new SqlParameter("@AdUrl",SqlDbType.NVarChar)
					};
                parameters[0].Value = entity.PositionId;
                parameters[1].Value = entity.AdName;
                parameters[2].Value = entity.AdLink;
                parameters[3].Value = entity.AdDesc;
                parameters[4].Value = entity.StartTime;
                parameters[5].Value = entity.EndTime;
                parameters[6].Value = entity.ClickNum;
                parameters[7].Value = entity.LinkMan;
                parameters[8].Value = entity.LinkPhone;
                parameters[9].Value = entity.LinkEmail;
                parameters[10].Value = entity.IsOpen;
                parameters[11].Value = entity.RankNum;
                parameters[12].Value = entity.AdUrl;

                sqlHelper.ExecuteSql(strSql.ToString(), parameters);
            }

            public override void Update(AdListEntity entity)
            {

                StringBuilder strSql = new StringBuilder();
                strSql.Append("update AdList set ");
                strSql.Append("PositionId=@PositionId,");
                strSql.Append("AdName=@AdName,");
                strSql.Append("AdLink=@AdLink,");
                strSql.Append("AdDesc=@AdDesc,");
                strSql.Append("StartTime=@StartTime,");
                strSql.Append("EndTime=@EndTime,");
                strSql.Append("ClickNum=@ClickNum,");
                strSql.Append("LinkMan=@LinkMan,");
                strSql.Append("LinkPhone=@LinkPhone,");
                strSql.Append("LinkEmail=@LinkEmail,");
                strSql.Append("IsOpen=@IsOpen,");
                strSql.Append("RankNum=@RankNum,");
                strSql.Append("AdUrl=@AdUrl");

                strSql.Append(" where AdId=@AdId");
                SqlParameter[] parameters = {
					new SqlParameter("@AdId",SqlDbType.Int),
					new SqlParameter("@PositionId",SqlDbType.Int),
					new SqlParameter("@AdName",SqlDbType.VarChar),
					new SqlParameter("@AdLink",SqlDbType.VarChar),
					new SqlParameter("@AdDesc",SqlDbType.VarChar),
					new SqlParameter("@StartTime",SqlDbType.DateTime),
					new SqlParameter("@EndTime",SqlDbType.DateTime),
					new SqlParameter("@ClickNum",SqlDbType.Int),
					new SqlParameter("@LinkMan",SqlDbType.VarChar),
					new SqlParameter("@LinkPhone",SqlDbType.VarChar),
					new SqlParameter("@LinkEmail",SqlDbType.VarChar),
					new SqlParameter("@IsOpen",SqlDbType.Int),
					new SqlParameter("@RankNum",SqlDbType.Int),
					new SqlParameter("@AdUrl",SqlDbType.NVarChar)
					};
                parameters[0].Value = entity.AdId;
                parameters[1].Value = entity.PositionId;
                parameters[2].Value = entity.AdName;
                parameters[3].Value = entity.AdLink;
                parameters[4].Value = entity.AdDesc;
                parameters[5].Value = entity.StartTime;
                parameters[6].Value = entity.EndTime;
                parameters[7].Value = entity.ClickNum;
                parameters[8].Value = entity.LinkMan;
                parameters[9].Value = entity.LinkPhone;
                parameters[10].Value = entity.LinkEmail;
                parameters[11].Value = entity.IsOpen;
                parameters[12].Value = entity.RankNum;
                parameters[13].Value = entity.AdUrl;

                sqlHelper.ExecuteSql(strSql.ToString(), parameters);
            }

            public bool UpdateSet(int ID, string ColumnName, string Value)
            {
                try
                {
                    StringBuilder StrSql = new StringBuilder();
                    StrSql.Append("update AdList set ");
                    StrSql.Append(ColumnName + "='" + Value + "'");
                    StrSql.Append(" where AdId=" + ID);
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
                string strSql = "delete from AdList where AdId=" + ID;
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

            public override void Delete(AdListEntity entity)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("delete from AdList ");
                strSql.Append(" where AdId=@primaryKeyId");
                SqlParameter[] parameters = {
						new SqlParameter("@primaryKeyId", SqlDbType.Int)
					};
                parameters[0].Value = entity.AdId;
                sqlHelper.ExecuteSql(strSql.ToString(), parameters);
            }

            public override AdListEntity FindById(long primaryKeyId)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select * from AdList ");
                strSql.Append(" where AdId=@primaryKeyId");
                SqlParameter[] parameters = {
						new SqlParameter("@primaryKeyId", SqlDbType.Int)};
                parameters[0].Value = primaryKeyId;
                DataSet ds = sqlHelper.ExecuteDateSet(strSql.ToString(), parameters);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count == 1)
                {
                    DataRow row = ds.Tables[0].Rows[0];
                    AdListEntity entity = new AdListEntity();
                    if (!Convert.IsDBNull(row["AdId"]))
                    {
                        entity.AdId = (int)row["AdId"];
                    }
                    if (!Convert.IsDBNull(row["PositionId"]))
                    {
                        entity.PositionId = (int)row["PositionId"];
                    }
                    entity.AdName = row["AdName"].ToString();
                    entity.AdLink = row["AdLink"].ToString();
                    entity.AdDesc = row["AdDesc"].ToString();
                    if (!Convert.IsDBNull(row["StartTime"]))
                    {
                        entity.StartTime = (DateTime)row["StartTime"];
                    }
                    if (!Convert.IsDBNull(row["EndTime"]))
                    {
                        entity.EndTime = (DateTime)row["EndTime"];
                    }
                    if (!Convert.IsDBNull(row["ClickNum"]))
                    {
                        entity.ClickNum = (int)row["ClickNum"];
                    }
                    entity.LinkMan = row["LinkMan"].ToString();
                    entity.LinkPhone = row["LinkPhone"].ToString();
                    entity.LinkEmail = row["LinkEmail"].ToString();
                    if (!Convert.IsDBNull(row["IsOpen"]))
                    {
                        entity.IsOpen = (int)row["IsOpen"];
                    }
                    if (!Convert.IsDBNull(row["RankNum"]))
                    {
                        entity.RankNum = (int)row["RankNum"];
                    }
                    entity.AdUrl = row["AdUrl"].ToString();
                    return entity;
                }
                else
                {
                    return null;
                }
            }

            public override List<AdListEntity> Find(string strWhere, SqlParameter[] parameters)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select *");
                strSql.Append(" FROM AdList(nolock) ");
                if (strWhere.Trim() != "")
                {
                    strSql.Append(" where " + strWhere);
                }

                DataSet ds = sqlHelper.ExecuteDateSet(strSql.ToString(), parameters);
                if (ds != null && ds.Tables.Count > 0)
                {
                    List<AdListEntity> list = new List<AdListEntity>();
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        AdListEntity entity = new AdListEntity();
                        if (!Convert.IsDBNull(row["AdId"]))
                        {
                            entity.AdId = (int)row["AdId"];
                        }
                        if (!Convert.IsDBNull(row["PositionId"]))
                        {
                            entity.PositionId = (int)row["PositionId"];
                        }
                        entity.AdName = row["AdName"].ToString();
                        entity.AdLink = row["AdLink"].ToString();
                        entity.AdDesc = row["AdDesc"].ToString();
                        if (!Convert.IsDBNull(row["StartTime"]))
                        {
                            entity.StartTime = (DateTime)row["StartTime"];
                        }
                        if (!Convert.IsDBNull(row["EndTime"]))
                        {
                            entity.EndTime = (DateTime)row["EndTime"];
                        }
                        if (!Convert.IsDBNull(row["ClickNum"]))
                        {
                            entity.ClickNum = (int)row["ClickNum"];
                        }
                        entity.LinkMan = row["LinkMan"].ToString();
                        entity.LinkPhone = row["LinkPhone"].ToString();
                        entity.LinkEmail = row["LinkEmail"].ToString();
                        if (!Convert.IsDBNull(row["IsOpen"]))
                        {
                            entity.IsOpen = (int)row["IsOpen"];
                        }
                        if (!Convert.IsDBNull(row["RankNum"]))
                        {
                            entity.RankNum = (int)row["RankNum"];
                        }
                        entity.AdUrl = row["AdUrl"].ToString();

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
                strSql.Append(" FROM AdList(nolock)");
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
                string sql = "select count(*) from AdList ";
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
                    sql += "  AdId )";
                }
                else
                {

                    sql += " (ORDER BY AdId )";//默认按主键排序

                }

                sql += " AS RowNumber,* FROM AdList";

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

