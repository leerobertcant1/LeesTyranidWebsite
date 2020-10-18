using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Tyranids.BusinessLogic.Abstractions;

namespace Tyranids.BusinessLogic.Services
{
    public class ApiService : IApiService
    {
        public async Task<HttpResponseMessage> GetDataAsync(string endPoint)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(endPoint);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                return await client.GetAsync(endPoint);
            }
        }
    }

}
