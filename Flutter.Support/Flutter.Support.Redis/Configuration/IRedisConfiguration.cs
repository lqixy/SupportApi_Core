using System;
using System.Collections.Generic;
using System.Text;

namespace Flutter.Support.Redis.Configuration
{
    public interface IRedisConfiguration
    {
        /// <summary>
        /// 组合redis key值
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        string GroupKeys(params string[] key);


        /// <summary>
        /// 组合redis key值
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        string GroupKeys(List<string> keys);
    }
}
