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
    public partial class SupplyEntity
    {
        private SqlHelper sqlHelper;

        #region const fields
        public const string DBName = "Cheese";
        public const string TableName = "Supply";
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
            public const string Province = "Province";
            public const string City = "City";
            public const string ZipCode = "ZipCode";
            public const string CoalType = "CoalType";
            public const string Category = "Category";
            public const string CreatedOn = "CreatedOn";
            public const string ValidDate = "ValidDate";
            public const string WholesaleDes = "WholesaleDes";
            public const string ShipDes = "ShipDes";
            public const string Volatility = "Volatility";
            public const string GrainSize = "GrainSize";
            public const string AshContent = "AshContent";
            public const string SurfurContent = "SurfurContent";
            public const string WaterContent = "WaterContent";
            public const string CalorificPower = "CalorificPower";
        }
        #endregion

        #region constructors
        public SupplyEntity()
        {
            sqlHelper = new SqlHelper(DBName);
        }

        public SupplyEntity(int id, string title, string details, decimal price, int userid, int county, int province, int city, string zipcode, int coaltype, int category, DateTime createdon, DateTime validdate, string wholesaledes, string shipdes, double volatility, double grainsize, double ashcontent, double surfurcontent, double watercontent, double calorificpower)
        {
            this.ID = id;

            this.Title = title;

            this.Details = details;

            this.Price = price;

            this.UserId = userid;

            this.County = county;

            this.Province = province;

            this.City = city;

            this.ZipCode = zipcode;

            this.CoalType = coaltype;

            this.Category = category;

            this.CreatedOn = createdon;

            this.ValidDate = validdate;

            this.WholesaleDes = wholesaledes;

            this.ShipDes = shipdes;

            this.Volatility = volatility;

            this.GrainSize = grainsize;

            this.AshContent = ashcontent;

            this.SurfurContent = surfurcontent;

            this.WaterContent = watercontent;

            this.CalorificPower = calorificpower;

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


        public int? Category
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

        #endregion

        #region CUD Method

        public void Add()
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Supply(");
            strSql.Append("Title,Details,Price,UserId,County,Province,City,ZipCode,CoalType,Category,CreatedOn,ValidDate,WholesaleDes,ShipDes,Volatility,GrainSize,AshContent,SurfurContent,WaterContent,CalorificPower)");
            strSql.Append(" values (");
            strSql.Append("@Title,@Details,@Price,@UserId,@County,@Province,@City,@ZipCode,@CoalType,@Category,@CreatedOn,@ValidDate,@WholesaleDes,@ShipDes,@Volatility,@GrainSize,@AshContent,@SurfurContent,@WaterContent,@CalorificPower)");
            SqlParameter[] parameters = {
					new SqlParameter("@Title",SqlDbType.NVarChar),
					new SqlParameter("@Details",SqlDbType.NVarChar),
					new SqlParameter("@Price",SqlDbType.Decimal),
					new SqlParameter("@UserId",SqlDbType.Int),
					new SqlParameter("@County",SqlDbType.Int),
					new SqlParameter("@Province",SqlDbType.Int),
					new SqlParameter("@City",SqlDbType.Int),
					new SqlParameter("@ZipCode",SqlDbType.Char),
					new SqlParameter("@CoalType",SqlDbType.Int),
					new SqlParameter("@Category",SqlDbType.Int),
					new SqlParameter("@CreatedOn",SqlDbType.DateTime),
					new SqlParameter("@ValidDate",SqlDbType.DateTime),
					new SqlParameter("@WholesaleDes",SqlDbType.NVarChar),
					new SqlParameter("@ShipDes",SqlDbType.NVarChar),
					new SqlParameter("@Volatility",SqlDbType.Float),
					new SqlParameter("@GrainSize",SqlDbType.Float),
					new SqlParameter("@AshContent",SqlDbType.Float),
					new SqlParameter("@SurfurContent",SqlDbType.Float),
					new SqlParameter("@WaterContent",SqlDbType.Float),
					new SqlParameter("@CalorificPower",SqlDbType.Float)
					};
            parameters[0].Value = this.Title;
            parameters[1].Value = this.Details;
            parameters[2].Value = this.Price;
            parameters[3].Value = this.UserId;
            parameters[4].Value = this.County;
            parameters[5].Value = this.Province;
            parameters[6].Value = this.City;
            parameters[7].Value = this.ZipCode;
            parameters[8].Value = this.CoalType;
            parameters[9].Value = this.Category;
            parameters[10].Value = this.CreatedOn;
            parameters[11].Value = this.ValidDate;
            parameters[12].Value = this.WholesaleDes;
            parameters[13].Value = this.ShipDes;
            parameters[14].Value = this.Volatility;
            parameters[15].Value = this.GrainSize;
            parameters[16].Value = this.AshContent;
            parameters[17].Value = this.SurfurContent;
            parameters[18].Value = this.WaterContent;
            parameters[19].Value = this.CalorificPower;

            sqlHelper.ExecuteSql(strSql.ToString(), parameters);
        }

        public void Update()
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Supply set ");
            strSql.Append("Title=@Title,");
            strSql.Append("Details=@Details,");
            strSql.Append("Price=@Price,");
            strSql.Append("UserId=@UserId,");
            strSql.Append("County=@County,");
            strSql.Append("Province=@Province,");
            strSql.Append("City=@City,");
            strSql.Append("ZipCode=@ZipCode,");
            strSql.Append("CoalType=@CoalType,");
            strSql.Append("Category=@Category,");
            strSql.Append("CreatedOn=@CreatedOn,");
            strSql.Append("ValidDate=@ValidDate,");
            strSql.Append("WholesaleDes=@WholesaleDes,");
            strSql.Append("ShipDes=@ShipDes,");
            strSql.Append("Volatility=@Volatility,");
            strSql.Append("GrainSize=@GrainSize,");
            strSql.Append("AshContent=@AshContent,");
            strSql.Append("SurfurContent=@SurfurContent,");
            strSql.Append("WaterContent=@WaterContent,");
            strSql.Append("CalorificPower=@CalorificPower");

            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID",SqlDbType.Int),
					new SqlParameter("@Title",SqlDbType.NVarChar),
					new SqlParameter("@Details",SqlDbType.NVarChar),
					new SqlParameter("@Price",SqlDbType.Decimal),
					new SqlParameter("@UserId",SqlDbType.Int),
					new SqlParameter("@County",SqlDbType.Int),
					new SqlParameter("@Province",SqlDbType.Int),
					new SqlParameter("@City",SqlDbType.Int),
					new SqlParameter("@ZipCode",SqlDbType.Char),
					new SqlParameter("@CoalType",SqlDbType.Int),
					new SqlParameter("@Category",SqlDbType.Int),
					new SqlParameter("@CreatedOn",SqlDbType.DateTime),
					new SqlParameter("@ValidDate",SqlDbType.DateTime),
					new SqlParameter("@WholesaleDes",SqlDbType.NVarChar),
					new SqlParameter("@ShipDes",SqlDbType.NVarChar),
					new SqlParameter("@Volatility",SqlDbType.Float),
					new SqlParameter("@GrainSize",SqlDbType.Float),
					new SqlParameter("@AshContent",SqlDbType.Float),
					new SqlParameter("@SurfurContent",SqlDbType.Float),
					new SqlParameter("@WaterContent",SqlDbType.Float),
					new SqlParameter("@CalorificPower",SqlDbType.Float)
					};
            parameters[0].Value = this.ID;
            parameters[1].Value = this.Title;
            parameters[2].Value = this.Details;
            parameters[3].Value = this.Price;
            parameters[4].Value = this.UserId;
            parameters[5].Value = this.County;
            parameters[6].Value = this.Province;
            parameters[7].Value = this.City;
            parameters[8].Value = this.ZipCode;
            parameters[9].Value = this.CoalType;
            parameters[10].Value = this.Category;
            parameters[11].Value = this.CreatedOn;
            parameters[12].Value = this.ValidDate;
            parameters[13].Value = this.WholesaleDes;
            parameters[14].Value = this.ShipDes;
            parameters[15].Value = this.Volatility;
            parameters[16].Value = this.GrainSize;
            parameters[17].Value = this.AshContent;
            parameters[18].Value = this.SurfurContent;
            parameters[19].Value = this.WaterContent;
            parameters[20].Value = this.CalorificPower;

            sqlHelper.ExecuteSql(strSql.ToString(), parameters);
        }

        public void Delete(int primaryKeyId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Supply ");
            strSql.Append(" where ID=@primaryKeyId");
            SqlParameter[] parameters = {
					new SqlParameter("@primaryKeyId", SqlDbType.Int)
				};
            parameters[0].Value = primaryKeyId;
            sqlHelper.ExecuteSql(strSql.ToString(), parameters);
        }

        #endregion

        public class SupplyEntityFinder
        {
            private SqlHelper sqlHelper;
            public const string DBName = "Cheese";

            public SupplyEntityFinder()
            {
                sqlHelper = new SqlHelper(DBName);
            }

            public SupplyEntity FindById(int primaryKeyId)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select * from Supply ");
                strSql.Append(" where ID=@primaryKeyId");
                SqlParameter[] parameters = {
						new SqlParameter("@primaryKeyId", SqlDbType.Int)};
                parameters[0].Value = primaryKeyId;
                DataSet ds = sqlHelper.ExecuteDateSet(strSql.ToString(), parameters);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count == 1)
                {
                    DataRow row = ds.Tables[0].Rows[0];
                    SupplyEntity entity = new SupplyEntity();
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
                    if (!Convert.IsDBNull(row["Province"]))
                    {
                        entity.Province = (int)row["Province"];
                    }
                    if (!Convert.IsDBNull(row["City"]))
                    {
                        entity.City = (int)row["City"];
                    }
                    entity.ZipCode = row["ZipCode"].ToString();
                    if (!Convert.IsDBNull(row["CoalType"]))
                    {
                        entity.CoalType = (int)row["CoalType"];
                    }
                    if (!Convert.IsDBNull(row["Category"]))
                    {
                        entity.Category = (int)row["Category"];
                    }
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
                    return entity;
                }
                else
                {
                    return null;
                }
            }

            public List<SupplyEntity> Find(string strWhere)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select *");
                strSql.Append(" FROM Supply(nolock) ");
                if (strWhere.Trim() != "")
                {
                    strSql.Append(" where " + strWhere);
                }
                SqlDataReader dr = sqlHelper.ExecuteReader(strSql.ToString());
                List<SupplyEntity> list = new List<SupplyEntity>();
                while (dr.Read())
                {
                    SupplyEntity entity = new SupplyEntity();
                    if (!Convert.IsDBNull(dr["ID"]))
                    {
                        entity.ID = (int)dr["ID"];
                    }
                    entity.Title = dr["Title"].ToString();
                    entity.Details = dr["Details"].ToString();
                    if (!Convert.IsDBNull(dr["Price"]))
                    {
                        entity.Price = (decimal)dr["Price"];
                    }
                    if (!Convert.IsDBNull(dr["UserId"]))
                    {
                        entity.UserId = (int)dr["UserId"];
                    }
                    if (!Convert.IsDBNull(dr["County"]))
                    {
                        entity.County = (int)dr["County"];
                    }
                    if (!Convert.IsDBNull(dr["Province"]))
                    {
                        entity.Province = (int)dr["Province"];
                    }
                    if (!Convert.IsDBNull(dr["City"]))
                    {
                        entity.City = (int)dr["City"];
                    }
                    entity.ZipCode = dr["ZipCode"].ToString();
                    if (!Convert.IsDBNull(dr["CoalType"]))
                    {
                        entity.CoalType = (int)dr["CoalType"];
                    }
                    if (!Convert.IsDBNull(dr["Category"]))
                    {
                        entity.Category = (int)dr["Category"];
                    }
                    if (!Convert.IsDBNull(dr["CreatedOn"]))
                    {
                        entity.CreatedOn = (DateTime)dr["CreatedOn"];
                    }
                    if (!Convert.IsDBNull(dr["ValidDate"]))
                    {
                        entity.ValidDate = (DateTime)dr["ValidDate"];
                    }
                    entity.WholesaleDes = dr["WholesaleDes"].ToString();
                    entity.ShipDes = dr["ShipDes"].ToString();
                    if (!Convert.IsDBNull(dr["Volatility"]))
                    {
                        entity.Volatility = (double)dr["Volatility"];
                    }
                    if (!Convert.IsDBNull(dr["GrainSize"]))
                    {
                        entity.GrainSize = (double)dr["GrainSize"];
                    }
                    if (!Convert.IsDBNull(dr["AshContent"]))
                    {
                        entity.AshContent = (double)dr["AshContent"];
                    }
                    if (!Convert.IsDBNull(dr["SurfurContent"]))
                    {
                        entity.SurfurContent = (double)dr["SurfurContent"];
                    }
                    if (!Convert.IsDBNull(dr["WaterContent"]))
                    {
                        entity.WaterContent = (double)dr["WaterContent"];
                    }
                    if (!Convert.IsDBNull(dr["CalorificPower"]))
                    {
                        entity.CalorificPower = (double)dr["CalorificPower"];
                    }
                    list.Add(entity);
                }

                dr.Close();
                dr.Dispose();

                return list;
            }

            public DataSet GetDataSet(string strWhere, SqlParameter[] param)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select *");
                strSql.Append(" FROM Supply(nolock)");
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
                string sql = "select count(*) from Supply ";
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

                sql += " AS RowNumber,* FROM Supply";

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

