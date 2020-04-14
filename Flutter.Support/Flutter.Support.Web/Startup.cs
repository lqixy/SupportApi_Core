using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Autofac;
using AutoMapper;
using Castle.Windsor;
using Flutter.Support.ApiRepository.Domain;
using Flutter.Support.ApiRepository.Repositories;
using Flutter.Support.Application.News.Services;
using Flutter.Support.Dapper;
using Flutter.Support.Domain.IApiRepositories.JuHe;
using Flutter.Support.Extension.Dependencies;
using Flutter.Support.QueryServices.Dapper.News;
using Flutter.Support.QueryServices.News;
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
using Microsoft.Extensions.DependencyModel;
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
            #endregion

            #region ������
            //������,�ɸ���API�е�body��
            services.Configure<KestrelServerOptions>(x => x.AllowSynchronousIO = true)
                .Configure<IISServerOptions>(x => x.AllowSynchronousIO = true);
            #endregion

            #region Hangfire �Զ�����
            ////ע��hangfire
            //services.AddHangfire(x =>
            //{
            //    var connectionString = Configuration.GetConnectionString("HangfireConnection");
            //    x.UseSqlServerStorage(connectionString
            //        //, new Hangfire.SqlServer.SqlServerStorageOptions
            //        //{
            //        //    CommandBatchMaxTimeout = TimeSpan.FromMinutes(5),
            //        //    SlidingInvisibilityTimeout = TimeSpan.FromMinutes(5),
            //        //    QueuePollInterval = TimeSpan.Zero,
            //        //    UseRecommendedIsolationLevel = true,
            //        //    UsePageLocksOnDequeue = true,
            //        //    DisableGlobalLocks = true
            //        //}
            //        );
            //});

            //services.AddHangfireServer();
            #endregion

            #region ��ȡ���� 
            ////��ȡjson����
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
            builder.RegisterType<ApiContext>().As<IApiContext>();
            builder.RegisterType<ApiHttpClient>().As<IApiHttpClient>();
            builder.RegisterType<JuHeApiRepository>().As<IJuHeApiRepository>();
            //builder.RegisterType<NewsApplicationService>().As<INewsApplicationService>();
            builder.RegisterType<SqlServerDbProviderFactory>().As<IDbProviderFactory>();
            builder.RegisterType<DefaultConnectionStringResolver>().As<IConnectionStringResolver>();
            
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
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            #region ע���м��
            //ȫ���쳣�м��
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
                //url��[V1]��ConfigureServices �����õ�SwaggerDoc("V1",..) ����һ��
                su.SwaggerEndpoint("/swagger/V1/swagger.json", "Flutter.Support");
            });
            #endregion

            //log4net
            loggerFactory.AddLog4Net();

            #region Hangfire
            //app.UseHangfireServer();
            //app.UseHangfireDashboard();

            ////demo
            //RecurringJob.AddOrUpdate(() => Console.WriteLine($"Asp.net Core Hangfire"), Cron.Minutely());
            //RecurringJob.AddOrUpdate<IMessageService>(x => x.SendMessage("Send message"), Cron.Minutely);
            //RecurringJob.AddOrUpdate<IMessageService>(x => x.ReceiveMessage("Receive message"), Cron.Minutely);

            ////������������
            //var jobOptions = new BackgroundJobServerOptions
            //{
            //    Queues = new[] { "test", "default" },//�������ƣ�ֻ��ΪСд
            //    WorkerCount = Environment.ProcessorCount * 5, //����������
            //    ServerName = "hangfire1",//���������� 
            //};
            //app.UseHangfireServer(jobOptions);
            ////���÷���Ȩ��
            //var options = new DashboardOptions
            //{
            //    Authorization = new[] { new HangfireAuthorizationFilter() }
            //};
            //app.UseHangfireDashboard("/hangfire", options);

            #endregion

        }
    }
}
