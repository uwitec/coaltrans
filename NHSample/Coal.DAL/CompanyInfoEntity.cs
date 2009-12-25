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
    public partial class CompanyInfoEntity
    {
        private SqlHelper sqlHelper;

        #region const fields
        public const string DBName = "Coal";
        public const string TableName = "CompanyInfo";
        public const string PrimaryKey = "PK_UserDetail";
        #endregion

        #region columns
        public struct Columns
        {
            public const string ID = "ID";
            public const string UserId = "UserId";
            public const string CompanyName = "CompanyName";
            public const string CompanyType = "CompanyType";
            public const string OperateType = "OperateType";
            public const string EstablishDate = "EstablishDate";
            public const string RegisteredCapital = "RegisteredCapital";
            public const string LegalPerson = "LegalPerson";
            public const string Introduction = "Introduction";
            public const string BusinessScope = "BusinessScope";
            public const string Address = "Address";
            public const string ZipCode = "ZipCode";
            public const string Province = "Province";
            public const string City = "City";
        }
        #endregion

        #region constructors
        public CompanyInfoEntity()
        {
            sqlHelper = new SqlHelper(DBName);
        }

        public CompanyInfoEntity(int id, int userid, string companyname, int companytype, int operatetype, DateTime establishdate, int registeredcapital, string legalperson, string introduction, string businessscope, string address, string zipcode, int province, int city)
        {
            this.ID = id;

            this.UserId = userid;

            this.CompanyName = companyname;

            this.CompanyType = companytype;

            this.OperateType = operatetype;

            this.EstablishDate = establishdate;

            this.RegisteredCapital = registeredcapital;

            this.LegalPerson = legalperson;

            this.Introduction = introduction;

            this.BusinessScope = businessscope;

            this.Address = address;

            this.ZipCode = zipcode;

            this.Province = province;

            this.City = city;

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


        public string CompanyName
        {
            get;
            set;
        }


        public int? CompanyType
        {
            get;
            set;
        }


        public int? OperateType
        {
            get;
            set;
        }


        public DateTime? EstablishDate
        {
            get;
            set;
        }


        public int? RegisteredCapital
        {
            get;
            set;
        }


        public string LegalPerson
        {
            get;
            set;
        }


        public string Introduction
        {
            get;
            set;
        }


        public string BusinessScope
        {
            get;
            set;
        }


        public string Address
        {
            get;
            set;
        }


        public string ZipCode
        {
            get;
            set;
        }


        public int? Province
        {
            get;
            set;
        }


        public int? City
        {
            get;
            set;
        }

        #endregion

        public class CompanyInfoDAO : SqlDAO<CompanyInfoEntity>
        {
            private SqlHelper sqlHelper;
            public const string DBName = "cheese";

            public CompanyInfoDAO()
            {
                sqlHelper = new SqlHelper(DBName);
            }

            public override void Add(CompanyInfoEntity entity)
            {

                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into CompanyInfo(");
                strSql.Append("UserId,CompanyName,CompanyType,OperateType,EstablishDate,RegisteredCapital,LegalPerson,Introduction,BusinessScope,Address,ZipCode,Province,City)");
                strSql.Append(" values (");
                strSql.Append("@UserId,@CompanyName,@CompanyType,@OperateType,@EstablishDate,@RegisteredCapital,@LegalPerson,@Introduction,@BusinessScope,@Address,@ZipCode,@Province,@City)");
                SqlParameter[] parameters = {
					new SqlParameter("@UserId",SqlDbType.Int),
					new SqlParameter("@CompanyName",SqlDbType.NVarChar),
					new SqlParameter("@CompanyType",SqlDbType.Int),
					new SqlParameter("@OperateType",SqlDbType.Int),
					new SqlParameter("@EstablishDate",SqlDbType.DateTime),
					new SqlParameter("@RegisteredCapital",SqlDbType.Int),
					new SqlParameter("@LegalPerson",SqlDbType.NVarChar),
					new SqlParameter("@Introduction",SqlDbType.NVarChar),
					new SqlParameter("@BusinessScope",SqlDbType.NVarChar),
					new SqlParameter("@Address",SqlDbType.NVarChar),
					new SqlParameter("@ZipCode",SqlDbType.Char),
					new SqlParameter("@Province",SqlDbType.Int),
					new SqlParameter("@City",SqlDbType.Int)
					};
                parameters[0].Value = entity.UserId;
                parameters[1].Value = entity.CompanyName;
                parameters[2].Value = entity.CompanyType;
                parameters[3].Value = entity.OperateType;
                parameters[4].Value = entity.EstablishDate;
                parameters[5].Value = entity.RegisteredCapital;
                parameters[6].Value = entity.LegalPerson;
                parameters[7].Value = entity.Introduction;
                parameters[8].Value = entity.BusinessScope;
                parameters[9].Value = entity.Address;
                parameters[10].Value = entity.ZipCode;
                parameters[11].Value = entity.Province;
                parameters[12].Value = entity.City;

                sqlHelper.ExecuteSql(strSql.ToString(), parameters);
            }

            public override void Update(CompanyInfoEntity entity)
            {

                StringBuilder strSql = new StringBuilder();
                strSql.Append("update CompanyInfo set ");
                strSql.Append("UserId=@UserId,");
                strSql.Append("CompanyName=@CompanyName,");
                strSql.Append("CompanyType=@CompanyType,");
                strSql.Append("OperateType=@OperateType,");
                strSql.Append("EstablishDate=@EstablishDate,");
                strSql.Append("RegisteredCapital=@RegisteredCapital,");
                strSql.Append("LegalPerson=@LegalPerson,");
                strSql.Append("Introduction=@Introduction,");
                strSql.Append("BusinessScope=@BusinessScope,");
                strSql.Append("Address=@Address,");
                strSql.Append("ZipCode=@ZipCode,");
                strSql.Append("Province=@Province,");
                strSql.Append("City=@City");

                strSql.Append(" where ID=@ID");
                SqlParameter[] parameters = {
					new SqlParameter("@ID",SqlDbType.Int),
					new SqlParameter("@UserId",SqlDbType.Int),
					new SqlParameter("@CompanyName",SqlDbType.NVarChar),
					new SqlParameter("@CompanyType",SqlDbType.Int),
					new SqlParameter("@OperateType",SqlDbType.Int),
					new SqlParameter("@EstablishDate",SqlDbType.DateTime),
					new SqlParameter("@RegisteredCapital",SqlDbType.Int),
					new SqlParameter("@LegalPerson",SqlDbType.NVarChar),
					new SqlParameter("@Introduction",SqlDbType.NVarChar),
					new SqlParameter("@BusinessScope",SqlDbType.NVarChar),
					new SqlParameter("@Address",SqlDbType.NVarChar),
					new SqlParameter("@ZipCode",SqlDbType.Char),
					new SqlParameter("@Province",SqlDbType.Int),
					new SqlParameter("@City",SqlDbType.Int)
					};
                parameters[0].Value = entity.ID;
                parameters[1].Value = entity.UserId;
                parameters[2].Value = entity.CompanyName;
                parameters[3].Value = entity.CompanyType;
                parameters[4].Value = entity.OperateType;
                parameters[5].Value = entity.EstablishDate;
                parameters[6].Value = entity.RegisteredCapital;
                parameters[7].Value = entity.LegalPerson;
                parameters[8].Value = entity.Introduction;
                parameters[9].Value = entity.BusinessScope;
                parameters[10].Value = entity.Address;
                parameters[11].Value = entity.ZipCode;
                parameters[12].Value = entity.Province;
                parameters[13].Value = entity.City;

                sqlHelper.ExecuteSql(strSql.ToString(), parameters);
            }

            public override void Delete(CompanyInfoEntity entity)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("delete from CompanyInfo ");
                strSql.Append(" where ID=@primaryKeyId");
                SqlParameter[] parameters = {
						new SqlParameter("@primaryKeyId", SqlDbType.Int)
					};
                parameters[0].Value = entity.ID;
                sqlHelper.ExecuteSql(strSql.ToString(), parameters);
            }

            public override CompanyInfoEntity FindById(long primaryKeyId)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select * from CompanyInfo ");
                strSql.Append(" where ID=@primaryKeyId");
                SqlParameter[] parameters = {
						new SqlParameter("@primaryKeyId", SqlDbType.Int)};
                parameters[0].Value = primaryKeyId;
                DataSet ds = sqlHelper.ExecuteDateSet(strSql.ToString(), parameters);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count == 1)
                {
                    DataRow row = ds.Tables[0].Rows[0];
                    CompanyInfoEntity entity = new CompanyInfoEntity();
                    if (!Convert.IsDBNull(row["ID"]))
                    {
                        entity.ID = (int)row["ID"];
                    }
                    if (!Convert.IsDBNull(row["UserId"]))
                    {
                        entity.UserId = (int)row["UserId"];
                    }
                    entity.CompanyName = row["CompanyName"].ToString();
                    if (!Convert.IsDBNull(row["CompanyType"]))
                    {
                        entity.CompanyType = (int)row["CompanyType"];
                    }
                    if (!Convert.IsDBNull(row["OperateType"]))
                    {
                        entity.OperateType = (int)row["OperateType"];
                    }
                    if (!Convert.IsDBNull(row["EstablishDate"]))
                    {
                        entity.EstablishDate = (DateTime)row["EstablishDate"];
                    }
                    if (!Convert.IsDBNull(row["RegisteredCapital"]))
                    {
                        entity.RegisteredCapital = (int)row["RegisteredCapital"];
                    }
                    entity.LegalPerson = row["LegalPerson"].ToString();
                    entity.Introduction = row["Introduction"].ToString();
                    entity.BusinessScope = row["BusinessScope"].ToString();
                    entity.Address = row["Address"].ToString();
                    entity.ZipCode = row["ZipCode"].ToString();
                    if (!Convert.IsDBNull(row["Province"]))
                    {
                        entity.Province = (int)row["Province"];
                    }
                    if (!Convert.IsDBNull(row["City"]))
                    {
                        entity.City = (int)row["City"];
                    }
                    return entity;
                }
                else
                {
                    return null;
                }
            }

            public override List<CompanyInfoEntity> Find(string strWhere, SqlParameter[] parameters)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select *");
                strSql.Append(" FROM CompanyInfo(nolock) ");
                if (strWhere.Trim() != "")
                {
                    strSql.Append(" where " + strWhere);
                }

                DataSet ds = sqlHelper.ExecuteDateSet(strSql.ToString(), parameters);
                if (ds != null && ds.Tables.Count > 0)
                {
                    List<CompanyInfoEntity> list = new List<CompanyInfoEntity>();
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        CompanyInfoEntity entity = new CompanyInfoEntity();
                        if (!Convert.IsDBNull(row["ID"]))
                        {
                            entity.ID = (int)row["ID"];
                        }
                        if (!Convert.IsDBNull(row["UserId"]))
                        {
                            entity.UserId = (int)row["UserId"];
                        }
                        entity.CompanyName = row["CompanyName"].ToString();
                        if (!Convert.IsDBNull(row["CompanyType"]))
                        {
                            entity.CompanyType = (int)row["CompanyType"];
                        }
                        if (!Convert.IsDBNull(row["OperateType"]))
                        {
                            entity.OperateType = (int)row["OperateType"];
                        }
                        if (!Convert.IsDBNull(row["EstablishDate"]))
                        {
                            entity.EstablishDate = (DateTime)row["EstablishDate"];
                        }
                        if (!Convert.IsDBNull(row["RegisteredCapital"]))
                        {
                            entity.RegisteredCapital = (int)row["RegisteredCapital"];
                        }
                        entity.LegalPerson = row["LegalPerson"].ToString();
                        entity.Introduction = row["Introduction"].ToString();
                        entity.BusinessScope = row["BusinessScope"].ToString();
                        entity.Address = row["Address"].ToString();
                        entity.ZipCode = row["ZipCode"].ToString();
                        if (!Convert.IsDBNull(row["Province"]))
                        {
                            entity.Province = (int)row["Province"];
                        }
                        if (!Convert.IsDBNull(row["City"]))
                        {
                            entity.City = (int)row["City"];
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
                strSql.Append(" FROM CompanyInfo(nolock)");
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
                string sql = "select count(*) from CompanyInfo ";
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

                sql += " AS RowNumber,* FROM CompanyInfo";

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

