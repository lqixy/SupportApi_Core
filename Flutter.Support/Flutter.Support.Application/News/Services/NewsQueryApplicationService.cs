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

        public NewsQueryApplicationService(
            IMapper mapper
            , INewsRepository newsRepository)
        {
            this.mapper = mapper;
            this.newsRepository = newsRepository;
        }

        
    }
}
