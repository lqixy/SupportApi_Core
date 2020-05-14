﻿using AutoMapper;
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
        public async Task<NewsQueryDto> Query(int pageSize = 12, int pageIndex = 1, int type = 0, string channelId = ShowApiNewsChannel.Domestic)
        {
            var dto = redisCache.GetValue<NewsQueryDto>($"{RedisTitle}{type}_{channelId}_{pageIndex}_{pageSize}");
            if (dto != null) return dto;

            var now = DateTime.Now;

            var first = newsRepository.FirstOrDefault(x => x.Type == (int)type, x => x.Date);
            if (first != null && (now - first.Date).TotalMinutes >= 30)
            {
                await newsApplicationService.InsertNews(type);
            }

            var result = GetNews(pageSize, pageIndex, type);

            redisCache.SetValue($"{RedisTitle}{type}_{pageIndex}_{pageSize}", result, TimeSpan.FromMinutes(5));
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public NewsQueryDto GetNews(int pageSize = 12, int pageIndex = 1, int type = 0)
        {

            var totalCount = 0;
            var list = newsRepository.Query(ref totalCount, type, pageSize, pageIndex);

            var result = new NewsQueryDto
            {
                TotalCount = totalCount,
                List = list.Select(x => mapper.Map<NewsInfoQueryDto>(x)).ToList()
            };
            return result;
        }
    }
}
