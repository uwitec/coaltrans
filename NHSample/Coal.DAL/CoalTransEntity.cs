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
    public partial class CoalTransEntity
    {
        private SqlHelper sqlHelper;

        #region const fields
        public const string DBName = "Cheese";
        public const string TableName = "CoalTrans";
        public const string PrimaryKey = "PK_Supply";
        #endregion

        #region columns
        public struct Columns
        {
            public const string ID = "ID";
            public const string Title = "Title";
            public const string Details = "Details";
            public const string Price = "Price";
            public const string UserId = "UserId";
            public const string County = "County";
            public const string CountyName = "CountyName";
            public const string Province = "Province";
            public const string ProvinceName = "ProvinceName";
            public const string City = "City";
            public const string CityName = "CityName";
            public const string ZipCode = "ZipCode";
            public const string CoalType = "CoalType";
            public const string CoalTypeName = "CoalTypeName";
            public const string Category = "Category";
            public const string CategoryName = "CategoryName";
            public const string CreatedOn = "CreatedOn";
            public const string ValidDate = "ValidDate";
            public const string WholesaleDes = "WholesaleDes";
            public const string ShipDes = "ShipDes";
            public const string Volatility = "Volatility";
            public const string GrainSize = "GrainSize";
            public const string GrainSizeDes = "GrainSizeDes";
            public const string AshContent = "AshContent";
            public const string SurfurContent = "SurfurContent";
            public const string WaterContent = "WaterContent";
            public const string CalorificPower = "CalorificPower";
            public const string TransType = "TransType";
        }
        #endregion

        #region constructors
        public CoalTransEntity()
        {
            sqlHelper = new SqlHelper(DBName);
        }

        public CoalTransEntity(int id, string title, string details, decimal price, int userid, int county, string countyname, int province, string provincename, int city, string cityname, string zipcode, int coaltype, string coaltypename, int category, string categoryname, DateTime createdon, DateTime validdate, string wholesaledes, string shipdes, double volatility, double grainsize, string grainsizedes, double ashcontent, double surfurcontent, double watercontent, double calorificpower, int transtype)
        {
            this.ID = id;

            this.Title = title;

            this.Details = details;

            this.Price = price;

            this.UserId = userid;

            this.County = county;

            this.CountyName = countyname;

            this.Province = province;

            this.ProvinceName = provincename;

            this.City = city;

            this.CityName = cityname;

            this.ZipCode = zipcode;

            this.CoalType = coaltype;

            this.CoalTypeName = coaltypename;

            this.Category = category;

            this.CategoryName = categoryname;

            this.CreatedOn = createdon;

            this.ValidDate = validdate;

            this.WholesaleDes = wholesaledes;

            this.ShipDes = shipdes;

            this.Volatility = volatility;

            this.GrainSize = grainsize;

            this.GrainSizeDes = grainsizedes;

            this.AshContent = ashcontent;

            this.SurfurContent = surfurcontent;

            this.WaterContent = watercontent;

            this.CalorificPower = calorificpower;

            this.TransType = transtype;

        }
        #endregion

        #region Properties

        public int? ID
        {
            get;
            set;
        }


        public string Title
        {
            get;
            set;
        }


        public string Details
        {
            get;
            set;
        }


        public decimal? Price
        {
            get;
            set;
        }


        public int? UserId
        {
            get;
            set;
        }


        public int? County
        {
            get;
            set;
        }


        public string CountyName
        {
            get;
            set;
        }


        public int? Province
        {
            get;
            set;
        }


        public string ProvinceName
        {
            get;
            set;
        }


        public int? City
        {
            get;
            set;
        }


        public string CityName
        {
            get;
            set;
        }


        public string ZipCode
        {
            get;
            set;
        }


        public int? CoalType
        {
            get;
            set;
        }


        public string CoalTypeName
        {
            get;
            set;
        }


        public int? Category
        {
            get;
            set;
        }


        public string CategoryName
        {
            get;
            set;
        }


        public DateTime? CreatedOn
        {
            get;
            set;
        }


        public DateTime? ValidDate
        {
            get;
            set;
        }


        public string WholesaleDes
        {
            get;
            set;
        }


        public string ShipDes
        {
            get;
            set;
        }


        public double? Volatility
        {
            get;
            set;
        }


        public double? GrainSize
        {
            get;
            set;
        }


        public string GrainSizeDes
        {
            get;
            set;
        }


        public double? AshContent
        {
            get;
            set;
        }


        public double? SurfurContent
        {
            get;
            set;
        }


        public double? WaterContent
        {
            get;
            set;
        }


        public double? CalorificPower
        {
            get;
            set;
        }


        public int? TransType
        {
            get;
            set;
        }

        #endregion

        public class CoalTransDAO : SqlDAO<CoalTransEntity>
        {
            private SqlHelper sqlHelper;
            public const string DBName = "cheese";

            public CoalTransDAO()
            {
                sqlHelper = new SqlHelper(DBName);
            }

            public override void Add(CoalTransEntity entity)
            {

                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into CoalTrans(");
                strSql.Append("Title,Details,Price,UserId,County,CountyName,Province,ProvinceName,City,CityName,ZipCode,CoalType,CoalTypeName,Category,CategoryName,CreatedOn,ValidDate,WholesaleDes,ShipDes,Volatility,GrainSize,GrainSizeDes,AshContent,SurfurContent,WaterContent,CalorificPower,TransType)");
                strSql.Append(" values (");
                strSql.Append("@Title,@Details,@Price,@UserId,@County,@CountyName,@Province,@ProvinceName,@City,@CityName,@ZipCode,@CoalType,@CoalTypeName,@Category,@CategoryName,@CreatedOn,@ValidDate,@WholesaleDes,@ShipDes,@Volatility,@GrainSize,@GrainSizeDes,@AshContent,@SurfurContent,@WaterContent,@CalorificPower,@TransType)");
                SqlParameter[] parameters = {
					new SqlParameter("@Title",SqlDbType.NVarChar),
					new SqlParameter("@Details",SqlDbType.NVarChar),
					new SqlParameter("@Price",SqlDbType.Decimal),
					new SqlParameter("@UserId",SqlDbType.Int),
					new SqlParameter("@County",SqlDbType.Int),
					new SqlParameter("@CountyName",SqlDbType.NVarChar),
					new SqlParameter("@Province",SqlDbType.Int),
					new SqlParameter("@ProvinceName",SqlDbType.NVarChar),
					new SqlParameter("@City",SqlDbType.Int),
					new SqlParameter("@CityName",SqlDbType.NVarChar),
					new SqlParameter("@ZipCode",SqlDbType.Char),
					new SqlParameter("@CoalType",SqlDbType.Int),
					new SqlParameter("@CoalTypeName",SqlDbType.NVarChar),
					new SqlParameter("@Category",SqlDbType.Int),
					new SqlParameter("@CategoryName",SqlDbType.NVarChar),
					new SqlParameter("@CreatedOn",SqlDbType.DateTime),
					new SqlParameter("@ValidDate",SqlDbType.DateTime),
					new SqlParameter("@WholesaleDes",SqlDbType.NVarChar),
					new SqlParameter("@ShipDes",SqlDbType.NVarChar),
					new SqlParameter("@Volatility",SqlDbType.Float),
					new SqlParameter("@GrainSize",SqlDbType.Float),
					new SqlParameter("@GrainSizeDes",SqlDbType.NVarChar),
					new SqlParameter("@AshContent",SqlDbType.Float),
					new SqlParameter("@SurfurContent",SqlDbType.Float),
					new SqlParameter("@WaterContent",SqlDbType.Float),
					new SqlParameter("@CalorificPower",SqlDbType.Float),
					new SqlParameter("@TransType",SqlDbType.Int)
					};
                parameters[0].Value = entity.Title;
                parameters[1].Value = entity.Details;
                parameters[2].Value = entity.Price;
                parameters[3].Value = entity.UserId;
                parameters[4].Value = entity.County;
                parameters[5].Value = entity.CountyName;
                parameters[6].Value = entity.Province;
                parameters[7].Value = entity.ProvinceName;
                parameters[8].Value = entity.City;
                parameters[9].Value = entity.CityName;
                parameters[10].Value = entity.ZipCode;
                parameters[11].Value = entity.CoalType;
                parameters[12].Value = entity.CoalTypeName;
                parameters[13].Value = entity.Category;
                parameters[14].Value = entity.CategoryName;
                parameters[15].Value = entity.CreatedOn;
                parameters[16].Value = entity.ValidDate;
                parameters[17].Value = entity.WholesaleDes;
                parameters[18].Value = entity.ShipDes;
                parameters[19].Value = entity.Volatility;
                parameters[20].Value = entity.GrainSize;
                parameters[21].Value = entity.GrainSizeDes;
                parameters[22].Value = entity.AshContent;
                parameters[23].Value = entity.SurfurContent;
                parameters[24].Value = entity.WaterContent;
                parameters[25].Value = entity.CalorificPower;
                parameters[26].Value = entity.TransType;

                sqlHelper.ExecuteSql(strSql.ToString(), parameters);
            }

            public override void Update(CoalTransEntity entity)
            {

                StringBuilder strSql = new StringBuilder();
                strSql.Append("update CoalTrans set ");
                strSql.Append("Title=@Title,");
                strSql.Append("Details=@Details,");
                strSql.Append("Price=@Price,");
                strSql.Append("UserId=@UserId,");
                strSql.Append("County=@County,");
                strSql.Append("CountyName=@CountyName,");
                strSql.Append("Province=@Province,");
                strSql.Append("ProvinceName=@ProvinceName,");
                strSql.Append("City=@City,");
                strSql.Append("CityName=@CityName,");
                strSql.Append("ZipCode=@ZipCode,");
                strSql.Append("CoalType=@CoalType,");
                strSql.Append("CoalTypeName=@CoalTypeName,");
                strSql.Append("Category=@Category,");
                strSql.Append("CategoryName=@CategoryName,");
                strSql.Append("CreatedOn=@CreatedOn,");
                strSql.Append("ValidDate=@ValidDate,");
                strSql.Append("WholesaleDes=@WholesaleDes,");
                strSql.Append("ShipDes=@ShipDes,");
                strSql.Append("Volatility=@Volatility,");
                strSql.Append("GrainSize=@GrainSize,");
                strSql.Append("GrainSizeDes=@GrainSizeDes,");
                strSql.Append("AshContent=@AshContent,");
                strSql.Append("SurfurContent=@SurfurContent,");
                strSql.Append("WaterContent=@WaterContent,");
                strSql.Append("CalorificPower=@CalorificPower,");
                strSql.Append("TransType=@TransType");

                strSql.Append(" where ID=@ID");
                SqlParameter[] parameters = {
					new SqlParameter("@ID",SqlDbType.Int),
					new SqlParameter("@Title",SqlDbType.NVarChar),
					new SqlParameter("@Details",SqlDbType.NVarChar),
					new SqlParameter("@Price",SqlDbType.Decimal),
					new SqlParameter("@UserId",SqlDbType.Int),
					new SqlParameter("@County",SqlDbType.Int),
					new SqlParameter("@CountyName",SqlDbType.NVarChar),
					new SqlParameter("@Province",SqlDbType.Int),
					new SqlParameter("@ProvinceName",SqlDbType.NVarChar),
					new SqlParameter("@City",SqlDbType.Int),
					new SqlParameter("@CityName",SqlDbType.NVarChar),
					new SqlParameter("@ZipCode",SqlDbType.Char),
					new SqlParameter("@CoalType",SqlDbType.Int),
					new SqlParameter("@CoalTypeName",SqlDbType.NVarChar),
					new SqlParameter("@Category",SqlDbType.Int),
					new SqlParameter("@CategoryName",SqlDbType.NVarChar),
					new SqlParameter("@CreatedOn",SqlDbType.DateTime),
					new SqlParameter("@ValidDate",SqlDbType.DateTime),
					new SqlParameter("@WholesaleDes",SqlDbType.NVarChar),
					new SqlParameter("@ShipDes",SqlDbType.NVarChar),
					new SqlParameter("@Volatility",SqlDbType.Float),
					new SqlParameter("@GrainSize",SqlDbType.Float),
					new SqlParameter("@GrainSizeDes",SqlDbType.NVarChar),
					new SqlParameter("@AshContent",SqlDbType.Float),
					new SqlParameter("@SurfurContent",SqlDbType.Float),
					new SqlParameter("@WaterContent",SqlDbType.Float),
					new SqlParameter("@CalorificPower",SqlDbType.Float),
					new SqlParameter("@TransType",SqlDbType.Int)
					};
                parameters[0].Value = entity.ID;
                parameters[1].Value = entity.Title;
                parameters[2].Value = entity.Details;
                parameters[3].Value = entity.Price;
                parameters[4].Value = entity.UserId;
                parameters[5].Value = entity.County;
                parameters[6].Value = entity.CountyName;
                parameters[7].Value = entity.Province;
                parameters[8].Value = entity.ProvinceName;
                parameters[9].Value = entity.City;
                parameters[10].Value = entity.CityName;
                parameters[11].Value = entity.ZipCode;
                parameters[12].Value = entity.CoalType;
                parameters[13].Value = entity.CoalTypeName;
                parameters[14].Value = entity.Category;
                parameters[15].Value = entity.CategoryName;
                parameters[16].Value = entity.CreatedOn;
                parameters[17].Value = entity.ValidDate;
                parameters[18].Value = entity.WholesaleDes;
                parameters[19].Value = entity.ShipDes;
                parameters[20].Value = entity.Volatility;
                parameters[21].Value = entity.GrainSize;
                parameters[22].Value = entity.GrainSizeDes;
                parameters[23].Value = entity.AshContent;
                parameters[24].Value = entity.SurfurContent;
                parameters[25].Value = entity.WaterContent;
                parameters[26].Value = entity.CalorificPower;
                parameters[27].Value = entity.TransType;

                sqlHelper.ExecuteSql(strSql.ToString(), parameters);
            }

            public override void Delete(CoalTransEntity entity)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("delete from CoalTrans ");
                strSql.Append(" where ID=@primaryKeyId");
                SqlParameter[] parameters = {
						new SqlParameter("@primaryKeyId", SqlDbType.Int)
					};
                parameters[0].Value = entity.ID;
                sqlHelper.ExecuteSql(strSql.ToString(), parameters);
            }

            public override CoalTransEntity FindById(long primaryKeyId)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select * from CoalTrans ");
                strSql.Append(" where ID=@primaryKeyId");
                SqlParameter[] parameters = {
						new SqlParameter("@primaryKeyId", SqlDbType.Int)};
                parameters[0].Value = primaryKeyId;
                DataSet ds = sqlHelper.ExecuteDateSet(strSql.ToString(), parameters);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count == 1)
                {
                    DataRow row = ds.Tables[0].Rows[0];
                    CoalTransEntity entity = new CoalTransEntity();
                    if (!Convert.IsDBNull(row["ID"]))
                    {
                        entity.ID = (int)row["ID"];
                    }
                    entity.Title = row["Title"].ToString();
                    entity.Details = row["Details"].ToString();
                    if (!Convert.IsDBNull(row["Price"]))
                    {
                        entity.Price = (decimal)row["Price"];
                    }
                    if (!Convert.IsDBNull(row["UserId"]))
                    {
                        entity.UserId = (int)row["UserId"];
                    }
                    if (!Convert.IsDBNull(row["County"]))
                    {
                        entity.County = (int)row["County"];
                    }
                    entity.CountyName = row["CountyName"].ToString();
                    if (!Convert.IsDBNull(row["Province"]))
                    {
                        entity.Province = (int)row["Province"];
                    }
                    entity.ProvinceName = row["ProvinceName"].ToString();
                    if (!Convert.IsDBNull(row["City"]))
                    {
                        entity.City = (int)row["City"];
                    }
                    entity.CityName = row["CityName"].ToString();
                    entity.ZipCode = row["ZipCode"].ToString();
                    if (!Convert.IsDBNull(row["CoalType"]))
                    {
                        entity.CoalType = (int)row["CoalType"];
                    }
                    entity.CoalTypeName = row["CoalTypeName"].ToString();
                    if (!Convert.IsDBNull(row["Category"]))
                    {
                        entity.Category = (int)row["Category"];
                    }
                    entity.CategoryName = row["CategoryName"].ToString();
                    if (!Convert.IsDBNull(row["CreatedOn"]))
                    {
                        entity.CreatedOn = (DateTime)row["CreatedOn"];
                    }
                    if (!Convert.IsDBNull(row["ValidDate"]))
                    {
                        entity.ValidDate = (DateTime)row["ValidDate"];
                    }
                    entity.WholesaleDes = row["WholesaleDes"].ToString();
                    entity.ShipDes = row["ShipDes"].ToString();
                    if (!Convert.IsDBNull(row["Volatility"]))
                    {
                        entity.Volatility = (double)row["Volatility"];
                    }
                    if (!Convert.IsDBNull(row["GrainSize"]))
                    {
                        entity.GrainSize = (double)row["GrainSize"];
                    }
                    entity.GrainSizeDes = row["GrainSizeDes"].ToString();
                    if (!Convert.IsDBNull(row["AshContent"]))
                    {
                        entity.AshContent = (double)row["AshContent"];
                    }
                    if (!Convert.IsDBNull(row["SurfurContent"]))
                    {
                        entity.SurfurContent = (double)row["SurfurContent"];
                    }
                    if (!Convert.IsDBNull(row["WaterContent"]))
                    {
                        entity.WaterContent = (double)row["WaterContent"];
                    }
                    if (!Convert.IsDBNull(row["CalorificPower"]))
                    {
                        entity.CalorificPower = (double)row["CalorificPower"];
                    }
                    if (!Convert.IsDBNull(row["TransType"]))
                    {
                        entity.TransType = (int)row["TransType"];
                    }
                    return entity;
                }
                else
                {
                    return null;
                }
            }

            public override List<CoalTransEntity> Find(string strWhere, SqlParameter[] parameters)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select *");
                strSql.Append(" FROM CoalTrans(nolock) ");
                if (strWhere.Trim() != "")
                {
                    strSql.Append(" where " + strWhere);
                }

                DataSet ds = sqlHelper.ExecuteDateSet(strSql.ToString(), parameters);
                if (ds != null && ds.Tables.Count > 0)
                {
                    List<CoalTransEntity> list = new List<CoalTransEntity>();
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        CoalTransEntity entity = new CoalTransEntity();
                        if (!Convert.IsDBNull(row["ID"]))
                        {
                            entity.ID = (int)row["ID"];
                        }
                        entity.Title = row["Title"].ToString();
                        entity.Details = row["Details"].ToString();
                        if (!Convert.IsDBNull(row["Price"]))
                        {
                            entity.Price = (decimal)row["Price"];
                        }
                        if (!Convert.IsDBNull(row["UserId"]))
                        {
                            entity.UserId = (int)row["UserId"];
                        }
                        if (!Convert.IsDBNull(row["County"]))
                        {
                            entity.County = (int)row["County"];
                        }
                        entity.CountyName = row["CountyName"].ToString();
                        if (!Convert.IsDBNull(row["Province"]))
                        {
                            entity.Province = (int)row["Province"];
                        }
                        entity.ProvinceName = row["ProvinceName"].ToString();
                        if (!Convert.IsDBNull(row["City"]))
                        {
                            entity.City = (int)row["City"];
                        }
                        entity.CityName = row["CityName"].ToString();
                        entity.ZipCode = row["ZipCode"].ToString();
                        if (!Convert.IsDBNull(row["CoalType"]))
                        {
                            entity.CoalType = (int)row["CoalType"];
                        }
                        entity.CoalTypeName = row["CoalTypeName"].ToString();
                        if (!Convert.IsDBNull(row["Category"]))
                        {
                            entity.Category = (int)row["Category"];
                        }
                        entity.CategoryName = row["CategoryName"].ToString();
                        if (!Convert.IsDBNull(row["CreatedOn"]))
                        {
                            entity.CreatedOn = (DateTime)row["CreatedOn"];
                        }
                        if (!Convert.IsDBNull(row["ValidDate"]))
                        {
                            entity.ValidDate = (DateTime)row["ValidDate"];
                        }
                        entity.WholesaleDes = row["WholesaleDes"].ToString();
                        entity.ShipDes = row["ShipDes"].ToString();
                        if (!Convert.IsDBNull(row["Volatility"]))
                        {
                            entity.Volatility = (double)row["Volatility"];
                        }
                        if (!Convert.IsDBNull(row["GrainSize"]))
                        {
                            entity.GrainSize = (double)row["GrainSize"];
                        }
                        entity.GrainSizeDes = row["GrainSizeDes"].ToString();
                        if (!Convert.IsDBNull(row["AshContent"]))
                        {
                            entity.AshContent = (double)row["AshContent"];
                        }
                        if (!Convert.IsDBNull(row["SurfurContent"]))
                        {
                            entity.SurfurContent = (double)row["SurfurContent"];
                        }
                        if (!Convert.IsDBNull(row["WaterContent"]))
                        {
                            entity.WaterContent = (double)row["WaterContent"];
                        }
                        if (!Convert.IsDBNull(row["CalorificPower"]))
                        {
                            entity.CalorificPower = (double)row["CalorificPower"];
                        }
                        if (!Convert.IsDBNull(row["TransType"]))
                        {
                            entity.TransType = (int)row["TransType"];
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
                strSql.Append(" FROM CoalTrans(nolock)");
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
                string sql = "select count(*) from CoalTrans ";
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

                sql += " AS RowNumber,* FROM CoalTrans";

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