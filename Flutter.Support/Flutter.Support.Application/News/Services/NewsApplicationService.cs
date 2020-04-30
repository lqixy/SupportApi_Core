using Flutter.Support.Domain.IApiRepositories.JuHe;
using Flutter.Support.Domain.IApiRepositories.JuHe.InputDto;
using Flutter.Support.Domain.IApiRepositories.JuHe.OutputDto;
using Flutter.Support.Domain.IRepositories;
using Flutter.Support.QueryServices.News;
using Flutter.Support.QueryServices.News.Dto;
using Flutter.Support.SqlSugar.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flutter.Support.Application.News.Services
{
    public class NewsApplicationService : INewsApplicationService
    {
        private readonly IJuHeApiRepository juHeApiRepository;
        private readonly INewsRepository newsRepository;
        private readonly INewsQueryService newsQueryService;

        public NewsApplicationService(IJuHeApiRepository juHeApiRepository
            , INewsRepository newsRepository
            , INewsQueryService newsQueryService)
        {
            this.juHeApiRepository = juHeApiRepository;
            this.newsRepository = newsRepository;
            this.newsQueryService = newsQueryService;
        }

        public void DeleteNews(int day)
        {
            var date = DateTime.Now.AddDays(Math.Abs(day)).Date;

            newsRepository.DeleteNews(date);
        }

        public async Task<NewsQueryDto> GetNews(int pageSize, int pageIndex, int type = 0)
        {
            var now = DateTime.Now;
            var firstDate = newsQueryService.GetFirstDateTime(type);

            if (firstDate == null || (now - firstDate.Value).TotalMinutes >= 30)
            {
                await InsertNews((NewsTypeEnum)type);
            }

            return await newsQueryService.GetNews(pageSize, pageIndex, type);
        }

        public async Task InsertNews(NewsTypeEnum type = NewsTypeEnum.top)
        {
            //for (int i = 0; i <= (int)NewsTypeEnum.caijing; i++)
            {
                //var currentType = (NewsTypeEnum)i;
                var input = new JuHeTopNewsInputDto { Type = type.ToString() };
                var apiResult = await juHeApiRepository.
                    GetAsync<JuHeTopNewsInputDto, JuHeTopNewsApiResultOutputDto>(input);

                if (apiResult.Success && apiResult.Result.List.Any())
                {
                    var existsNews = newsRepository.GetNews(x => x.Date.Date.Equals(DateTime.Now.Date));
                    var existsUniqueKeys = existsNews.Select(x => x.UniqueKey);

                    apiResult.Result.List.RemoveAll(x => existsUniqueKeys.Contains(x.UniqueKey));
                    newsRepository.InsertNews(apiResult.Result.List, type);
                }
            }

        }
        //public async Task NewsQuery(string type)
        //{
        //    var input = new JuHeTopNewsInputDto { Type = type };
        //    var apiResult = await juHeApiRepository.
        //        GetAsync<JuHeTopNewsInputDto, JuHeTopNewsApiResultOutputDto>(input);



        //    if (apiResult.Result.List.Any())
        //    {
        //        apiResult.Result.List.ForEach(async x =>
        //            await newsRepository.TryInsertRecordAsync(
        //            new Entities.News(x.Title,
        //                              x.UniqueKey,
        //                              x.Category,
        //                              x.Url,
        //                              x.Date,
        //                              JsonConvert.SerializeObject(x.ImageUrls),
        //                              x.AuthorName)
        //            ));
        //        //var model = new Entities.News("test", "1234", "top", "", "");
        //        //await newsRepository.TryInsertRecordAsync(model);
        //    }

        //}
    }
}
