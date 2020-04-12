using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using AutoMapper;
using Flutter.Support.ApiRepository.Domain;
using Flutter.Support.ApiRepository.Repositories;
using Flutter.Support.Application.News.Services;
using Flutter.Support.Domain.IApiRepositories.JuHe;
using Flutter.Support.Extension.Configurations;
using Flutter.Support.Web.Filters;
using Flutter.Support.Web.Mappers;
using log4net;
using log4net.Config;
using log4net.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
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
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            Repository = LogManager.CreateRepository("rollingAppender");
            XmlConfigurator.Configure(Repository,
                new FileInfo(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "log4net.config")));

        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            //automapper
            services.AddAutoMapper(typeof(FlutterSupportProfile));
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
            //Log
            services.AddMvc(options =>
            {
                options.Filters.Add<HttpGlobalExceptionFilter>();//全局注册
            });
            //
            services.Configure<KestrelServerOptions>(x => x.AllowSynchronousIO = true)
                .Configure<IISServerOptions>(x => x.AllowSynchronousIO = true);
            ////读取json配置
            //services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));

        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterType<ApiContext>().As<IApiContext>();
            builder.RegisterType<ApiHttpClient>().As<IApiHttpClient>();
            builder.RegisterType<JuHeApiRepository>().As<IJuHeApiRepository>();
            builder.RegisterType<NewsApplicationService>().As<INewsApplicationService>();
            //builder.RegisterType<NewsApplicationService>().As<INewsApplicationService>();
        }

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
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
            //swagger
            app.UseSwagger();
            app.UseSwaggerUI(su =>
            {
                //url中[V1]与ConfigureServices 中配置的SwaggerDoc("V1",..) 保持一致
                su.SwaggerEndpoint("/swagger/V1/swagger.json", "Flutter.Support");
            });

            //log4net
            loggerFactory.AddLog4Net();

          
        }
    }
}
