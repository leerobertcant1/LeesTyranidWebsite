﻿using System.Threading.Tasks;
using Tyranids.BusinessLogic.Models;

namespace Tyranids.BusinessLogic.Abstractions
{
    public interface IApiDataService<T>
    {
        Task<ApiModel> GetApiData(string endPoint);
    }
}