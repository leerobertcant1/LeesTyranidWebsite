using Api.Static_Values;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using TyranidsApi.Abstractions;

namespace TyranidsApi.Services
{
    public class ApiService: IApiService
    {
        public async Task<HttpResponseMessage> GetDataAsync(string endPoint)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(endPoint);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(WebTypes.Json));

                return  await client.GetAsync(endPoint);
            }
        }
    }
}