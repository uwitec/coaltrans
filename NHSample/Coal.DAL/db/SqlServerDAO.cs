using System.Data;
using System.Data.SqlClient;

using Coal.Util;

namespace Coal.DAL
{
    public class SqlServerDAO : DAO
    {
        public override IDbConnection CreateConnection()
        {
            return new SqlConnection();
        }

        #region parameter type
        protected override IDbDataParameter String
        {
            get { return new SqlParameter(string.Empty, SqlDbType.VarChar); }
        }
        protected override IDbDataParameter TinyInt
        {
            get { return new SqlParameter(string.Empty, SqlDbType.TinyInt); }
        }
        protected override IDbDataParameter SmallInt
        {
            get { return new SqlParameter(string.Empty, SqlDbType.SmallInt); }
        }
        protected override IDbDataParameter Int
        {
            get { return new SqlParameter(string.Empty, SqlDbType.Int); }
        }
        protected override IDbDataParameter BigInt
        {
            get { return new SqlParameter(string.Empty, SqlDbType.BigInt); }
        }
        protected override IDbDataParameter Float
        {
            get { return new SqlParameter(string.Empty, SqlDbType.Float); }
        }
        protected override IDbDataParameter DateTime
        {
            get { return new SqlParameter(string.Empty, SqlDbType.DateTime); }
        }
        protected override IDbDataParameter Bool
        {
            get { return new SqlParameter(string.Empty, SqlDbType.Bit); }
        }
        protected override IDbDataParameter Text
        {
            get { return new SqlParameter(string.Empty, SqlDbType.Text); }
        }
        protected override IDbDataParameter Image
        {
            get { return new SqlParameter(string.Empty, SqlDbType.Image); }
        }
        protected override IDbDataParameter GUID
        {
            get { return new SqlParameter(string.Empty, SqlDbType.UniqueIdentifier); }
        }
        #endregion 

    }
}
