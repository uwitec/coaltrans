using System;
using System.Data;
using System.Text;
using System.Reflection;
using System.Collections;

using Autonomy.Demo.Util;

namespace Autonomy.Demo.Dal
{
    public abstract class DAO
    {
        public abstract IDbConnection CreateConnection();

        #region
        protected abstract IDbDataParameter String { get;}
        protected abstract IDbDataParameter TinyInt { get;}
        protected abstract IDbDataParameter SmallInt { get;}
        protected abstract IDbDataParameter Int { get;}
        protected abstract IDbDataParameter BigInt { get;}
        protected abstract IDbDataParameter Float { get;}
        protected abstract IDbDataParameter DateTime { get;}
        protected abstract IDbDataParameter Bool { get;}
        protected abstract IDbDataParameter Text { get;}
        protected abstract IDbDataParameter Image { get;}
        protected abstract IDbDataParameter GUID { get;}
        #endregion


        public bool Open(IDbCommand iCmd)
        {
            try
            {
                iCmd.Connection.Open();
                return true;
            }
            catch (Exception exc)
            {
                LogWriter.WriteErrLog(exc.Message);
                return false;
            }
        }

        public bool Close(IDbCommand iCmd)
        {
            try
            {
                iCmd.Connection.Close();
                iCmd.Connection.Dispose();
                iCmd.Dispose();
                return true;
            }
            catch (Exception exc)
            {
                LogWriter.WriteErrLog(exc.Message);
                return false;
            }
        }

        public object ExecuteScalar(IDbCommand iCmd)
        {
            try
            {
                return iCmd.ExecuteScalar();
            }
            catch (Exception e)
            {
                LogWriter.WriteErrLog(e.Message);
                return null;
            }
        }

        public IList ExecuteScalarList(IDbCommand iCmd)
        {
            IDataReader reader = null;

            try
            {
                reader = iCmd.ExecuteReader();
            }
            catch (Exception e)
            {
                LogWriter.WriteErrLog(e.Message);
                return null;
            }

            IList list = new ArrayList();

            while (reader.Read())
                list.Add(reader[0]);

            reader.Close();

            return list;

        }

        public DataTable ExecuteTable(IDbCommand iCmd)
        {
            
            IDataReader reader = null;

            try
            {
                reader = iCmd.ExecuteReader();
            }
            catch (Exception e)
            {
                LogWriter.WriteErrLog(e.Message);
                return null;
            }

            DataTable dt = new DataTable();
            int fieldCount = reader.FieldCount;
            for (int i = 0; i < fieldCount; i++)
                dt.Columns.Add(reader.GetName(i), reader.GetFieldType(i));

            while (reader.Read())
            {
                DataRow dr = dt.NewRow();
                for (int i = 0; i < fieldCount; i++)
                    dr[i] = reader[i];
                dt.Rows.Add(dr);
            }

            reader.Close();
            reader.Dispose();

            return dt;

        }

        public DataTable ExecutePartTable(IDbCommand iCmd, int page_index, int page_size)
        {
            IDataReader reader = null;
            try
            {
                reader = iCmd.ExecuteReader();
            }
            catch (Exception e)
            {
                LogWriter.WriteErrLog(e.Message);
                return null;
            }

            int i, start_index = (page_index - 1) * page_size;
            for (i = 0; i < start_index && reader.Read(); i++) ;//skip rows;

            DataTable dt = new DataTable();
            int fieldCount = reader.FieldCount;
            for (i = 0; i < fieldCount; i++)
                dt.Columns.Add(reader.GetName(i), reader.GetFieldType(i));

            int j = 0;
            for (i = 0; i < page_size && reader.Read(); i++)
            {
                DataRow dr = dt.NewRow();
                for (j = 0; j < fieldCount; j++)
                    dr[j] = reader[j];
                dt.Rows.Add(dr);
            }

            return dt;
        }

        public IList ExecuteList(IDbCommand iCmd)
        {
            IDataReader reader = null;
            try
            {
                reader = iCmd.ExecuteReader();
            }
            catch (Exception e)
            {
                LogWriter.WriteErrLog(e.Message);
                return null;
            }

            IList list = new ArrayList();
            SortedList row_data = null;
            int fieldCount = reader.FieldCount;

            while (reader.Read())
            {
                row_data = new SortedList(fieldCount);
                for (int i = 0; i < fieldCount; i++)
                    row_data[reader.GetName(i)] = reader[i];
                list.Add(row_data);
            }

            reader.Close();
            reader.Dispose();

            return list;

        }

