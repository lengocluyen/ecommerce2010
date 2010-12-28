using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Libs
{
    public class LibCookie
    {
        public static string Get(string key)
        {
            HttpCookie nusCookie = HttpContext.Current.Request.Cookies[key];
            if (nusCookie == null)
                return "";
            else
                return nusCookie.Value;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="expireTime">if null: expireTime is 1 day</param>
        public static void Add(string key, string value, DateTime? expireTime)
        {
            HttpCookie nusCookie = new HttpCookie(key);
            nusCookie.Value = value;
            if (expireTime != null)
                nusCookie.Expires = (DateTime)expireTime;
            else
                nusCookie.Expires = DateTime.Now + new TimeSpan(24, 0, 0);//1 Day
            HttpContext.Current.Response.Cookies.Add(nusCookie);
        }
        public static void Remove(string key)
        {
            HttpContext.Current.Response.Cookies[key].Expires = DateTime.Now.AddDays(-1);
        }
    }
}
