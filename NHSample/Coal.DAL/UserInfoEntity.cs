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
    public partial class UserInfoEntity
    {
        private SqlHelper sqlHelper;

        #region const fields
        public const string DBName = "Coal";
        public const string TableName = "UserInfo";
        public const string PrimaryKey = "PK_UserInfo";
        #endregion

        #region columns
        public struct Columns
        {
            public const string ID = "ID";
            public const string UserId = "UserId";
            public const string TrueName = "TrueName";
            public const string Occupation = "Occupation";
            public const string FixedTel = "FixedTel";
            public const string MobileTel = "MobileTel";
            public const string CorpName = "CorpName";
            public const string Fax = "Fax";
            public const string BizEmail = "BizEmail";
            public const string CorpId = "CorpId";
        }
        #endregion

        #region constructors
        public UserInfoEntity()
        {
            sqlHelper = new SqlHelper(DBName);
        }

        public UserInfoEntity(int id, int userid, string truename, string occupation, string fixedtel, string mobiletel, string corpname, string fax, string bizemail, int corpid)
        {
            this.ID = id;

            this.UserId = userid;

            this.TrueName = truename;

            this.Occupation = occupation;

            this.FixedTel = fixedtel;

            this.MobileTel = mobiletel;

            this.CorpName = corpname;

            this.Fax = fax;

            this.BizEmail = bizemail;

            this.CorpId = corpid;

        }
        #endregion

        #region Properties

        public int? ID
        {
            get;
            set;
        }


        public int? UserId
        {
            get;
            set;
        }


        public string TrueName
        {
            get;
            set;
        }


        public string Occupation
        {
            get;
            set;
        }


        public string FixedTel
        {
            get;
            set;
        }


        public string MobileTel
        {
            get;
            set;
        }


        public string CorpName
        {
            get;
            set;
        }


        public string Fax
        {
            get;
            set;
        }


        public string BizEmail
        {
            get;
            set;
        }


        public int? CorpId
        {
            get;
            set;
        }

        #endregion

        public class UserInfoDAO : SqlDAO<UserInfoEntity>
        {
            private SqlHelper sqlHelper;
            public const string DBName = "cheese";

            public UserInfoDAO()
            {
                sqlHelper = new SqlHelper(DBName);
            }

            public override void Add(UserInfoEntity entity)
            {

                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into UserInfo(");
                strSql.Append("UserId,TrueName,Occupation,FixedTel,MobileTel,CorpName,Fax,BizEmail,CorpId)");
                strSql.Append(" values (");
                strSql.Append("@UserId,@TrueName,@Occupation,@FixedTel,@MobileTel,@CorpName,@Fax,@BizEmail,@CorpId)");
                SqlParameter[] parameters = {
					new SqlParameter("@UserId",SqlDbType.Int),
					new SqlParameter("@TrueName",SqlDbType.NVarChar),
					new SqlParameter("@Occupation",SqlDbType.NVarChar),
					new SqlParameter("@FixedTel",SqlDbType.NVarChar),
					new SqlParameter("@MobileTel",SqlDbType.NVarChar),
					new SqlParameter("@CorpName",SqlDbType.NVarChar),
					new SqlParameter("@Fax",SqlDbType.NVarChar),
					new SqlParameter("@BizEmail",SqlDbType.NVarChar),
					new SqlParameter("@CorpId",SqlDbType.Int)
					};
                parameters[0].Value = entity.UserId;
                parameters[1].Value = entity.TrueName;
                parameters[2].Value = entity.Occupation;
                parameters[3].Value = entity.FixedTel;
                parameters[4].Value = entity.MobileTel;
                parameters[5].Value = entity.CorpName;
                parameters[6].Value = entity.Fax;
                parameters[7].Value = entity.BizEmail;
                parameters[8].Value = entity.CorpId;

                sqlHelper.ExecuteSql(strSql.ToString(), parameters);
            }

            public override void Update(UserInfoEntity entity)
            {

                StringBuilder strSql = new StringBuilder();
                strSql.Append("update UserInfo set ");
                strSql.Append("UserId=@UserId,");
                strSql.Append("TrueName=@TrueName,");
                strSql.Append("Occupation=@Occupation,");
                strSql.Append("FixedTel=@FixedTel,");
                strSql.Append("MobileTel=@MobileTel,");
                strSql.Append("CorpName=@CorpName,");
                strSql.Append("Fax=@Fax,");
                strSql.Append("BizEmail=@BizEmail,");
                strSql.Append("CorpId=@CorpId");

                strSql.Append(" where ID=@ID");
                SqlParameter[] parameters = {
					new SqlParameter("@ID",SqlDbType.Int),
					new SqlParameter("@UserId",SqlDbType.Int),
					new SqlParameter("@TrueName",SqlDbType.NVarChar),
					new SqlParameter("@Occupation",SqlDbType.NVarChar),
					new SqlParameter("@FixedTel",SqlDbType.NVarChar),
					new SqlParameter("@MobileTel",SqlDbType.NVarChar),
					new SqlParameter("@CorpName",SqlDbType.NVarChar),
					new SqlParameter("@Fax",SqlDbType.NVarChar),
					new SqlParameter("@BizEmail",SqlDbType.NVarChar),
					new SqlParameter("@CorpId",SqlDbType.Int)
					};
                parameters[0].Value = entity.ID;
                parameters[1].Value = entity.UserId;
                parameters[2].Value = entity.TrueName;
                parameters[3].Value = entity.Occupation;
                parameters[4].Value = entity.FixedTel;
                parameters[5].Value = entity.MobileTel;
                parameters[6].Value = entity.CorpName;
                parameters[7].Value = entity.Fax;
                parameters[8].Value = entity.BizEmail;
                parameters[9].Value = entity.CorpId;

                sqlHelper.ExecuteSql(strSql.ToString(), parameters);
            }

            public override void Delete(UserInfoEntity entity)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("delete from UserInfo ");
                strSql.Append(" where ID=@primaryKeyId");
                SqlParameter[] parameters = {
						new SqlParameter("@primaryKeyId", SqlDbType.Int)
					};
                parameters[0].Value = entity.ID;
                sqlHelper.ExecuteSql(strSql.ToString(), parameters);
            }

            public override UserInfoEntity FindById(long primaryKeyId)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select * from UserInfo ");
                strSql.Append(" where ID=@primaryKeyId");
                SqlParameter[] parameters = {
						new SqlParameter("@primaryKeyId", SqlDbType.Int)};
                parameters[0].Value = primaryKeyId;
                DataSet ds = sqlHelper.ExecuteDateSet(strSql.ToString(), parameters);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count == 1)
                {
                    DataRow row = ds.Tables[0].Rows[0];
                    UserInfoEntity entity = new UserInfoEntity();
                    if (!Convert.IsDBNull(row["ID"]))
                    {
                        entity.ID = (int)row["ID"];
                    }
                    if (!Convert.IsDBNull(row["UserId"]))
                    {
                        entity.UserId = (int)row["UserId"];
                    }
                    entity.TrueName = row["TrueName"].ToString();
                    entity.Occupation = row["Occupation"].ToString();
                    entity.FixedTel = row["FixedTel"].ToString();
                    entity.MobileTel = row["MobileTel"].ToString();
                    entity.CorpName = row["CorpName"].ToString();
                    entity.Fax = row["Fax"].ToString();
                    entity.BizEmail = row["BizEmail"].ToString();
                    if (!Convert.IsDBNull(row["CorpId"]))
                    {
                        entity.CorpId = (int)row["CorpId"];
                    }
                    return entity;
                }
                else
                {
                    return null;
                }
            }

            public override List<UserInfoEntity> Find(string strWhere, SqlParameter[] parameters)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select *");
                strSql.Append(" FROM UserInfo(nolock) ");
                if (strWhere.Trim() != "")
                {
                    strSql.Append(" where " + strWhere);
                }

                DataSet ds = sqlHelper.ExecuteDateSet(strSql.ToString(), parameters);
                if (ds != null && ds.Tables.Count > 0)
                {
                    List<UserInfoEntity> list = new List<UserInfoEntity>();
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        UserInfoEntity entity = new UserInfoEntity();
                        if (!Convert.IsDBNull(row["ID"]))
                        {
                            entity.ID = (int)row["ID"];
                        }
                        if (!Convert.IsDBNull(row["UserId"]))
                        {
                            entity.UserId = (int)row["UserId"];
                        }
                        entity.TrueName = row["TrueName"].ToString();
                        entity.Occupation = row["Occupation"].ToString();
                        entity.FixedTel = row["FixedTel"].ToString();
                        entity.MobileTel = row["MobileTel"].ToString();
                        entity.CorpName = row["CorpName"].ToString();
                        entity.Fax = row["Fax"].ToString();
                        entity.BizEmail = row["BizEmail"].ToString();
                        if (!Convert.IsDBNull(row["CorpId"]))
                        {
                            entity.CorpId = (int)row["CorpId"];
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
                strSql.Append(" FROM UserInfo(nolock)");
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
                string sql = "select count(*) from UserInfo ";
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

                    sql += " (ORDER BY ID)";//默认按主键排序

                }

                sql += " AS RowNumber,* FROM UserInfo";

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