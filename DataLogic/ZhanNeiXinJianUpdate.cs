﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行库版本:2.0.50727.1433
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataLogic
{
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Data.SqlTypes;
    using System.Xml;
    using System.Reflection;
    
    
    public class ZhanNeiXinJianUpdate : BaseExecute
    {
        
        private SqlParameter paraID;
        
        public int ID
        {
            get
            {
return (System.Int32)this.paraID.Value;
            }
            set
            {
this.paraID.Value = value;
            }
        }
        
        private SqlParameter paraToUserId;
        
        public int ToUserId
        {
            get
            {
return (System.Int32)this.paraToUserId.Value;
            }
            set
            {
this.paraToUserId.Value = value;
            }
        }
        
        private SqlParameter paraFromUserId;
        
        public int FromUserId
        {
            get
            {
return (System.Int32)this.paraFromUserId.Value;
            }
            set
            {
this.paraFromUserId.Value = value;
            }
        }
        
        private SqlParameter paraLiuYanNeiRong;
        
        public string LiuYanNeiRong
        {
            get
            {
return (System.String)this.paraLiuYanNeiRong.Value;
            }
            set
            {
this.paraLiuYanNeiRong.Value = value;
            }
        }
        
        private SqlParameter paraShiJian;
        
        public System.DateTime ShiJian
        {
            get
            {
return (System.DateTime)this.paraShiJian.Value;
            }
            set
            {
this.paraShiJian.Value = value;
            }
        }
        
        private SqlParameter paraIsRead;
        
        public bool IsRead
        {
            get
            {
return (System.Boolean)this.paraIsRead.Value;
            }
            set
            {
this.paraIsRead.Value = value;
            }
        }
        
        private SqlParameter paraIsDelete;
        
        public bool IsDelete
        {
            get
            {
return (System.Boolean)this.paraIsDelete.Value;
            }
            set
            {
this.paraIsDelete.Value = value;
            }
        }
        
        public ZhanNeiXinJianUpdate()
        {
base.InitCommand("ZhanNeiXinJianUpdate");
ConfigParameter();
        }
        
        #region 存储过程参数赋值
        public void ConfigParameter()
        {
//--------------------------------------------------------
this.paraID = new SqlParameter();
this.paraID.ParameterName = "@ID";
this.paraID.SqlDbType = SqlDbType.Int;
this.paraID.Size = 4;
this.paraID.Direction = ParameterDirection.Input;
this.paraID.Value=DBNull.Value;
base.m_cmd.Parameters.Add(this.paraID);
//--------------------------------------------------------
this.paraToUserId = new SqlParameter();
this.paraToUserId.ParameterName = "@ToUserId";
this.paraToUserId.SqlDbType = SqlDbType.Int;
this.paraToUserId.Size = 4;
this.paraToUserId.Direction = ParameterDirection.Input;
this.paraToUserId.Value=DBNull.Value;
base.m_cmd.Parameters.Add(this.paraToUserId);
//--------------------------------------------------------
this.paraFromUserId = new SqlParameter();
this.paraFromUserId.ParameterName = "@FromUserId";
this.paraFromUserId.SqlDbType = SqlDbType.Int;
this.paraFromUserId.Size = 4;
this.paraFromUserId.Direction = ParameterDirection.Input;
this.paraFromUserId.Value=DBNull.Value;
base.m_cmd.Parameters.Add(this.paraFromUserId);
//--------------------------------------------------------
this.paraLiuYanNeiRong = new SqlParameter();
this.paraLiuYanNeiRong.ParameterName = "@LiuYanNeiRong";
this.paraLiuYanNeiRong.SqlDbType = SqlDbType.NVarChar;
this.paraLiuYanNeiRong.Size = 100;
this.paraLiuYanNeiRong.Direction = ParameterDirection.Input;
this.paraLiuYanNeiRong.Value=DBNull.Value;
base.m_cmd.Parameters.Add(this.paraLiuYanNeiRong);
//--------------------------------------------------------
this.paraShiJian = new SqlParameter();
this.paraShiJian.ParameterName = "@ShiJian";
this.paraShiJian.SqlDbType = SqlDbType.DateTime;
this.paraShiJian.Size = 8;
this.paraShiJian.Direction = ParameterDirection.Input;
this.paraShiJian.Value=DBNull.Value;
base.m_cmd.Parameters.Add(this.paraShiJian);
//--------------------------------------------------------
this.paraIsRead = new SqlParameter();
this.paraIsRead.ParameterName = "@IsRead";
this.paraIsRead.SqlDbType = SqlDbType.Bit;
this.paraIsRead.Size = 1;
this.paraIsRead.Direction = ParameterDirection.Input;
this.paraIsRead.Value=DBNull.Value;
base.m_cmd.Parameters.Add(this.paraIsRead);
//--------------------------------------------------------
this.paraIsDelete = new SqlParameter();
this.paraIsDelete.ParameterName = "@IsDelete";
this.paraIsDelete.SqlDbType = SqlDbType.Bit;
this.paraIsDelete.Size = 1;
this.paraIsDelete.Direction = ParameterDirection.Input;
this.paraIsDelete.Value=DBNull.Value;
base.m_cmd.Parameters.Add(this.paraIsDelete);
        }
        #endregion
    }
}
