using Flutter.Support.SqlSugar.Enums;
using System.Threading.Tasks;

namespace Flutter.Support.Application.News.Services
{
    public interface INewsApplicationService
    {
        //Task  NewsQuery(string type);

        Task InsertNews(NewsTypeEnum type = NewsTypeEnum.top);
    }
}
