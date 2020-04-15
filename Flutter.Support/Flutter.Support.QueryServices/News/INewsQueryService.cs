using Flutter.Support.QueryServices.News.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Flutter.Support.QueryServices.News
{
    public interface INewsQueryService
    {
        //Task<NewsQueryDto> QueryNews();
        Task<List<Entities.News>> GetNews();
    }
}
