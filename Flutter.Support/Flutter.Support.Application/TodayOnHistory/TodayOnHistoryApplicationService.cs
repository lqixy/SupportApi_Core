using AutoMapper;
using Flutter.Support.Domain.Dtos;
using Flutter.Support.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Flutter.Support.Application.TodayOnHistory
{
    public class TodayOnHistoryApplicationService : ITodayOnHistoryApplicationService
    {
        private readonly IMapper mapper;
        private readonly ITodayOnHistoryRepository todayOnHistoryRepository;

        public TodayOnHistoryApplicationService(
            IMapper mapper
            , ITodayOnHistoryRepository todayOnHistoryRepository)
        {
            this.mapper = mapper;
            this.todayOnHistoryRepository = todayOnHistoryRepository;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<TodayOnHistoryDetailDto> Detail(int id)
        {
            SqlSugar.Entities.TodayOnHistoryDetail model = todayOnHistoryRepository.Detail(id);
            return mapper.Map<TodayOnHistoryDetailDto>(model);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="day"></param>
        /// <returns></returns>
        public async Task<List<TodayOnHistoryQueryDto>> Query(string day)
        {
            List<SqlSugar.Entities.TodayOnHistory> list = todayOnHistoryRepository.Query(day);
            return mapper.Map<List<TodayOnHistoryQueryDto>>(list);
        }
    }
}
