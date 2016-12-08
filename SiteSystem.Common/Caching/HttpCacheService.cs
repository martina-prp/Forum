using System;
using System.Web;
using System.Web.Caching;

namespace SiteSystem.Common.Caching
{
    public class HttpCacheService : ICacheService
    {
        private static readonly Object lockObject = new object();

        public T Get<T>(string itemName, Func<T> getData, int durationInSeconds)
        {
            if (HttpRuntime.Cache[itemName] == null)
            {
                lock (lockObject)
                {
                    if (HttpRuntime.Cache[itemName] == null)
                    {
                        var data = getData();
                        HttpRuntime.Cache.Insert(
                            itemName,
                            data,
                            null,
                            DateTime.Now.AddSeconds(durationInSeconds),
                            Cache.NoSlidingExpiration);
                    }
                }
            }

            return (T)HttpRuntime.Cache[itemName];
        }
    }
}
