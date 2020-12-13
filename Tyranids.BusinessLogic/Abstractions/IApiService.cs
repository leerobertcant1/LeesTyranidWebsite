﻿using System.Net.Http;
using System.Threading.Tasks;

namespace Tyranids.BusinessLogic.Abstractions
{
    public interface IApiService
    {
        Task<HttpResponseMessage> GetDataAsync(string endPoint);
    }
}