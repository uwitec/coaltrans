using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using System.Reflection;
using System.Text;
using Coal.DAL;

namespace Coal.DAL
{
    [Serializable]
    public partial class DemandInfoEntity
    {
        private SqlHelper sqlHelper;

        #region const fields
        public const string DBName = "cheese";
        public const string TableName = "DemandInfo";
        public const string PrimaryKey = "PK_DemandInfo";
        #endregion

        #region columns
        public struct Columns
        {
            public const string ID = "ID";
            public const string UserId = "UserId";
            public const string DemandTitle = "DemandTitle";
            public const string InfoIndate = "InfoIndate";
            public const string CoalType = "CoalType";
            public const string Granularity = "Granularity";
            public const string DemandQuantity = "DemandQuantity";
            public const string DeliveryPlace = "DeliveryPlace";
            public const string CalorificPower = "CalorificPower";
            public const string Volatilize = "Volatilize";
            public const string Ash = "Ash";
            public const string Sulphur = "Sulphur";
            public const string Water = "Water";
            public const string HotStability = "HotStability";
            public const string AshFusing = "AshFusing";
            public const string Wearproof = "Wearproof";
            public const string Carbon = "Carbon";
            public const string MaStrength = "MaStrength";
            public const string BinderMark = "BinderMark";
            public const string IsTransport = "IsTransport";
            public const string TransportPrice = "TransportPrice";
            public const string EstimateStyle = "EstimateStyle";
            public const string CreateTime = "CreateTime";
            public const string IsAudit = "IsAudit";
            public const string Sequence = "Sequence";
        }
        #endregion

        #region constructors
        public DemandInfoEntity()
        {
            sqlHelper = new SqlHelper(DBName);
        }

        public DemandInfoEntity(int id, int userid, string demandtitle, DateTime infoindate, string coaltype, string granularity, string demandquantity, string deliveryplace, string calorificpower, string volatilize, string ash, string sulphur, string water, string hotstability, string ashfusing, string wearproof, string carbon, string mastrength, string bindermark, int istransport, string transportprice, string estimatestyle, DateTime createtime, int isaudit, int sequence)
        {
            this.ID = id;

            this.UserId = userid;

            this.DemandTitle = demandtitle;

            this.InfoIndate = infoindate;

            this.CoalType = coaltype;

            this.Granularity = granularity;

            this.DemandQuantity = demandquantity;

            this.DeliveryPlace = deliveryplace;

            this.CalorificPower = calorificpower;

            this.Volatilize = volatilize;

            this.Ash = ash;

            this.Sulphur = sulphur;

            this.Water = water;

            this.HotStability = hotstability;

            this.AshFusing = ashfusing;

            this.Wearproof = wearproof;

            this.Carbon = carbon;

            this.MaStrength = mastrength;

            this.BinderMark = bindermark;

            this.IsTransport = istransport;

            this.TransportPrice = transportprice;

            this.EstimateStyle = estimatestyle;

            this.CreateTime = createtime;

            this.IsAudit = isaudit;

            this.Sequence = sequence;

        }
        #endregion

        #region Properties
        /// <summary>
        /// 主键
        /// </summary>
        public int? ID
        {
            get;
            set;
        }

        /// <summary>
        /// 公司的ID号
        /// </summary>
        public int? UserId
        {
            get;
            set;
        }

        /// <summary>
        /// 求购标题
        /// </summary>
        public string DemandTitle
        {
            get;
            set;
        }

        /// <summary>
        /// 信息有效期限
        /// </summary>
        public DateTime? InfoIndate
        {
            get;
            set;
        }

        /// <summary>
        /// 煤炭种类
        /// </summary>
        public string CoalType
        {
            get;
            set;
        }

        /// <summary>
        /// 煤炭粒度
        /// </summary>
        public string Granularity
        {
            get;
            set;
        }

        /// <summary>
        /// 需求量（以吨为单位）
        /// </summary>
        public string DemandQuantity
        {
            get;
            set;
        }

        /// <summary>
        /// 交货地点（如：111&112）
        /// </summary>
        public string DeliveryPlace
        {
            get;
            set;
        }

        /// <summary>
        /// 发热量
        /// </summary>
        public string CalorificPower
        {
            get;
            set;
        }

        /// <summary>
        /// 挥发百分比
        /// </summary>
        public string Volatilize
        {
            get;
            set;
        }

