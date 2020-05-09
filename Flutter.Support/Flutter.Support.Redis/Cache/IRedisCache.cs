using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Text;

namespace Flutter.Support.Redis.Cache
{
    public interface IRedisCache
    {
        IDatabase Database { get; }

        bool SetValue(string key, string value, TimeSpan? expiry = null);

        bool SetValue<T>(string key, T value, TimeSpan? expiry = null);

        string GetValue(string key);

        T GetValue<T>(string key);

    }
}
