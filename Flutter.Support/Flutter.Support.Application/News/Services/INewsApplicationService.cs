using Flutter.Support.Application.News.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Flutter.Support.Application.News.Services
{
    public interface INewsApplicationService
    {
        Task  NewsQuery(string type);
    }
}
