using Dapper;
using Flutter.Support.Dapper;
using Flutter.Support.QueryServices.News;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Flutter.Support.QueryServices.Dapper.News
{
    public class NewsQueryService : AbstractDomains, INewsQueryService
    {
        public NewsQueryService(IConnectionStringResolver connectionStringResolver) : base(connectionStringResolver)
        {
        }

        public async Task QueryNews()
        {
            var sql = "select * from News;";

            using (var connection = GetDbConnection())
            {
                var result = await connection.QueryAsync(sql);
            }
        }
    }
}
