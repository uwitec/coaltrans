using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using System.Reflection;
using System.Text;
using Coal.DAL;

namespace Coal.Entity
{
    [Serializable]
    public partial class RegionEntity
    {
        private SqlHelper sqlHelper;

        #region const fields
        public const string DBName = "Coal";
        public const string TableName = "Region";
        public const string PrimaryKey = "PK_Region";
        #endregion

        #region columns
        public struct Columns
        {
            public const string Id = "Id";
            public const string Name = "Name";
            public const string Parent = "Parent";
        }
        #endregion

        #region constructors
        public RegionEntity()
        {
            sqlHelper = new SqlHelper(DBName);
        }

        public RegionEntity(int id, string name, int parent)
        {
            this.Id = id;

            this.Name = name;

            this.Parent = parent;

        }
        #endregion

        #region Properties

        public int? Id
        {
            get;
            set;
        }


        public string Name
        {
            get;
            set;
        }


        public int? Parent
        {
            get;
            set;
        }

        #endregion

        public class RegionDAO : SqlDAO<RegionEntity>
        {
            private SqlHelper sqlHelper;
            public const string DBName = "cheese";

            public RegionDAO()
            {
                sqlHelper = new SqlHelper(DBName);
            }

            public override void Add(RegionEntity entity)
            {

                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into Region(");
                strSql.Append("Id,Name,Parent)");
                strSql.Append(" values (");
                strSql.Append("@Id,@Name,@Parent)");
                SqlParameter[] parameters = {
					new SqlParameter("@Id",SqlDbType.Int),
					new SqlParameter("@Name",SqlDbType.NVarChar),
					new SqlParameter("@Parent",SqlDbType.Int)
					};
                parameters[0].Value = entity.Id;
                parameters[1].Value = entity.Name;
                parameters[2].Value = entity.Parent;

                sqlHelper.ExecuteSql(strSql.ToString(), parameters);
            }

            public override void Update(RegionEntity entity)
            {

                StringBuilder strSql = new StringBuilder();
                strSql.Append("update Region set ");
                strSql.Append("Name=@Name,");
                strSql.Append("Parent=@Parent");

                strSql.Append(" where Id=@Id");
                SqlParameter[] parameters = {
					new SqlParameter("@Id",SqlDbType.Int),
					new SqlParameter("@Name",SqlDbType.NVarChar),
					new SqlParameter("@Parent",SqlDbType.Int)
					};
                parameters[0].Value = entity.Id;
                parameters[1].Value = entity.Name;
                parameters[2].Value = entity.Parent;

                sqlHelper.ExecuteSql(strSql.ToString(), parameters);
            }

            public override void Delete(RegionEntity entity)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("delete from Region ");
                strSql.Append(" where Id=@primaryKeyId");
                SqlParameter[] parameters = {
						new SqlParameter("@primaryKeyId", SqlDbType.Int)
					};
                parameters[0].Value = entity.Id;
                sqlHelper.ExecuteSql(strSql.ToString(), parameters);
            }

            public override RegionEntity FindById(long primaryKeyId)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select * from Region ");
                strSql.Append(" where Id=@primaryKeyId");
                SqlParameter[] parameters = {
						new SqlParameter("@primaryKeyId", SqlDbType.Int)};
                parameters[0].Value = primaryKeyId;
                DataSet ds = sqlHelper.ExecuteDateSet(strSql.ToString(), parameters);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count == 1)
                {
                    DataRow row = ds.Tables[0].Rows[0];
                    RegionEntity entity = new RegionEntity();
                    if (!Convert.IsDBNull(row["Id"]))
                    {
                        entity.Id = (int)row["Id"];
                    }
                    entity.Name = row["Name"].ToString();
                    if (!Convert.IsDBNull(row["Parent"]))
                    {
                        entity.Parent = (int)row["Parent"];
                    }
                    return entity;
                }
                else
                {
                    return null;
                }
            }

            public override List<RegionEntity> Find(string strWhere, SqlParameter[] parameters)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select *");
                strSql.Append(" FROM Region(nolock) ");
                if (strWhere.Trim() != "")
                {
                    strSql.Append(" where " + strWhere);
                }

                DataSet ds = sqlHelper.ExecuteDateSet(strSql.ToString(), parameters);
                if (ds != null && ds.Tables.Count > 0)
                {
                    List<RegionEntity> list = new List<RegionEntity>();
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        RegionEntity entity = new RegionEntity();
                        if (!Convert.IsDBNull(row["Id"]))
                        {
                            entity.Id = (int)row["Id"];
                        }
                        entity.Name = row["Name"].ToString();
                        if (!Convert.IsDBNull(row["Parent"]))
                        {
                            entity.Parent = (int)row["Parent"];
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
                strSql.Append(" FROM Region(nolock)");
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
                string sql = "select count(*) from Region ";
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
            public DataTable GetPager(string where, SqlParameter[] param, string orderBy, int pageSize, int pageNumber)
            {
                int startNumber = pageSize * (pageNumber - 1);

                string sql = string.Format("SELECT TOP {0} * FROM (SELECT ROW_NUMBER() OVER", pageSize);

                if (!string.IsNullOrEmpty(orderBy))
                {
                    sql += string.Format(" (ORDER BY {0})", orderBy);
                }
                else
                {

                    sql += " (ORDER BY Id)";//默认按主键排序

                }

                sql += " AS RowNumber,* FROM Region";

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
