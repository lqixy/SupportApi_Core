using Flutter.Support.Common;
using Flutter.Support.Dapper;
using Flutter.Support.Dapper.Extensions;
using Flutter.Support.Domain.IRepositories;
using Flutter.Support.Entities;
using Flutter.Support.SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Flutter.Support.Repository.Repositories
{
    public class NewsRepository :  AbstractDenormalizer, 
        INewsRepository
    {
        public NewsRepository(IConnectionStringResolver connectionStringResolver) : base(connectionStringResolver)
        {
        }

        public Task TryInsertRecordAsync(News model)
        {
            return base.TryInsertRecordAsync(async connection =>
            {
                return await connection.InsertAsync(new
                {
                    UniqueKey = model.UniqueKey,
                    Title = model.Title,
                    Category = model.Category,
                    Url = model.Url,
                    JsonData = model.JsonData,
                    AddDate = DateTime.Now,
                    DelStatus = model.DelStatus,
                    Date = model.Date
                }, TableNames.News);
            });
        }
    }
}
