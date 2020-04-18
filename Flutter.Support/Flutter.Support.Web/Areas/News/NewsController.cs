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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mapper"></param>
        /// <param name="newsQueryService"></param>
        public NewsController(IMapper mapper
            , INewsQueryService newsQueryService) : base(mapper)
        {
            this.newsQueryService = newsQueryService;
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
