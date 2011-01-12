using System;
using System.Configuration;
using SubSonic;

namespace ECommerce2010.Core
{
    public class Configuration : IConfiguration
    {
        public int ItemperPageUser {
            get { return Convert.ToInt32(getAppSetting(typeof(int), "ItemperPageUser")); }
        }
        public int ItemperPageAdmin
        {
            get { return Convert.ToInt32(getAppSetting(typeof(int), "ItemperPageAdmin")); }
        }
        public string AdminSiteURL
        {
            get { return getAppSetting(typeof (string), "AdminSiteURL").ToString(); }
        }

        public string RootURL
        {
            get { return getAppSetting(typeof(string), "RootURL").ToString(); }
        }

        private static object getAppSetting(Type expectedType, string key)
        {
            string value = ConfigurationManager.AppSettings.Get(key);
            if (value == null)
            {
                Log.Fatal("Configuration.cs", string.Format("AppSetting: {0} is not configured", key));
                throw new Exception(string.Format("AppSetting: {0} is not configured.", key));
            }

            try
            {
                if (expectedType.Equals(typeof(int)))
                {
                    return int.Parse(value);
                }

                if (expectedType.Equals(typeof(string)))
                {
                    return value;
                }

                throw new Exception("Type not supported.");
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Config key:{0} was expected to be of type {1} but was not.", key, expectedType),
                                    ex);
            }
        }
    }
}
