using Business.Abstract;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CacheExample:ICacheExample
    {
        private IDistributedCache _distributedCache;
        private IMemoryCache _memoryCache;

        public CacheExample(IDistributedCache distCache, IMemoryCache memoryCache)
        {
            _distributedCache = distCache;
            _memoryCache = memoryCache;
        }

        public void DistSetString(string key, string value)
        {
            _distributedCache.SetString(key, value);
        }

        //Redis liste olarak saklar fakat distributed Cache byte array yada string olarak saklar.
        public void DistSetList(string key)
        {
            var arrayNumber = new int[] { 2, 4, 8, 16 };

            //array listi string'   e çevirir.
            var strArrayNumber = System.Text.Json.JsonSerializer.Serialize(arrayNumber);
            _distributedCache.SetString(key, strArrayNumber);
        }

        public string DistGetValue(string key)
        {
            return _distributedCache.GetString(key);
        }

        public void InMemSetString(string key, string value)
        {
            _memoryCache.Set(key, value);
        }

        public void InMemSetObject(string key, object value)
        {
            _memoryCache.Set(key, value);
        }

        //InMemory'de hangi modeli veriyorsak o şekilde dönebiliriz
        public T InMemGetValue<T>(string key)
        {
            return _memoryCache.Get<T>(key);
        }
    }
}
