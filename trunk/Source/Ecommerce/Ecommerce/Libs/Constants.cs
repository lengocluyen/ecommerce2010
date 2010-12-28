using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

namespace Libs
{
    public class Constants
    {
        public static string tempFolder = "~/Temp";
        public static string uploadFolder = "/Upload";

        public static int AdminItemsPerPage = LibConvert.ConvertToInt(LibConfig.GetConfigValue("AdminItemPerPage"), 10);
        public static int AdminPageSize = LibConvert.ConvertToInt(LibConfig.GetConfigValue("AdminPageSize"), 20);

        public static string ACCOUNT_LOGIN = "ACCOUNT_LOGIN";
        public static string COOKIE_USERNAME = "COOKIE_USERNAME";
        public static string COOKIE_USERPASS = "COOKIE_USERPASS";
		public static string CAPTCHA = "CAPTCHA";

        public static string CartSessionKey = "CartID";
    }
}
