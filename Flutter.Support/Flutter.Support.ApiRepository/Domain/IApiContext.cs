using Flutter.Support.Extension.Application.Services.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Flutter.Support.ApiRepository.Domain
{
    public interface IApiContext
    {
        Task<TResult> PostAsync<TResult>(string url, object input) where TResult : class, IApiResultDto;

        Task<TResult> GetAsync<TResult>(string url) where TResult : class, IApiResultDto;
    }
}
