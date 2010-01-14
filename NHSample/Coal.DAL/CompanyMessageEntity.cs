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
    public partial class CompanyMessageEntity
    {
        private SqlHelper SqlHelper;

        #region Const Fields            
        public const string DBName = "Coal";
        public const string TableName = "CompanyMessage";
        public const string PrimaryKey = "PK_CompanyMessage";
        #endregion

        #region columns
        public struct Columns
        {
            public const string ID = "ID";
            public const string Sender = "Sender";
            public const string embracer = "embracer";
            public const string MessageTitle = "MessageTitle";
            public const string MessageContent = "MessageContent";
            public const string ParentId = "ParentId";
            public const string IsSee = "IsSee";
        }
        #endregion

        #region constructors
        public CompanyMessageEntity()
        {
            SqlHelper = new SqlHelper(DBName);
        }

        public CompanyMessageEntity(int id, int Sender, int embracer, string MessageTitle, string MessageContent, int ParentId, int IsSee)
        {
            this.ID = id;
            this.Sender = Sender;
            this.embracer = embracer;
            this.MessageTitle = MessageTitle;
            this.MessageContent = MessageContent;
            this.ParentId = ParentId;
            this.IsSee = IsSee;
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
        /// 留言者ID
        /// </summary>
        public int? Sender
        {
            get;
            set;
        }
        /// <summary>
        /// 接受者ID
        /// </summary>
        public int? embracer
        {
            get;
            set;
        }
        /// <summary>
        /// 标题
        /// </summary>
        public string MessageTitle
        {
            get;
            set;
        }
        /// <summary>
        /// 留言内容
        /// </summary>
        public string MessageContent
        {
            get;
            set;
        }
        /// <summary>
        /// 留言父级ID
        /// </summary>
        public int? ParentId
        {
            get;
            set;
        }
        /// <summary>
        /// 是否查看
        /// </summary>
        public int? IsSee
        {
            get;
            set;
        }
        #endregion
        #region CRUD Method
        public class CompanyMessageInfoDao : SqlDAO<CompanyMessageEntity>
        {
            private SqlHelper sqlHelper;
            public const string DBName = "cheese";

            public CompanyMessageInfoDao()
            {
                sqlHelper = new SqlHelper(DBName);
            }

            public override void Add(CompanyMessageEntity entity)
            {
                StringBuilder StrSql = new StringBuilder();
                StrSql.Append("Insert into CompanyMessage(");
                StrSql.Append("Sender,embracer,MessageTitle,MessageContent,ParentId,IsSee)");
                StrSql.Append("Values (");
                StrSql.Append("@Sender,@embracer,@MessageTitle,@MessageContent,@ParentId,@IsSee)");
                SqlParameter[] Parameters = 
                { 
                    new SqlParameter("@Sender",SqlDbType.Int),
                    new SqlParameter("@embracer",SqlDbType.Int),
                    new SqlParameter("@MessageTitle",SqlDbType.NVarChar),
                    new SqlParameter("@MessageContent",SqlDbType.NVarChar),
                    new SqlParameter("@ParentId",SqlDbType.Int),
                    new SqlParameter("@IsSee",SqlDbType.Int)
                                            };
                Parameters[0].Value = entity.Sender;
                Parameters[1].Value = entity.embracer;
                Parameters[2].Value = entity.MessageTitle;
                Parameters[3].Value = entity.MessageContent;
                Parameters[4].Value = entity.ParentId;
                Parameters[5].Value = entity.IsSee;

                sqlHelper.ExecuteSql(StrSql.ToString(), Parameters);
            }

            public override object FindByWhere(string StrWhere)
            {
                StringBuilder StrSql = new StringBuilder();
                StrSql.Append("Select count(*) from CompanyMessage");                
                StrSql.Append(StrWhere);

                return sqlHelper.GetSingle(StrSql.ToString(), null);
            }

            public override List<CompanyMessageEntity> Find(string strWhere, SqlParameter[] parameters)
            {
                StringBuilder StrSql = new StringBuilder();
                StrSql.Append("select * from CompanyMessage");
                if (strWhere.Trim() != "")
                {
                    StrSql.Append(" Where " + strWhere);
                }
                DataSet ds = sqlHelper.ExecuteDateSet(StrSql.ToString(), parameters);
                if (ds != null && ds.Tables.Count > 0)
                {
                    List<CompanyMessageEntity> list = new List<CompanyMessageEntity>();
                    foreach (DataRow Row in ds.Tables[0].Rows)
                    {
                        CompanyMessageEntity Entity = new CompanyMessageEntity();
                        if (!Convert.IsDBNull(Row["ID"]))
                        {
                            Entity.ID = (int)Row["ID"];
                        }
                        if (!Convert.IsDBNull(Row["Sender"]))
                        {
                            Entity.Sender = (int)Row["Sender"];
                        }
                        if (!Convert.IsDBNull(Row["embracer"]))
                        {
                            Entity.embracer = (int)Row["embracer"];
                        }
                        Entity.MessageTitle = Row["MessageTitle"].ToString();
                        Entity.MessageContent = Row["MessageContent"].ToString();
                        if (!Convert.IsDBNull(Row["ParentId"]))
                        {
                            Entity.ParentId = (int)Row["ParentId"];
                        }
                        if (!Convert.IsDBNull(Row["IsSee"]))
                        {
                            Entity.IsSee = (int)Row["IsSee"];
                        }
                        list.Add(Entity);
                    }
                    return list;
                }
                else
                {
                    return null;
                }
            }

            public DataTable GetMessageTable(string strWhere, SqlParameter[] parameters)
            {
                StringBuilder StrSql = new StringBuilder();
                StrSql.Append("select * from CompanyMessage");
                if (strWhere.Trim() != "")
                {
                    StrSql.Append(" Where " + strWhere);
                }
                DataSet ds = sqlHelper.ExecuteDateSet(StrSql.ToString(), parameters);
                DataTable dt = new DataTable();
                if (ds != null && ds.Tables.Count > 0)
                {
                    dt = ds.Tables[0];
                }
                return dt;
            }
        }
        #endregion
    }
}
