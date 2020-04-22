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
        public void DeleteNews(DateTime date)
        {
            CurrentDb.Delete(x => x.AddDate <= date);
        }

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
