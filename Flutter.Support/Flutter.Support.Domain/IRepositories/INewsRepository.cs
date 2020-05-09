using Flutter.Support.Domain.Dtos;
using Flutter.Support.Domain.IApiRepositories.JuHe.OutputDto;
using Flutter.Support.SqlSugar.Entities;
using Flutter.Support.SqlSugar.Enums;
using SqlSugar;
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

        News FirstOrDefault(Expression<Func<News, bool>> whereExpression,
                            Expression<Func<News, object>> orderByExpression, OrderByType orderByType = OrderByType.Desc);

        bool InsertNews(List<News> list);

        void DeleteNews(Expression<Func<News,bool>> whereExpression);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="totalCount"></param>
        /// <param name="type"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <returns></returns>
        List<News> Query(ref int totalCount, int type = 0, int pageSize = 12, int pageIndex = 1);
    }
}
