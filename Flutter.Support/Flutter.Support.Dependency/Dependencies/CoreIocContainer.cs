using Autofac;
using Autofac.Extensions.DependencyInjection;
using Flutter.Support.ApiRepository.Domain;
using Flutter.Support.ApiRepository.Repositories;
using Flutter.Support.Domain.IApiRepositories.JuHe;
using Flutter.Support.Redis.Cache;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Flutter.Support.Dependency.Dependencies
{
    /// <summary>
    /// Core的AutoFac容器
    /// </summary>
    public static class CoreIocContainer
    {
        /// <summary>
        /// 容器实例
        /// </summary>
        public static IContainer Instance;
        /// <summary>
        /// 初始化容器
        /// </summary>
        /// <param name="services"></param>
        /// <param name="func"></param>
        /// <returns></returns>
        public static IServiceProvider Init(IServiceCollection services, Func<ContainerBuilder, ContainerBuilder> func = null)
        {
            //新建容器构建器，用于注册组件和服务
            var builder = new ContainerBuilder();
            //将Core自带DI容器内的服务迁移到AutoFac容器
            builder.Populate(services);
            //自定义注册组件
            IocBuilder(builder);
            func?.Invoke(builder);
            //利用构建器创建容器
            Instance = builder.Build();

            return new AutofacServiceProvider(Instance);
        }
        /// <summary>
        /// 自定义注册
        /// </summary>
        /// <param name="builder"></param>
        public static void IocBuilder(this ContainerBuilder builder)
        {

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