        public IList ExecutePartList(IDbCommand iCmd, int page_index, int page_size)
        {
            IDataReader reader = null;
            try
            {
                reader = iCmd.ExecuteReader();
            }
            catch (Exception e)
            {
                LogWriter.WriteErrLog(e.Message);
                return null;
            }

            int i,start_index = (page_index - 1) * page_size;
            for (i = 0; i < start_index && reader.Read(); i++) ; //skip rows;

            int fieldCount = reader.FieldCount;
            string[] column_names = new string[fieldCount];
            for (i = 0; i < fieldCount; i++)
                column_names[i] = reader.GetName(i);


            int j = 0;
            ArrayList list = new ArrayList();

            for (i = 0; i < page_size && reader.Read(); i++)
            {
                SortedList row_data = new SortedList();
                for (j = 0; j < fieldCount; j++)
                    row_data[column_names[j]] = reader[j];
                list.Add(row_data);
            }
            return list;
        }

        public int ExecuteNonQuery(IDbCommand iCmd)
        {
            try
            {
                return iCmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                LogWriter.WriteErrLog(e.Message);
                return -1;
            }
        }

        public object ExecuteObject(IDbCommand iCmd)
        {
            IDataReader reader = null;
            try
            {
                reader = iCmd.ExecuteReader(CommandBehavior.SingleRow);
            }
            catch (Exception e)
            {
                LogWriter.WriteErrLog(e.Message);
                return null;
            }

            object data = null;

            if (reader.Read())
                data = reader.GetValue(0);

            reader.Close();
            reader.Dispose();
            return data;
        }

        public IDictionary ExecuteDictionary(IDbCommand iCmd)
        {
            IDataReader reader = null;
            try
            {
                reader = iCmd.ExecuteReader(CommandBehavior.SingleRow);
            }
            catch (Exception e)
            {
                LogWriter.WriteErrLog(e.Message);
                return null;
            }

            IDictionary dict = null;

            if (reader.Read())
            {
                int fieldCount = reader.FieldCount;
                dict = new SortedList(fieldCount);
                for (int i = 0; i < fieldCount; i++)
                    dict[reader.GetName(i)] = reader.GetValue(i);
            }

            reader.Close();
            reader.Dispose();
            return dict;
        }


        #region
        public void SetString(IDbCommand iCmd, string para_name, object para_data)
        {
            this.setParameter(iCmd, this.getParameter(this.String, para_name, para_data, -1, ParameterDirection.Input));
        }
        public void SetOutputString(IDbCommand iCmd, string para_name)
        {
            this.setParameter(iCmd, this.getParameter(this.String, para_name, null, -1, ParameterDirection.Output));
        }
        public void SetText(IDbCommand iCmd, string para_name, object para_data)
        {
            this.setParameter(iCmd, this.getParameter(this.Text, para_name, para_data, -1, ParameterDirection.Input));
        }
        public void SetTinyInt(IDbCommand iCmd, string para_name, object para_data)
        {
            this.setParameter(iCmd, this.getParameter(this.TinyInt, para_name, para_data, -1, ParameterDirection.Input));
        }
        public void SetSmallInt(IDbCommand iCmd, string para_name, object para_data)
        {
            this.setParameter(iCmd, this.getParameter(this.SmallInt, para_name, para_data, -1, ParameterDirection.Input));
        }
        public void SetInt(IDbCommand iCmd, string para_name, object para_data)
        {
            this.setParameter(iCmd, this.getParameter(this.Int, para_name, para_data, -1, ParameterDirection.Input));
        }
        public void SetOutputInt(IDbCommand iCmd, string para_name)
        {
            this.setParameter(iCmd, this.getParameter(this.Int, para_name, null, -1, ParameterDirection.Output));
        }
        public void SetBigInt(IDbCommand iCmd, string para_name, object para_data)
        {
            this.setParameter(iCmd, this.getParameter(this.BigInt, para_name, para_data, -1, ParameterDirection.Input));
        }
        public void SetBigInt(IDbCommand iCmd, string para_name, object para_data, int size)
        {
            this.setParameter(iCmd, this.getParameter(this.BigInt, para_name, para_data, size, ParameterDirection.Input));
        }
        public void SetFloat(IDbCommand iCmd, string para_name, object para_data)
        {
            this.setParameter(iCmd, this.getParameter(this.Float, para_name, para_data, -1, ParameterDirection.Input));
        }
        public void SetDateTime(IDbCommand iCmd, string para_name, object para_data)
        {
            this.setParameter(iCmd, this.getParameter(this.DateTime, para_name, para_data, -1, ParameterDirection.Input));
        }
        public virtual void SetBool(IDbCommand iCmd, string para_name, object para_data)
        {
            this.setParameter(iCmd, this.getParameter(this.Bool, para_name, para_data, -1, ParameterDirection.Input));
        }
        public void SetImage(IDbCommand iCmd, string para_name, object para_data)
        {
            this.setParameter(iCmd, this.getParameter(this.Image, para_name, para_data, -1, ParameterDirection.Input));
        }
        public void SetGUID(IDbCommand iCmd, string para_name, object para_data)
        {
            this.setParameter(iCmd, this.getParameter(this.GUID, para_name, para_data, -1, ParameterDirection.Input));
        }
        private void setParameter(IDbCommand iCmd, IDbDataParameter iPara)
        {
            string para_name = iPara.ParameterName;

            if (!iCmd.Parameters.Contains(para_name))
                iCmd.Parameters.Add(iPara);
            else
                iCmd.Parameters[para_name] = iPara;
        }
        private IDbDataParameter getParameter(IDbDataParameter iPara, string name, object para_data, int size, ParameterDirection direction)
        {
            iPara.ParameterName = name;
            iPara.Value = null == para_data ? DBNull.Value : para_data;

            if (size != -1)
                iPara.Size = size;
            iPara.Direction = direction;
            return iPara;
        }

