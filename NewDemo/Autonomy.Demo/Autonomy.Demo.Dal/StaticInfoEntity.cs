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
    public partial class StaticInfoEntity
    {
        private SqlHelper sqlHelper;

        #region const fields
        public const string DBName = "SentimentConnStr";
        public const string TableName = "StaticInfo";
        public const string PrimaryKey = "PK_STATICINFO";
        #endregion

        #region columns
        public struct Columns
        {
            public const string ID = "ID";
            public const string MainCateID = "MainCateID";
            public const string CateDisplay = "CateDisplay";
            public const string CateType = "CateType";
            public const string TimeID = "TimeID";
            public const string FromTime = "FromTime";
            public const string ToTime = "ToTime";
            public const string TodayHitCount = "TodayHitCount";
            public const string YestodayHitCount = "YestodayHitCount";
            public const string ThisWeekHitCount = "ThisWeekHitCount";
            public const string SevendayHitCount = "SevendayHitCount";
            public const string ThisMontHitCount = "ThisMontHitCount";
            public const string ThirtydayHitCount = "ThirtydayHitCount";
            public const string TotalHitCount = "TotalHitCount";
            public const string GenDate = "GenDate";
        }
        #endregion

        #region constructors
        public StaticInfoEntity()
        {
            sqlHelper = new SqlHelper(DBName);
        }

        public StaticInfoEntity(long id, string maincateid, string catedisplay, int catetype, int timeid, DateTime fromtime, DateTime totime, long todayhitcount, long yestodayhitcount, long thisweekhitcount, long sevendayhitcount, long thismonthitcount, long thirtydayhitcount, long totalhitcount, DateTime gendate)
        {
            this.ID = id;

            this.MainCateID = maincateid;

            this.CateDisplay = catedisplay;

            this.CateType = catetype;

            this.TimeID = timeid;

            this.FromTime = fromtime;

            this.ToTime = totime;

            this.TodayHitCount = todayhitcount;

            this.YestodayHitCount = yestodayhitcount;

            this.ThisWeekHitCount = thisweekhitcount;

            this.SevendayHitCount = sevendayhitcount;

            this.ThisMontHitCount = thismonthitcount;

            this.ThirtydayHitCount = thirtydayhitcount;

            this.TotalHitCount = totalhitcount;

            this.GenDate = gendate;

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
        /// 分类ID
        /// </summary>
        public string MainCateID
        {
            get;
            set;
        }

        /// <summary>
        /// 分类名称
        /// </summary>
        public string CateDisplay
        {
            get;
            set;
        }

        /// <summary>
        /// 分类类型
        /// </summary>
        public int? CateType
        {
            get;
            set;
        }

        /// <summary>
        /// 时间栅ID
        /// </summary>
        public int? TimeID
        {
            get;
            set;
        }

        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime? FromTime
        {
            get;
            set;
        }

        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime? ToTime
        {
            get;
            set;
        }

        /// <summary>
        /// 今天记录
        /// </summary>
        public long? TodayHitCount
        {
            get;
            set;
        }

        /// <summary>
        /// 昨天记录
        /// </summary>
        public long? YestodayHitCount
        {
            get;
            set;
        }

        /// <summary>
        /// 本周记录
        /// </summary>
        public long? ThisWeekHitCount
        {
            get;
            set;
        }

        /// <summary>
        /// 一周记录
        /// </summary>
        public long? SevendayHitCount
        {
            get;
            set;
        }

        /// <summary>
        /// 本月记录
        /// </summary>
        public long? ThisMontHitCount
        {
            get;
            set;
        }

        /// <summary>
        /// 一月记录
        /// </summary>
        public long? ThirtydayHitCount
        {
            get;
            set;
        }

        /// <summary>
        /// 记录总数
        /// </summary>
        public long? TotalHitCount
        {
            get;
            set;
        }

        /// <summary>
        /// 产生记录时间
        /// </summary>
        public DateTime? GenDate
        {
            get;
            set;
        }

        #endregion

        public class StaticInfoDAO : SqlDAO<StaticInfoEntity>
        {
            private SqlHelper sqlHelper;
            public const string DBName = "SentimentConnStr";

            public StaticInfoDAO()
            {
                sqlHelper = new SqlHelper(DBName);
            }

            public override void Add(StaticInfoEntity entity)
            {

                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into StaticInfo(");
                strSql.Append("MainCateID,CateDisplay,CateType,TimeID,FromTime,ToTime,TodayHitCount,YestodayHitCount,ThisWeekHitCount,SevendayHitCount,ThisMontHitCount,ThirtydayHitCount,TotalHitCount,GenDate)");
                strSql.Append(" values (");
                strSql.Append("@MainCateID,@CateDisplay,@CateType,@TimeID,@FromTime,@ToTime,@TodayHitCount,@YestodayHitCount,@ThisWeekHitCount,@SevendayHitCount,@ThisMontHitCount,@ThirtydayHitCount,@TotalHitCount,@GenDate)");
                SqlParameter[] parameters = {
					new SqlParameter("@MainCateID",SqlDbType.VarChar),
					new SqlParameter("@CateDisplay",SqlDbType.VarChar),
					new SqlParameter("@CateType",SqlDbType.Int),
					new SqlParameter("@TimeID",SqlDbType.Int),
					new SqlParameter("@FromTime",SqlDbType.DateTime),
					new SqlParameter("@ToTime",SqlDbType.DateTime),
					new SqlParameter("@TodayHitCount",SqlDbType.BigInt),
					new SqlParameter("@YestodayHitCount",SqlDbType.BigInt),
					new SqlParameter("@ThisWeekHitCount",SqlDbType.BigInt),
					new SqlParameter("@SevendayHitCount",SqlDbType.BigInt),
					new SqlParameter("@ThisMontHitCount",SqlDbType.BigInt),
					new SqlParameter("@ThirtydayHitCount",SqlDbType.BigInt),
					new SqlParameter("@TotalHitCount",SqlDbType.BigInt),
					new SqlParameter("@GenDate",SqlDbType.DateTime)
					};
                parameters[0].Value = entity.MainCateID;
                parameters[1].Value = entity.CateDisplay;
                parameters[2].Value = entity.CateType;
                parameters[3].Value = entity.TimeID;
                parameters[4].Value = entity.FromTime;
                parameters[5].Value = entity.ToTime;
                parameters[6].Value = entity.TodayHitCount;
                parameters[7].Value = entity.YestodayHitCount;
                parameters[8].Value = entity.ThisWeekHitCount;
                parameters[9].Value = entity.SevendayHitCount;
                parameters[10].Value = entity.ThisMontHitCount;
                parameters[11].Value = entity.ThirtydayHitCount;
                parameters[12].Value = entity.TotalHitCount;
                parameters[13].Value = entity.GenDate;

                sqlHelper.ExecuteSql(strSql.ToString(), parameters);
            }

            public override void Update(StaticInfoEntity entity)
            {

                StringBuilder strSql = new StringBuilder();
                strSql.Append("update StaticInfo set ");
                strSql.Append("MainCateID=@MainCateID,");
                strSql.Append("CateDisplay=@CateDisplay,");
                strSql.Append("CateType=@CateType,");
                strSql.Append("TimeID=@TimeID,");
                strSql.Append("FromTime=@FromTime,");
                strSql.Append("ToTime=@ToTime,");
                strSql.Append("TodayHitCount=@TodayHitCount,");
                strSql.Append("YestodayHitCount=@YestodayHitCount,");
                strSql.Append("ThisWeekHitCount=@ThisWeekHitCount,");
                strSql.Append("SevendayHitCount=@SevendayHitCount,");
                strSql.Append("ThisMontHitCount=@ThisMontHitCount,");
                strSql.Append("ThirtydayHitCount=@ThirtydayHitCount,");
                strSql.Append("TotalHitCount=@TotalHitCount,");
                strSql.Append("GenDate=@GenDate");

                strSql.Append(" where ID=@ID");
                SqlParameter[] parameters = {
					new SqlParameter("@ID",SqlDbType.BigInt),
					new SqlParameter("@MainCateID",SqlDbType.VarChar),
					new SqlParameter("@CateDisplay",SqlDbType.VarChar),
					new SqlParameter("@CateType",SqlDbType.Int),
					new SqlParameter("@TimeID",SqlDbType.Int),
					new SqlParameter("@FromTime",SqlDbType.DateTime),
					new SqlParameter("@ToTime",SqlDbType.DateTime),
					new SqlParameter("@TodayHitCount",SqlDbType.BigInt),
					new SqlParameter("@YestodayHitCount",SqlDbType.BigInt),
					new SqlParameter("@ThisWeekHitCount",SqlDbType.BigInt),
					new SqlParameter("@SevendayHitCount",SqlDbType.BigInt),
					new SqlParameter("@ThisMontHitCount",SqlDbType.BigInt),
					new SqlParameter("@ThirtydayHitCount",SqlDbType.BigInt),
					new SqlParameter("@TotalHitCount",SqlDbType.BigInt),
					new SqlParameter("@GenDate",SqlDbType.DateTime)
					};
                parameters[0].Value = entity.ID;
                parameters[1].Value = entity.MainCateID;
                parameters[2].Value = entity.CateDisplay;
                parameters[3].Value = entity.CateType;
                parameters[4].Value = entity.TimeID;
                parameters[5].Value = entity.FromTime;
                parameters[6].Value = entity.ToTime;
                parameters[7].Value = entity.TodayHitCount;
                parameters[8].Value = entity.YestodayHitCount;
                parameters[9].Value = entity.ThisWeekHitCount;
                parameters[10].Value = entity.SevendayHitCount;
                parameters[11].Value = entity.ThisMontHitCount;
                parameters[12].Value = entity.ThirtydayHitCount;
                parameters[13].Value = entity.TotalHitCount;
                parameters[14].Value = entity.GenDate;

                sqlHelper.ExecuteSql(strSql.ToString(), parameters);
            }

            public bool UpdateSet(int ID, string ColumnName, string Value)
            {
                try
                {
                    StringBuilder StrSql = new StringBuilder();
                    StrSql.Append("update StaticInfo set ");
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
                string strSql = "delete from StaticInfo where ID=" + ID;
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

            public override void Delete(StaticInfoEntity entity)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("delete from StaticInfo ");
                strSql.Append(" where ID=@primaryKeyId");
                SqlParameter[] parameters = {
						new SqlParameter("@primaryKeyId", SqlDbType.Int)
					};
                parameters[0].Value = entity.ID;
                sqlHelper.ExecuteSql(strSql.ToString(), parameters);
            }

            public override StaticInfoEntity FindById(long primaryKeyId)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select * from StaticInfo ");
                strSql.Append(" where ID=@primaryKeyId");
                SqlParameter[] parameters = {
						new SqlParameter("@primaryKeyId", SqlDbType.Int)};
                parameters[0].Value = primaryKeyId;
                DataSet ds = sqlHelper.ExecuteDateSet(strSql.ToString(), parameters);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count == 1)
                {
                    DataRow row = ds.Tables[0].Rows[0];
                    StaticInfoEntity entity = new StaticInfoEntity();
                    if (!Convert.IsDBNull(row["ID"]))
                    {
                        entity.ID = (long)row["ID"];
                    }
                    entity.MainCateID = row["MainCateID"].ToString();
                    entity.CateDisplay = row["CateDisplay"].ToString();
                    if (!Convert.IsDBNull(row["CateType"]))
                    {
                        entity.CateType = (int)row["CateType"];
                    }
                    if (!Convert.IsDBNull(row["TimeID"]))
                    {
                        entity.TimeID = (int)row["TimeID"];
                    }
                    if (!Convert.IsDBNull(row["FromTime"]))
                    {
                        entity.FromTime = (DateTime)row["FromTime"];
                    }
                    if (!Convert.IsDBNull(row["ToTime"]))
                    {
                        entity.ToTime = (DateTime)row["ToTime"];
                    }
                    if (!Convert.IsDBNull(row["TodayHitCount"]))
                    {
                        entity.TodayHitCount = (long)row["TodayHitCount"];
                    }
                    if (!Convert.IsDBNull(row["YestodayHitCount"]))
                    {
                        entity.YestodayHitCount = (long)row["YestodayHitCount"];
                    }
                    if (!Convert.IsDBNull(row["ThisWeekHitCount"]))
                    {
                        entity.ThisWeekHitCount = (long)row["ThisWeekHitCount"];
                    }
                    if (!Convert.IsDBNull(row["SevendayHitCount"]))
                    {
                        entity.SevendayHitCount = (long)row["SevendayHitCount"];
                    }
                    if (!Convert.IsDBNull(row["ThisMontHitCount"]))
                    {
                        entity.ThisMontHitCount = (long)row["ThisMontHitCount"];
                    }
                    if (!Convert.IsDBNull(row["ThirtydayHitCount"]))
                    {
                        entity.ThirtydayHitCount = (long)row["ThirtydayHitCount"];
                    }
                    if (!Convert.IsDBNull(row["TotalHitCount"]))
                    {
                        entity.TotalHitCount = (long)row["TotalHitCount"];
                    }
                    if (!Convert.IsDBNull(row["GenDate"]))
                    {
                        entity.GenDate = (DateTime)row["GenDate"];
                    }
                    return entity;
                }
                else
                {
                    return null;
                }
            }

            public override List<StaticInfoEntity> Find(string strWhere, SqlParameter[] parameters, int top, string OrderBy)
            {
                StringBuilder strSql = new StringBuilder();
                if (top != 0)
                {
                    strSql.Append("select top(" + top + ") *");
                }
                else
                {
                    strSql.Append("select *");
                }
                strSql.Append(" FROM StaticInfo(nolock) ");
                if (strWhere.Trim() != "")
                {
                    strSql.Append(" where " + strWhere);
                }
                if (OrderBy.Trim() != "")
                {
                    strSql.Append(" order by " + OrderBy);
                }

                DataSet ds = sqlHelper.ExecuteDateSet(strSql.ToString(), parameters);
                if (ds != null && ds.Tables.Count > 0)
                {
                    List<StaticInfoEntity> list = new List<StaticInfoEntity>();
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        StaticInfoEntity entity = new StaticInfoEntity();
                        if (!Convert.IsDBNull(row["ID"]))
                        {
                            entity.ID = (long)row["ID"];
                        }
                        entity.MainCateID = row["MainCateID"].ToString();
                        entity.CateDisplay = row["CateDisplay"].ToString();
                        if (!Convert.IsDBNull(row["CateType"]))
                        {
                            entity.CateType = (int)row["CateType"];
                        }
                        if (!Convert.IsDBNull(row["TimeID"]))
                        {
                            entity.TimeID = (int)row["TimeID"];
                        }
                        if (!Convert.IsDBNull(row["FromTime"]))
                        {
                            entity.FromTime = (DateTime)row["FromTime"];
                        }
                        if (!Convert.IsDBNull(row["ToTime"]))
                        {
                            entity.ToTime = (DateTime)row["ToTime"];
                        }
                        if (!Convert.IsDBNull(row["TodayHitCount"]))
                        {
                            entity.TodayHitCount = (long)row["TodayHitCount"];
                        }
                        if (!Convert.IsDBNull(row["YestodayHitCount"]))
                        {
                            entity.YestodayHitCount = (long)row["YestodayHitCount"];
                        }
                        if (!Convert.IsDBNull(row["ThisWeekHitCount"]))
                        {
                            entity.ThisWeekHitCount = (long)row["ThisWeekHitCount"];
                        }
                        if (!Convert.IsDBNull(row["SevendayHitCount"]))
                        {
                            entity.SevendayHitCount = (long)row["SevendayHitCount"];
                        }
                        if (!Convert.IsDBNull(row["ThisMontHitCount"]))
                        {
                            entity.ThisMontHitCount = (long)row["ThisMontHitCount"];
                        }
                        if (!Convert.IsDBNull(row["ThirtydayHitCount"]))
                        {
                            entity.ThirtydayHitCount = (long)row["ThirtydayHitCount"];
                        }
                        if (!Convert.IsDBNull(row["TotalHitCount"]))
                        {
                            entity.TotalHitCount = (long)row["TotalHitCount"];
                        }
                        if (!Convert.IsDBNull(row["GenDate"]))
                        {
                            entity.GenDate = (DateTime)row["GenDate"];
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
                strSql.Append(" FROM StaticInfo(nolock)");
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
                string sql = "select count(*) from StaticInfo ";
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

                sql += " AS RowNumber,* FROM StaticInfo";

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

