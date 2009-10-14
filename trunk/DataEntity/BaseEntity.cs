using System;
using System.Data;
using System.Xml;
using System.Reflection;
//using System.Collections.Generic;
using System.Text;

namespace DataEntity
{
	/// <summary>
	/// 数据实体层基类
	/// </summary>
	[Serializable]
	public abstract class BaseEntity
	{
		private bool m_IsEmpty = true;
		private int m_ReturnValue=0;

		public BaseEntity() { }

		public bool IsEmpty
		{
			get { return m_IsEmpty; }
			set { m_IsEmpty=value; }
		}

		public int ReturnValue
		{
			get { return m_ReturnValue; }
			set { m_ReturnValue=value; }
		}

		/// <summary>
		/// 初始化
		/// </summary>
		protected void InitMetaData()
		{
			foreach(PropertyInfo property in this.GetType().GetProperties())
			{									
				string typeString=property.PropertyType.ToString();
				switch(typeString)
				{				
					case "System.String":
						Console.WriteLine(property.Name);
						property.SetValue(this,"",null);
						break;	
					case "System.DateTime":
						property.SetValue(this,new DateTime(1900,1,1),null);
						break;		
				} 							
			}
		}

        /// <summary>
		/// 实体与数据表的相互转换
        /// </summary>
        #region MetaDataTable
        public DataTable MetaDataTable
		{
			get //将实体转化为数据表
			{ 				
				DataTable dt = this.GetDataTableSchema;
			
				// 添加新行,把公共属性和公共字段的值存储
				DataRow row = dt.NewRow();
				foreach(DataColumn column in dt.Columns)
				{
					string columnName = this.TransformFirstToUpper(column.ColumnName);
                    PropertyInfo property = this.GetType().GetProperty(columnName);
                    if (property != null)
                    {
                        if (column.DataType.ToString() != "System.Byte[]")
                            row[columnName] = property.GetValue(this, null);
                        else
                            row[columnName] = DBNull.Value;
                    }
				}				
				dt.Rows.Add(row);
				return dt;  //返回带一行数据的表DataTable
			}
            set //将数据表转换为实体 列如：obj.MetaDataTable = exec.ExecDataTable()
			{
				DataTable dtReceive = value;

				// 如果表格的行数为0，则表示该实体没有初始化，IsEmpty=true
                if (dtReceive == null || dtReceive.Rows.Count == 0)
                {
                    this.m_IsEmpty = true;
                    return;
                }
                else
                {
                    this.m_IsEmpty = false;
                }

				// 枚举实体类属性,把接受的datatable中的数据赋給根据类属性架构的datatable
                foreach (DataColumn column in dtReceive.Columns)
                {
                    string columnName = this.TransformFirstToUpper(column.ColumnName);
                    PropertyInfo property = this.GetType().GetProperty(columnName);
					if( property != null && dtReceive.Rows[0][columnName] != DBNull.Value)
					{
						if(property.PropertyType.Name=="DateTime"&&dtReceive.Rows[0][columnName].ToString()=="")
						{}
						else
							property.SetValue(this, dtReceive.Rows[0][columnName], null);
					}
				}				
			}
        }
        #endregion

        /// <summary>
        /// 将实体结构转化为表结构
        /// </summary>
        #region GetSchema
        public DataTable GetDataTableSchema
		{
			get
			{
				string tableName = this.GetType().Name;
				DataTable dt = new DataTable(tableName);
				// 架构表结构
				// 枚举公共属性-- public property	
                foreach (PropertyInfo propertyInfo in this.GetType().GetProperties())
				{
                    string typeString = propertyInfo.PropertyType.ToString();

					// 测试该属性的数据类型是否受本版本的支持
					if(this.IsSupportType(typeString) == true)
					{
                        dt.Columns.Add(propertyInfo.Name, Type.GetType(typeString));
                        dt.Columns[propertyInfo.Name].AllowDBNull = true;
					}								
				}
				return dt;
			}
        }

        /// <summary>
        /// 测试数据类型是否受此版本支持
        /// </summary>
        /// <param name="typeString">数据类型</param>
        /// <returns></returns>
        private bool IsSupportType(string typeString)
		{
			bool isSupport=false;
			switch(typeString)
			{
				case "System.Boolean":
					isSupport = true;
					break;
				case "System.Byte":
					isSupport = true;
					break;
				case "System.String":
					isSupport = true;
					break;
				case "System.Byte[]":
					isSupport = true;
					break;
				case "System.Char":
					isSupport = true;
					break;
				case "System.DateTime":
					isSupport = true;
					break;
				case "System.Decimal":
					isSupport = true;
					break;
                case "System.Single":
                    isSupport = true;
                    break;
				case "System.Int32":
					isSupport = true;
					break;
				case "System.Int64":
					isSupport = true;
					break;
				case "System.Int16":
					isSupport = true;
					break;							
			} 
			return isSupport;
        }
        #endregion

		public void WriteXmlData(string fileName)
		{
			DataSet ds=new DataSet("BaseEntitySet");
			DataTable dt=this.MetaDataTable;
			ds.Tables.Add(dt);
			ds.WriteXml(fileName,XmlWriteMode.WriteSchema);		
		}

		public XmlDocument XmlDom
		{
			get
			{
				DataSet ds=new DataSet("BaseEntitySet");
				DataTable dt=this.MetaDataTable;
				ds.Tables.Add(dt);

				XmlDocument doc=new XmlDocument();
				doc.LoadXml(ds.GetXml());
				return doc;
			}
		}

        /// <summary>
        /// 将指定字符串转换第一个字母为大写，
        /// 如果字符串只有两个字母，则都转换为大写
        /// </summary>
        /// <param name="text">要转换的字符串</param>
        /// <returns></returns>
        #region TransformFirstToUpper
        public string TransformFirstToUpper(string str)
        {
            string tmp = "";
            if (str.Length > 2)
                tmp = str.Substring(0, 1).ToUpper() + str.Substring(1);
            else
            {
                if (str.Length == 0)
                    tmp = str;
                else
                    tmp = str.ToUpper();
            }
            return tmp;
        }
        #endregion
	}
}
