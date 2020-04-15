using AutoMapper;
using Flutter.Support.Application.News.Services;
using Flutter.Support.QueryServices.News;
using Flutter.Support.Web.Filters;
using Flutter.Support.Web.Models.Output;
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
        private readonly INewsQueryService newsQueryService;
        private readonly IMapper mapper;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="newsApplicationService"></param>
        /// <param name="newsQueryService"></param>
        /// <param name="mapper"></param>
        public NewsController(INewsQueryService newsQueryService
            , IMapper mapper)
        {
            this.newsQueryService = newsQueryService;
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
            var result = await newsQueryService.GetNews(viewModel.PageSize, viewModel.PageIndex, (int)viewModel.Type);
            return mapper.Map<NewsQueryOutput>(result);
        }

    }
}