        //2008-06-16 wengmj
        protected virtual string[] ParaNames 
        { 
            get { return DAO.para_names; } 
        }
        //2008-06-16 wengmj
        public void SetIDs(IDbCommand cmd, int[] ids)
        {
            int ids_len = ids.Length;

            if (ids_len > 50)
            {
                cmd.CommandText = string.Format(cmd.CommandText, string.Join(",", Array.ConvertAll<int, string>(ids, Convert.ToString)));
            }
            else
            {
                cmd.CommandText = string.Format(cmd.CommandText, string.Join(",", this.ParaNames, 0, ids_len));
                for (int i = 0; i < ids_len; i++)
                    this.SetInt(cmd, this.ParaNames[i], ids[i]);
            }
        }

        #endregion

        public object GetParameterValue(IDbCommand iCmd, string para_name)
        {
            IDbDataParameter iPara = iCmd.Parameters[para_name] as IDbDataParameter;
            return null == iPara ? null : iPara.Value;
        }

        private static readonly string[] para_names ={ "@id0", "@id1", "@id2", "@id3", "@id4", "@id5", "@id6", "@id7", "@id8", "@id9", "@id10", "@id11", "@id12", "@id13", "@id14", "@id15", "@id16", "@id17", "@id18", "@id19", "@id20", "@id21", "@id22", "@id23", "@id24", "@id25", "@id26", "@id27", "@id28", "@id29", "@id30", "@id31", "@id32", "@id33", "@id34", "@id35", "@id36", "@id37", "@id38", "@id39", "@id40", "@id41", "@id42", "@id43", "@id44", "@id45", "@id46", "@id47", "@id48", "@id49" };
        public static DAO SQLSERVER = new SqlServerDAO();
    }
}
                                ent.Domain"/>).
            </para>
            </remarks>
        </member>
        <member name="P:log4net.Appender.RemoteSyslogAppender.Facility">
            <summary>
            Syslog facility
            </summary>
            <remarks>
            Set to one of the <see cref="T:log4net.Appender.RemoteSyslogAppender.SyslogFacility"/> values. The list of
            facilities is predefined and cannot be extended. The default value
            is <see cref="F:log4net.Appender.RemoteSyslogAppender.SyslogFacility.User"/>.
            </remarks>
        </member>
        <member name="T:log4net.Appender.RemoteSyslogAppender.SyslogSeverity">
            <summary>
            syslog severities
            </summary>
            <remarks>
            <para>
            The syslog severities.
            </para>
            </remarks>
        </member>
        <member name="F:log4net.Appender.RemoteSyslogAppender.SyslogSeverity.Emergency">
            <summary>
            system is unusable
            </summary>
        </member>
        <member name="F:log4net.Appender.RemoteSyslogAppender.SyslogSeverity.Alert">
            <summary>
            action must be taken immediately
            </summary>
        </member>
        <member name="F:log4net.Appender.RemoteSyslogAppender.SyslogSeverity.Critical">
            <summary>
            critical conditions
            </summary>
        </member>
        <member name="F:log4net.Appender.RemoteSyslogAppender.SyslogSeverity.Error">
            <summary>
            error conditions
            </summary>
        </member>
        <member name="F:log4net.Appender.RemoteSyslogAppender.SyslogSeverity.Warning">
            <summary>
            warning conditions
            </summary>
        </member>
        <member name="F:log4net.Appender.RemoteSyslogAppender.SyslogSeverity.Notice">
            <summary>
            normal but significant condition
            </summary>
        </member>
        <member name="F:log4net.Appender.RemoteSyslogAppender.SyslogSeverity.Informational">
            <summary>
            informational
            </summary>
        </member>
        <member name="F:log4net.Appender.RemoteSyslogAppender.SyslogSeverity.Debug">
            <summary>
            debug-level messages
            </summary>
        </member>
        <member name="T:log4net.Appender.RemoteSyslogAppender.SyslogFacility">
            <summary>
            syslog facilities
            </summary>
