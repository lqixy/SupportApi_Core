using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;

namespace Flutter.Support.Dapper
{
    public class SqlServerDbProviderFactory : IDbProviderFactory
    {
        private readonly IConnectionStringResolver connectionStringResolver;

        public SqlServerDbProviderFactory(IConnectionStringResolver connectionStringResolver)
        {
            this.connectionStringResolver = connectionStringResolver;
        }
        public DbProviderFactory DbFactory => SqlClientFactory.Instance;

        public string ConnectionString => connectionStringResolver.GetConnectionString();
    }
}
