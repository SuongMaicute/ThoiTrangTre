using Microsoft.Extensions.Caching.Memory;

namespace API.Util
{
    public class CacheHelper 
    {
        private IMemoryCache _cache;
        public CacheHelper( IMemoryCache cache)
        {
            _cache = cache;
        }
        public  void CacheSave(String key, Object? entry)
        {
            var cacheEntryOptions = new MemoryCacheEntryOptions()
                .SetSlidingExpiration(TimeSpan.FromSeconds(15))
                .SetAbsoluteExpiration(TimeSpan.FromSeconds(3600))
                .SetPriority(CacheItemPriority.Normal);

            _cache.Set(key, entry, cacheEntryOptions);
        }

        public T? CheckCache<T>(string key) where T : class
        {
            if (_cache.TryGetValue(key, out T? returnObj))
            {
                return returnObj;
            }
            return null;
        }


        public enum CategoryKey
        {
            MPVI_CategoryListKey,
            MPVI_CategoryDetailByID
        }

    }
}
