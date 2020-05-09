using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Text;

namespace Flutter.Support.Redis.Cache
{
    public interface IRedisCacheDatabaseProvider
    {
        /// <summary>
        /// 连接池
        /// </summary>
        ConnectionMultiplexer ConnectionMultiplexer { get; }

        /// <summary>
        /// redis 连接对象
        /// </summary>
        /// <returns></returns>
        IDatabase GetDatabase();

        /// <summary>
        /// 获取server的连接个数
        /// </summary>
        /// <returns></returns>
        IList<IServer> GetServer();

        /// <summary>
        /// 是否从缓存内获取数据
        /// </summary>
        /// <returns></returns>
        bool IsReadForCache { get; }
    }
}
