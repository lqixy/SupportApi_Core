using AutoMapper;
using Flutter.Support.Application.News.Dtos;
using Flutter.Support.Application.News.Services;
using Flutter.Support.Web.Filters;
using Flutter.Support.Web.Models.Output.News;
using Flutter.Support.Web.Models.ViewModel;
using log4net;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace Flutter.Support.Web.Areas.News
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/news")]
    public class NewsController : FlutterSupportControllerBase
    {
        private readonly INewsApplicationService newsApplicationService;
        private readonly IMapper mapper;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="newsApplicationService"></param>
        /// <param name="mapper"></param>
        public NewsController(INewsApplicationService newsApplicationService
            , IMapper mapper)
        {
            this.newsApplicationService = newsApplicationService;
            this.mapper = mapper;
        }
        /// <summary>
        /// 新闻查询
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("query")]
        public async Task<NewsQueryOutput> NewsQuery(NewsQueryViewModel viewModel)
        {
            var dto = await newsApplicationService.NewsQuery(viewModel.type);
            var result = mapper.Map<NewsQueryOutput>(dto);
            return result;
        }

    }
}
