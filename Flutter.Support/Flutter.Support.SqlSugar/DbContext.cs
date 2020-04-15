using Flutter.Support.Entities;
using Flutter.Support.Extension.Configurations;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;

namespace Flutter.Support.SqlSugar
{
    public class DbContext<T> where T : class, new()
    {
        public SqlSugarClient Db;

        public DbContext()
        {
            Db = new SqlSugarClient(new ConnectionConfig()
            {
                ConnectionString = ConfigHelper.GetConnectionString("Default"),
                DbType = DbType.SqlServer,
                InitKeyType = InitKeyType.Attribute,//从特性读取主键和自增列信息
                IsAutoCloseConnection = true,//开启自动释放模式和EF原理一样我就不多解释了

            });
        }

        public SimpleClient<News> NewsDb { get { return new SimpleClient<News>(Db); } }

        public SimpleClient<T> CurrentDb => new SimpleClient<T>(Db);
    }
}
