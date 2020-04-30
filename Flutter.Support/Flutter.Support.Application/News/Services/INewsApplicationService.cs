using Flutter.Support.QueryServices.News.Dto;
using Flutter.Support.SqlSugar.Enums;
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
        Task InsertNews(NewsTypeEnum type = NewsTypeEnum.top);
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        void DeleteNews(int day);

        Task<NewsQueryDto> GetNews(int pageSize, int pageIndex, int type = 0);
    }
}
