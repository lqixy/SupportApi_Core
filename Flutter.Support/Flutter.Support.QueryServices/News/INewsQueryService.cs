using Flutter.Support.QueryServices.News.Dto;
using System.Threading.Tasks;

namespace Flutter.Support.QueryServices.News
{
    public interface INewsQueryService
    {
        //Task<NewsQueryDto> QueryNews();
        Task<NewsQueryDto> GetNews(int pageSize, int pageIndex, int type);
    }
}
