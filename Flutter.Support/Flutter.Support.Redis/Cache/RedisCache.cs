using Newtonsoft.Json;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Text;

namespace Flutter.Support.Redis.Cache
{
    public class RedisCache : IRedisCache
    {
        private readonly IDatabase database;
        private readonly IRedisCacheDatabaseProvider redisCacheDatabaseProvider;

        public IDatabase Database => database;

        public RedisCache(IRedisCacheDatabaseProvider redisCacheDatabaseProvider)
        {
            this.redisCacheDatabaseProvider = redisCacheDatabaseProvider;
            database = redisCacheDatabaseProvider.GetDatabase();
        }

        public string GetValue(string key)
        {
            return database.StringGet(key);
        }

        public T GetValue<T>(string key)
        {
            var str = database.StringGet(key);
            if (!string.IsNullOrWhiteSpace(str))
            {
                return JsonConvert.DeserializeObject<T>(str);
            }
            return default;
        }

        public bool SetValue(string key, string value, TimeSpan? expiry = null)
        {
            return database.StringSet(key, value, expiry);
        }

        public bool SetValue<T>(string key, T value, TimeSpan? expiry = null)
        {
            var str = JsonConvert.SerializeObject(value);
            return database.StringSet(key, str, expiry);
        }
    }
}
