using Flutter.Support.ApiRepository.Domain;
using Flutter.Support.Domain.IApiRepositories.ShowApi;
using Flutter.Support.Extension.Application.Services.Dtos;
using System.Threading.Tasks;

namespace Flutter.Support.ApiRepository.Repositories
{
    public class ShowApiRepository : ApiRepositoryBase, IShowApiRepository
    {
        private readonly IApiContext apiContext;

        public ShowApiRepository(IApiContext apiContext)
        {
            this.apiContext = apiContext;
        }

        public async Task<TResult> GetAsync<TInput, TResult>(TInput input, bool propertyNameLower = true)
            where TInput : IApiInputDto
            where TResult : class, IApiResultDto
        {
            var attribute = GetApiUrl<TInput>();
            var url = attribute.GetUrl();

            input.CounterSign();
            var properties = input.GetType().GetProperties();
            //if (properties.Length <= 0) throw new UserFriendlyException("input is null");

            var parames = "";
            for (int i = 0; i < properties.Length; i++)
            {
                var curproperty = properties[i];
                parames += $"{(i > 0 ? "&" : "")}{(propertyNameLower ? curproperty.Name.ToLower() : curproperty.Name)}={curproperty.GetValue(input, null)}";
            }
            //ApiLogHelper.Logger.Debug($"GET URL：{url}\r\n参数：{parames}");
            var result = await apiContext.GetAsync<TResult>($"{url}?{parames}");
            //if (!result.Success) throw new UserFriendlyException(result.Error.Message);
            return result;
        }

        //public Task<TResult> PostAsync<TInput, TResult>(TInput input)
        //    where TInput : IApiInputDto
        //    where TResult : ShowApiOutputDtoBase<ShowApiOutputBodyBase>
        //{
        //    throw new NotImplementedException();
        //}
    }
}
