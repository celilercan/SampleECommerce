﻿using SampleECommerce.Core.Caching;
using System;
using System.Collections.Generic;
using System.Text;

namespace SampleECommerce.Core.Extensions
{
    public static class CacheManagerExtension
    {
        public static T Get<T>(this ICacheManager cacheManager, string key, Func<T> acquire)
        {

            return Get(cacheManager, key, acquire, 20);

        }

        public static T Get<T>(this ICacheManager cacheManager, string key, Func<T> acquire, int cacheTime = 20)
        {
            var result = cacheManager.Get<T>(key);
            if (result != null)
            {
                return result;
            }

            result = acquire();
            cacheManager.Set(key, result, cacheTime);
            return result;
        }
    }
}
