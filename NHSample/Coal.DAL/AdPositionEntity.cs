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
    public partial class AdPositionEntity
    {
        private SqlHelper sqlHelper;

        #region const fields
        public const string DBName = "cheese";
        public const string TableName = "AdPosition";
        public const string PrimaryKey = "PK_ADPOSITION";
        #endregion

        #region columns
        public struct Columns
        {
            public const string PositionId = "PositionId";
            public const string PositionName = "PositionName";
            public const string AdWidth = "AdWidth";
            public const string AdHeight = "AdHeight";
            public const string AdDetails = "AdDetails";
            public const string AdType = "AdType";
        }
        #endregion

        #region constructors
        public AdPositionEntity()
        {
            sqlHelper = new SqlHelper(DBName);
        }

        public AdPositionEntity(int positionid, string positionname, int adwidth, int adheight, string addetails, int adtype)
        {
            this.PositionId = positionid;

            this.PositionName = positionname;

            this.AdWidth = adwidth;

            this.AdHeight = adheight;

            this.AdDetails = addetails;

            this.AdType = adtype;

        }
        #endregion

        #region Properties
        /// <summary>
        /// 广告位置标识
        /// </summary>
        public int? PositionId
        {
            get;
            set;
        }

        /// <summary>
        /// 广告位置名称
        /// </summary>
        public string PositionName
        {
            get;
            set;
        }

        /// <summary>
        /// 广告的宽度
        /// </summary>
        public int? AdWidth
        {
            get;
            set;
        }

        /// <summary>
        /// 广告的高度
        /// </summary>
        public int? AdHeight
        {
            get;
            set;
        }

        /// <summary>
        /// 广告位置描述
        /// </summary>
        public string AdDetails
        {
            get;
            set;
        }

        /// <summary>
        /// 广告类型
        /// </summary>
        public int? AdType
        {
            get;
            set;
        }

        #endregion

        public class AdPositionDAO : SqlDAO<AdPositionEntity>
        {
            private SqlHelper sqlHelper;
            public const string DBName = "cheese";

            public AdPositionDAO()
            {
                sqlHelper = new SqlHelper(DBName);
            }

            public override void Add(AdPositionEntity entity)
            {

                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into AdPosition(");
                strSql.Append("PositionName,AdWidth,AdHeight,AdDetails,AdType)");
                strSql.Append(" values (");
                strSql.Append("@PositionName,@AdWidth,@AdHeight,@AdDetails,@AdType)");
                SqlParameter[] parameters = {
					new SqlParameter("@PositionName",SqlDbType.VarChar),
					new SqlParameter("@AdWidth",SqlDbType.Int),
					new SqlParameter("@AdHeight",SqlDbType.Int),
					new SqlParameter("@AdDetails",SqlDbType.VarChar),
					new SqlParameter("@AdType",SqlDbType.Int)
					};
                parameters[0].Value = entity.PositionName;
                parameters[1].Value = entity.AdWidth;
                parameters[2].Value = entity.AdHeight;
                parameters[3].Value = entity.AdDetails;
                parameters[4].Value = entity.AdType;

                sqlHelper.ExecuteSql(strSql.ToString(), parameters);
            }

            public override void Update(AdPositionEntity entity)
            {

                StringBuilder strSql = new StringBuilder();
                strSql.Append("update AdPosition set ");
                strSql.Append("PositionName=@PositionName,");
                strSql.Append("AdWidth=@AdWidth,");
                strSql.Append("AdHeight=@AdHeight,");
                strSql.Append("AdDetails=@AdDetails,");
                strSql.Append("AdType=@AdType");

                strSql.Append(" where PositionId=@PositionId");
                SqlParameter[] parameters = {
					new SqlParameter("@PositionId",SqlDbType.Int),
					new SqlParameter("@PositionName",SqlDbType.VarChar),
					new SqlParameter("@AdWidth",SqlDbType.Int),
					new SqlParameter("@AdHeight",SqlDbType.Int),
					new SqlParameter("@AdDetails",SqlDbType.VarChar),
					new SqlParameter("@AdType",SqlDbType.Int)
					};
                parameters[0].Value = entity.PositionId;
                parameters[1].Value = entity.PositionName;
                parameters[2].Value = entity.AdWidth;
                parameters[3].Value = entity.AdHeight;
                parameters[4].Value = entity.AdDetails;
                parameters[5].Value = entity.AdType;

                sqlHelper.ExecuteSql(strSql.ToString(), parameters);
            }

            public bool UpdateSet(int positionId, string ColumnName, string Value)
            {
                try
                {
                    StringBuilder StrSql = new StringBuilder();
                    StrSql.Append("update AdPosition set ");
                    StrSql.Append(ColumnName + "='" + Value+"'");
                    StrSql.Append(" where PositionId=" + positionId);
                    sqlHelper.ExecuteSql(StrSql.ToString(), null);
                    return true;
                }
                catch
                {
                    return false;
                }
            }

            public override void Delete(AdPositionEntity entity)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("delete from AdPosition ");
                strSql.Append(" where PositionId=@primaryKeyId");
                SqlParameter[] parameters = {
						new SqlParameter("@primaryKeyId", SqlDbType.Int)
					};
                parameters[0].Value = entity.PositionId;
                sqlHelper.ExecuteSql(strSql.ToString(), parameters);
            }

            public bool Delete(int PositionId)
            {
                string strSql = "delete from AdPosition where PositionId=" + PositionId;
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
            public override AdPositionEntity FindById(long primaryKeyId)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select * from AdPosition ");
                strSql.Append(" where PositionId=@primaryKeyId");
                SqlParameter[] parameters = {
						new SqlParameter("@primaryKeyId", SqlDbType.Int)};
                parameters[0].Value = primaryKeyId;
                DataSet ds = sqlHelper.ExecuteDateSet(strSql.ToString(), parameters);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count == 1)
                {
                    DataRow row = ds.Tables[0].Rows[0];
                    AdPositionEntity entity = new AdPositionEntity();
                    if (!Convert.IsDBNull(row["PositionId"]))
                    {
                        entity.PositionId = (int)row["PositionId"];
                    }
                    entity.PositionName = row["PositionName"].ToString();
                    if (!Convert.IsDBNull(row["AdWidth"]))
                    {
                        entity.AdWidth = (int)row["AdWidth"];
                    }
                    if (!Convert.IsDBNull(row["AdHeight"]))
                    {
                        entity.AdHeight = (int)row["AdHeight"];
                    }
                    entity.AdDetails = row["AdDetails"].ToString();
                    if (!Convert.IsDBNull(row["AdType"]))
                    {
                        entity.AdType = (int)row["AdType"];
                    }
                    return entity;
                }
                else
                {
                    return null;
                }
            }

            public override List<AdPositionEntity> Find(string strWhere, SqlParameter[] parameters)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select *");
                strSql.Append(" FROM AdPosition(nolock) ");
                if (strWhere.Trim() != "")
                {
                    strSql.Append(" where " + strWhere);
                }

                DataSet ds = sqlHelper.ExecuteDateSet(strSql.ToString(), parameters);
                if (ds != null && ds.Tables.Count > 0)
                {
                    List<AdPositionEntity> list = new List<AdPositionEntity>();
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        AdPositionEntity entity = new AdPositionEntity();
                        if (!Convert.IsDBNull(row["PositionId"]))
                        {
                            entity.PositionId = (int)row["PositionId"];
                        }
                        entity.PositionName = row["PositionName"].ToString();
                        if (!Convert.IsDBNull(row["AdWidth"]))
                        {
                            entity.AdWidth = (int)row["AdWidth"];
                        }
                        if (!Convert.IsDBNull(row["AdHeight"]))
                        {
                            entity.AdHeight = (int)row["AdHeight"];
                        }
                        entity.AdDetails = row["AdDetails"].ToString();
                        if (!Convert.IsDBNull(row["AdType"]))
                        {
                            entity.AdType = (int)row["AdType"];
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
                strSql.Append(" FROM AdPosition(nolock)");
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
                string sql = "select count(*) from AdPosition ";
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

                    sql += " (ORDER BY PositionId " + method + ")";//默认按主键排序

                }

                sql += " AS RowNumber,* FROM AdPosition";

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

