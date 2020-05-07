using Flutter.Support.Domain.IApiRepositories.JuHe.InputDto;
using Flutter.Support.Domain.IApiRepositories.JuHe.OutputDto;
using Flutter.Support.Extension.Application.Services.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Flutter.Support.Domain.IApiRepositories.JuHe
{
    public interface IJuHeApiRepository
    {
        Task<TResult> GetAsync<TInput, TResult>(TInput input)
            where TInput : IApiInputDto where TResult : class, IApiResultDto;

        Task<TResult> PostAsync<TInput, TResult>(TInput input)
            where TInput : IApiInputDto where TResult : class, IApiResultDto;
    }
}
