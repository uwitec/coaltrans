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
    public partial class CategoryEntity
    {
        private SqlHelper sqlHelper;

        #region const fields
        public const string DBName = "SentimentConnStr";
        public const string TableName = "Category";
        public const string PrimaryKey = "PK_CATEGORY";
        #endregion

        #region columns
        public struct Columns
        {
            public const string ID = "ID";
            public const string CategoryID = "CategoryID";
            public const string DataBaseId = "DataBaseId";
            public const string CategoryName = "CategoryName";
            public const string CateDisplay = "CateDisplay";
            public const string ParentCate = "ParentCate";
            public const string CatePath = "CatePath";
            public const string CreateBy = "CreateBy";
            public const string CreateTime = "CreateTime";
            public const string CateType = "CateType";
            public const string CateSource = "CateSource";
            public const string CateTrainInfo = "CateTrainInfo";
        }
        #endregion

        #region constructors
        public CategoryEntity()
        {
            sqlHelper = new SqlHelper(DBName);
        }

        public CategoryEntity(int id, int categoryid, string databaseid, string categoryname, string catedisplay, int parentcate, string catepath, string createby, DateTime createtime, int catetype, string catesource, string catetraininfo)
        {
            this.ID = id;

            this.CategoryID = categoryid;

            this.DataBaseId = databaseid;

            this.CategoryName = categoryname;

            this.CateDisplay = catedisplay;

            this.ParentCate = parentcate;

            this.CatePath = catepath;

            this.CreateBy = createby;

            this.CreateTime = createtime;

            this.CateType = catetype;

            this.CateSource = catesource;

            this.CateTrainInfo = catetraininfo;

        }
        #endregion

        #region Properties
        /// <summary>
        /// 主键标识
        /// </summary>
        public int? ID
        {
            get;
            set;
        }

        /// <summary>
        /// 分类ID号
        /// </summary>
        public int? CategoryID
        {
            get;
            set;
        }

        /// <summary>
        /// 所属表名
        /// </summary>
        public string DataBaseId
        {
            get;
            set;
        }

        /// <summary>
        /// 分类名称
        /// </summary>
        public string CategoryName
        {
            get;
            set;
        }

        /// <summary>
        /// 分类展示
        /// </summary>
        public string CateDisplay
        {
            get;
            set;
        }

        /// <summary>
        /// 父级分类
        /// </summary>
        public int? ParentCate
        {
            get;
            set;
        }

        /// <summary>
        /// 分类路径
        /// </summary>
        public string CatePath
        {
            get;
            set;
        }

        /// <summary>
        /// 分类创建人
        /// </summary>
        public string CreateBy
        {
            get;
            set;
        }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CreateTime
        {
            get;
            set;
        }

        /// <summary>
        /// 分类类型(如1:人物，2:事件)等
        /// </summary>
        public int? CateType
        {
            get;
            set;
        }

        /// <summary>
        /// 分类来源
        /// </summary>
        public string CateSource
        {
            get;
            set;
        }

        /// <summary>
        /// 分类训练信息
        /// </summary>
        public string CateTrainInfo
        {
            get;
            set;
        }

        #endregion

        public class CategoryDAO : SqlDAO<CategoryEntity>
        {
            private SqlHelper sqlHelper;
            public const string DBName = "SentimentConnStr";

            public CategoryDAO()
            {
                sqlHelper = new SqlHelper(DBName);
            }

            public override void Add(CategoryEntity entity)
            {

                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into Category(");
                strSql.Append("CategoryID,DataBaseId,CategoryName,CateDisplay,ParentCate,CatePath,CreateBy,CreateTime,CateType,CateSource,CateTrainInfo)");
                strSql.Append(" values (");
                strSql.Append("@CategoryID,@DataBaseId,@CategoryName,@CateDisplay,@ParentCate,@CatePath,@CreateBy,@CreateTime,@CateType,@CateSource,@CateTrainInfo)");
                SqlParameter[] parameters = {
					new SqlParameter("@CategoryID",SqlDbType.Int),
					new SqlParameter("@DataBaseId",SqlDbType.VarChar),
					new SqlParameter("@CategoryName",SqlDbType.VarChar),
					new SqlParameter("@CateDisplay",SqlDbType.VarChar),
					new SqlParameter("@ParentCate",SqlDbType.Int),
					new SqlParameter("@CatePath",SqlDbType.VarChar),
					new SqlParameter("@CreateBy",SqlDbType.VarChar),
					new SqlParameter("@CreateTime",SqlDbType.DateTime),
					new SqlParameter("@CateType",SqlDbType.Int),
					new SqlParameter("@CateSource",SqlDbType.VarChar),
					new SqlParameter("@CateTrainInfo",SqlDbType.VarChar)
					};
                parameters[0].Value = entity.CategoryID;
                parameters[1].Value = entity.DataBaseId;
                parameters[2].Value = entity.CategoryName;
                parameters[3].Value = entity.CateDisplay;
                parameters[4].Value = entity.ParentCate;
                parameters[5].Value = entity.CatePath;
                parameters[6].Value = entity.CreateBy;
                parameters[7].Value = entity.CreateTime;
                parameters[8].Value = entity.CateType;
                parameters[9].Value = entity.CateSource;
                parameters[10].Value = entity.CateTrainInfo;

                sqlHelper.ExecuteSql(strSql.ToString(), parameters);
            }

            public override void Update(CategoryEntity entity)
            {

                StringBuilder strSql = new StringBuilder();
                strSql.Append("update Category set ");
                strSql.Append("CategoryID=@CategoryID,");
                strSql.Append("DataBaseId=@DataBaseId,");
                strSql.Append("CategoryName=@CategoryName,");
                strSql.Append("CateDisplay=@CateDisplay,");
                strSql.Append("ParentCate=@ParentCate,");
                strSql.Append("CatePath=@CatePath,");
                strSql.Append("CreateBy=@CreateBy,");
                strSql.Append("CreateTime=@CreateTime,");
                strSql.Append("CateType=@CateType,");
                strSql.Append("CateSource=@CateSource,");
                strSql.Append("CateTrainInfo=@CateTrainInfo");

                strSql.Append(" where ID=@ID");
                SqlParameter[] parameters = {
					new SqlParameter("@ID",SqlDbType.Int),
					new SqlParameter("@CategoryID",SqlDbType.Int),
					new SqlParameter("@DataBaseId",SqlDbType.VarChar),
					new SqlParameter("@CategoryName",SqlDbType.VarChar),
					new SqlParameter("@CateDisplay",SqlDbType.VarChar),
					new SqlParameter("@ParentCate",SqlDbType.Int),
					new SqlParameter("@CatePath",SqlDbType.VarChar),
					new SqlParameter("@CreateBy",SqlDbType.VarChar),
					new SqlParameter("@CreateTime",SqlDbType.DateTime),
					new SqlParameter("@CateType",SqlDbType.Int),
					new SqlParameter("@CateSource",SqlDbType.VarChar),
					new SqlParameter("@CateTrainInfo",SqlDbType.VarChar)
					};
                parameters[0].Value = entity.ID;
                parameters[1].Value = entity.CategoryID;
                parameters[2].Value = entity.DataBaseId;
                parameters[3].Value = entity.CategoryName;
                parameters[4].Value = entity.CateDisplay;
                parameters[5].Value = entity.ParentCate;
                parameters[6].Value = entity.CatePath;
                parameters[7].Value = entity.CreateBy;
                parameters[8].Value = entity.CreateTime;
                parameters[9].Value = entity.CateType;
                parameters[10].Value = entity.CateSource;
                parameters[11].Value = entity.CateTrainInfo;

                sqlHelper.ExecuteSql(strSql.ToString(), parameters);
            }

            public bool UpdateSet(int ID, string ColumnName, string Value)
            {
                try
                {
                    StringBuilder StrSql = new StringBuilder();
                    StrSql.Append("update Category set ");
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
                string strSql = "delete from Category where ID=" + ID;
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

            public override void Delete(CategoryEntity entity)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("delete from Category ");
                strSql.Append(" where ID=@primaryKeyId");
                SqlParameter[] parameters = {
						new SqlParameter("@primaryKeyId", SqlDbType.Int)
					};
                parameters[0].Value = entity.ID;
                sqlHelper.ExecuteSql(strSql.ToString(), parameters);
            }

            public override CategoryEntity FindById(long primaryKeyId)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select * from Category ");
                strSql.Append(" where ID=@primaryKeyId");
                SqlParameter[] parameters = {
						new SqlParameter("@primaryKeyId", SqlDbType.Int)};
                parameters[0].Value = primaryKeyId;
                DataSet ds = sqlHelper.ExecuteDateSet(strSql.ToString(), parameters);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count == 1)
                {
                    DataRow row = ds.Tables[0].Rows[0];
                    CategoryEntity entity = new CategoryEntity();
                    if (!Convert.IsDBNull(row["ID"]))
                    {
                        entity.ID = (int)row["ID"];
                    }
                    if (!Convert.IsDBNull(row["CategoryID"]))
                    {
                        entity.CategoryID = (int)row["CategoryID"];
                    }
                    entity.DataBaseId = row["DataBaseId"].ToString();
                    entity.CategoryName = row["CategoryName"].ToString();
                    entity.CateDisplay = row["CateDisplay"].ToString();
                    if (!Convert.IsDBNull(row["ParentCate"]))
                    {
                        entity.ParentCate = (int)row["ParentCate"];
                    }
                    entity.CatePath = row["CatePath"].ToString();
                    entity.CreateBy = row["CreateBy"].ToString();
                    if (!Convert.IsDBNull(row["CreateTime"]))
                    {
                        entity.CreateTime = (DateTime)row["CreateTime"];
                    }
                    if (!Convert.IsDBNull(row["CateType"]))
                    {
                        entity.CateType = (int)row["CateType"];
                    }
                    entity.CateSource = row["CateSource"].ToString();
                    entity.CateTrainInfo = row["CateTrainInfo"].ToString();
                    return entity;
                }
                else
                {
                    return null;
                }
            }

            public override List<CategoryEntity> Find(string strWhere, SqlParameter[] parameters)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select *");
                strSql.Append(" FROM Category(nolock) ");
                if (strWhere.Trim() != "")
                {
                    strSql.Append(" where " + strWhere);
                }

                DataSet ds = sqlHelper.ExecuteDateSet(strSql.ToString(), parameters);
                if (ds != null && ds.Tables.Count > 0)
                {
                    List<CategoryEntity> list = new List<CategoryEntity>();
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        CategoryEntity entity = new CategoryEntity();
                        if (!Convert.IsDBNull(row["ID"]))
                        {
                            entity.ID = (int)row["ID"];
                        }
                        if (!Convert.IsDBNull(row["CategoryID"]))
                        {
                            entity.CategoryID = (int)row["CategoryID"];
                        }
                        entity.DataBaseId = row["DataBaseId"].ToString();
                        entity.CategoryName = row["CategoryName"].ToString();
                        entity.CateDisplay = row["CateDisplay"].ToString();
                        if (!Convert.IsDBNull(row["ParentCate"]))
                        {
                            entity.ParentCate = (int)row["ParentCate"];
                        }
                        entity.CatePath = row["CatePath"].ToString();
                        entity.CreateBy = row["CreateBy"].ToString();
                        if (!Convert.IsDBNull(row["CreateTime"]))
                        {
                            entity.CreateTime = (DateTime)row["CreateTime"];
                        }
                        if (!Convert.IsDBNull(row["CateType"]))
                        {
                            entity.CateType = (int)row["CateType"];
                        }
                        entity.CateSource = row["CateSource"].ToString();
                        entity.CateTrainInfo = row["CateTrainInfo"].ToString();

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
                strSql.Append(" FROM Category(nolock)");
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
                string sql = "select count(*) from Category ";
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

                sql += " AS RowNumber,* FROM Category";

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

