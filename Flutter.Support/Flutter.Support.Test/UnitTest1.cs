using Flutter.Support.Domain.IApiRepositories.ShowApi.InputDto;
using System;
using Xunit;

namespace Flutter.Support.Test
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var model = new ShowApiNewsInputDto
            {
                ChannelId = "5572a108b3cdc86cf39001cd",
                ChannelName = "¹úÄÚ½¹µã",
                Timestamp = "20200509160125",
                Page = 1,
                MaxResult = 20
            };

            var str = model.CounterSign();
        }
    }
}
