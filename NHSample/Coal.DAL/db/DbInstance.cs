using System;
using System.Data;
using System.Collections;
using Coal.Util;

namespace Coal.DAL
{
    public class DbInstance
    {
        private IDbCommand iCmd = null;
        private IDbTransaction iDbTran = null;

        protected virtual DAO DAO
        {
            get
            {
                return DAO.SQLSERVER;
            }
        }

        public DbInstance()
        {
            IDbConnection conn = this.DAO.CreateConnection();
            conn.ConnectionString = this.ConnectionString;
            this.iCmd = conn.CreateCommand();
        }

        public string CommandText
        {
            set
            {
                this.iCmd.Parameters.Clear();
                this.iCmd.CommandText = value;
            }
        }

        public CommandType CommandType
        {
            set
            {
                this.iCmd.CommandType = value;
            }
        }

        public bool Open()
        {
            if (!this.DAO.Open(this.iCmd))
            {
                this.iCmd.Connection.ConnectionString = this.CandidateConnString;
                return this.DAO.Open(this.iCmd);
            }

            return true;
        }

        public IDictionary ExecuteDictionary()
        {
            return this.DAO.ExecuteDictionary(this.iCmd);
        }

        public object ExecuteObject()
        {
            return this.DAO.ExecuteObject(this.iCmd);
        }

        public object ExecuteScalar()
        {
            return this.DAO.ExecuteScalar(this.iCmd);
        }

        
        public IList ExecuteScalarList()
        {
            return this.DAO.ExecuteScalarList(this.iCmd);
        }

        public DataTable ExecuteTable()
        {
            return this.DAO.ExecuteTable(this.iCmd);
        }

        public IList ExecuteList()
        {
            return this.DAO.ExecuteList(this.iCmd);
        }

        public DataTable ExecutePartTable(int page_index, int page_size)
        {
            return this.DAO.ExecutePartTable(this.iCmd, page_index, page_size);
        }

        public IList ExecutePartList(int page_index, int page_size)
        {
            return this.DAO.ExecutePartList(this.iCmd, page_index, page_size);
        }
               
        public void BeginTransaction()
        {
            this.iDbTran=this.iCmd.Transaction=this.iCmd.Connection.BeginTransaction();
        }

        public int ExecuteNonQuery()
        {
            if (this.iDbTran != null)
                return this.iCmd.ExecuteNonQuery();
            else
                return this.DAO.ExecuteNonQuery(this.iCmd);
        }
        
        public void Commit()
        {
            if (this.iDbTran != null)
                this.iDbTran.Commit();
        }

        public void Rollback()
        {
          if (this.iDbTran != null)
            this.iDbTran.Rollback();
        }

        public bool Close()
        {
            return this.DAO.Close(this.iCmd);
        }

        public virtual string ConnectionString
        {
            get{return this.GetConnectionString(0);}
        }

        public virtual string CandidateConnString
        {
            get { return this.ConnectionString; }
        }

        protected string GetConnectionString(string key)
        {
            //return AppContext.StrConnList[key];
            return ConfigUtility.GetConnectionString("CoalTrans");
        }

        private string GetConnectionString(int index)
        {
            //return AppContext.StrConnList.Values[index];
            return ConfigUtility.GetConnectionString("CoalTrans");
        }

        #region
        public void SetString(string para_name, object para_data)
        {
            this.DAO.SetString(this.iCmd, para_name, para_data);
        }
        public void SetOutputString(string para_name)
        {
            this.DAO.SetOutputString(this.iCmd, para_name);
        }
        public void SetText(string para_name, object para_data)
        {
            this.DAO.SetText(this.iCmd, para_name, para_data);
        }
        public void SetTinyInt(string para_name, object para_data)
        {
            this.DAO.SetTinyInt(this.iCmd, para_name, para_data);
        }
        public void SetSmallInt(string para_name, object para_data)
        {
            this.DAO.SetSmallInt(this.iCmd, para_name, para_data);
        }
        public void SetInt(string para_name, object para_data)
        {
            this.DAO.SetInt(this.iCmd, para_name, para_data);
        }
        public void SetOutputInt(string para_name)
        {
            this.DAO.SetOutputInt(this.iCmd, para_name);
        }
        public void SetBigInt(string para_name, object para_data)
        {
            this.DAO.SetBigInt(this.iCmd, para_name, para_data);
        }
        public void SetFloat(string para_name, object para_data)
        {
            this.DAO.SetFloat(this.iCmd, para_name, para_data);
        }
        public void SetDateTime(string para_name, object para_data)
        {
            this.DAO.SetDateTime(this.iCmd, para_name, para_data);
        }
        public void SetBool(string para_name, object para_data)
        {
            this.DAO.SetBool(this.iCmd, para_name, para_data);
        }
        public void SetImage(string para_name, object para_data)
        {
            this.DAO.SetImage(this.iCmd, para_name, para_data);
        }
        public void SetGUID(string para_name, object para_data)
        {
            this.DAO.SetGUID(this.iCmd, para_name, para_data);
        }
        #endregion 

        public object GetParameterValue(string para_name)
        {
            return this.DAO.GetParameterValue(this.iCmd, para_name);
        }

    }
}
