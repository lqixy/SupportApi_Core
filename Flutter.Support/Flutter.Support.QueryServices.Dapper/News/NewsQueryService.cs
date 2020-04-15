using Dapper;
using Flutter.Support.Dapper;
using Flutter.Support.QueryServices.News;
using Flutter.Support.QueryServices.News.Dto;
using Flutter.Support.SqlSugar;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flutter.Support.QueryServices.Dapper.News
{
    public class NewsQueryService : DbContext<Entities.News>,//AbstractDomains, 
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
        public async Task<List<Entities.News>> GetNews()
        {
            //var result = CurrentDb.GetList();
            var result = new NewsQueryDto();
            result.TotalCount = CurrentDb.Count(x => !x.DelStatus);
            result.List = Db.Queryable<NewsInfoQueryDto>().AS("News").ToList();
            return new List<Entities.News>();
        }
    }
}
