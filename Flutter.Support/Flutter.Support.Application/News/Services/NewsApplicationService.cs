using Flutter.Support.Application.News.Dtos;
using Flutter.Support.Domain.IApiRepositories.JuHe;
using Flutter.Support.Domain.IApiRepositories.JuHe.InputDto;
using Flutter.Support.Domain.IApiRepositories.JuHe.OutputDto;
using Flutter.Support.Domain.IRepositories;
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

        public NewsApplicationService(IJuHeApiRepository juHeApiRepository
            ,INewsRepository  newsRepository)
        {
            this.juHeApiRepository = juHeApiRepository;
            this.newsRepository = newsRepository;
        }
        public async Task  NewsQuery(string type)
        {
            var input = new JuHeTopNewsInputDto { Type = type };
            var apiResult = await juHeApiRepository.
                GetAsync<JuHeTopNewsInputDto, JuHeTopNewsApiResultOutputDto>(input);



            //return new NewsQueryDto
            //{
            //    TotalCount = apiResult.Result.List.Count,
            //    News = apiResult.Result.List.Select(x => new NewsInfoDto
            //    {
            //        UniqueKey = x.UniqueKey,
            //        AuthorName = x.AuthorName,
            //        Category = x.Category,
            //        ImageUrls = x.ImageUrls,
            //        Date = x.Date,
            //        Title = x.Title,
            //        Url = x.Url
            //    })
            //};
        }
    }
}
