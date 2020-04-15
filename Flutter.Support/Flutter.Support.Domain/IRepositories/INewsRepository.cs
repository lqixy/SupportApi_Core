using Flutter.Support.Domain.IApiRepositories.JuHe.OutputDto;
using Flutter.Support.SqlSugar.Entities;
using Flutter.Support.SqlSugar.Enums;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Flutter.Support.Domain.IRepositories
{
    public interface INewsRepository
    {
        IEnumerable<News> GetNews(Expression<Func<News, bool>> whereExpression);

        //Task TryInsertRecordAsync(News model);

        void InsertNews(List<JuHeNewsInfoOutDto> list,NewsTypeEnum type);
    }
}
