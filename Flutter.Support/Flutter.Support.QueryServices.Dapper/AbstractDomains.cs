using Flutter.Support.Dapper;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;

namespace Flutter.Support.QueryServices.Dapper
{
  public class AbstractDomains
    {
        protected IConnectionStringResolver ConnectionStringResolver { get; }

        public AbstractDomains(IConnectionStringResolver connectionStringResolver)
        {
            ConnectionStringResolver = connectionStringResolver;
        }

        protected DbConnection GetDbConnection()
        {
            return new SqlConnection(ConnectionStringResolver.GetConnectionString());
        }

    }
}
