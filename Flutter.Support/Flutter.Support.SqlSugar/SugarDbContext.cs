﻿using Flutter.Support.Common.Strings;
using Flutter.Support.Extension.Configurations;
using Flutter.Support.SqlSugar.Entities;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;

namespace Flutter.Support.SqlSugar
{
    public class SugarDbContext<T> where T : class, new()
    {
        public SqlSugarClient Db;

        public SugarDbContext()
        {
            var dbTypeStr = ConfigHelper.Get("SqlConfig:DbType");
            Enum.TryParse(dbTypeStr, out DbType dbType);
            Db = new SqlSugarClient(new ConnectionConfig()
            {
                ConnectionString = ConfigHelper.GetConnectionString(dbTypeStr),
                DbType = dbType,// DbType.SqlServer,
                InitKeyType = InitKeyType.Attribute,//从特性读取主键和自增列信息
                IsAutoCloseConnection = true,//开启自动释放模式和EF原理一样我就不多解释了

            });
        }

        public SimpleClient<News> NewsDb { get { return new SimpleClient<News>(Db); } }

        public SimpleClient<Weather> WeatherDb { get { return new SimpleClient<Weather>(Db); } }

        public SimpleClient<T> CurrentDb => new SimpleClient<T>(Db);
    }
}
