using AutoMapper;
using Flutter.Support.Domain.Dtos;
using Flutter.Support.Domain.IApiRepositories.JuHe;
using Flutter.Support.Domain.IApiRepositories.JuHe.InputDto;
using Flutter.Support.Domain.IApiRepositories.JuHe.OutputDto;
using Flutter.Support.Domain.IRepositories;
using Flutter.Support.SqlSugar.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Flutter.Support.Application.News.Services
{
    public class NewsApplicationService : INewsApplicationService
    {
        private readonly IJuHeApiRepository juHeApiRepository;
        private readonly INewsRepository newsRepository;

        public NewsApplicationService(IJuHeApiRepository juHeApiRepository
            , INewsRepository newsRepository
            )
        {
            this.juHeApiRepository = juHeApiRepository;
            this.newsRepository = newsRepository;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="day"></param>
        public void DeleteNews(Expression<Func<SqlSugar.Entities.News,bool>> whereExpression)
        {
            newsRepository.DeleteNews(whereExpression);
        }

        ///// <summary>
        ///// 查询
        ///// </summary>
        ///// <param name="pageSize"></param>
        ///// <param name="pageIndex"></param>
        ///// <param name="type"></param>
        ///// <returns></returns>
        //public async Task<NewsQueryDto> Query(int pageSize = 12, int pageIndex = 1, int type = 0)
        //{
        //    var now = DateTime.Now;

        //    var first = newsRepository.FirstOrDefault(x => x.Type == (int)type, x => x.Date);
        //    if (first != null && (now - first.Date).TotalMinutes >= 30)
        //    {
        //        await InsertNews(type);
        //    }

        //    return GetNews(pageSize, pageIndex, type); 
        //}

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="pageSize"></param>
        ///// <param name="pageIndex"></param>
        ///// <param name="type"></param>
        ///// <returns></returns>
        //public NewsQueryDto GetNews(int pageSize = 12, int pageIndex = 1, int type = 0)
        //{

        //    var totalCount = 0;
        //    var list = newsRepository.Query(ref totalCount, type, pageSize, pageIndex);

        //    var result = new NewsQueryDto
        //    {
        //        TotalCount = totalCount,
        //        List = list.Select(x => mapper.Map<NewsInfoQueryDto>(x)).ToList()
        //    };
        //    return result;
        //}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public async Task InsertNews(int type = 0)
        {
            //for (int i = 0; i <= (int)NewsTypeEnum.caijing; i++)
            //{
            //var currentType = (NewsTypeEnum)i;
            var input = new JuHeTopNewsInputDto { Type = type.ToString() };
            var apiResult = await juHeApiRepository.
                GetAsync<JuHeTopNewsInputDto, JuHeTopNewsApiResultOutputDto>(input);

            if (apiResult.Success && apiResult.Result.List.Any())
            {
                var existsNews = newsRepository.GetNews(x => x.Date.Date.Equals(DateTime.Now.Date));
                var existsUniqueKeys = existsNews.Select(x => x.UniqueKey);

                apiResult.Result.List.RemoveAll(x => existsUniqueKeys.Contains(x.UniqueKey));
                newsRepository.InsertNews(apiResult.Result.List.Select(x => new SqlSugar.Entities.News(x.Title,
                                                            x.UniqueKey,
                                                            x.Category,
                                                            x.Url,
                                                            x.Date,
                                                            JsonConvert.SerializeObject(x.ImageUrls),
                                                            x.AuthorName, type)).ToList());
            }
            //}

        }
    }
}
