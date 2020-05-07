using AutoMapper;
using Flutter.Support.Application.TodayOnHistory;
using Flutter.Support.Domain.Dtos;
using Flutter.Support.Web.Models.Output.TodayOnHistory;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
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
        /// <param name="day"></param>
        /// <returns></returns>
        [Route("query")]
        public async Task<List<TodayOnHistoryQueryOutput>> Query(string day)
        {
            List<TodayOnHistoryQueryDto> result = await todayOnHistoryApplicationService.Query(day);
            return mapper.Map<List<TodayOnHistoryQueryOutput>>(result);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("detail")]
        public async Task<TodayOnHistoryDetailOutput> Detail(int id)
        {
            TodayOnHistoryDetailDto result = await todayOnHistoryApplicationService.Detail(id);
            return mapper.Map<TodayOnHistoryDetailOutput>(result);
        }
    }
}
