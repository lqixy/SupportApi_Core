using Flutter.Support.ApiRepository.Domain;
using Flutter.Support.ApiRepository.Repositories;
using Flutter.Support.Application.News.Services;
using Flutter.Support.Domain.IApiRepositories.JuHe;
using Flutter.Support.Domain.IRepositories;
using Flutter.Support.Repository.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Flutter.Support.HostedServer.Cores
{
    public static class IocManager
    {

        public static void RegisterTypes(this IServiceCollection services)
        {
            services.AddSingleton<INewsApplicationService, NewsApplicationService>();
            services.AddSingleton<IJuHeApiRepository, JuHeApiRepository>();
            services.AddSingleton<IApiHttpClient, ApiHttpClient>();
            services.AddSingleton<IApiContext, ApiContext>();
            //services.AddSingleton<IDbProviderFactory, SqlServerDbProviderFactory>();
            //services.AddSingleton<IConnectionStringResolver, DefaultConnectionStringResolver>();
            services.AddSingleton<INewsRepository, NewsRepository>();
        }
    }
}
