using Flutter.Support.Extension.Configurations;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Text;

namespace Flutter.Support.Redis.Cache
{
    public class RedisCacheDatabaseProvider : IRedisCacheDatabaseProvider
    {
        private const string ConnectionStringKey = "Redis:ConnectionStringKey";
        private const string EnableCacheKey = "Redis:EnableCacheKey";
        private const string DatabaseIdSettingKey = "Redis:DatabaseIdSettingKey";

        private bool? _isReadForCache;

        private readonly Lazy<ConnectionMultiplexer> connectionMultiplexer;

        public ConnectionMultiplexer Multiplexer => connectionMultiplexer.Value;

        public RedisCacheDatabaseProvider()
        {
            connectionMultiplexer = new Lazy<ConnectionMultiplexer>(CreateConnectionMultiplexer());

            connectionMultiplexer.Value.ConnectionFailed += (sender, e) =>
            {
                throw new Exception("Redis to Server connection error");
            };
        }


        public IDatabase GetDatabase()
        {
            return connectionMultiplexer.Value.GetDatabase(GetDatabaseId());
        }

        private int GetDatabaseId()
        {
            var appSetting = ConfigHelper.Get(DatabaseIdSettingKey);
            if (string.IsNullOrWhiteSpace(appSetting))
            {
                return -1;
            }

            //int databaseId;
            if (!int.TryParse(appSetting, out int databaseId))
            {
                return -1;
            }

            return databaseId;
        }

        public bool IsReadForCache
        {
            get
            {
                if (!_isReadForCache.HasValue)
                {
                    //bool isEnable = false;
                    bool.TryParse(ConfigHelper.Get(EnableCacheKey), out bool isEnable);
                    _isReadForCache = isEnable;
                }
                return _isReadForCache.Value;
            }
        }

        private static ConnectionMultiplexer CreateConnectionMultiplexer()
        {
            var config = ConfigurationOptions.Parse(GetConnectionString());


            var connect = ConnectionMultiplexer.Connect(config);
            return connect;
        }

        /// <summary>
        /// 获取数据连接
        /// </summary>
        /// <returns></returns>
        private static string GetConnectionString()
        {
            var connStr = ConfigHelper.Get(ConnectionStringKey);
            if (connStr == null || string.IsNullOrWhiteSpace(connStr))
            {
                return "localhost";
            }

            return connStr;
        }

        public ConnectionMultiplexer ConnectionMultiplexer => throw new NotImplementedException();

        //public bool IsReadForCache => throw new NotImplementedException();

        //public IDatabase GetDatabase()
        //{
        //    throw new NotImplementedException();
        //}

        public IList<IServer> GetServer()
        {
            var list = new List<IServer>();
            var multiplexer = connectionMultiplexer.Value;
            foreach (var endPoint in multiplexer.GetEndPoints())
            {
                var server = multiplexer.GetServer(endPoint);
                if (!server.IsConnected || !server.Features.Scan)
                    continue;
                list.Add(server);
            }
            return list;
        }
    }
}
