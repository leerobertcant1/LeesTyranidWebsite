using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using BusinessLogic.Abstractions;
using TyranidsApi.Models;
using TyranidsApi.Static_Values;

namespace BusinessLogic.Services.Api
{
    public class ApiService : IApiService
    {
        private HttpClient _apiClient;

        public ApiService() =>
            InitializeClient();

        public async Task<AuthenticatedUser> Authenticate(string username, string password)
        {
            var data = new FormUrlEncodedContent(new[] 
            {
               new KeyValuePair<string, string>(WebTypes.GrantType, WebTypes.Password),
               new KeyValuePair<string, string>(WebTypes.Username, username),
               new KeyValuePair<string, string>(WebTypes.Password, password)
            });

            using (HttpResponseMessage responseMessage = await _apiClient.PostAsync(WebTypes.Token, data))
            {
                if (!responseMessage.IsSuccessStatusCode)
                    throw new Exception(responseMessage.ReasonPhrase);
                else
                    return await responseMessage.Content.ReadAsAsync<AuthenticatedUser>();
            }
        }

        private void InitializeClient()
        {
            _apiClient = new HttpClient();
            _apiClient.BaseAddress = new Uri(GlobalTypes.TestApiLocation);
            _apiClient.DefaultRequestHeaders.Accept.Clear();
            _apiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(WebTypes.Json));
        }
    }
}
