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
    public partial class LeaderEntity
    {
        private SqlHelper sqlHelper;

        #region const fields
        public const string DBName = "SentimentConnStr";
        public const string TableName = "Leader";
        public const string PrimaryKey = "PK_LEADER";
        #endregion

        #region columns
        public struct Columns
        {
            public const string ID = "ID";
            public const string Name = "Name";
            public const string Code = "Code";
            public const string Category1 = "Category1";
            public const string Category2 = "Category2";
            public const string Category3 = "Category3";
            public const string MainCategoryID = "MainCategoryID";
            public const string TotalDocNums = "TotalDocNums";
            public const string PositiveNums = "PositiveNums";
            public const string NegativeNums = "NegativeNums";
        }
        #endregion

        #region constructors
        public LeaderEntity()
        {
            sqlHelper = new SqlHelper(DBName);
        }

        public LeaderEntity(int id, string name, string code, string category1, string category2, string category3, int maincategoryid, long totaldocnums, long positivenums, long negativenums)
        {
            this.ID = id;

            this.Name = name;

            this.Code = code;

            this.Category1 = category1;

            this.Category2 = category2;

            this.Category3 = category3;

            this.MainCategoryID = maincategoryid;

            this.TotalDocNums = totaldocnums;

            this.PositiveNums = positivenums;

            this.NegativeNums = negativenums;

        }
        #endregion

        #region Properties
        /// <summary>
        /// 主键ID
        /// </summary>
        public int? ID
        {
            get;
            set;
        }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        /// 名称标识
        /// </summary>
        public string Code
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
        /// MainCategoryID
        /// </summary>
        public int? MainCategoryID
        {
            get;
            set;
        }

        /// <summary>
        /// DOC总数
        /// </summary>
        public long? TotalDocNums
        {
            get;
            set;
        }

        /// <summary>
        /// 正面总数
        /// </summary>
        public long? PositiveNums
        {
            get;
            set;
        }

        /// <summary>
        /// 负面总数
        /// </summary>
        public long? NegativeNums
        {
            get;
            set;
        }

        #endregion

        public class LeaderDAO : SqlDAO<LeaderEntity>
        {
            private SqlHelper sqlHelper;
            public const string DBName = "SentimentConnStr";

            public LeaderDAO()
            {
                sqlHelper = new SqlHelper(DBName);
            }

            public override void Add(LeaderEntity entity)
            {

                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into Leader(");
                strSql.Append("Name,Code,Category1,Category2,Category3,MainCategoryID,TotalDocNums,PositiveNums,NegativeNums)");
                strSql.Append(" values (");
                strSql.Append("@Name,@Code,@Category1,@Category2,@Category3,@MainCategoryID,@TotalDocNums,@PositiveNums,@NegativeNums)");
                SqlParameter[] parameters = {
					new SqlParameter("@Name",SqlDbType.VarChar),
					new SqlParameter("@Code",SqlDbType.VarChar),
					new SqlParameter("@Category1",SqlDbType.VarChar),
					new SqlParameter("@Category2",SqlDbType.VarChar),
					new SqlParameter("@Category3",SqlDbType.VarChar),
					new SqlParameter("@MainCategoryID",SqlDbType.Int),
					new SqlParameter("@TotalDocNums",SqlDbType.BigInt),
					new SqlParameter("@PositiveNums",SqlDbType.BigInt),
					new SqlParameter("@NegativeNums",SqlDbType.BigInt)
					};
                parameters[0].Value = entity.Name;
                parameters[1].Value = entity.Code;
                parameters[2].Value = entity.Category1;
                parameters[3].Value = entity.Category2;
                parameters[4].Value = entity.Category3;
                parameters[5].Value = entity.MainCategoryID;
                parameters[6].Value = entity.TotalDocNums;
                parameters[7].Value = entity.PositiveNums;
                parameters[8].Value = entity.NegativeNums;

                sqlHelper.ExecuteSql(strSql.ToString(), parameters);
            }

            public override void Update(LeaderEntity entity)
            {

                StringBuilder strSql = new StringBuilder();
                strSql.Append("update Leader set ");
                strSql.Append("Name=@Name,");
                strSql.Append("Code=@Code,");
                strSql.Append("Category1=@Category1,");
                strSql.Append("Category2=@Category2,");
                strSql.Append("Category3=@Category3,");
                strSql.Append("MainCategoryID=@MainCategoryID,");
                strSql.Append("TotalDocNums=@TotalDocNums,");
                strSql.Append("PositiveNums=@PositiveNums,");
                strSql.Append("NegativeNums=@NegativeNums");

                strSql.Append(" where ID=@ID");
                SqlParameter[] parameters = {
					new SqlParameter("@ID",SqlDbType.Int),
					new SqlParameter("@Name",SqlDbType.VarChar),
					new SqlParameter("@Code",SqlDbType.VarChar),
					new SqlParameter("@Category1",SqlDbType.VarChar),
					new SqlParameter("@Category2",SqlDbType.VarChar),
					new SqlParameter("@Category3",SqlDbType.VarChar),
					new SqlParameter("@MainCategoryID",SqlDbType.Int),
					new SqlParameter("@TotalDocNums",SqlDbType.BigInt),
					new SqlParameter("@PositiveNums",SqlDbType.BigInt),
					new SqlParameter("@NegativeNums",SqlDbType.BigInt)
					};
                parameters[0].Value = entity.ID;
                parameters[1].Value = entity.Name;
                parameters[2].Value = entity.Code;
                parameters[3].Value = entity.Category1;
                parameters[4].Value = entity.Category2;
                parameters[5].Value = entity.Category3;
                parameters[6].Value = entity.MainCategoryID;
                parameters[7].Value = entity.TotalDocNums;
                parameters[8].Value = entity.PositiveNums;
                parameters[9].Value = entity.NegativeNums;

                sqlHelper.ExecuteSql(strSql.ToString(), parameters);
            }

            public bool UpdateSet(int ID, string ColumnName, string Value)
            {
                try
                {
                    StringBuilder StrSql = new StringBuilder();
                    StrSql.Append("update Leader set ");
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
                string strSql = "delete from Leader where ID=" + ID;
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

            public override void Delete(LeaderEntity entity)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("delete from Leader ");
                strSql.Append(" where ID=@primaryKeyId");
                SqlParameter[] parameters = {
						new SqlParameter("@primaryKeyId", SqlDbType.Int)
					};
                parameters[0].Value = entity.ID;
                sqlHelper.ExecuteSql(strSql.ToString(), parameters);
            }

            public override LeaderEntity FindById(long primaryKeyId)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select * from Leader ");
                strSql.Append(" where ID=@primaryKeyId");
                SqlParameter[] parameters = {
						new SqlParameter("@primaryKeyId", SqlDbType.Int)};
                parameters[0].Value = primaryKeyId;
                DataSet ds = sqlHelper.ExecuteDateSet(strSql.ToString(), parameters);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count == 1)
                {
                    DataRow row = ds.Tables[0].Rows[0];
                    LeaderEntity entity = new LeaderEntity();
                    if (!Convert.IsDBNull(row["ID"]))
                    {
                        entity.ID = (int)row["ID"];
                    }
                    entity.Name = row["Name"].ToString();
                    entity.Code = row["Code"].ToString();
                    entity.Category1 = row["Category1"].ToString();
                    entity.Category2 = row["Category2"].ToString();
                    entity.Category3 = row["Category3"].ToString();
                    if (!Convert.IsDBNull(row["MainCategoryID"]))
                    {
                        entity.MainCategoryID = (int)row["MainCategoryID"];
                    }
                    if (!Convert.IsDBNull(row["TotalDocNums"]))
                    {
                        entity.TotalDocNums = (long)row["TotalDocNums"];
                    }
                    if (!Convert.IsDBNull(row["PositiveNums"]))
                    {
                        entity.PositiveNums = (long)row["PositiveNums"];
                    }
                    if (!Convert.IsDBNull(row["NegativeNums"]))
                    {
                        entity.NegativeNums = (long)row["NegativeNums"];
                    }
                    return entity;
                }
                else
                {
                    return null;
                }
            }

            public override List<LeaderEntity> Find(string strWhere, SqlParameter[] parameters)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select *");
                strSql.Append(" FROM Leader(nolock) ");
                if (strWhere.Trim() != "")
                {
                    strSql.Append(" where " + strWhere);
                }

                DataSet ds = sqlHelper.ExecuteDateSet(strSql.ToString(), parameters);
                if (ds != null && ds.Tables.Count > 0)
                {
                    List<LeaderEntity> list = new List<LeaderEntity>();
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        LeaderEntity entity = new LeaderEntity();
                        if (!Convert.IsDBNull(row["ID"]))
                        {
                            entity.ID = (int)row["ID"];
                        }
                        entity.Name = row["Name"].ToString();
                        entity.Code = row["Code"].ToString();
                        entity.Category1 = row["Category1"].ToString();
                        entity.Category2 = row["Category2"].ToString();
                        entity.Category3 = row["Category3"].ToString();
                        if (!Convert.IsDBNull(row["MainCategoryID"]))
                        {
                            entity.MainCategoryID = (int)row["MainCategoryID"];
                        }
                        if (!Convert.IsDBNull(row["TotalDocNums"]))
                        {
                            entity.TotalDocNums = (long)row["TotalDocNums"];
                        }
                        if (!Convert.IsDBNull(row["PositiveNums"]))
                        {
                            entity.PositiveNums = (long)row["PositiveNums"];
                        }
                        if (!Convert.IsDBNull(row["NegativeNums"]))
                        {
                            entity.NegativeNums = (long)row["NegativeNums"];
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
                strSql.Append(" FROM Leader(nolock)");
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
                string sql = "select count(*) from Leader ";
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

                sql += " AS RowNumber,* FROM Leader";

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

                                                                                                                                                                                                                                                                                                                                   a r e   F o u n d a t i o n     h   F i l e D e s c r i p t i o n     l o g 4 n e t   f o r   . N E T   F r a m e w o r k   2 . 0     4 	  F i l e V e r s i o n     1 . 2 . 1 0 . 0     8   I n t e r n a l N a m e   l o g 4 n e t . d l l   � 4  L e g a l C o p y r i g h t   C o p y r i g h t   2 0 0 1 - 2 0 0 6   T h e   A p a c h e   S o f t w a r e   F o u n d a t i o n .   � 4  L e g a l T r a d e m a r k s     C o p y r i g h t   2 0 0 1 - 2 0 0 6   T h e   A p a c h e   S o f t w a r e   F o u n d a t i o n .   @   O r i g i n a l F i l e n a m e   l o g 4 n e t . d l l   0   P r o d u c t N a m e     l o g 4 n e t   ,   P r o d u c t V e r s i o n   1 . 2   < 	  A s s e m b l y   V e r s i o n   1 . 2 . 1 0 . 0                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                             