        /// <summary>
        /// 灰分
        /// </summary>
        public string Ash
        {
            get;
            set;
        }

        /// <summary>
        /// 硫份
        /// </summary>
        public string Sulphur
        {
            get;
            set;
        }

        /// <summary>
        /// 水分
        /// </summary>
        public string Water
        {
            get;
            set;
        }

        /// <summary>
        /// 热稳定性
        /// </summary>
        public string HotStability
        {
            get;
            set;
        }

        /// <summary>
        /// 灰熔融性
        /// </summary>
        public string AshFusing
        {
            get;
            set;
        }

        /// <summary>
        /// 耐磨性
        /// </summary>
        public string Wearproof
        {
            get;
            set;
        }

        /// <summary>
        /// 固定碳含量
        /// </summary>
        public string Carbon
        {
            get;
            set;
        }

        /// <summary>
        /// 机械强度
        /// </summary>
        public string MaStrength
        {
            get;
            set;
        }

        /// <summary>
        /// 粘结指数
        /// </summary>
        public string BinderMark
        {
            get;
            set;
        }

        /// <summary>
        /// 是否运输
        /// </summary>
        public int? IsTransport
        {
            get;
            set;
        }

        /// <summary>
        /// 运输费用
        /// </summary>
        public string TransportPrice
        {
            get;
            set;
        }

        /// <summary>
        /// 结算方式
        /// </summary>
        public string EstimateStyle
        {
            get;
            set;
        }

        /// <summary>
        /// 发布时间
        /// </summary>
        public DateTime? CreateTime
        {
            get;
            set;
        }

        /// <summary>
        /// 是否审核（0：否，1：是）
        /// </summary>
        public int? IsAudit
        {
            get;
            set;
        }

        /// <summary>
        /// 竞价排名
        /// </summary>
        public int? Sequence
        {
            get;
            set;
        }

        #endregion

        public class DemandInfoDAO : SqlDAO<DemandInfoEntity>
        {
            private SqlHelper sqlHelper;
            public const string DBName = "cheese";

            public DemandInfoDAO()
            {
                sqlHelper = new SqlHelper(DBName);
            }

