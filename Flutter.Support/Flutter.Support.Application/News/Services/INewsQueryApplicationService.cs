using Flutter.Support.Application.News.ShowApiChannels;
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
        NewsQueryDto GetNews(string channelId = ShowApiNewsChannel.Domestic, int pageIndex = 1, int pageSize = 20);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        Task<NewsQueryDto> Query(string channelId = ShowApiNewsChannel.Domestic, int pageIndex=1, int pageSize=20 );
    }
}
