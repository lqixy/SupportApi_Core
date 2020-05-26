using Flutter.Support.SqlSugar.Entities;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Flutter.Support.Domain.IRepositories
{
    public interface INewsRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="whereExpression"></param>
        /// <returns></returns>
        IEnumerable<News> GetNews(Expression<Func<News, bool>> whereExpression);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="whereExpression"></param>
        /// <param name="orderByExpression"></param>
        /// <param name="orderByType"></param>
        /// <returns></returns>
        News FirstOrDefault(Expression<Func<News, bool>> whereExpression,
                            Expression<Func<News, object>> orderByExpression,
                            OrderByType orderByType = OrderByType.Desc);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        bool InsertNews(List<News> list);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="whereExpression"></param>
        void DeleteNews(Expression<Func<News, bool>> whereExpression);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="totalCount"></param>
        /// <param name="type"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <returns></returns>
        List<News> Query(string channelId,
                         int type,
                         ref int totalCount,
                         int pageSize = 12,
                         int pageIndex = 1);
    }
}
