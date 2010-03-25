using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using System.Reflection;
using System.Text;

namespace Autonomy.Demo.Dal
{
    [Serializable]
    public partial class Cluster2DMapEntity
    {
        private SqlHelper sqlHelper;

        #region const fields
        public const string DBName = "SentimentConnStr";
        public const string TableName = "Cluster2DMap";
        public const string PrimaryKey = "PK_Cluster2DMap";
        #endregion

        #region columns
        public struct Columns
        {
            public const string MapId = "MapId";
            public const string ClusterTimeId = "ClusterTimeId";
            public const string PreClusterTimeId = "PreClusterTimeId";
        }
        #endregion

        #region constructors
        public Cluster2DMapEntity()
        {
            sqlHelper = new SqlHelper(DBName);
        }

        public Cluster2DMapEntity(long mapid, long clustertimeid, long preclustertimeid)
        {
            this.MapId = mapid;

            this.ClusterTimeId = clustertimeid;

            this.PreClusterTimeId = preclustertimeid;

        }
        #endregion

        #region Properties
        /// <summary>
        /// 主键ID
        /// </summary>
        public long? MapId
        {
            get;
            set;
        }

        /// <summary>
        /// 当前时间ID
        /// </summary>
        public long? ClusterTimeId
        {
            get;
            set;
        }

        /// <summary>
        /// 前一张时间ID
        /// </summary>
        public long? PreClusterTimeId
        {
            get;
            set;
        }

        #endregion

        public class Cluster2DMapDAO : SqlDAO<Cluster2DMapEntity>
        {
            private SqlHelper sqlHelper;
            public const string DBName = "SentimentConnStr";

            public Cluster2DMapDAO()
            {
                sqlHelper = new SqlHelper(DBName);
            }

            public override long Add(Cluster2DMapEntity entity)
            {

                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into Cluster2DMap(");
                strSql.Append("ClusterTimeId,PreClusterTimeId)");
                strSql.Append(" values (");
                strSql.Append("@ClusterTimeId,@PreClusterTimeId)");
                strSql.Append(";select SCOPE_IDENTITY();");
                
                SqlParameter[] parameters = {
					new SqlParameter("@ClusterTimeId",SqlDbType.BigInt),
					new SqlParameter("@PreClusterTimeId",SqlDbType.BigInt),
                    new SqlParameter("@LastestId",SqlDbType.BigInt)
					};

                parameters[0].Value = entity.ClusterTimeId;
                parameters[1].Value = entity.PreClusterTimeId;
                parameters[2].Direction = ParameterDirection.Output;

                Object obj = sqlHelper.GetSingle(strSql.ToString(), parameters);
                return obj == null ? -1 : long.Parse(obj.ToString());
            }

            public override void Update(Cluster2DMapEntity entity)
            {

                StringBuilder strSql = new StringBuilder();
                strSql.Append("update Cluster2DMap set ");
                strSql.Append("ClusterTimeId=@ClusterTimeId,");
                strSql.Append("PreClusterTimeId=@PreClusterTimeId");

                strSql.Append(" where MapId=@MapId");
                SqlParameter[] parameters = {
					new SqlParameter("@MapId",SqlDbType.BigInt),
					new SqlParameter("@ClusterTimeId",SqlDbType.BigInt),
					new SqlParameter("@PreClusterTimeId",SqlDbType.BigInt)
					};
                parameters[0].Value = entity.MapId;
                parameters[1].Value = entity.ClusterTimeId;
                parameters[2].Value = entity.PreClusterTimeId;

                sqlHelper.ExecuteSql(strSql.ToString(), parameters);
            }

            public bool UpdateSet(int ID, string ColumnName, string Value)
            {
                try
                {
                    StringBuilder StrSql = new StringBuilder();
                    StrSql.Append("update Cluster2DMap set ");
                    StrSql.Append(ColumnName + "='" + Value + "'");
                    StrSql.Append(" where MapId=" + ID);
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
                string strSql = "delete from Cluster2DMap where MapId=" + ID;
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

            public override void Delete(Cluster2DMapEntity entity)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("delete from Cluster2DMap ");
                strSql.Append(" where MapId=@primaryKeyId");
                SqlParameter[] parameters = {
						new SqlParameter("@primaryKeyId", SqlDbType.Int)
					};
                parameters[0].Value = entity.MapId;
                sqlHelper.ExecuteSql(strSql.ToString(), parameters);
            }

            public override Cluster2DMapEntity FindById(long primaryKeyId)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select * from Cluster2DMap ");
                strSql.Append(" where MapId=@primaryKeyId");
                SqlParameter[] parameters = {
						new SqlParameter("@primaryKeyId", SqlDbType.Int)};
                parameters[0].Value = primaryKeyId;
                DataSet ds = sqlHelper.ExecuteDateSet(strSql.ToString(), parameters);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count == 1)
                {
                    DataRow row = ds.Tables[0].Rows[0];
                    Cluster2DMapEntity entity = new Cluster2DMapEntity();
                    if (!Convert.IsDBNull(row["MapId"]))
                    {
                        entity.MapId = (long)row["MapId"];
                    }
                    if (!Convert.IsDBNull(row["ClusterTimeId"]))
                    {
                        entity.ClusterTimeId = (long)row["ClusterTimeId"];
                    }
                    if (!Convert.IsDBNull(row["PreClusterTimeId"]))
                    {
                        entity.PreClusterTimeId = (long)row["PreClusterTimeId"];
                    }
                    return entity;
                }
                else
                {
                    return null;
                }
            }

            public override List<Cluster2DMapEntity> Find(string strWhere, SqlParameter[] parameters)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select *");
                strSql.Append(" FROM Cluster2DMap(nolock) ");
                if (strWhere.Trim() != "")
                {
                    strSql.Append(" where " + strWhere);
                }

                DataSet ds = sqlHelper.ExecuteDateSet(strSql.ToString(), parameters);
                if (ds != null && ds.Tables.Count > 0)
                {
                    List<Cluster2DMapEntity> list = new List<Cluster2DMapEntity>();
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        Cluster2DMapEntity entity = new Cluster2DMapEntity();
                        if (!Convert.IsDBNull(row["MapId"]))
                        {
                            entity.MapId = (long)row["MapId"];
                        }
                        if (!Convert.IsDBNull(row["ClusterTimeId"]))
                        {
                            entity.ClusterTimeId = (long)row["ClusterTimeId"];
                        }
                        if (!Convert.IsDBNull(row["PreClusterTimeId"]))
                        {
                            entity.PreClusterTimeId = (long)row["PreClusterTimeId"];
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
                strSql.Append(" FROM Cluster2DMap(nolock)");
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
                string sql = "select count(*) from Cluster2DMap ";
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
                    sql += "  MapId )";
                }
                else
                {

                    sql += " (ORDER BY MapId )";//默认按主键排序

                }

                sql += " AS RowNumber,* FROM Cluster2DMap";

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