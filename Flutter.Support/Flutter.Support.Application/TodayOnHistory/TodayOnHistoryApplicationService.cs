using AutoMapper;
using Flutter.Support.Domain.Dtos;
using Flutter.Support.Domain.IApiRepositories.JuHe;
using Flutter.Support.Domain.IApiRepositories.JuHe.InputDto;
using Flutter.Support.Domain.IApiRepositories.JuHe.OutputDto;
using Flutter.Support.Domain.IRepositories;
using Flutter.Support.Redis.Cache;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flutter.Support.Application.TodayOnHistory
{
    public class TodayOnHistoryApplicationService : ITodayOnHistoryApplicationService
    {
        private const string RedisTitle = "TodayOnHistory:";

        private readonly IMapper mapper;
        private readonly ITodayOnHistoryRepository todayOnHistoryRepository;
        private readonly IJuHeApiRepository juHeApiRepository;
        private readonly IRedisCache redisCache;

        public TodayOnHistoryApplicationService(
            IMapper mapper
            , ITodayOnHistoryRepository todayOnHistoryRepository
            , IJuHeApiRepository juHeApiRepository
            , IRedisCache redisCache)
        {
            this.mapper = mapper;
            this.todayOnHistoryRepository = todayOnHistoryRepository;
            this.juHeApiRepository = juHeApiRepository;
            this.redisCache = redisCache;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<TodayOnHistoryDetailDto> Detail(int id)
        {
            var dto = redisCache.GetValue<TodayOnHistoryDetailDto>($"{RedisTitle}{id}");
            if (dto != null) return dto;

            var model = todayOnHistoryRepository.Detail(id);
            if (model == null)
            {
                await InsertDetail(id);

                model = todayOnHistoryRepository.Detail(id);
            }
            var result = mapper.Map<TodayOnHistoryDetailDto>(model);

            redisCache.SetValue($"{RedisTitle}{id}", result, TimeSpan.FromDays(180));

            return result;
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
            var dtos = redisCache.GetValue<List<TodayOnHistoryQueryDto>>($"{RedisTitle}{day}");
            if (dtos != null) return dtos;

            var list = todayOnHistoryRepository.Query(day);
            if (!list.Any())
            {
                await Insert(day);

                list = todayOnHistoryRepository.Query(day);
            }
            var result = mapper.Map<List<TodayOnHistoryQueryDto>>(list);

            redisCache.SetValue($"{RedisTitle}{day}", result, TimeSpan.FromDays(180));
            return result;
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
