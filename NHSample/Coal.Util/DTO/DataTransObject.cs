using System;
using System.Collections;

namespace Coal.Util
{
    public class DataTransObject
    {
        protected IDictionary content = null;

        public DataTransObject()
        {
            this.content = new SortedList();
        }

        public object this[string key]
        {
            set
            {
                this.content[key] = value;
            }
            get
            {
                return this.content[key];
            }
        }

        public string GetString(string key)
        {
            object data = this.content[key];

            if (data == null)
                return null;

            return EConvert.ToString(data);
        }

        public int GetInt(string key)
        {
            return EConvert.ToInt(this.content[key]);
        }

        public bool GetBoolean(string key)
        {
            return EConvert.ToBoolean(this.content[key]);
        }

        public DateTime GetDateTime(string key)
        {
            return EConvert.ToDateTime(this.content[key]);
        }
    }
}
