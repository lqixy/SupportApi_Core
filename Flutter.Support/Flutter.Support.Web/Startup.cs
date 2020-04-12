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
using Flutter.Support.Web.Middleware;
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
                //���swagger ��Ϣ�������Զ��壩
                //V1.0.0-->SwaggerEndpoint(url,name)-->url ʹ��
                s.SwaggerDoc("V1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "Flutter.Support",
                    Version = "V1",
                });
                // Ϊ Swagger JSON and UI����xml�ĵ�ע��·��
                var basePath = Path.GetDirectoryName(typeof(Program).Assembly.Location);//��ȡӦ�ó�������Ŀ¼
                var xmlPath = Path.Combine(basePath, "Flutter.Support.xml");
                s.IncludeXmlComments(xmlPath);
            });
            ////Log
            //services.AddMvc(options =>
            //{
            //    options.Filters.Add<HttpGlobalExceptionFilter>();//ȫ��ע��
            //});
            //
            services.Configure<KestrelServerOptions>(x => x.AllowSynchronousIO = true)
                .Configure<IISServerOptions>(x => x.AllowSynchronousIO = true);
            ////��ȡjson����
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

            //ȫ���쳣�м��
            //app.UseUnifyException();
            app.UseMiddleware(typeof(GlobalExceptionMiddleware));
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
                //url��[V1]��ConfigureServices �����õ�SwaggerDoc("V1",..) ����һ��
                su.SwaggerEndpoint("/swagger/V1/swagger.json", "Flutter.Support");
            });

            //log4net
            loggerFactory.AddLog4Net();

          
        }
    }
}
