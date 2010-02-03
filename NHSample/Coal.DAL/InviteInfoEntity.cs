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
    public partial class InviteInfoEntity
    {
        private SqlHelper sqlHelper;

        #region const fields
        public const string DBName = "cheese";
        public const string TableName = "InviteInfo";
        public const string PrimaryKey = "PK_InviteInfo";
        #endregion

        #region columns
        public struct Columns
        {
            public const string ID = "ID";
            public const string UserId = "UserId";
            public const string InviteTitle = "InviteTitle";
            public const string Region = "Region";
            public const string CreateTime = "CreateTime";
            public const string StartTime = "StartTime";
            public const string EndTime = "EndTime";
            public const string Details = "Details";
            public const string AdjunctUrl = "AdjunctUrl";
            public const string ViewCount = "ViewCount";
            public const string IsAudit = "IsAudit";
            public const string RankNum = "RankNum";
        }
        #endregion

        #region constructors
        public InviteInfoEntity()
        {
            sqlHelper = new SqlHelper(DBName);
        }

        public InviteInfoEntity(int id, int userid, string invitetitle, int region, DateTime createtime, DateTime starttime, DateTime endtime, string details, string adjuncturl, int viewcount, int isaudit, int ranknum)
        {
            this.ID = id;

            this.UserId = userid;

            this.InviteTitle = invitetitle;

            this.Region = region;

            this.CreateTime = createtime;

            this.StartTime = starttime;

            this.EndTime = endtime;

            this.Details = details;

            this.AdjunctUrl = adjuncturl;

            this.ViewCount = viewcount;

            this.IsAudit = isaudit;

            this.RankNum = ranknum;

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
        /// 发布者的userId
        /// </summary>
        public int? UserId
        {
            get;
            set;
        }

        /// <summary>
        /// 招标主题
        /// </summary>
        public string InviteTitle
        {
            get;
            set;
        }

        /// <summary>
        /// 招标地区
        /// </summary>
        public int? Region
        {
            get;
            set;
        }

        /// <summary>
        /// 发布时间
        /// </summary>
        public DateTime? CreateTime
        {
            get;
            set;
        }

        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime? StartTime
        {
            get;
            set;
        }

        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime? EndTime
        {
            get;
            set;
        }

        /// <summary>
        /// 招标细节
        /// </summary>
        public string Details
        {
            get;
            set;
        }

        /// <summary>
        /// 附件地址
        /// </summary>
        public string AdjunctUrl
        {
            get;
            set;
        }

        /// <summary>
        /// 记录公司的浏览数
        /// </summary>
        public int? ViewCount
        {
            get;
            set;
        }

        /// <summary>
        /// 是否通过审核
        /// </summary>
        public int? IsAudit
        {
            get;
            set;
        }

        /// <summary>
        /// 信息排名
        /// </summary>
        public int? RankNum
        {
            get;
            set;
        }

        #endregion

        public class InviteInfoDAO : SqlDAO<InviteInfoEntity>
        {
            private SqlHelper sqlHelper;
            public const string DBName = "cheese";

            public InviteInfoDAO()
            {
                sqlHelper = new SqlHelper(DBName);
            }

            public override void Add(InviteInfoEntity entity)
            {

                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into InviteInfo(");
                strSql.Append("UserId,InviteTitle,Region,CreateTime,StartTime,EndTime,Details,AdjunctUrl,ViewCount,IsAudit,RankNum)");
                strSql.Append(" values (");
                strSql.Append("@UserId,@InviteTitle,@Region,@CreateTime,@StartTime,@EndTime,@Details,@AdjunctUrl,@ViewCount,@IsAudit,@RankNum)");
                SqlParameter[] parameters = {
					new SqlParameter("@UserId",SqlDbType.Int),
					new SqlParameter("@InviteTitle",SqlDbType.NVarChar),
					new SqlParameter("@Region",SqlDbType.Int),
					new SqlParameter("@CreateTime",SqlDbType.DateTime),
					new SqlParameter("@StartTime",SqlDbType.DateTime),
					new SqlParameter("@EndTime",SqlDbType.DateTime),
					new SqlParameter("@Details",SqlDbType.VarChar),
					new SqlParameter("@AdjunctUrl",SqlDbType.VarChar),
					new SqlParameter("@ViewCount",SqlDbType.Int),
					new SqlParameter("@IsAudit",SqlDbType.Int),
					new SqlParameter("@RankNum",SqlDbType.Int)
					};
                parameters[0].Value = entity.UserId;
                parameters[1].Value = entity.InviteTitle;
                parameters[2].Value = entity.Region;
                parameters[3].Value = entity.CreateTime;
                parameters[4].Value = entity.StartTime;
                parameters[5].Value = entity.EndTime;
                parameters[6].Value = entity.Details;
                parameters[7].Value = entity.AdjunctUrl;
                parameters[8].Value = entity.ViewCount;
                parameters[9].Value = entity.IsAudit;
                parameters[10].Value = entity.RankNum;

                sqlHelper.ExecuteSql(strSql.ToString(), parameters);
            }

            public override void Update(InviteInfoEntity entity)
            {

                StringBuilder strSql = new StringBuilder();
                strSql.Append("update InviteInfo set ");
                strSql.Append("UserId=@UserId,");
                strSql.Append("InviteTitle=@InviteTitle,");
                strSql.Append("Region=@Region,");
                strSql.Append("CreateTime=@CreateTime,");
                strSql.Append("StartTime=@StartTime,");
                strSql.Append("EndTime=@EndTime,");
                strSql.Append("Details=@Details,");
                strSql.Append("AdjunctUrl=@AdjunctUrl,");
                strSql.Append("ViewCount=@ViewCount,");
                strSql.Append("IsAudit=@IsAudit,");
                strSql.Append("RankNum=@RankNum");

                strSql.Append(" where ID=@ID");
                SqlParameter[] parameters = {
					new SqlParameter("@ID",SqlDbType.Int),
					new SqlParameter("@UserId",SqlDbType.Int),
					new SqlParameter("@InviteTitle",SqlDbType.NVarChar),
					new SqlParameter("@Region",SqlDbType.Int),
					new SqlParameter("@CreateTime",SqlDbType.DateTime),
					new SqlParameter("@StartTime",SqlDbType.DateTime),
					new SqlParameter("@EndTime",SqlDbType.DateTime),
					new SqlParameter("@Details",SqlDbType.VarChar),
					new SqlParameter("@AdjunctUrl",SqlDbType.VarChar),
					new SqlParameter("@ViewCount",SqlDbType.Int),
					new SqlParameter("@IsAudit",SqlDbType.Int),
					new SqlParameter("@RankNum",SqlDbType.Int)
					};
                parameters[0].Value = entity.ID;
                parameters[1].Value = entity.UserId;
                parameters[2].Value = entity.InviteTitle;
                parameters[3].Value = entity.Region;
                parameters[4].Value = entity.CreateTime;
                parameters[5].Value = entity.StartTime;
                parameters[6].Value = entity.EndTime;
                parameters[7].Value = entity.Details;
                parameters[8].Value = entity.AdjunctUrl;
                parameters[9].Value = entity.ViewCount;
                parameters[10].Value = entity.IsAudit;
                parameters[11].Value = entity.RankNum;

                sqlHelper.ExecuteSql(strSql.ToString(), parameters);
            }

            public bool UpdateSet(int ID, string ColumnName, string Value)
            {
                try
                {
                    StringBuilder StrSql = new StringBuilder();
                    StrSql.Append("update InviteInfo set ");
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
                string strSql = "delete from InviteInfo where ID=" + ID;
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

            public override void Delete(InviteInfoEntity entity)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("delete from InviteInfo ");
                strSql.Append(" where ID=@primaryKeyId");
                SqlParameter[] parameters = {
						new SqlParameter("@primaryKeyId", SqlDbType.Int)
					};
                parameters[0].Value = entity.ID;
                sqlHelper.ExecuteSql(strSql.ToString(), parameters);
            }

            public override InviteInfoEntity FindById(long primaryKeyId)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select * from InviteInfo ");
                strSql.Append(" where ID=@primaryKeyId");
                SqlParameter[] parameters = {
						new SqlParameter("@primaryKeyId", SqlDbType.Int)};
                parameters[0].Value = primaryKeyId;
                DataSet ds = sqlHelper.ExecuteDateSet(strSql.ToString(), parameters);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count == 1)
                {
                    DataRow row = ds.Tables[0].Rows[0];
                    InviteInfoEntity entity = new InviteInfoEntity();
                    if (!Convert.IsDBNull(row["ID"]))
                    {
                        entity.ID = (int)row["ID"];
                    }
                    if (!Convert.IsDBNull(row["UserId"]))
                    {
                        entity.UserId = (int)row["UserId"];
                    }
                    entity.InviteTitle = row["InviteTitle"].ToString();
                    if (!Convert.IsDBNull(row["Region"]))
                    {
                        entity.Region = (int)row["Region"];
                    }
                    if (!Convert.IsDBNull(row["CreateTime"]))
                    {
                        entity.CreateTime = (DateTime)row["CreateTime"];
                    }
                    if (!Convert.IsDBNull(row["StartTime"]))
                    {
                        entity.StartTime = (DateTime)row["StartTime"];
                    }
                    if (!Convert.IsDBNull(row["EndTime"]))
                    {
                        entity.EndTime = (DateTime)row["EndTime"];
                    }
                    entity.Details = row["Details"].ToString();
                    entity.AdjunctUrl = row["AdjunctUrl"].ToString();
                    if (!Convert.IsDBNull(row["ViewCount"]))
                    {
                        entity.ViewCount = (int)row["ViewCount"];
                    }
                    if (!Convert.IsDBNull(row["IsAudit"]))
                    {
                        entity.IsAudit = (int)row["IsAudit"];
                    }
                    if (!Convert.IsDBNull(row["RankNum"]))
                    {
                        entity.RankNum = (int)row["RankNum"];
                    }
                    return entity;
                }
                else
                {
                    return null;
                }
            }

            public override List<InviteInfoEntity> Find(string strWhere, SqlParameter[] parameters)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select *");
                strSql.Append(" FROM InviteInfo(nolock) ");
                if (strWhere.Trim() != "")
                {
                    strSql.Append(" where " + strWhere);
                }

                DataSet ds = sqlHelper.ExecuteDateSet(strSql.ToString(), parameters);
                if (ds != null && ds.Tables.Count > 0)
                {
                    List<InviteInfoEntity> list = new List<InviteInfoEntity>();
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        InviteInfoEntity entity = new InviteInfoEntity();
                        if (!Convert.IsDBNull(row["ID"]))
                        {
                            entity.ID = (int)row["ID"];
                        }
                        if (!Convert.IsDBNull(row["UserId"]))
                        {
                            entity.UserId = (int)row["UserId"];
                        }
                        entity.InviteTitle = row["InviteTitle"].ToString();
                        if (!Convert.IsDBNull(row["Region"]))
                        {
                            entity.Region = (int)row["Region"];
                        }
                        if (!Convert.IsDBNull(row["CreateTime"]))
                        {
                            entity.CreateTime = (DateTime)row["CreateTime"];
                        }
                        if (!Convert.IsDBNull(row["StartTime"]))
                        {
                            entity.StartTime = (DateTime)row["StartTime"];
                        }
                        if (!Convert.IsDBNull(row["EndTime"]))
                        {
                            entity.EndTime = (DateTime)row["EndTime"];
                        }
                        entity.Details = row["Details"].ToString();
                        entity.AdjunctUrl = row["AdjunctUrl"].ToString();
                        if (!Convert.IsDBNull(row["ViewCount"]))
                        {
                            entity.ViewCount = (int)row["ViewCount"];
                        }
                        if (!Convert.IsDBNull(row["IsAudit"]))
                        {
                            entity.IsAudit = (int)row["IsAudit"];
                        }
                        if (!Convert.IsDBNull(row["RankNum"]))
                        {
                            entity.RankNum = (int)row["RankNum"];
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
                strSql.Append(" FROM InviteInfo(nolock)");
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
                string sql = "select count(*) from InviteInfo ";
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
            public DataTable GetPager(string where, SqlParameter[] param, Hashtable ht , int pageSize, int pageNumber)
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

                sql += " AS RowNumber,* FROM InviteInfo";

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

