using AutoMapper;
using Flutter.Support.Application.News.Dtos;
using Flutter.Support.Application.News.Services;
using Flutter.Support.Web.Models.Output.News;
using Flutter.Support.Web.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Flutter.Support.Web.Areas.News
{
    [ApiController]
    [Route("api/news")]
    public class NewsController : ControllerBase
    {
        private readonly INewsApplicationService newsApplicationService;
        private readonly IMapper mapper;

        public NewsController(INewsApplicationService newsApplicationService
            , IMapper mapper)
        {
            this.newsApplicationService = newsApplicationService;
            this.mapper = mapper;
        }

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
