using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Coal.DAL;
using System.Data;
using System.Data.SqlClient;
using Coal.Entity;

namespace Coal.BLL
{
    public class TransListManager
    {
        public DataTable GetList(string where, SqlParameter[] paramters, int pageSize, int pageIndex, ref int rowCount)
        {
            SupplyEntity.SupplyEntityFinder finder = new SupplyEntity.SupplyEntityFinder();
            rowCount = finder.GetPagerRowsCount(where, paramters);
            return finder.GetPager(where, paramters, string.Empty, pageSize, pageIndex);
        }

        [Permission]
        public bool GetDetails(int id, ref SupplyEntity entity)
        {
            SupplyEntity.SupplyEntityFinder finder = new SupplyEntity.SupplyEntityFinder();
            entity = finder.FindById(id);
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
