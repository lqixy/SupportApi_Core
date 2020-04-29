using Autofac;
using Autofac.Core;
using Autofac.Extensions.DependencyInjection;
using Flutter.Support.ApiRepository.Domain;
using Flutter.Support.ApiRepository.Repositories;
using Flutter.Support.AutoService.Core.Configuration;
using Flutter.Support.AutoService.Jobs;
using Flutter.Support.Dapper;
using Flutter.Support.Domain.IApiRepositories.JuHe;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyModel;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Loader;
using System.Text;

namespace Flutter.Support.AutoService.Core
{
    public class CoreIocContainer
    {
        private static ContainerBuilder _builder = new ContainerBuilder();
        private static IContainer _container;
        private static string[] _otherAssembly;
        private static List<Type> _types = new List<Type>();
        private static Dictionary<Type, Type> _dicTypes = new Dictionary<Type, Type>();

        /// <summary>
        /// 注册程序集
        /// </summary>
        /// <param name="assemblies">程序集名称的集合</param>
        public static void Register(params string[] assemblies)
        {
            _otherAssembly = assemblies;
        }

        /// <summary>
        /// 注册类型
        /// </summary>
        /// <param name="types"></param>
        public static void Register(params Type[] types)
        {
            _types.AddRange(types.ToList());
        }
        /// <summary>
        /// 注册程序集。
        /// </summary>
        /// <param name="implementationAssemblyName"></param>
        /// <param name="interfaceAssemblyName"></param>
        public static void Register(string implementationAssemblyName, string interfaceAssemblyName)
        {
            var implementationAssembly = Assembly.Load(implementationAssemblyName);
            var interfaceAssembly = Assembly.Load(interfaceAssemblyName);
            var implementationTypes =
                implementationAssembly.DefinedTypes.Where(t =>
                    t.IsClass && !t.IsAbstract && !t.IsGenericType && !t.IsNested);
            foreach (var type in implementationTypes)
            {
                var interfaceTypeName = interfaceAssemblyName + ".I" + type.Name;
                var interfaceType = interfaceAssembly.GetType(interfaceTypeName);
                if (interfaceType.IsAssignableFrom(type))
                {
                    _dicTypes.Add(interfaceType, type);
                }
            }
        }
        /// <summary>
        /// 注册
        /// </summary>
        /// <typeparam name="TInterface"></typeparam>
        /// <typeparam name="TImplementation"></typeparam>
        public static void Register<TInterface, TImplementation>() where TImplementation : TInterface
        {
            _dicTypes.Add(typeof(TInterface), typeof(TImplementation));
        }

        /// <summary>
        /// 注册一个单例实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="instance"></param>
        public static void Register<T>(T instance) where T : class
        {
            _builder.RegisterInstance(instance).SingleInstance();
        }

        /// <summary>
        /// 构建IOC容器
        /// </summary>
        public static IServiceProvider Build(IServiceCollection services)
        {
            if (_otherAssembly != null)
            {
                foreach (var item in _otherAssembly)
                {
                    _builder.RegisterAssemblyTypes(Assembly.Load(item));
                }
            }

            if (_types != null)
            {
                foreach (var type in _types)
                {
                    _builder.RegisterType(type);
                }
            }

            if (_dicTypes != null)
            {
                foreach (var dicType in _dicTypes)
                {
                    _builder.RegisterType(dicType.Value).As(dicType.Key);
                }
            }

            _builder.Populate(services);
            IocBuilder();
            _container = _builder.Build();
            return new AutofacServiceProvider(_container);
        }

        /// <summary>
        /// 自定义注册
        /// </summary>
        /// <param name="builder"></param>
        public static void IocBuilder()
        {
            _builder.RegisterType<QuartzScheduleJobManager>().As<IQuartzScheduleJobManager>();
            _builder.RegisterType<QuartzConfiguration>().As<IQuartzConfiguration>();
            _builder.RegisterType<ApiContext>().As<IApiContext>();
            _builder.RegisterType<ApiHttpClient>().As<IApiHttpClient>();
            _builder.RegisterType<JuHeApiRepository>().As<IJuHeApiRepository>();
            //_builder.RegisterType<NewsApplicationService>().As<INewsApplicationService>();
            _builder.RegisterType<SqlServerDbProviderFactory>().As<IDbProviderFactory>();
            _builder.RegisterType<DefaultConnectionStringResolver>().As<IConnectionStringResolver>();
            //_builder.RegisterType<InsertNewsToDbService>().As<IAutoService>();
            

            var assemblies = GetAllAssemblies();
            //注册仓储 && Service
            _builder.RegisterAssemblyTypes(assemblies)
                .Where(cc => cc.Name.EndsWith("Repository") |//筛选
                             cc.Name.EndsWith("Service"))
                .PublicOnly()//只要public访问权限的
                .Where(cc => cc.IsClass)//只要class型（主要为了排除值和interface类型）
                .AsImplementedInterfaces();//自动以其实现的所有接口类型暴露（包括IDisposable接口）

        }

        /// <summary>
        ///
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T Resolve<T>()
        {
            return _container.Resolve<T>();
        }

        public static T Resolve<T>(params Parameter[] parameters)
        {
            return _container.Resolve<T>(parameters);
        }

        public static object Resolve(Type targetType)
        {
            return _container.Resolve(targetType);
        }

        public static object Resolve(Type targetType, params Parameter[] parameters)
        {
            return _container.Resolve(targetType, parameters);
        }

        /// <summary>
        /// 获取项目程序集，排除所有的系统程序集(Microsoft.***、System.***等)、Nuget下载包
        /// </summary>
        /// <returns></returns>
        private static Assembly[] GetAllAssemblies()
        {
            var list = new List<Assembly>();
            var deps = DependencyContext.Default;

            var libs = deps.CompileLibraries.Where(x => !x.Serviceable && x.Type != "package");
            foreach (var lib in libs)
            {
                try
                {
                    var assembly = AssemblyLoadContext.Default.LoadFromAssemblyName(new AssemblyName(lib.Name));
                    list.Add(assembly);
                }
                catch (Exception ex)
                {

                }
            }

            return list.ToArray();
        }
    }
}
