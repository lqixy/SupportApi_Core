using AutoMapper;
using Flutter.Support.Domain.Dtos;
using Flutter.Support.Domain.IApiRepositories.JuHe;
using Flutter.Support.Domain.IApiRepositories.JuHe.InputDto;
using Flutter.Support.Domain.IApiRepositories.JuHe.OutputDto;
using Flutter.Support.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flutter.Support.Application.TodayOnHistory
{
    public class TodayOnHistoryApplicationService : ITodayOnHistoryApplicationService
    {
        private readonly IMapper mapper;
        private readonly ITodayOnHistoryRepository todayOnHistoryRepository;
        private readonly IJuHeApiRepository juHeApiRepository;

        public TodayOnHistoryApplicationService(
            IMapper mapper
            , ITodayOnHistoryRepository todayOnHistoryRepository
            , IJuHeApiRepository juHeApiRepository)
        {
            this.mapper = mapper;
            this.todayOnHistoryRepository = todayOnHistoryRepository;
            this.juHeApiRepository = juHeApiRepository;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<TodayOnHistoryDetailDto> Detail(int id)
        {
            var model = todayOnHistoryRepository.Detail(id);
            if (model == null)
            {
                await InsertDetail(id);

                model = todayOnHistoryRepository.Detail(id);
            }
            return mapper.Map<TodayOnHistoryDetailDto>(model);
        }

        private async Task InsertDetail(int id)
        {
            var input = new JuHeTodayOnHistoryDetailInputDto { E_Id = id };
            var apiResult = await juHeApiRepository.GetAsync<JuHeTodayOnHistoryDetailInputDto, JuHeTodayOnHistoryDetailOutputDto>(input);

            if (apiResult.Success)
            {
                var info = apiResult.Result.First();
                todayOnHistoryRepository.InsertDetail(new SqlSugar.Entities.TodayOnHistoryDetail(id, info.Content));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="day"></param>
        /// <returns></returns>
        public async Task<List<TodayOnHistoryQueryDto>> Query(string day)
        {
            var list = todayOnHistoryRepository.Query(day);
            if (!list.Any())
            {
                await Insert(day);

                list = todayOnHistoryRepository.Query(day);
            }
            return mapper.Map<List<TodayOnHistoryQueryDto>>(list);
        }

        public async Task Insert(string day)
        {
            var input = new JuHeTodayOnHistoryInputDto { Date = day };
            var apiResult = await juHeApiRepository.GetAsync<JuHeTodayOnHistoryInputDto, JuHeTodayOnHistoryOutputDto>(input);

            if (apiResult.Success)
            {
                var list = apiResult.Result.Select(x => new SqlSugar.Entities.TodayOnHistory(
                    x.E_Id, x.Day, x.Date, x.Title)).ToList();

                todayOnHistoryRepository.InsertRange(list);
            }
        }
    }
}
