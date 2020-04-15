using Flutter.Support.Common;
using Flutter.Support.Dapper;
using Flutter.Support.Dapper.Extensions;
using Flutter.Support.Domain.IApiRepositories.JuHe.OutputDto;
using Flutter.Support.Domain.IRepositories;
using Flutter.Support.SqlSugar;
using Flutter.Support.SqlSugar.Entities;
using Flutter.Support.SqlSugar.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Flutter.Support.Repository.Repositories
{
    public class NewsRepository : DbContext<News>,// AbstractDenormalizer, 
        INewsRepository
    {
        //public NewsRepository(IConnectionStringResolver connectionStringResolver) : base(connectionStringResolver)
        //{
        //}

        //public Task TryInsertRecordAsync(News model)
        //{
        //    return base.TryInsertRecordAsync(async connection =>
        //    {
        //        return await connection.InsertAsync(new
        //        {
        //            UniqueKey = model.UniqueKey,
        //            Title = model.Title,
        //            Category = model.Category,
        //            Url = model.Url,
        //            JsonData = model.JsonData,
        //            AddDate = DateTime.Now,
        //            DelStatus = model.DelStatus,
        //            Date = model.Date
        //        }, TableNames.News);
        //    });
        //}

        public IEnumerable<News> GetNews(Expression<Func<News, bool>> whereExpression)
        {
            return CurrentDb.GetList(whereExpression);
        }

        public void InsertNews(List<JuHeNewsInfoOutDto> list, NewsTypeEnum type)
        {
            CurrentDb.InsertRange(list.Select(x => new News(x.Title,
                                                            x.UniqueKey,
                                                            x.Category,
                                                            x.Url,
                                                            x.Date,
                                                            JsonConvert.SerializeObject(x.ImageUrls),
                                                            x.AuthorName, type)).ToList());

        }
    }
}
