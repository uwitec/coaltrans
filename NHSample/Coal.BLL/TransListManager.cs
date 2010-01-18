using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Coal.DAL;
using System.Data;
using System.Data.SqlClient;
using Coal.Entity;
using Coal.AOP;

namespace Coal.BLL
{
    public class TransListManager
    {
        public DataTable GetList(string where, SqlParameter[] paramters, int pageSize, int pageIndex, ref int rowCount)
        {
            CoalTransEntity.CoalTransDAO transDao = new CoalTransEntity.CoalTransDAO();
            rowCount = transDao.GetPagerRowsCount(where, paramters);
            return transDao.GetPager(where, paramters, string.Empty, pageSize, pageIndex);
        }

        public DataTable GetDemandList(string where, SqlParameter[] paramters, int pageSize, int pageIndex, ref int rowCount)
        {
            DemandInfoEntity.DemandInfoDAO transDao = new DemandInfoEntity.DemandInfoDAO();
            rowCount = transDao.GetPagerRowsCount(where, paramters);
            return transDao.GetPager(where, paramters, string.Empty, pageSize, pageIndex);
        }


        public DataTable GetLastestList(string where, int topNum, string orderField, SqlParameter[] paramters)
        {
            CoalTransEntity.CoalTransDAO transDao = new CoalTransEntity.CoalTransDAO();
            DataSet ds = transDao.GetDataSet(where, topNum, orderField, paramters);

            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            else
            {
                return null;
            }
        }

        [Permission]
        public bool GetDetails(long id, string userEmail, ref CoalTransEntity entity)
        {
            CoalTransEntity.CoalTransDAO transDao = new CoalTransEntity.CoalTransDAO();
            entity = transDao.FindById(id);
            if (entity != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
