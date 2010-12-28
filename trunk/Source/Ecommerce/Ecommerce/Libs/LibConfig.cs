using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

namespace Libs
{
    public class LibConfig
    {
        public static string GetConfigValue(string key)
        {
            try
            {
                return ConfigurationManager.AppSettings.Get(key);
            }
            catch
            {
                return "";
            }
        }
    }
}