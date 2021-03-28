using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Tyranids.BusinessLogic.Abstractions;
using Tyranids.BusinessLogic.Models;
using Tyranids.Globals;

namespace Tyranids.BusinessLogic.Services
{
    public class ApiDataService<T> : IApiDataService<T>
    {
        private readonly IApiService _apiService;
        private readonly IJsonService _jsonService;
        private readonly ISeriLoggerService _seriLoggerService;

        public ApiDataService(IApiService apiService, IJsonService jsonService, ISeriLoggerService seriLoggerService)
        {
            _apiService = apiService;
            _jsonService = jsonService;
            _seriLoggerService = seriLoggerService;
        }

        public async Task<ApiModel> GetApiData(string endPoint)
        {
            try
            {
                var response = await _apiService.GetDataAsync(endPoint);

                if (!response.IsSuccessStatusCode)
                {
                    return new ApiModel { ErrorMessage = GlobalStrings.ErrorOccurred, IsError = true, StatusCode = 400 };
                }
                else
                {
                    var asyncResult = response.Content.ReadAsStringAsync().Result;

                    return new ApiModel { IsError = false, Response = _jsonService.ConvertJsonList<T>(asyncResult), StatusCode = 200 };
                }
            }
            catch (Exception exception)
            {
                _seriLoggerService.LogData(exception);

                return new ApiModel { ErrorMessage = GlobalStrings.ErrorOccurred, IsError = true, StatusCode = 500 };
            }
        }

        public async Task<ApiModel> PostApiData(string endPoint, dynamic model)
        {
            try
            {
                var json = JsonConvert.SerializeObject(model);
                var content =  new StringContent(json, Encoding.UTF8, GlobalStrings.ApplicationJson);
                var response = await _apiService.PostDataAsync(endPoint, content);

                if (!response.IsSuccessStatusCode)
                {
                    return new ApiModel { ErrorMessage = GlobalStrings.ErrorOccurred, IsError = true, StatusCode = 400 };
                }
                else
                {
                    var asyncResult = response.Content.ReadAsStringAsync().Result;

                    return new ApiModel { IsError = false, Response = GlobalStrings.SuccessfullyUpdated, StatusCode = 200 };
                }
            }
            catch (Exception exception)
            {
                _seriLoggerService.LogData(exception);

                return new ApiModel { ErrorMessage = GlobalStrings.ErrorOccurred, IsError = true, StatusCode = 500 };
            }
        }

    }
}