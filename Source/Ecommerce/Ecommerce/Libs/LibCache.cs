using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Caching;

namespace Libs
{
    public class LibCache
    {
        private static Cache _cache;

        public static Cache Cache
        {
            get { return LibCache._cache; }
        }
        static LibCache()
        {
            _cache = HttpRuntime.Cache;
        }
        public static object Get(string key)
        {
            return _cache[key];
            //return null;
        }
        public static void Set(string key, object value)
        {
            _cache[key] = value;
        }
        public static void Add(string key, object value)
        {
            //dependencies: xac dinh doi tuong ma object trong cache phu thuoc (ex: a file), khi doi tuong fu thuoc nay change thi object do se bi xoa trong cache
            //timeSpan: Cache bi xoa sau n phut ke tu lan request cuoi cung doi voi trang web
            if (value == null)
                return;
            _cache.Add(key, value, null, Cache.NoAbsoluteExpiration, Cache.NoSlidingExpiration, CacheItemPriority.Default, null);
        }
        public static void Remove(string key)
        {
            _cache.Remove(key);
        }
    }
}