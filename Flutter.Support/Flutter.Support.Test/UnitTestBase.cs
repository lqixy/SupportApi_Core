using Autofac;
using Flutter.Support.ApiRepository.Domain;
using Flutter.Support.ApiRepository.Repositories;
using Flutter.Support.Application.News.Services;
using Flutter.Support.Domain.IApiRepositories.JuHe;
using Flutter.Support.Domain.IApiRepositories.ShowApi;
using Flutter.Support.Domain.IRepositories;
using Flutter.Support.Repository.Repositories;
using Flutter.Support.Test.IOC;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Flutter.Support.Test
{
    public class UnitTestBase
    {
        protected IServiceProvider ServiceProvider;

        public UnitTestBase()
        {
            //var container = new ContainerBuilder();
            //container.IocBuilder();

            //var services = new ServiceCollection();
            //UnitTestIocContainer.Init(services);

            IServiceCollection services = new ServiceCollection();
            services.AddLogging();
            services.AddSingleton<INewsApplicationService, NewsApplicationService>();
            services.AddSingleton<IJuHeApiRepository, JuHeApiRepository>();
            services.AddSingleton<IShowApiRepository, ShowApiRepository>();
            services.AddSingleton<IApiHttpClient, ApiHttpClient>();
            services.AddSingleton<IApiContext, ApiContext>();
            //services.AddSingleton<IDbProviderFactory, SqlServerDbProviderFactory>();
            //services.AddSingleton<IConnectionStringResolver, DefaultConnectionStringResolver>();
            services.AddSingleton<INewsRepository, NewsRepository>();
            ServiceProvider = services.BuildServiceProvider();

        }
    }
}
