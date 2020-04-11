using Flutter.Support.ApiRepository.Domain;
using Flutter.Support.Domain.Attributes;
using Flutter.Support.Extension.Application.Services.Dtos;
using lutter.Support.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Flutter.Support.ApiRepository.Repositories
{
    public class ApiRepositoryBase
    {
        protected ApiUrlAttribute GetApiUrl<TData>() where TData : IApiInputDto
        {
            return ApiUrlAttributeHelper.GetApiUrlAttribute<TData>();
        }
    }
}
