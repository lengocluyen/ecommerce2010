using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Libs
{
    public class LibConvert
    {
        /// <summary>
        /// Convert to DataType.
        /// </summary>
        /// <param name="data">input object Data</param>
        /// <param name="type">input typeof(Type). Type: string, int, double ...</param>
        /// <param name="defaultValue">Default value - object</param>
        /// <param name="provider">IFormatProvider provider</param>
        /// <returns>object</returns>  
        static object ConvertDataType(object data, Type type, object defaultValue, IFormatProvider provider)
        {
            if (data == null)
                return defaultValue;
            try
            {
                return Convert.ChangeType(data, type, provider);
            }
            catch
            {
                return defaultValue;
            }
        }
        //Int
        public static int ConvertToInt(object data, int defaultValue)
        {
            return (int)ConvertDataType(data, typeof(Int32), defaultValue, System.Globalization.CultureInfo.CurrentCulture);
        }
        public static Int64 ConvertToInt64(object data, int defaultValue)
        {
            return (Int64)ConvertDataType(data, typeof(Int64), defaultValue, System.Globalization.CultureInfo.CurrentCulture);
        }

        //Bool
        public static bool ConvertToBool(object data, bool defaultValue)
        {
            return (bool)ConvertDataType(data, typeof(bool), defaultValue, System.Globalization.CultureInfo.CurrentCulture);
        }

        //Float
        public static float ConvertToFloat(object data, float defaultValue)
        {
            return (float)ConvertDataType(data, typeof(float), defaultValue, System.Globalization.CultureInfo.CurrentCulture);
        }

        //Double
        public static double ConvertToDouble(object data, double defaultValue)
        {
            return (double)ConvertDataType(data, typeof(double), defaultValue, System.Globalization.CultureInfo.CurrentCulture);
        }

        //DateTime
        public static DateTime ConvertToDateTime(object obj)
        {
            try
            {
                return Convert.ToDateTime(obj);
            }
            catch
            {
                return new DateTime(1753, 1, 1);//Min value for SQL Server
            }
        }
        public static DateTime ConvertToDateTime(object obj, DateTime defaulfValue)
        {
            try
            {
                return Convert.ToDateTime(obj);
            }
            catch
            {
                return defaulfValue;
            }
        }

        public static DateTime ConvertToDateTimeByFormat(object obj, string format)
        {
            try
            {
                return DateTime.ParseExact(obj.ToString().Trim(), format, null);
            }
            catch
            {
                return new DateTime(1753, 1, 1);//Min value for SQL Server
            }
        }

        /// <summary>
        /// Convert to Vietnam Date Format "dd/mm/yyyy"
        /// </summary>
        /// <param name="dt">DateTime object</param>
        /// <returns>dd/mm/yyyy</returns>
        public static string ConvertVNDateFormat(DateTime dt)
        {
            try
            {
                return dt.ToString("dd/MM/yyyy");
            }
            catch
            {
                return dt.ToString();
            }
        }

        public static DateTime ConvertFromVNDateFormat(string vn_dt, char charSpilit)
        {
            string[] lst = vn_dt.Split(charSpilit);
            return ConvertToDateTime(lst[1] + "/" + lst[0] + "/" + lst[2]);
        }
        //Money
        /// <summary>
        /// Convert value to Vietnam currency
        /// </summary>
        /// <param name="_currencyValue">value need to convert</param>
        /// <returns>Value in Vietnam format ex: 250,000</returns>
        public static string ConvertToVNCurrency(object _currencyValue)
        {
            int currencyValue = ConvertToInt(_currencyValue, 0);
            string _result = String.Format("{0:0,0}", _currencyValue);

            if (_result != String.Empty)
                return _result;
            return "0";
        }

        //String
        /// <summary>
        /// Convert object to string with safe mode. Encode HTML.
        /// </summary>
        /// <param name="input">object data</param>
        /// <returns>string with encode html</returns>
        public static string ForceString(object input)
        {
            if (input == null)
                return string.Empty;

            return HttpUtility.HtmlEncode(input.ToString().Trim());
        }
        public static string ConvertToString(object data, string defaultValue)
        {
            try
            {
                return data.ToString().Trim();
            }
            catch
            {
                return defaultValue;
            }
        }
    }
}