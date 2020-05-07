using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace Flutter.Support.Dapper
{
   public interface IDbProviderFactory
    {
        /// <summary>
        /// DbFactory
        /// </summary>
        DbProviderFactory DbFactory { get; }
        /// <summary>
        /// 连接字符串
        /// </summary>
        string ConnectionString { get; }
    }
}
