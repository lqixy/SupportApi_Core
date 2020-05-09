using Flutter.Support.Domain.IApiRepositories.ShowApi.InputDto;
using Flutter.Support.Domain.IApiRepositories.ShowApi.OutputDto;
using Flutter.Support.Extension.Application.Services.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Flutter.Support.Domain.IApiRepositories.ShowApi
{
    public interface IShowApiRepository
    {
        Task<TResult> GetAsync<TInput, TResult>(TInput input)
            where TInput : IApiInputDto where TResult : class, IApiResultDto;

        //Task<TResult> PostAsync<TInput, TResult>(TInput input)
        //    where TInput : IApiInputDto where TResult : ShowApiOutputDtoBase<ShowApiOutputBodyBase>;
    }
}
