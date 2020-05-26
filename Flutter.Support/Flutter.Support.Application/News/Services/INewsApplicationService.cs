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
        Task InsertNews(string channelId, int type, int pageIndex = 1, int pageSize = 20);
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        void DeleteNews(Expression<Func<SqlSugar.Entities.News, bool>> whereExpression);
        
    }
}
