using DataManager.Models;
using System;
using System.Threading.Tasks;
using Tyranids.BusinessLogic.Abstractions;
using Tyranids.BusinessLogic.Models;
using Tyranids.Globals;

namespace Tyranids.BusinessLogic.Services
{
    public class ApiDataService : IApiDataService
    {
        private readonly IApiService _apiService;
        private readonly IJsonService _jsonService;
        private readonly ISeriLoggerService _seriLoggerService;

        public ApiDataService(IServiceLocator serviceLocator)
        {
            _apiService = serviceLocator.Get<IApiService>();
            _jsonService = serviceLocator.Get<IJsonService>();
            _seriLoggerService = serviceLocator.Get<ISeriLoggerService>();
        }

        public async Task<ApiModel> GetApiData(string endPoint)
        {
            try
            {
                var response = await _apiService.GetDataAsync(endPoint);

                if (!response.IsSuccessStatusCode)
                    return new ApiModel { ErrorMessage = GlobalStrings.ErrorOccurred, IsError = true };
                else
                {
                    var asyncResult = response.Content.ReadAsStringAsync().Result;

                    return new ApiModel { IsError = false, Response = _jsonService.ConvertJsonList<ModelModel>(asyncResult) };
                }
            }
            catch (Exception exception)
            {
                _seriLoggerService.LogData(exception);

                return new ApiModel { ErrorMessage = "An error occcured", IsError = true };
            }
        }
    }
}
