using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace Autonomy.Demo.Util
{
    public class ConfigUtil
    {
        public static string GetAppSetting(string key)
        {
            if (ConfigurationManager.AppSettings[key] != null)
            {
                return ConfigurationManager.AppSettings[key].ToString();
            }
            else
            {
                return null;
            }
        }

        public static string GetConnStr(string key)
        {
            if (ConfigurationManager.ConnectionStrings[key] != null)
            {
                return ConfigurationManager.ConnectionStrings[key].ConnectionString;
            }
            else
            {
                return null;
            }
        }

    }
}
