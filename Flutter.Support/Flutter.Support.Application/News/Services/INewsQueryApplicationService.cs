using Flutter.Support.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Flutter.Support.Application.News.Services
{
    public interface INewsQueryApplicationService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="type"></param>
        NewsQueryDto GetNews(int pageSize = 12, int pageIndex = 1, int type = 0);

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
