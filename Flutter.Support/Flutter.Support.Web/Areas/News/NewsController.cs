using AutoMapper;
using Flutter.Support.Application.News.Services;
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
        private readonly INewsQueryApplicationService newsApplicationService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mapper"></param>
        /// <param name="newsApplicationService"></param> 
        public NewsController(IMapper mapper
            , INewsQueryApplicationService newsApplicationService) : base(mapper)
        {
            this.newsApplicationService = newsApplicationService;
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
            var result = await newsApplicationService.Query(viewModel.PageSize, viewModel.PageIndex, (int)viewModel.Type);
            return mapper.Map<NewsQueryOutput>(result);
        }

    }
}
