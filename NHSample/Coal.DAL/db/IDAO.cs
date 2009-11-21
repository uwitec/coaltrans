using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Coal.DAL
{
    public interface IDAO<T>
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        T FindById(long id);
        List<T> Find(string strWhere, SqlParameter[] parameters);
        DataSet GetDataSet(string strWhere, SqlParameter[] parameters);
    }

    public class SqlDAO<T> : IDAO<T>
    {
        #region IDAO<T> Members

        public virtual void Add(T entity)
        {
            throw new NotImplementedException();
        }

        public virtual void Update(T entity)
        {
            throw new NotImplementedException();
        }

        public virtual void Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public virtual T FindById(long id)
        {
            throw new NotImplementedException();
        }

        public virtual List<T> Find(string strWhere, SqlParameter[] parameters)
        {
            throw new NotImplementedException();
        }

        public virtual DataSet GetDataSet(string strWhere, SqlParameter[] parameters)
        {
            throw new NotImplementedException();
        }

        #endregion
    }

}
