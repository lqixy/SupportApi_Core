using AutoMapper;
using Flutter.Support.Application.TodayOnHistory;
using Flutter.Support.Domain.Dtos;
using Flutter.Support.Web.Models.Output.TodayOnHistory;
using Flutter.Support.Web.Models.ViewModel.TodayOnHistorys;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Flutter.Support.Web.Areas.TodayOnHistory
{
    /// <summary>
    /// 历史上的今天
    /// </summary>
    [Route("api/today-on-history")]
    public class TodayOnHistoryController : FlutterSupportControllerBase
    {
        private readonly ITodayOnHistoryApplicationService todayOnHistoryApplicationService;

        public TodayOnHistoryController(IMapper mapper
            , ITodayOnHistoryApplicationService todayOnHistoryApplicationService) : base(mapper)
        {
            this.todayOnHistoryApplicationService = todayOnHistoryApplicationService;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="viewModel"></param> 
        /// <returns></returns>
        [Route("query")]
        public async Task<List<TodayOnHistoryQueryOutput>> Query(TodayOnHistoryQueryViewModel viewModel)
        {
            List<TodayOnHistoryQueryDto> result = await todayOnHistoryApplicationService.Query(viewModel.Day);
            return mapper.Map<List<TodayOnHistoryQueryOutput>>(result);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="viewModel"></param> 
        /// <returns></returns>
        [Route("detail")]
        public async Task<TodayOnHistoryDetailOutput> Detail(TodayOnHistoryDetailViewModel viewModel)
        {
            TodayOnHistoryDetailDto result = await todayOnHistoryApplicationService.Detail(viewModel.Id);
            return mapper.Map<TodayOnHistoryDetailOutput>(result);
        }
    }
}
