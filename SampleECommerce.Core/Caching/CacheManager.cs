using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using SampleECommerce.Core.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace SampleECommerce.Core.Caching
{
    public class CacheManager : ICacheManager
    {
        private readonly IDistributedCache _distributedCache;

        public CacheManager(IDistributedCache distributedCache)
        {
            _distributedCache = distributedCache;
        }

        public T Get<T>(string key)
        {
            var doc = _distributedCache.GetString(key);
            return !doc.IsNullOrEmptWhiteSpace() ? JsonConvert.DeserializeObject<T>(doc) : default(T);
        }

        public bool IsSet(string key)
        {
            var doc = _distributedCache.GetString(key);
            return !doc.IsNullOrEmptWhiteSpace();
        }

        public void Remove(string key)
        {
            _distributedCache.Remove(key);
        }

        public void Set(string key, object data, int cacheTime)
        {
            _distributedCache.SetString(key, JsonConvert.SerializeObject(data), new DistributedCacheEntryOptions { AbsoluteExpiration = DateTimeOffset.Now.AddMinutes(cacheTime) });
        }
    }
}
