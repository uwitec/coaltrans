using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoalTrans.DAL;
using System.Data;
using System.Data.SqlClient;

namespace CoalTrans.BLL
{
    public class TransListManager
    {
        public DataTable GetList(string where, SqlParameter[] paramters, int pageSize, int pageIndex, ref int rowCount)
        {
            SupplyEntity supply = new SupplyEntity();
            rowCount = supply.GetPagerRowsCount(where, paramters);
            return supply.GetPager(where, string.Empty, pageSize, pageIndex, paramters);
        }
    }
}
