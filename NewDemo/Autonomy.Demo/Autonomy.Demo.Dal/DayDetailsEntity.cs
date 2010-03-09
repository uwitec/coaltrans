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
    public partial class DayDetailsEntity
    {
        private SqlHelper sqlHelper;

        #region const fields
        public const string DBName = "SentimentConnStr";
        public const string TableName = "DayDetails";
        public const string PrimaryKey = "PK_DAYDETAILS";
        #endregion

        #region columns
        public struct Columns
        {
            public const string ID = "ID";
            public const string MainCateID = "MainCateID";
            public const string CateDisplay = "CateDisplay";
            public const string TimeID = "TimeID";
            public const string FromTime = "FromTime";
            public const string ToTime = "ToTime";
            public const string HitCount = "HitCount";
            public const string QueryCondition = "QueryCondition";
            public const string GenDate = "GenDate";
        }
        #endregion

        #region constructors
        public DayDetailsEntity()
        {
            sqlHelper = new SqlHelper(DBName);
        }

        public DayDetailsEntity(long id, int maincateid, string catedisplay, int timeid, DateTime fromtime, DateTime totime, long hitcount, string querycondition, DateTime gendate)
        {
            this.ID = id;

            this.MainCateID = maincateid;

            this.CateDisplay = catedisplay;

            this.TimeID = timeid;

            this.FromTime = fromtime;

            this.ToTime = totime;

            this.HitCount = hitcount;

            this.QueryCondition = querycondition;

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
        public int? MainCateID
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
        /// HitCount
        /// </summary>
        public long? HitCount
        {
            get;
            set;
        }

        /// <summary>
        /// 查询条件
        /// </summary>
        public string QueryCondition
        {
            get;
            set;
        }

        /// <summary>
        /// 产生记录统计时间
        /// </summary>
        public DateTime? GenDate
        {
            get;
            set;
        }

        #endregion

        public class DayDetailsDAO : SqlDAO<DayDetailsEntity>
        {
            private SqlHelper sqlHelper;
            public const string DBName = "SentimentConnStr";

            public DayDetailsDAO()
            {
                sqlHelper = new SqlHelper(DBName);
            }

            public override void Add(DayDetailsEntity entity)
            {

                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into DayDetails(");
                strSql.Append("MainCateID,CateDisplay,TimeID,FromTime,ToTime,HitCount,QueryCondition,GenDate)");
                strSql.Append(" values (");
                strSql.Append("@MainCateID,@CateDisplay,@TimeID,@FromTime,@ToTime,@HitCount,@QueryCondition,@GenDate)");
                SqlParameter[] parameters = {
					new SqlParameter("@MainCateID",SqlDbType.Int),
					new SqlParameter("@CateDisplay",SqlDbType.VarChar),
					new SqlParameter("@TimeID",SqlDbType.Int),
					new SqlParameter("@FromTime",SqlDbType.DateTime),
					new SqlParameter("@ToTime",SqlDbType.DateTime),
					new SqlParameter("@HitCount",SqlDbType.BigInt),
					new SqlParameter("@QueryCondition",SqlDbType.VarChar),
					new SqlParameter("@GenDate",SqlDbType.DateTime)
					};
                parameters[0].Value = entity.MainCateID;
                parameters[1].Value = entity.CateDisplay;
                parameters[2].Value = entity.TimeID;
                parameters[3].Value = entity.FromTime;
                parameters[4].Value = entity.ToTime;
                parameters[5].Value = entity.HitCount;
                parameters[6].Value = entity.QueryCondition;
                parameters[7].Value = entity.GenDate;

                sqlHelper.ExecuteSql(strSql.ToString(), parameters);
            }

            public override void Update(DayDetailsEntity entity)
            {

                StringBuilder strSql = new StringBuilder();
                strSql.Append("update DayDetails set ");
                strSql.Append("MainCateID=@MainCateID,");
                strSql.Append("CateDisplay=@CateDisplay,");
                strSql.Append("TimeID=@TimeID,");
                strSql.Append("FromTime=@FromTime,");
                strSql.Append("ToTime=@ToTime,");
                strSql.Append("HitCount=@HitCount,");
                strSql.Append("QueryCondition=@QueryCondition,");
                strSql.Append("GenDate=@GenDate");

                strSql.Append(" where ID=@ID");
                SqlParameter[] parameters = {
					new SqlParameter("@ID",SqlDbType.BigInt),
					new SqlParameter("@MainCateID",SqlDbType.Int),
					new SqlParameter("@CateDisplay",SqlDbType.VarChar),
					new SqlParameter("@TimeID",SqlDbType.Int),
					new SqlParameter("@FromTime",SqlDbType.DateTime),
					new SqlParameter("@ToTime",SqlDbType.DateTime),
					new SqlParameter("@HitCount",SqlDbType.BigInt),
					new SqlParameter("@QueryCondition",SqlDbType.VarChar),
					new SqlParameter("@GenDate",SqlDbType.DateTime)
					};
                parameters[0].Value = entity.ID;
                parameters[1].Value = entity.MainCateID;
                parameters[2].Value = entity.CateDisplay;
                parameters[3].Value = entity.TimeID;
                parameters[4].Value = entity.FromTime;
                parameters[5].Value = entity.ToTime;
                parameters[6].Value = entity.HitCount;
                parameters[7].Value = entity.QueryCondition;
                parameters[8].Value = entity.GenDate;

                sqlHelper.ExecuteSql(strSql.ToString(), parameters);
            }

            public bool UpdateSet(int ID, string ColumnName, string Value)
            {
                try
                {
                    StringBuilder StrSql = new StringBuilder();
                    StrSql.Append("update DayDetails set ");
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
                string strSql = "delete from DayDetails where ID=" + ID;
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

            public override void Delete(DayDetailsEntity entity)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("delete from DayDetails ");
                strSql.Append(" where ID=@primaryKeyId");
                SqlParameter[] parameters = {
						new SqlParameter("@primaryKeyId", SqlDbType.Int)
					};
                parameters[0].Value = entity.ID;
                sqlHelper.ExecuteSql(strSql.ToString(), parameters);
            }

            public override DayDetailsEntity FindById(long primaryKeyId)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select * from DayDetails ");
                strSql.Append(" where ID=@primaryKeyId");
                SqlParameter[] parameters = {
						new SqlParameter("@primaryKeyId", SqlDbType.Int)};
                parameters[0].Value = primaryKeyId;
                DataSet ds = sqlHelper.ExecuteDateSet(strSql.ToString(), parameters);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count == 1)
                {
                    DataRow row = ds.Tables[0].Rows[0];
                    DayDetailsEntity entity = new DayDetailsEntity();
                    if (!Convert.IsDBNull(row["ID"]))
                    {
                        entity.ID = (long)row["ID"];
                    }
                    if (!Convert.IsDBNull(row["MainCateID"]))
                    {
                        entity.MainCateID = (int)row["MainCateID"];
                    }
                    entity.CateDisplay = row["CateDisplay"].ToString();
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
                    if (!Convert.IsDBNull(row["HitCount"]))
                    {
                        entity.HitCount = (long)row["HitCount"];
                    }
                    entity.QueryCondition = row["QueryCondition"].ToString();
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

            public override List<DayDetailsEntity> Find(string strWhere, SqlParameter[] parameters)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select *");
                strSql.Append(" FROM DayDetails(nolock) ");
                if (strWhere.Trim() != "")
                {
                    strSql.Append(" where " + strWhere);
                }

                DataSet ds = sqlHelper.ExecuteDateSet(strSql.ToString(), parameters);
                if (ds != null && ds.Tables.Count > 0)
                {
                    List<DayDetailsEntity> list = new List<DayDetailsEntity>();
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        DayDetailsEntity entity = new DayDetailsEntity();
                        if (!Convert.IsDBNull(row["ID"]))
                        {
                            entity.ID = (long)row["ID"];
                        }
                        if (!Convert.IsDBNull(row["MainCateID"]))
                        {
                            entity.MainCateID = (int)row["MainCateID"];
                        }
                        entity.CateDisplay = row["CateDisplay"].ToString();
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
                        if (!Convert.IsDBNull(row["HitCount"]))
                        {
                            entity.HitCount = (long)row["HitCount"];
                        }
                        entity.QueryCondition = row["QueryCondition"].ToString();
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
                strSql.Append(" FROM DayDetails(nolock)");
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
                string sql = "select count(*) from DayDetails ";
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

                sql += " AS RowNumber,* FROM DayDetails";

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

                                                                       