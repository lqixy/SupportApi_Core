﻿using Flutter.Support.Domain.IRepositories;
using Flutter.Support.SqlSugar;
using Flutter.Support.SqlSugar.Entities;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Flutter.Support.Repository.Repositories
{
    public class NewsRepository : SugarDbContext<News>,// AbstractDenormalizer, 
        INewsRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="whereExpression"></param>
        public void DeleteNews(Expression<Func<News, bool>> whereExpression)
        {
            CurrentDb.Delete(whereExpression);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="whereExpression"></param>
        /// <param name="orderByExpression"></param>
        /// <param name="orderByType"></param>
        /// <returns></returns>
        public News FirstOrDefault(Expression<Func<News, bool>> whereExpression,
                                   Expression<Func<News, object>> orderByExpression,
                                   OrderByType orderByType = OrderByType.Desc)
        {
            return Db.Queryable<News>().OrderBy(orderByExpression, orderByType).First(whereExpression);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="whereExpression"></param>
        /// <returns></returns>
        public IEnumerable<News> GetNews(Expression<Func<News, bool>> whereExpression)
        {
            return CurrentDb.GetList(whereExpression);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="list"></param>
        /// <param name="type"></param>
        public bool InsertNews(List<News> list)
        {
            return CurrentDb.InsertRange(list);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<News> Query(ref int totalCount, int type = 0, int pageSize = 12, int pageIndex = 1)
        {
            var pageModel = new PageModel { PageIndex = pageIndex, PageSize = pageSize };
            var list = CurrentDb.GetPageList(x => x.Type == (int)type, pageModel, x => x.Date, OrderByType.Desc);
            totalCount = pageModel.PageCount;

            return list;
        }
    }
}
