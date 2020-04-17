using Flutter.Support.QueryServices.News;
using Flutter.Support.QueryServices.News.Dto;
using Flutter.Support.SqlSugar;
using SqlSugar;
using System.Threading.Tasks;

namespace Flutter.Support.QueryServices.Dapper.News
{
    public class NewsQueryService : DbContext<SqlSugar.Entities.News>,//AbstractDomains, 
        INewsQueryService
    {
        //public NewsQueryService(IConnectionStringResolver connectionStringResolver) : base(connectionStringResolver)
        //{
        //}

        //public async Task<NewsQueryDto> QueryNews()
        //{
        //    //var sql = "select count(*) from News;   select * from News;";

        //    var result = new NewsQueryDto();

        //    //using var connection = GetDbConnection();
        //    //using var multi = await connection.QueryMultipleAsync(sql);
        //    //result.TotalCount = multi.Read<int?>().FirstOrDefault() ?? 0;
        //    //result.List = multi.Read<NewsInfoQueryDto>();

        //    return result;
        //}
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<NewsQueryDto> GetNews(int pageSize=12, int pageIndex=1, int type=0)
        {
            var totalCount = 0;
            var list = Db.Queryable<NewsInfoQueryDto>().Where(x => x.Type == type).AS("News")
                .OrderBy(x => x.Date, OrderByType.Desc).ToPageList(pageIndex, pageSize, ref totalCount);

            var result = new NewsQueryDto
            {
                TotalCount = totalCount,
                List = list
            };
            return result;
        }
    }
}