            public override void Add(DemandInfoEntity entity)
            {

                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into DemandInfo(");
                strSql.Append("UserId,DemandTitle,InfoIndate,CoalType,Granularity,DemandQuantity,DeliveryPlace,CalorificPower,Volatilize,Ash,Sulphur,Water,HotStability,AshFusing,Wearproof,Carbon,MaStrength,BinderMark,IsTransport,TransportPrice,EstimateStyle,CreateTime,IsAudit,Sequence)");
                strSql.Append(" values (");
                strSql.Append("@UserId,@DemandTitle,@InfoIndate,@CoalType,@Granularity,@DemandQuantity,@DeliveryPlace,@CalorificPower,@Volatilize,@Ash,@Sulphur,@Water,@HotStability,@AshFusing,@Wearproof,@Carbon,@MaStrength,@BinderMark,@IsTransport,@TransportPrice,@EstimateStyle,@CreateTime,@IsAudit,@Sequence)");
                SqlParameter[] parameters = {
					new SqlParameter("@UserId",SqlDbType.Int),
					new SqlParameter("@DemandTitle",SqlDbType.NVarChar),
					new SqlParameter("@InfoIndate",SqlDbType.DateTime),
					new SqlParameter("@CoalType",SqlDbType.NVarChar),
					new SqlParameter("@Granularity",SqlDbType.NVarChar),
					new SqlParameter("@DemandQuantity",SqlDbType.NVarChar),
					new SqlParameter("@DeliveryPlace",SqlDbType.NVarChar),
					new SqlParameter("@CalorificPower",SqlDbType.NVarChar),
					new SqlParameter("@Volatilize",SqlDbType.NVarChar),
					new SqlParameter("@Ash",SqlDbType.NVarChar),
					new SqlParameter("@Sulphur",SqlDbType.NVarChar),
					new SqlParameter("@Water",SqlDbType.NVarChar),
					new SqlParameter("@HotStability",SqlDbType.NVarChar),
					new SqlParameter("@AshFusing",SqlDbType.NVarChar),
					new SqlParameter("@Wearproof",SqlDbType.NVarChar),
					new SqlParameter("@Carbon",SqlDbType.NVarChar),
					new SqlParameter("@MaStrength",SqlDbType.NVarChar),
					new SqlParameter("@BinderMark",SqlDbType.NVarChar),
					new SqlParameter("@IsTransport",SqlDbType.Int),
					new SqlParameter("@TransportPrice",SqlDbType.NVarChar),
					new SqlParameter("@EstimateStyle",SqlDbType.NVarChar),
					new SqlParameter("@CreateTime",SqlDbType.DateTime),
					new SqlParameter("@IsAudit",SqlDbType.Int),
					new SqlParameter("@Sequence",SqlDbType.Int)
					};
                parameters[0].Value = entity.UserId;
                parameters[1].Value = entity.DemandTitle;
                parameters[2].Value = entity.InfoIndate;
                parameters[3].Value = entity.CoalType;
                parameters[4].Value = entity.Granularity;
                parameters[5].Value = entity.DemandQuantity;
                parameters[6].Value = entity.DeliveryPlace;
                parameters[7].Value = entity.CalorificPower;
                parameters[8].Value = entity.Volatilize;
                parameters[9].Value = entity.Ash;
                parameters[10].Value = entity.Sulphur;
                parameters[11].Value = entity.Water;
                parameters[12].Value = entity.HotStability;
                parameters[13].Value = entity.AshFusing;
                parameters[14].Value = entity.Wearproof;
                parameters[15].Value = entity.Carbon;
                parameters[16].Value = entity.MaStrength;
                parameters[17].Value = entity.BinderMark;
                parameters[18].Value = entity.IsTransport;
                parameters[19].Value = entity.TransportPrice;
                parameters[20].Value = entity.EstimateStyle;
                parameters[21].Value = entity.CreateTime;
                parameters[22].Value = entity.IsAudit;
                parameters[23].Value = entity.Sequence;

                sqlHelper.ExecuteSql(strSql.ToString(), parameters);
            }

            public override void Update(DemandInfoEntity entity)
            {

                StringBuilder strSql = new StringBuilder();
                strSql.Append("update DemandInfo set ");
                strSql.Append("UserId=@UserId,");
                strSql.Append("DemandTitle=@DemandTitle,");
                strSql.Append("InfoIndate=@InfoIndate,");
                strSql.Append("CoalType=@CoalType,");
                strSql.Append("Granularity=@Granularity,");
                strSql.Append("DemandQuantity=@DemandQuantity,");
                strSql.Append("DeliveryPlace=@DeliveryPlace,");
                strSql.Append("CalorificPower=@CalorificPower,");
                strSql.Append("Volatilize=@Volatilize,");
                strSql.Append("Ash=@Ash,");
                strSql.Append("Sulphur=@Sulphur,");
                strSql.Append("Water=@Water,");
                strSql.Append("HotStability=@HotStability,");
                strSql.Append("AshFusing=@AshFusing,");
                strSql.Append("Wearproof=@Wearproof,");
                strSql.Append("Carbon=@Carbon,");
                strSql.Append("MaStrength=@MaStrength,");
                strSql.Append("BinderMark=@BinderMark,");
                strSql.Append("IsTransport=@IsTransport,");
                strSql.Append("TransportPrice=@TransportPrice,");
                strSql.Append("EstimateStyle=@EstimateStyle,");
                strSql.Append("CreateTime=@CreateTime,");
                strSql.Append("IsAudit=@IsAudit,");
                strSql.Append("Sequence=@Sequence");

                strSql.Append(" where ID=@ID");
                SqlParameter[] parameters = {
					new SqlParameter("@ID",SqlDbType.Int),
					new SqlParameter("@UserId",SqlDbType.Int),
					new SqlParameter("@DemandTitle",SqlDbType.NVarChar),
					new SqlParameter("@InfoIndate",SqlDbType.DateTime),
					new SqlParameter("@CoalType",SqlDbType.NVarChar),
					new SqlParameter("@Granularity",SqlDbType.NVarChar),
					new SqlParameter("@DemandQuantity",SqlDbType.NVarChar),
					new SqlParameter("@DeliveryPlace",SqlDbType.NVarChar),
					new SqlParameter("@CalorificPower",SqlDbType.NVarChar),
					new SqlParameter("@Volatilize",SqlDbType.NVarChar),
					new SqlParameter("@Ash",SqlDbType.NVarChar),
					new SqlParameter("@Sulphur",SqlDbType.NVarChar),
					new SqlParameter("@Water",SqlDbType.NVarChar),
					new SqlParameter("@HotStability",SqlDbType.NVarChar),
					new SqlParameter("@AshFusing",SqlDbType.NVarChar),
					new SqlParameter("@Wearproof",SqlDbType.NVarChar),
					new SqlParameter("@Carbon",SqlDbType.NVarChar),
					new SqlParameter("@MaStrength",SqlDbType.NVarChar),
					new SqlParameter("@BinderMark",SqlDbType.NVarChar),
					new SqlParameter("@IsTransport",SqlDbType.Int),
					new SqlParameter("@TransportPrice",SqlDbType.NVarChar),
					new SqlParameter("@EstimateStyle",SqlDbType.NVarChar),
					new SqlParameter("@CreateTime",SqlDbType.DateTime),
					new SqlParameter("@IsAudit",SqlDbType.Int),
					new SqlParameter("@Sequence",SqlDbType.Int)
					};
                parameters[0].Value = entity.ID;
                parameters[1].Value = entity.UserId;
                parameters[2].Value = entity.DemandTitle;
                parameters[3].Value = entity.InfoIndate;
                parameters[4].Value = entity.CoalType;
                parameters[5].Value = entity.Granularity;
                parameters[6].Value = entity.DemandQuantity;
                parameters[7].Value = entity.DeliveryPlace;
                parameters[8].Value = entity.CalorificPower;
                parameters[9].Value = entity.Volatilize;
                parameters[10].Value = entity.Ash;
                parameters[11].Value = entity.Sulphur;
                parameters[12].Value = entity.Water;
                parameters[13].Value = entity.HotStability;
                parameters[14].Value = entity.AshFusing;
                parameters[15].Value = entity.Wearproof;
                parameters[16].Value = entity.Carbon;
                parameters[17].Value = entity.MaStrength;
                parameters[18].Value = entity.BinderMark;
                parameters[19].Value = entity.IsTransport;
                parameters[20].Value = entity.TransportPrice;
                parameters[21].Value = entity.EstimateStyle;
                parameters[22].Value = entity.CreateTime;
                parameters[23].Value = entity.IsAudit;
                parameters[24].Value = entity.Sequence;

                sqlHelper.ExecuteSql(strSql.ToString(), parameters);
            }

            public bool UpdateSet(int ID, string ColumnName, string Value)
            {
                try
                {
                    StringBuilder StrSql = new StringBuilder();
                    StrSql.Append("update DemandInfo set ");
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

            public override void Delete(DemandInfoEntity entity)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("delete from DemandInfo ");
                strSql.Append(" where ID=@primaryKeyId");
                SqlParameter[] parameters = {
						new SqlParameter("@primaryKeyId", SqlDbType.Int)
					};
                parameters[0].Value = entity.ID;
                sqlHelper.ExecuteSql(strSql.ToString(), parameters);
            }

            public bool Delete(int ID)
            {
                string strSql = "delete from DemandInfo where ID=" + ID;
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

            public override DemandInfoEntity FindById(long primaryKeyId)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select * from DemandInfo ");
                strSql.Append(" where ID=@primaryKeyId");
                SqlParameter[] parameters = {
						new SqlParameter("@primaryKeyId", SqlDbType.Int)};
                parameters[0].Value = primaryKeyId;
                DataSet ds = sqlHelper.ExecuteDateSet(strSql.ToString(), parameters);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count == 1)
                {
                    DataRow row = ds.Tables[0].Rows[0];
                    DemandInfoEntity entity = new DemandInfoEntity();
                    if (!Convert.IsDBNull(row["ID"]))
                    {
                        entity.ID = (int)row["ID"];
                    }
                    if (!Convert.IsDBNull(row["UserId"]))
                    {
                        entity.UserId = (int)row["UserId"];
                    }
                    entity.DemandTitle = row["DemandTitle"].ToString();
                    if (!Convert.IsDBNull(row["InfoIndate"]))
                    {
                        entity.InfoIndate = (DateTime)row["InfoIndate"];
                    }
                    entity.CoalType = row["CoalType"].ToString();
                    entity.Granularity = row["Granularity"].ToString();
                    entity.DemandQuantity = row["DemandQuantity"].ToString();
                    entity.DeliveryPlace = row["DeliveryPlace"].ToString();
                    entity.CalorificPower = row["CalorificPower"].ToString();
                    entity.Volatilize = row["Volatilize"].ToString();
                    entity.Ash = row["Ash"].ToString();
                    entity.Sulphur = row["Sulphur"].ToString();
                    entity.Water = row["Water"].ToString();
                    entity.HotStability = row["HotStability"].ToString();
                    entity.AshFusing = row["AshFusing"].ToString();
                    entity.Wearproof = row["Wearproof"].ToString();
                    entity.Carbon = row["Carbon"].ToString();
                    entity.MaStrength = row["MaStrength"].ToString();
                    entity.BinderMark = row["BinderMark"].ToString();
                    if (!Convert.IsDBNull(row["IsTransport"]))
                    {
                        entity.IsTransport = (int)row["IsTransport"];
                    }
                    entity.TransportPrice = row["TransportPrice"].ToString();
                    entity.EstimateStyle = row["EstimateStyle"].ToString();
                    if (!Convert.IsDBNull(row["CreateTime"]))
                    {
                        entity.CreateTime = (DateTime)row["CreateTime"];
                    }
                    if (!Convert.IsDBNull(row["IsAudit"]))
                    {
                        entity.IsAudit = (int)row["IsAudit"];
                    }
                    if (!Convert.IsDBNull(row["Sequence"]))
                    {
                        entity.Sequence = (int)row["Sequence"];
                    }
                    return entity;
                }
                else
                {
                    return null;
                }
            }

            public override List<DemandInfoEntity> Find(string strWhere, SqlParameter[] parameters)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select *");
                strSql.Append(" FROM DemandInfo(nolock) ");
                if (strWhere.Trim() != "")
                {
                    strSql.Append(" where " + strWhere);
                }

                DataSet ds = sqlHelper.ExecuteDateSet(strSql.ToString(), parameters);
                if (ds != null && ds.Tables.Count > 0)
                {
                    List<DemandInfoEntity> list = new List<DemandInfoEntity>();
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        DemandInfoEntity entity = new DemandInfoEntity();
                        if (!Convert.IsDBNull(row["ID"]))
                        {
                            entity.ID = (int)row["ID"];
                        }
                        if (!Convert.IsDBNull(row["UserId"]))
                        {
                            entity.UserId = (int)row["UserId"];
                        }
                        entity.DemandTitle = row["DemandTitle"].ToString();
                        if (!Convert.IsDBNull(row["InfoIndate"]))
                        {
                            entity.InfoIndate = (DateTime)row["InfoIndate"];
                        }
                        entity.CoalType = row["CoalType"].ToString();
                        entity.Granularity = row["Granularity"].ToString();
                        entity.DemandQuantity = row["DemandQuantity"].ToString();
                        entity.DeliveryPlace = row["DeliveryPlace"].ToString();
                        entity.CalorificPower = row["CalorificPower"].ToString();
                        entity.Volatilize = row["Volatilize"].ToString();
                        entity.Ash = row["Ash"].ToString();
                        entity.Sulphur = row["Sulphur"].ToString();
                        entity.Water = row["Water"].ToString();
                        entity.HotStability = row["HotStability"].ToString();
                        entity.AshFusing = row["AshFusing"].ToString();
                        entity.Wearproof = row["Wearproof"].ToString();
                        entity.Carbon = row["Carbon"].ToString();
                        entity.MaStrength = row["MaStrength"].ToString();
                        entity.BinderMark = row["BinderMark"].ToString();
                        if (!Convert.IsDBNull(row["IsTransport"]))
                        {
                            entity.IsTransport = (int)row["IsTransport"];
                        }
                        entity.TransportPrice = row["TransportPrice"].ToString();
                        entity.EstimateStyle = row["EstimateStyle"].ToString();
                        if (!Convert.IsDBNull(row["CreateTime"]))
                        {
                            entity.CreateTime = (DateTime)row["CreateTime"];
                        }
                        if (!Convert.IsDBNull(row["IsAudit"]))
                        {
                            entity.IsAudit = (int)row["IsAudit"];
                        }
                        if (!Convert.IsDBNull(row["Sequence"]))
                        {
                            entity.Sequence = (int)row["Sequence"];
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
                strSql.Append(" FROM DemandInfo(nolock)");
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
                string sql = "select count(*) from DemandInfo ";
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

                sql += " AS RowNumber,* FROM DemandInfo";

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

