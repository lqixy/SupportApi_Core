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

namespace Flutter.Support.Test
{
    public static class UnitTestIocManager
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

            builder.RegisterType<ApiContext>().As<IApiContext>();
            builder.RegisterType<ApiHttpClient>().As<IApiHttpClient>();
            builder.RegisterType<JuHeApiRepository>().As<IJuHeApiRepository>();
            //builder.RegisterType<SqlServerDbProviderFactory>().As<IDbProviderFactory>();
            //builder.RegisterType<DefaultConnectionStringResolver>().As<IConnectionStringResolver>();
            builder.RegisterType<RedisCacheDatabaseProvider>().As<IRedisCacheDatabaseProvider>();
            builder.RegisterType<RedisCache>().As<IRedisCache>();

            var assemblies = ReflectionHelper.GetAllAssemblies();
            //注册仓储 && Service
            builder.RegisterAssemblyTypes(assemblies)
                .Where(cc => cc.Name.EndsWith("Repository") |//筛选
                             cc.Name.EndsWith("Service"))
                .PublicOnly()//只要public访问权限的
                .Where(cc => cc.IsClass)//只要class型（主要为了排除值和interface类型）
                .AsImplementedInterfaces();//自动以其实现的所有接口类型暴露（包括IDisposable接口）

        }

    }
}
