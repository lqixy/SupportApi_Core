using AutoMapper;
using Flutter.Support.Application.News.ShowApiChannels;
using Flutter.Support.Domain.Dtos;
using Flutter.Support.Domain.IRepositories;
using Flutter.Support.Redis.Cache;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flutter.Support.Application.News.Services
{
    public class NewsQueryApplicationService : INewsQueryApplicationService
    {
        private const string RedisTitle = "News:";

        private readonly IMapper mapper;
        private readonly INewsRepository newsRepository;
        private readonly INewsApplicationService newsApplicationService;
        private readonly IRedisCache redisCache;

        public NewsQueryApplicationService(
            IMapper mapper
            , INewsRepository newsRepository
            , INewsApplicationService newsApplicationService
            , IRedisCache redisCache)
        {
            this.mapper = mapper;
            this.newsRepository = newsRepository;
            this.newsApplicationService = newsApplicationService;
            this.redisCache = redisCache;
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public async Task<NewsQueryDto> Query(string channelId = ShowApiNewsChannel.Domestic,
                                              int type = 0,
                                              int pageIndex = 1,
                                              int pageSize = 20)
        {
            var redisKey = $"{RedisTitle}{type}{channelId}_{pageIndex}_{pageSize}";

            var dto = redisCache.GetValue<NewsQueryDto>(redisKey);
            if (dto != null && dto.List.Any()) return dto;

            var now = DateTime.Now;

            var first = newsRepository.FirstOrDefault(x => x.ChannelId == channelId && x.Type == type, x => x.Date);
            if (first == null || (first != null && (now - first.Date).TotalMinutes >= 30))
            {
                await newsApplicationService.InsertNews(channelId, type, pageIndex, pageSize);
            }

            var result = GetNews(channelId, pageIndex, pageSize);

            redisCache.SetValue(redisKey, result, TimeSpan.FromMinutes(5));
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public NewsQueryDto GetNews(string channelId = ShowApiNewsChannel.Domestic,
                                    int type = 0,
                                    int pageIndex = 1,
                                    int pageSize = 20)
        {

            var totalCount = 0;
            var list = newsRepository.Query(channelId, type, ref totalCount, pageSize, pageIndex);

            var result = new NewsQueryDto
            {
                TotalCount = totalCount,
                List = list.Select(x => mapper.Map<NewsInfoQueryDto>(x)).ToList()
            };
            return result;
        }
    }
}
