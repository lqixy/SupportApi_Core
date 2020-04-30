using Flutter.Support.QueryServices.News.Dto;
using System;
using System.Threading.Tasks;

namespace Flutter.Support.QueryServices.News
{
    public interface INewsQueryService
    {
        DateTime? GetFirstDateTime(int type = 0);

        //Task<NewsQueryDto> QueryNews();
        Task<NewsQueryDto> GetNews(int pageSize = 12, int pageIndex = 1, int type = 0);
    }
}
