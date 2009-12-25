using System;
using System.Data;
using System.Collections.Generic;

namespace Coal.Util
{
    public sealed class ObjectCache<K,V>
    {
        private DataTable m_table = null;
        private  int m_duration = 0;
        private Queue<DataRow> m_queue = null;

        public ObjectCache(int duration)
        {
            this.m_table = new DataTable();
            m_table.Columns.Add("_id", typeof(K));
            m_table.Columns.Add("_data", typeof(V));
            m_table.Columns.Add("_update", typeof(DateTime));

            this.m_duration = -1 * duration;
            this.m_queue = new Queue<DataRow>();
        }

        public ObjectCache() : this(60) { }

        public int Duration
        {
            set
            {
                this.m_duration = -1 * value;
            }
            get
            {
                return -1 * this.m_duration;
            }
        }

        public V this[K id]
        {
            set
            {
                this.set_data(id, value);
            }
            get
            {
                return this.get_data(id);
            }
        }

        private DataRow dequeue()
        {
            if (this.m_queue.Count == 0)
                return null;
            return this.m_queue.Dequeue();
        }

        private DataRow findAvailableDataRow(object id)
        {
            DataRow dr = dequeue();
            if (dr == null)
            {
                DataRow[] rows = m_table.Select(string.Format("_update<=#{0}#", DateTime.Now.AddSeconds(this.m_duration)));
                if (rows == null || rows.Length == 0)
                {
                    dr = m_table.NewRow();
                    dr["_id"] = id;
                    m_table.Rows.Add(dr);
                }
                else
                {
                    dr = rows[0];
                    dr["_id"] = id;
                    foreach (DataRow row in rows)
                        this.m_queue.Enqueue(row);
                }
            }
            dr["_id"] = id;
            return dr;
        }

        private void set_data(K id, V data)
        {
            lock (this.m_table) 
            { 
             DataRow row = findAvailableDataRow(id);
             row["_data"] = data;
             row["_update"] = DateTime.Now;
            }
            
        }

        private V get_data(K id)
        {
            DataRow[] m_rows = m_table.Select(string.Format("_id='{0}' and _update>#{1}#", id, DateTime.Now.AddSeconds(this.m_duration)));
            if (m_rows == null || m_rows.Length == 0)
                return default(V);
            return (V)m_rows[0]["_data"];
        }

        public void SetOverdue(K id)
        {
            DataRow[] m_rows = m_table.Select(string.Format("_id='{0}' and _update>#{1}#", id, DateTime.Now.AddSeconds(this.m_duration)));
            if (m_rows == null || m_rows.Length == 0)
                return;
            m_rows[0]["_update"] = DateTime.MinValue;
        }
    }
}
