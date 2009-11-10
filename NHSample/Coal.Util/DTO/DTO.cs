using System;
using System.Xml;
using System.Text;
using System.Collections;

namespace Coal.Util
{
    public class DTO
    {
        protected IDictionary m_content = null;
        private string m_name = null;

        public DTO() : this("DTO") { }

        public DTO(string name)
        {
            this.m_name = name;
            this.m_content = new SortedList();
        }

        public object this[string key]
        {
            set
            {
                this.m_content[key] = value;
            }
            get
            {
                return this.m_content[key];
            }
        }

        public object Rows
        {
            get
            {
                return this.m_content["rows"];
            }
            set
            {
                this.m_content["rows"] = value;
            }
        }



        public static object ParseField(object row, object field_id)
        {
            IDictionary dict = row as IDictionary;
            if (dict == null) return null;

            return dict[field_id];
        }

        public static object ParseField(object row, object field_id, string format)
        {
            object data = ParseField(row, field_id);

            if (data == null) return null;

            return string.Format(format, data);
        }



        public string GetString(string key)
        {
            return EConvert.ToString(this.m_content[key]);
        }

        public float GetFloat(string key)
        {
            return EConvert.ToFloat(this.m_content[key]);
        }

        public int GetInt(string key)
        {
            return EConvert.ToInt(this.m_content[key]);
        }

        public long GetLong(string key)
        {
            return EConvert.ToLong(this.m_content[key]);
        }

        public bool GetBoolean(string key)
        {
            return EConvert.ToBoolean(this.m_content[key]);
        }

        public DateTime GetDateTime(string key)
        {
            return EConvert.ToDateTime(this.m_content[key]);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<?xml version=\"1.0\" encoding=\"utf-8\" standalone=\"yes\" ?>");
            sb.AppendFormat("<{0}>", this.m_name);
            foreach (string key in this.m_content.Keys)
                visit_object(sb, key, this.m_content[key]);
            sb.AppendFormat("</{0}>", this.m_name);
            return sb.ToString();
        }

        private bool loadFromXDoc(XmlDocument xdoc)
        {
            XmlNode root = xdoc.SelectSingleNode(string.Format("/{0}", this.m_name));
            if (root == null) return false;

            foreach (XmlNode node in root.ChildNodes)
            {
                if (isLeafNode(node))
                {
                    this.m_content[node.Name] = node.InnerText;
                }
                else if (hasRowChild(node))
                {
                    IList list = new ArrayList();
                    visit_list(node, list);
                    this.m_content[node.Name] = list;
                }
                else
                {
                    IDictionary dict = new SortedList();
                    visit_dictionary(node, dict);
                    this.m_content[node.Name] = dict;
                }
            }

            return true;
        }

        public bool LoadXML(string xml)
        {
            XmlDocument xdoc = new XmlDocument();
            try
            {
                xdoc.LoadXml(xml);
            }
            catch
            {
                return false;
            }

            return loadFromXDoc(xdoc);

        }

        public bool Load(string urlFormat, params object[] args)
        {
            string url = string.Format(urlFormat, args);

            XmlDocument xdoc = new XmlDocument();
            try
            {
                xdoc.Load(url);
            }
            catch
            {
                return false;
            }

            return loadFromXDoc(xdoc);
        }

        public static object Eval(object row, object field_id)
        {
            IDictionary dict = row as IDictionary;
            if (dict == null) return null;
            return dict[field_id];
        }

        public static object Eval(object row, object field_id, string format)
        {
            object data = Eval(row, field_id);
            if (data == null) return null;
            return string.Format(format, data);
        }

        private static void visit_dictionary(StringBuilder sb, string key, IDictionary data)
        {
            sb.AppendFormat("<{0}>", key);
            foreach (string item_key in data.Keys)
                visit_object(sb, item_key, data[item_key]);
            sb.AppendFormat("</{0}>", key);
        }

        private static void visit_list(StringBuilder sb, string key, IList data)
        {
            sb.AppendFormat("<{0}>", key);
            foreach (object item_data in data)
                visit_object(sb, "row", item_data);
            sb.AppendFormat("</{0}>", key);
        }

        private static void visit_object(StringBuilder sb, string key, object data)
        {
            string type_name = null;
            if (data != null)
                type_name = data.GetType().Name;

            switch (type_name)
            {
                case "SortedList":
                case "Hashtable":
                    visit_dictionary(sb, key, data as IDictionary);
                    break;
                case "ArrayList":
                    visit_list(sb, key, data as IList);
                    break;
                default:
                    sb.AppendFormat("<{0}><![CDATA[{1}]]></{0}>", key, data);
                    break;
            }
        }

