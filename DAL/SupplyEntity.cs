using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace CoalTrans.DAL
{
    [Serializable]
    public class SupplyEntity
    {
        public const string DBName = "CoalTrans";
        public const string TableName = "Supply";
        public const string IdentityColumn = "ID";
        public const string PrimaryKey = "ID";
        private SqlHelper sqlHelper;


        public long ID{get;set;}
        public string Subject{get;set;}
        public int CoalType{get;set;}
        public int Category{get;set;}
        public long UserID{get;set;}
        public DateTime CreatedOn{get;set;}
        public DateTime ValidDate{get;set;}
        public int Region{get;set;}
        public string Description{get;set;}
        public string WholesaleDes{get;set;}
        public string ShipDes{get;set;}
        public int Volatility{get;set;}
        public int GrainSize{get;set;}
        public int AshContent{get;set;}
        public int SurfurContent{get;set;}
        public int WaterContent{get;set;}
        public int CalorificPower{get;set;}
	
        public struct Columns
        {
            public const string ID = "ID";
            public const string Subject = "Subject";
            public const string CoalType = "CoalType";
            public const string Category = "Category";
            public const string UserID = "UserID";
            public const string CreatedOn = "CreatedOn";
            public const string ValidDate = "ValidDate";
            public const string Region = "Region";
            public const string Description = "Description";
            public const string WholesaleDes = "WholesaleDes";
            public const string ShipDes = "ShipDes";
            public const string Volatility = "Volatility";
            public const string GrainSize = "GrainSize";
            public const string AshContent = "AshContent";
            public const string SurfurContent = "SurfurContent";
            public const string WaterContent = "WaterContent";
            public const string CalorificPower = "CalorificPower";
        }

        public SupplyEntity()
        {
            sqlHelper = new SqlHelper(DBName);
        }

        #region CUD Method

        public void Add()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Functions(");
            strSql.Append("name,description,url)");
            strSql.Append(" values (");
            strSql.Append("@name,@description,@url)");

            SqlParameter[] parameters = {
				new SqlParameter("@name",SqlDbType.VarChar),
				new SqlParameter("@description",SqlDbType.VarChar),
				new SqlParameter("@url",SqlDbType.VarChar),
				};

            parameters[0].Value = this.AshContent;
            parameters[1].Value = this.Description;
            parameters[2].Value = this.CalorificPower;

            sqlHelper.ExecuteSql(strSql.ToString(), parameters);
        }

        #endregion CUD Method


        #region paging methods

        /// <summary>
        /// 获取分页记录总数
        /// </summary>
        /// <param name="where">条件，等同于GetPaer()方法的where</param>
        /// <returns>返回记录总数</returns>
        public int GetPagerRowsCount(string where, SqlParameter[] paramters)
        {
            string sql = "select count(*) from Supply ";
            if (!string.IsNullOrEmpty(where))
            {
                sql += "where " + where;
            }

            object obj = sqlHelper.GetSingle(sql, paramters);

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
        public DataTable GetPager(string where, string orderBy, int pageSize, int pageNumber, SqlParameter[] paramters)
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

            return sqlHelper.ExecuteDateSet(sql, paramters).Tables[0];
        }

        #endregion
    }
}
