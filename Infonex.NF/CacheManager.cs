using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Caching ;

namespace Infonex.NF.Facade {
    public class CacheManager {
        public static void Add(string key, object cachedItem) {
            Add(key, null, cachedItem);
        }

        public static void Add(string key, CacheDependency cacheDependency, object cachedItem) {
            Add(HttpContext.Current, key, DateTime.Now.AddHours(10), cacheDependency, cachedItem);
        }

        public static void Add(HttpContext current, string key, DateTime expiration, CacheDependency cacheDependency, object cachedItem) {
            current.Cache.Add(key, cachedItem, cacheDependency, expiration, TimeSpan.Zero, System.Web.Caching.CacheItemPriority.Normal, null);
        }

        public static bool IsValid(string key) {
            return HttpContext.Current.Cache[key] != null;   
        }

        public static object Get(string key) {
            return Get(HttpContext.Current, key);
        }

        public static object Get(HttpContext current, string key) {
            return current.Cache[key];
        }
    }
}