        private static void visit_list(XmlNode node, IList list)
        {
            foreach (XmlNode node_item in node.ChildNodes)
            {
                if (isLeafNode(node_item))
                {
                    list.Add(node_item.InnerText);
                }
                else if (hasRowChild(node_item))
                {
                    IList list_item = new ArrayList();
                    visit_list(node_item, list_item);
                    list.Add(list_item);
                }
                else
                {
                    IDictionary dict_item = new SortedList();
                    visit_dictionary(node_item, dict_item);
                    list.Add(dict_item);
                }
            }
        }

        private static void visit_dictionary(XmlNode node, IDictionary dict)
        {
            foreach (XmlNode node_item in node.ChildNodes)
            {
                if (isLeafNode(node_item))
                {
                    dict[node_item.Name] = node_item.InnerText;
                }
                else if (hasRowChild(node_item))
                {
                    IList list_item = new ArrayList();
                    visit_list(node_item, list_item);
                    dict[node_item.Name] = list_item;
                }
                else
                {
                    IDictionary dict_item = new SortedList();
                    visit_dictionary(node_item, dict_item);
                    dict[node_item.Name] = dict_item;
                }
            }
        }

        private static bool isLeafNode(XmlNode node)
        {
            return node.InnerXml.StartsWith("<![CDATA[");
        }

        private static bool hasRowChild(XmlNode node)
        {
            return node.InnerXml.StartsWith("<row>");
        }

        /// <summary>
        /// just for client javascript 
        /// </summary>
        /// <returns></returns>
        public string ToJSONString()
        {
            StringBuilder sb = new StringBuilder("{");
            bool hasItem = false;
            foreach (string key in this.m_content.Keys)
            {
                if (hasItem) sb.Append(",");
                visit_json_object(sb, key, this.m_content[key]);
                hasItem = true;
            }
            sb.Append("}");

            return sb.ToString();
        }

        public static string escape(object data)
        {
            string text = EConvert.ToString(data);
            if (text.Contains(@"\"))
            {
                text = text.Replace(@"\", @"\\");
            }
            if (text.Contains("'"))
            {
                text = text.Replace("'", @"\'");
            }
            if (text.Contains("\r\n"))
            {
                text = text.Replace("\r\n", @"\r\n");
            }
            return text;
        }

        private static void visit_json_object(StringBuilder sb, string key, object data)
        {
            string type_name = null;
            if (data != null)
                type_name = data.GetType().Name;

            switch (type_name)
            {
                case "SortedList":
                case "Hashtable":
                    visit_json_dictionary(sb, key, data as IDictionary);
                    break;
                case "ArrayList":
                    visit_json_list(sb, key, data as IList);
                    break;

                case "Byte":
                case "Int16":
                case "Int32":
                case "Int64":
                case "Single":
                case "Double":
                    if (key == null)
                        sb.AppendFormat("'{0}'", data);
                    else
                        sb.AppendFormat("'{0}':{1}", key, data);
                    break;

                case "Boolean":
                    if (key == null)
                        sb.AppendFormat("'{0}'", data);
                    else
                        sb.AppendFormat("'{0}':{1}", key, EConvert.ToBoolean(data) ? "true" : "false");
                    break;

                case "DateTime":
                    if (key == null)
                        sb.AppendFormat("'{0}'", data);
                    else
                        sb.AppendFormat("'{0}':'{1}'", key, data);
                    break;

                default:
                    if (key == null)
                        sb.AppendFormat("'{0}'", escape(data));
                    else
                        sb.AppendFormat("'{0}':'{1}'", key, escape(data));
                    break;
            }
        }

        private static void visit_json_list(StringBuilder sb, string key, IList data)
        {
            if (key == null)
                sb.Append("[");
            else
                sb.AppendFormat("'{0}':[", key);

            bool hasItem = false;
            foreach (object item_data in data)
            {
                if (hasItem) sb.Append(",");
                visit_json_object(sb, null, item_data);
                hasItem = true;
            }
            sb.AppendFormat("]", key);
        }

        private static void visit_json_dictionary(StringBuilder sb, string key, IDictionary data)
        {

            if (key != null)
                sb.AppendFormat("'{0}':{{", key);
            else
                sb.Append("{");

            bool hasItem = false;
            foreach (string item_key in data.Keys)
            {
                if (hasItem) sb.Append(",");
                visit_json_object(sb, item_key, data[item_key]);
                hasItem = true;
            }
            sb.Append("}");
        }
    }
}
