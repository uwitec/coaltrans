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
    public class DemandInfoEntity
    {
        

        #region propertiese
        /// <summary>
        /// 主键
        /// </summary>
        public int? ID
        {
            get;
            set;
        }
        /// <summary>
        /// 公司ID
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
        public DateTime InfoIndate
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
        /// 需求量
        /// </summary>
        public string DemandQuantity
        {
            get;
            set;
        }
        /// <summary>
        /// 交货地点
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
        /// 固碳含量
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
        /// 是否要卖家提供运输
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
        /// 结算方法
        /// </summary>
        public string EstimateStyle
        {
            get;
            set;
        }
        /// <summary>
        /// 发布时间
        /// </summary>
        public DateTime CreateTime
        {
            get;
            set;
        }
        /// <summary>
        /// 是否审核
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
        #region method
        public partial class DemandInfoDao : SqlDAO<DemandInfoEntity>
        {
            private SqlHelper sqlHelp;
            public const string DBName = "cheese";

            public DemandInfoDao()
            {
                sqlHelp = new SqlHelper(DBName);
            }

            public override void Add(DemandInfoEntity entity)
            {
                StringBuilder StrSql = new StringBuilder();
                StrSql.Append("Insert into DemandInfo(");
                StrSql.Append("UserId,DemandTitle,InfoIndate,CoalType,Granularity,DemandQuantity,DeliveryPlace,CalorificPower,");
                StrSql.Append("Volatilize,Ash,Sulphur,Water,HotStability,AshFusing,Wearproof,Carbon,MaStrength,BinderMark,");
                StrSql.Append("IsTransport,TransportPrice,EstimateStyle,CreateTime,IsAudit,Sequence)");
                StrSql.Append(" values (");
                StrSql.Append("@UserId,@DemandTitle,@InfoIndate,@CoalType,@Granularity,@DemandQuantity,@DeliveryPlace,@CalorificPower,");
                StrSql.Append("@Volatilize,@Ash,@Sulphur,@Water,@HotStability,@AshFusing,@Wearproof,@Carbon,@MaStrength,@BinderMark,");
                StrSql.Append("@IsTransport,@TransportPrice,@EstimateStyle,@CreateTime,@IsAudit,@Sequence)");
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
                    new SqlParameter("@Water",SqlDbType.NVarChar),
                    new SqlParameter("@HotStability",SqlDbType.NVarChar),
                    new SqlParameter("@AshFusing",SqlDbType.NVarChar),
                    new SqlParameter("@Wearproof",SqlDbType.NVarChar),
                    new SqlParameter("@Carbon",SqlDbType.NVarChar),
                    new SqlParameter("@MaStrength",SqlDbType.NVarChar),
                    new SqlParameter("@BinderMark",SqlDbType.NVarChar),
                    new SqlParameter("@IsTransport",SqlDbType.NVarChar),
                    new SqlParameter("@TransportPrice",SqlDbType.NVarChar),
                    new SqlParameter("@EstimateStyle",SqlDbType.NVarChar),
                    new SqlParameter("@CreateTime",SqlDbType.DateTime),
                    new SqlParameter("@IsAudit",SqlDbType.Int),
                    new SqlParameter("@Sequence",SqlDbType.Int),
                    new SqlParameter("@Sulphur",SqlDbType.NVarChar)
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
                parameters[10].Value = entity.Water;
                parameters[11].Value = entity.HotStability;
                parameters[12].Value = entity.AshFusing;
                parameters[13].Value = entity.Wearproof;
                parameters[14].Value = entity.Carbon;
                parameters[15].Value = entity.MaStrength;
                parameters[16].Value = entity.BinderMark;
                parameters[17].Value = entity.IsTransport;
                parameters[18].Value = entity.TransportPrice;
                parameters[19].Value = entity.EstimateStyle;
                parameters[20].Value = entity.CreateTime;
                parameters[21].Value = entity.IsAudit;
                parameters[22].Value = entity.Sequence;
                parameters[23].Value = entity.Sulphur;
                sqlHelp.ExecuteSql(StrSql.ToString(), parameters);
            }
        }
        #endregion
    }
}
