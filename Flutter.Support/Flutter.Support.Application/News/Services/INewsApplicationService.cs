using Flutter.Support.Domain.Dtos;
using Flutter.Support.SqlSugar.Enums;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Flutter.Support.Application.News.Services
{
    public interface INewsApplicationService
    {
        //Task  NewsQuery(string type);
        /// <summary>
        /// 插入新闻
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        Task InsertNews(int type = 0);
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        void DeleteNews(Expression<Func<SqlSugar.Entities.News, bool>> whereExpression);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        Task<NewsQueryDto> Query(int pageSize, int pageIndex, int type = 0);

    }
}
