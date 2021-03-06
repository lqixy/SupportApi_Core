using System;
using System.IO;
using Autofac;
using AutoMapper;
using Flutter.Support.Dependency.Dependencies;
using Flutter.Support.Web.Mappers;
using Flutter.Support.Web.Middleware;
using log4net;
using log4net.Config;
using log4net.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Flutter.Support.Web
{
    public class Startup
    {
        public static ILoggerRepository Repository { get; set; }
        //private const string CONFIGROOT = "HangfireConfig";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

            #region Log4net
            Repository = LogManager.CreateRepository("rollingAppender");
            XmlConfigurator.Configure(Repository,
                new FileInfo(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "log4net.config")));
            #endregion

        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            #region AutoMapper
            //automapper
            services.AddAutoMapper(typeof(FlutterSupportProfile));
            #endregion

            #region Swagger
            //swagger
            services.AddSwaggerGen(s =>
            {
                //标记swagger 信息（内容自定义）
                //V1.0.0-->SwaggerEndpoint(url,name)-->url 使用
                s.SwaggerDoc("V1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "Flutter.Support",
                    Version = "V1",
                });
                // 为 Swagger JSON and UI设置xml文档注释路径
                var basePath = Path.GetDirectoryName(typeof(Program).Assembly.Location);//获取应用程序所在目录
                var xmlPath = Path.Combine(basePath, "Flutter.Support.xml");
                s.IncludeXmlComments(xmlPath);
            });
            #endregion

            #region 流操作
            //开启用,可更改API中的body流
            services.Configure<KestrelServerOptions>(x => x.AllowSynchronousIO = true)
                .Configure<IISServerOptions>(x => x.AllowSynchronousIO = true);
            #endregion

            #region Hangfire 自动任务
            //services.AddHangfire(Configuration);
            //////注入hangfire
            //services.AddHangfire(x =>
            //{
            //    //var configRoot = "HangfireConfig";
            //    var storageType = Configuration[$"{CONFIGROOT}:StorageType"];
            //    var connectionString = Configuration[$"HangfireConfig:ConnectionStrings:{storageType}"];
            //    x.UseSqlServerStorage(connectionString);
            //});
            //services.AddHangfireServer();
            #endregion

            #region 读取配置 
            ////读取json配置
            //services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));

            #endregion

        }

        #region Autofac
        /// <summary>
        /// 
        /// </summary>
        /// <param name="builder"></param>
        public void ConfigureContainer(ContainerBuilder builder)
        {
            //builder.RegisterType<ApiContext>().As<IApiContext>();
            //builder.RegisterType<ApiHttpClient>().As<IApiHttpClient>();
            //builder.RegisterType<JuHeApiRepository>().As<IJuHeApiRepository>();
            ////builder.RegisterType<NewsApplicationService>().As<INewsApplicationService>();
            //builder.RegisterType<SqlServerDbProviderFactory>().As<IDbProviderFactory>();
            //builder.RegisterType<DefaultConnectionStringResolver>().As<IConnectionStringResolver>();
            builder.IocBuilder();
        }

        #endregion
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            //hangfire
            //app.UseHangfire(Configuration);

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            #region 注册中间键
            //全局异常中间键
            //app.UseUnifyException();
            app.UseMiddleware(typeof(GlobalExceptionMiddleware));
            #endregion

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

            #region Swagger
            //swagger
            app.UseSwagger();
            app.UseSwaggerUI(su =>
            {
                //url中[V1]与ConfigureServices 中配置的SwaggerDoc("V1",..) 保持一致
                su.SwaggerEndpoint("/swagger/V1/swagger.json", "Flutter.Support");
            });
            #endregion

            //log4net
            loggerFactory.AddLog4Net();

            #region Hangfire
            //AutoServiceCompute.Start();

            #endregion

        }
    }
}
