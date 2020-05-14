using AutoMapper;
using Flutter.Support.Application.News.ShowApiChannels;
using Flutter.Support.Domain.Dtos;
using Flutter.Support.Domain.IApiRepositories.JuHe;
using Flutter.Support.Domain.IApiRepositories.JuHe.InputDto;
using Flutter.Support.Domain.IApiRepositories.JuHe.OutputDto;
using Flutter.Support.Domain.IApiRepositories.ShowApi;
using Flutter.Support.Domain.IApiRepositories.ShowApi.InputDto;
using Flutter.Support.Domain.IApiRepositories.ShowApi.OutputDto;
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
        private readonly IShowApiRepository showApiRepository;

        public NewsApplicationService(IJuHeApiRepository juHeApiRepository
            , INewsRepository newsRepository
            , IShowApiRepository showApiRepository
            )
        {
            this.juHeApiRepository = juHeApiRepository;
            this.newsRepository = newsRepository;
            this.showApiRepository = showApiRepository;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="day"></param>
        public void DeleteNews(Expression<Func<SqlSugar.Entities.News, bool>> whereExpression)
        {
            newsRepository.DeleteNews(whereExpression);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public async Task InsertNews(string channelId = ShowApiNewsChannel.Domestic, int pageIndex = 1, int pageSize = 20)
        {
            #region JuHe
            //for (int i = 0; i <= (int)NewsTypeEnum.caijing; i++)
            //{
            //var currentType = (NewsTypeEnum)i;
            //var input = new JuHeTopNewsInputDto { Type = type.ToString() };
            //var apiResult = await juHeApiRepository.
            //    GetAsync<JuHeTopNewsInputDto, JuHeTopNewsApiResultOutputDto>(input);

            //if (apiResult.Success && apiResult.Result.List.Any())
            //{
            //    var existsNews = newsRepository.GetNews(x => x.Date.Date.Equals(DateTime.Now.Date));
            //    var existsUniqueKeys = existsNews.Select(x => x.UniqueKey);

            //    apiResult.Result.List.RemoveAll(x => existsUniqueKeys.Contains(x.UniqueKey));
            //    newsRepository.InsertNews(apiResult.Result.List.Select(x => new SqlSugar.Entities.News(x.Title,
            //                                                x.UniqueKey,
            //                                                x.Category,
            //                                                x.Url,
            //                                                x.Date,
            //                                                JsonConvert.SerializeObject(x.ImageUrls),
            //                                                x.AuthorName, type)).ToList());
            //}
            //} 
            #endregion

            #region ShowApi
            //var channelId = ShowApiNewsChannel.DomesticNew;
            var input = new ShowApiNewsInputDto(channelId, page: pageIndex, maxResult: pageSize);

            var apiResult = await showApiRepository.GetAsync<ShowApiNewsInputDto
                , ShowApiOutputDtoBase<ShowApiNewsOutputDto>>(input, false);

            if (apiResult.Success)
            {
                var existsList = newsRepository.GetNews(x => x.Date.Date.Equals(DateTime.Now.Date) && x.ChannelId == channelId);
                var existsUniqueKeys = existsList.Select(x => x.UniqueKey);

                apiResult.Showapi_Res_Body.PageBean.ContentList.RemoveAll(x => existsUniqueKeys.Contains(x.Id));

                newsRepository.InsertNews(apiResult.Showapi_Res_Body.PageBean.ContentList
                    .Select(x => new SqlSugar.Entities.News(x.Title, x.Id, x.ChannelName, x.Link, x.PubDate,
                    JsonConvert.SerializeObject(x.ImageUrls), x.Source, 0, channelId, x.Desc)).ToList());
            }
            #endregion

        }
    }
}
