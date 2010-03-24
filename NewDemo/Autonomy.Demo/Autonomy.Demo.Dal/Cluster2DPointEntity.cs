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
    public partial class Cluster2DPointEntity
    {
        private SqlHelper sqlHelper;

        #region const fields
        public const string DBName = "SentimentConnStr";
        public const string TableName = "Cluster2DPoint";
        public const string PrimaryKey = "PK_Cluster2DPoint";
        #endregion

        #region columns
        public struct Columns
        {
            public const string PointId = "PointId";
            public const string MapTimeId = "MapTimeId";
            public const string ClusterX = "ClusterX";
            public const string ClusterY = "ClusterY";
            public const string ClusterTitle = "ClusterTitle";
        }
        #endregion

        #region constructors
        public Cluster2DPointEntity()
        {
            sqlHelper = new SqlHelper(DBName);
        }

        public Cluster2DPointEntity(long pointid, long maptimeid, int clusterx, int clustery, string clustertitle)
        {
            this.PointId = pointid;

            this.MapTimeId = maptimeid;

            this.ClusterX = clusterx;

            this.ClusterY = clustery;

            this.ClusterTitle = clustertitle;

        }
        #endregion

        #region Properties
        /// <summary>
        /// 主键ID
        /// </summary>
        public long? PointId
        {
            get;
            set;
        }

        /// <summary>
        /// 2D图时间ID
        /// </summary>
        public long? MapTimeId
        {
            get;
            set;
        }

        /// <summary>
        /// X坐标
        /// </summary>
        public int? ClusterX
        {
            get;
            set;
        }

        /// <summary>
        /// Y坐标
        /// </summary>
        public int? ClusterY
        {
            get;
            set;
        }

        /// <summary>
        /// 标题
        /// </summary>
        public string ClusterTitle
        {
            get;
            set;
        }

        #endregion

        public class Cluster2DPointDAO : SqlDAO<Cluster2DPointEntity>
        {
            private SqlHelper sqlHelper;
            public const string DBName = "SentimentConnStr";

            public Cluster2DPointDAO()
            {
                sqlHelper = new SqlHelper(DBName);
            }

            public override void Add(Cluster2DPointEntity entity)
            {

                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into Cluster2DPoint(");
                strSql.Append("MapTimeId,ClusterX,ClusterY,ClusterTitle)");
                strSql.Append(" values (");
                strSql.Append("@MapTimeId,@ClusterX,@ClusterY,@ClusterTitle)");
                SqlParameter[] parameters = {
					new SqlParameter("@MapTimeId",SqlDbType.BigInt),
					new SqlParameter("@ClusterX",SqlDbType.Int),
					new SqlParameter("@ClusterY",SqlDbType.Int),
					new SqlParameter("@ClusterTitle",SqlDbType.NVarChar)
					};
                parameters[0].Value = entity.MapTimeId;
                parameters[1].Value = entity.ClusterX;
                parameters[2].Value = entity.ClusterY;
                parameters[3].Value = entity.ClusterTitle;

                sqlHelper.ExecuteSql(strSql.ToString(), parameters);
            }

            public override void Update(Cluster2DPointEntity entity)
            {

                StringBuilder strSql = new StringBuilder();
                strSql.Append("update Cluster2DPoint set ");
                strSql.Append("MapTimeId=@MapTimeId,");
                strSql.Append("ClusterX=@ClusterX,");
                strSql.Append("ClusterY=@ClusterY,");
                strSql.Append("ClusterTitle=@ClusterTitle");

                strSql.Append(" where PointId=@PointId");
                SqlParameter[] parameters = {
					new SqlParameter("@PointId",SqlDbType.BigInt),
					new SqlParameter("@MapTimeId",SqlDbType.BigInt),
					new SqlParameter("@ClusterX",SqlDbType.Int),
					new SqlParameter("@ClusterY",SqlDbType.Int),
					new SqlParameter("@ClusterTitle",SqlDbType.NVarChar)
					};
                parameters[0].Value = entity.PointId;
                parameters[1].Value = entity.MapTimeId;
                parameters[2].Value = entity.ClusterX;
                parameters[3].Value = entity.ClusterY;
                parameters[4].Value = entity.ClusterTitle;

                sqlHelper.ExecuteSql(strSql.ToString(), parameters);
            }

            public bool UpdateSet(int ID, string ColumnName, string Value)
            {
                try
                {
                    StringBuilder StrSql = new StringBuilder();
                    StrSql.Append("update Cluster2DPoint set ");
                    StrSql.Append(ColumnName + "='" + Value + "'");
                    StrSql.Append(" where PointId=" + ID);
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
                string strSql = "delete from Cluster2DPoint where PointId=" + ID;
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

            public override void Delete(Cluster2DPointEntity entity)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("delete from Cluster2DPoint ");
                strSql.Append(" where PointId=@primaryKeyId");
                SqlParameter[] parameters = {
						new SqlParameter("@primaryKeyId", SqlDbType.Int)
					};
                parameters[0].Value = entity.PointId;
                sqlHelper.ExecuteSql(strSql.ToString(), parameters);
            }

            public override Cluster2DPointEntity FindById(long primaryKeyId)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select * from Cluster2DPoint ");
                strSql.Append(" where PointId=@primaryKeyId");
                SqlParameter[] parameters = {
						new SqlParameter("@primaryKeyId", SqlDbType.Int)};
                parameters[0].Value = primaryKeyId;
                DataSet ds = sqlHelper.ExecuteDateSet(strSql.ToString(), parameters);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count == 1)
                {
                    DataRow row = ds.Tables[0].Rows[0];
                    Cluster2DPointEntity entity = new Cluster2DPointEntity();
                    if (!Convert.IsDBNull(row["PointId"]))
                    {
                        entity.PointId = (long)row["PointId"];
                    }
                    if (!Convert.IsDBNull(row["MapTimeId"]))
                    {
                        entity.MapTimeId = (long)row["MapTimeId"];
                    }
                    if (!Convert.IsDBNull(row["ClusterX"]))
                    {
                        entity.ClusterX = (int)row["ClusterX"];
                    }
                    if (!Convert.IsDBNull(row["ClusterY"]))
                    {
                        entity.ClusterY = (int)row["ClusterY"];
                    }
                    entity.ClusterTitle = row["ClusterTitle"].ToString();
                    return entity;
                }
                else
                {
                    return null;
                }
            }

            public override List<Cluster2DPointEntity> Find(string strWhere, SqlParameter[] parameters)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select *");
                strSql.Append(" FROM Cluster2DPoint(nolock) ");
                if (strWhere.Trim() != "")
                {
                    strSql.Append(" where " + strWhere);
                }

                DataSet ds = sqlHelper.ExecuteDateSet(strSql.ToString(), parameters);
                if (ds != null && ds.Tables.Count > 0)
                {
                    List<Cluster2DPointEntity> list = new List<Cluster2DPointEntity>();
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        Cluster2DPointEntity entity = new Cluster2DPointEntity();
                        if (!Convert.IsDBNull(row["PointId"]))
                        {
                            entity.PointId = (long)row["PointId"];
                        }
                        if (!Convert.IsDBNull(row["MapTimeId"]))
                        {
                            entity.MapTimeId = (long)row["MapTimeId"];
                        }
                        if (!Convert.IsDBNull(row["ClusterX"]))
                        {
                            entity.ClusterX = (int)row["ClusterX"];
                        }
                        if (!Convert.IsDBNull(row["ClusterY"]))
                        {
                            entity.ClusterY = (int)row["ClusterY"];
                        }
                        entity.ClusterTitle = row["ClusterTitle"].ToString();

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
                strSql.Append(" FROM Cluster2DPoint(nolock)");
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
                string sql = "select count(*) from Cluster2DPoint ";
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
                    sql += "  PointId )";
                }
                else
                {

                    sql += " (ORDER BY PointId )";//默认按主键排序

                }

                sql += " AS RowNumber,* FROM Cluster2DPoint";

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

