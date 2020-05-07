using AutoMapper;
using Flutter.Support.Domain.Dtos;
using Flutter.Support.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flutter.Support.Application.News.Services
{
    public class NewsQueryApplicationService : INewsQueryApplicationService
    {
        private readonly IMapper mapper;
        private readonly INewsRepository newsRepository;
        private readonly INewsApplicationService newsApplicationService;

        public NewsQueryApplicationService(
            IMapper mapper
            , INewsRepository newsRepository
            , INewsApplicationService newsApplicationService)
        {
            this.mapper = mapper;
            this.newsRepository = newsRepository;
            this.newsApplicationService = newsApplicationService;
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public async Task<NewsQueryDto> Query(int pageSize = 12, int pageIndex = 1, int type = 0)
        {
            var now = DateTime.Now;

            var first = newsRepository.FirstOrDefault(x => x.Type == (int)type, x => x.Date);
            if (first != null && (now - first.Date).TotalMinutes >= 30)
            {
                await newsApplicationService.InsertNews(type);
            }

            return GetNews(pageSize, pageIndex, type);
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
