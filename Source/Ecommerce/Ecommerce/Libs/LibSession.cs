using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Libs
{
    public class LibSession
    {
        public static object Get(string key)
        {
            object obj = new object();
            obj = HttpContext.Current.Session[key];
            return obj;
        }
        public static void Set(string key, object value)
        {
            HttpContext.Current.Session[key] = value;
        }
        public static void Remove(string key)
        {
            HttpContext.Current.Session.Remove(key); 
        }
    }
}
