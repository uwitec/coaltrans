﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行库版本:2.0.50727.1433
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataEntity
{
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Data.SqlTypes;
    using System.Xml;
    using System.Reflection;
    
    
    public class ProvinceDataEntity : BaseEntity
    {
        
        public ProvinceDataEntity()
        {
        }
        
        private int m_ProID;
        
        public int ProID
        {
            get
            {
return this.m_ProID;
            }
            set
            {
this.m_ProID = value;
            }
        }
        
        private string m_ProName;
        
        public string ProName
        {
            get
            {
return this.m_ProName;
            }
            set
            {
this.m_ProName = value;
            }
        }
        
        private string m_Keys;
        
        public string Keys
        {
            get
            {
return this.m_Keys;
            }
            set
            {
this.m_Keys = value;
            }
        }
    }
}
