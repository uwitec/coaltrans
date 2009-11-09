using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Collections;
using System.IO;
using System.Xml;
namespace Coal.Util
{
    public sealed class ConfigUtility
    {
        #region config method
        /// <summary>
        /// 得到AppSettings中的配置字符串信息
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetConfigString(string key)
        {

            object config= System.Configuration.ConfigurationManager.AppSettings[key];
            return config == null ? string.Empty : config.ToString();

            //string CacheKey = "AppSettings-" + key;
            //object objModel =CacheUtility.GetCache(CacheKey);
            //if (objModel == null)
            //{
            //    try
            //    {
            //        objModel = System.Configuration.ConfigurationManager.AppSettings[key];
            //        if (objModel != null)
            //        {
            //           CacheUtility.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(180), TimeSpan.Zero);
            //        }
            //    }
            //    catch
            //    { }
            //}
            //return objModel.ToString();
        }

        public static string GetConnectionString(string key)
        {
            object config = System.Configuration.ConfigurationManager.ConnectionStrings[key];
            return config == null ? string.Empty : config.ToString();
        }

        /// <summary>
        /// 得到AppSettings中的配置Bool信息
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static bool GetConfigBool(string key)
        {
            bool result = false;
            string cfgVal = GetConfigString(key);
            if (null != cfgVal && string.Empty != cfgVal)
            {
                try
                {
                    result = bool.Parse(cfgVal);
                }
                catch (FormatException)
                {
                    // Ignore format exceptions.
                }
            }
            return result;
        }
        /// <summary>
        /// 得到AppSettings中的配置Decimal信息
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static decimal GetConfigDecimal(string key)
        {
            decimal result = 0;
            string cfgVal = GetConfigString(key);
            if (null != cfgVal && string.Empty != cfgVal)
            {
                try
                {
                    result = decimal.Parse(cfgVal);
                }
                catch (FormatException)
                {
                    // Ignore format exceptions.
                }
            }

            return result;
        }
        /// <summary>
        /// 得到AppSettings中的配置int信息
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static int GetConfigInt(string key)
        {
            int result = 0;
            string cfgVal = GetConfigString(key);
            if (null != cfgVal && string.Empty != cfgVal)
            {
                try
                {
                    result = int.Parse(cfgVal);
                }
                catch (FormatException)
                {
                    // Ignore format exceptions.
                }
            }

            return result;
        }
        #endregion

        #region xmlmethod
        // Fields
        private static Hashtable Configurations = new Hashtable();

        // Methods
        /// <summary>
        /// get xml configurations
        /// </summary>
        /// <param name="filename">filename</param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetConfig(string filename, string key)
        {
            return GetConfig(filename, key, null);
        }

        public static string GetConfig(string filename, string key, string defaultValue)
        {
            if ((key == null) || (key == ""))
            {
                throw new Exception("The key cannot be null or empty!");
            }
            key = key.ToLower();
            filename = filename.ToLower();
            LoadConfigurationFile(filename);
            if (((Hashtable)Configurations[filename]).ContainsKey(key))
            {
                return Environment.ExpandEnvironmentVariables(((Hashtable)Configurations[filename])[key].ToString());
            }
            if (defaultValue == null)
            {
                throw new Exception(string.Format("The key '{0}' cannot be found in the config file {1}.", key, filename));
            }
            return defaultValue;
        }

        /// <summary>
        /// load xml config file,xml file format is root node need written as <code>root</code>
        /// </summary>
        /// <param name="filename">file name</param>
        private static void LoadConfigurationFile(string filename)
        {
            if (Configurations[filename] == null)
            {
                if (!File.Exists(filename))
                {
                    throw new Exception(string.Format("The configuration file '{0}' could not be found.", filename));
                }
                Hashtable hashtable = new Hashtable();
                XmlTextReader reader = new XmlTextReader(filename);
                while (reader.Read())
                {
                    string key = reader.Name.ToString().ToLower();
                    if ((reader.NodeType == XmlNodeType.Element) && (reader.Name != "root"))
                    {
                        reader.Read();
                        hashtable.Add(key, reader.Value.ToString());
                    }
                }
              
                Configurations.Add(filename, hashtable);
            }
        }

        public static void UpdateConfig(string filename, string key, string val)
        {
            if ((key == null) || (key == ""))
            {
                throw new Exception("The key cannot be null or empty!");
            }
            filename = filename.ToLower();
            LoadConfigurationFile(filename);
            ((Hashtable)Configurations[filename])[key.ToLower()] = val;
        }

        #endregion

    }
}
