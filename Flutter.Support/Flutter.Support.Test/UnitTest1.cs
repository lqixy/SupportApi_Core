using Flutter.Support.Application.News.Services;
using Flutter.Support.Domain.IApiRepositories.ShowApi;
using Flutter.Support.Domain.IApiRepositories.ShowApi.InputDto;
using Flutter.Support.Domain.IApiRepositories.ShowApi.OutputDto;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Flutter.Support.Test
{
    public class UnitTest1 : UnitTestBase
    {
        private readonly INewsApplicationService newsApplicationService;
        private readonly IShowApiRepository showApiRepository;

        public UnitTest1() : base()
        {
            this.newsApplicationService = ServiceProvider.GetService<INewsApplicationService>();
            this.showApiRepository = ServiceProvider.GetService<IShowApiRepository>();
        }

        [Fact]
        public async Task Test1()
        {
            var input = new ShowApiNewsInputDto("5572a108b3cdc86cf39001cd");
            //{
            //    ChannelId = "5572a108b3cdc86cf39001cd",
            //    ChannelName = "���ڽ���",
            //    Timestamp = "20200509160125",
            //    Page = 1,
            //    MaxResult = 20
            //};
            //var str = model.CounterSign();

            var result = await showApiRepository.GetAsync<ShowApiNewsInputDto, ShowApiOutputDtoBase<ShowApiNewsOutputDto>>(input, false);

        }
    }
}
