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
    public partial class Cluster2DDocEntity
    {
        private SqlHelper sqlHelper;

        #region const fields
        public const string DBName = "SentimentConnStr";
        public const string TableName = "Cluster2DDoc";
        public const string PrimaryKey = "PK_Cluster2DDoc";
        #endregion

        #region columns
        public struct Columns
        {
            public const string ID = "ID";
            public const string DocRef = "DocRef";
            public const string DocTitle = "DocTitle";
            public const string PointId = "PointId";
        }
        #endregion

        #region constructors
        public Cluster2DDocEntity()
        {
            sqlHelper = new SqlHelper(DBName);
        }

        public Cluster2DDocEntity(long id, string docref, string doctitle, long pointid)
        {
            this.ID = id;

            this.DocRef = docref;

            this.DocTitle = doctitle;

            this.PointId = pointid;

        }
        #endregion

        #region Properties
        /// <summary>
        /// 
        /// </summary>
        public long? ID
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        public string DocRef
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        public string DocTitle
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        public long? PointId
        {
            get;
            set;
        }

        #endregion

        public class Cluster2DDocDAO : SqlDAO<Cluster2DDocEntity>
        {
            private SqlHelper sqlHelper;
            public const string DBName = "SentimentConnStr";

            public Cluster2DDocDAO()
            {
                sqlHelper = new SqlHelper(DBName);
            }

            public override void Add(Cluster2DDocEntity entity)
            {

                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into Cluster2DDoc(");
                strSql.Append("DocRef,DocTitle,PointId)");
                strSql.Append(" values (");
                strSql.Append("@DocRef,@DocTitle,@PointId)");
                strSql.Append(";select SCOPE_IDENTITY();");

                SqlParameter[] parameters = {
					new SqlParameter("@DocRef",SqlDbType.NVarChar),
					new SqlParameter("@DocTitle",SqlDbType.NVarChar),
					new SqlParameter("@PointId",SqlDbType.BigInt),
                    new SqlParameter("@LastestId",SqlDbType.BigInt)
					};

                parameters[0].Value = entity.DocRef;
                parameters[1].Value = entity.DocTitle;
                parameters[2].Value = entity.PointId;
                parameters[3].Direction = ParameterDirection.Output;

                Object obj = sqlHelper.GetSingle(strSql.ToString(), parameters);
                //return obj == null ? -1 : long.Parse(obj.ToString());
            }

            public override void Update(Cluster2DDocEntity entity)
            {

                StringBuilder strSql = new StringBuilder();
                strSql.Append("update Cluster2DDoc set ");
                strSql.Append("DocRef=@DocRef,");
                strSql.Append("DocTitle=@DocTitle,");
                strSql.Append("PointId=@PointId");

                strSql.Append(" where ID=@ID");
                SqlParameter[] parameters = {
					new SqlParameter("@ID",SqlDbType.BigInt),
					new SqlParameter("@DocRef",SqlDbType.NVarChar),
					new SqlParameter("@DocTitle",SqlDbType.NVarChar),
					new SqlParameter("@PointId",SqlDbType.BigInt)
					};
                parameters[0].Value = entity.ID;
                parameters[1].Value = entity.DocRef;
                parameters[2].Value = entity.DocTitle;
                parameters[3].Value = entity.PointId;

                sqlHelper.ExecuteSql(strSql.ToString(), parameters);
            }

            public bool UpdateSet(int ID, string ColumnName, string Value)
            {
                try
                {
                    StringBuilder StrSql = new StringBuilder();
                    StrSql.Append("update Cluster2DDoc set ");
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
                string strSql = "delete from Cluster2DDoc where ID=" + ID;
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

            public override void Delete(Cluster2DDocEntity entity)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("delete from Cluster2DDoc ");
                strSql.Append(" where ID=@primaryKeyId");
                SqlParameter[] parameters = {
						new SqlParameter("@primaryKeyId", SqlDbType.Int)
					};
                parameters[0].Value = entity.ID;
                sqlHelper.ExecuteSql(strSql.ToString(), parameters);
            }

            public override Cluster2DDocEntity FindById(long primaryKeyId)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select * from Cluster2DDoc ");
                strSql.Append(" where ID=@primaryKeyId");
                SqlParameter[] parameters = {
						new SqlParameter("@primaryKeyId", SqlDbType.Int)};
                parameters[0].Value = primaryKeyId;
                DataSet ds = sqlHelper.ExecuteDateSet(strSql.ToString(), parameters);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count == 1)
                {
                    DataRow row = ds.Tables[0].Rows[0];
                    Cluster2DDocEntity entity = new Cluster2DDocEntity();
                    if (!Convert.IsDBNull(row["ID"]))
                    {
                        entity.ID = (long)row["ID"];
                    }
                    entity.DocRef = row["DocRef"].ToString();
                    entity.DocTitle = row["DocTitle"].ToString();
                    if (!Convert.IsDBNull(row["PointId"]))
                    {
                        entity.PointId = (long)row["PointId"];
                    }
                    return entity;
                }
                else
                {
                    return null;
                }
            }

            public override List<Cluster2DDocEntity> Find(string strWhere, SqlParameter[] parameters)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select *");
                strSql.Append(" FROM Cluster2DDoc(nolock) ");
                if (strWhere.Trim() != "")
                {
                    strSql.Append(" where " + strWhere);
                }

                DataSet ds = sqlHelper.ExecuteDateSet(strSql.ToString(), parameters);
                if (ds != null && ds.Tables.Count > 0)
                {
                    List<Cluster2DDocEntity> list = new List<Cluster2DDocEntity>();
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        Cluster2DDocEntity entity = new Cluster2DDocEntity();
                        if (!Convert.IsDBNull(row["ID"]))
                        {
                            entity.ID = (long)row["ID"];
                        }
                        entity.DocRef = row["DocRef"].ToString();
                        entity.DocTitle = row["DocTitle"].ToString();
                        if (!Convert.IsDBNull(row["PointId"]))
                        {
                            entity.PointId = (long)row["PointId"];
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
                strSql.Append(" FROM Cluster2DDoc(nolock)");
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
                string sql = "select count(*) from Cluster2DDoc ";
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

                sql += " AS RowNumber,* FROM Cluster2DDoc";

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