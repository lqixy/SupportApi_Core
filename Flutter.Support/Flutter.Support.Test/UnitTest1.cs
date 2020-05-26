using Flutter.Support.Application.News.Services;
using Flutter.Support.Application.News.ShowApiChannels;
using Flutter.Support.Domain.IApiRepositories.ShowApi;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using Xunit;

namespace Flutter.Support.Test
{
    public class UnitTest1 : UnitTestBase
    {
        private readonly INewsApplicationService newsApplicationService;
        private readonly IShowApiRepository showApiRepository;
        private readonly INewsQueryApplicationService newsQueryApplicationService;

        public UnitTest1() : base()
        {
            this.newsApplicationService = ServiceProvider.GetService<INewsApplicationService>();
            this.showApiRepository = ServiceProvider.GetService<IShowApiRepository>();
            this.newsQueryApplicationService = ServiceProvider.GetService<INewsQueryApplicationService>();
        }

        [Fact]
        public async Task Test1()
        {
            //var input = new ShowApiNewsInputDto(ShowApiNewsChannel.DomesticNew, needContent: 1);
            ////{
            ////    ChannelId = "5572a108b3cdc86cf39001cd",
            ////    ChannelName = "¹úÄÚ½¹µã",
            ////    Timestamp = "20200509160125",
            ////    Page = 1,
            ////    MaxResult = 20
            ////};
            ////var str = model.CounterSign();

            //var result = await showApiRepository.GetAsync<ShowApiNewsInputDto, ShowApiOutputDtoBase<ShowApiNewsOutputDto>>(input, false);

            //await newsApplicationService.InsertNews();
            var result = newsQueryApplicationService.GetNews(ShowApiNewsChannel.DomesticNew);
        }
    }
}
