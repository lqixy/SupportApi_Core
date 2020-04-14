using Flutter.Support.Common;
using Flutter.Support.Dapper;
using Flutter.Support.Dapper.Extensions;
using Flutter.Support.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Flutter.Support.Repository.Repositories
{
    public class NewsRepository : AbstractDenormalizer, INewsRepository
    {
        public NewsRepository(IConnectionStringResolver connectionStringResolver) : base(connectionStringResolver)
        {
        }

        public Task TryInsertRecordAsync()
        {
            return base.TryInsertRecordAsync(async connection =>
            {
                return await connection.InsertAsync(new
                {
                    UniqueKey = "",
                    Title = "",
                    Category = "",
                    Url = "",
                    JsonData = "",
                    AddDate = DateTime.Now
                }, TableNames.News);
            });
        }
    }
}
