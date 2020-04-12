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
    [ApiController]
    [Route("api/news")]
    [ApiReceivedLogActionFilterAttribute]
    public class NewsController : ControllerBase
    {
        private readonly INewsApplicationService newsApplicationService;
        private readonly IMapper mapper;
        //private ILog log = LogManager.GetLogger(Startup.Repository.Name, typeof(NewsController));
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

        /// <summary>
        /// 新闻查询
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("throw")]
        public async Task<NewsQueryOutput> ExceptionTest(NewsQueryViewModel viewModel)
        {
            //var dto = await newsApplicationService.NewsQuery(viewModel.type);
            //var result = mapper.Map<NewsQueryOutput>(dto);
            //return result;
            throw new System.Exception("异常测试");
        }
    }
}
