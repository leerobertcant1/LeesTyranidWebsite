using System.Net.Http;
using System.Threading.Tasks;
using Tyranids.BusinessLogic.Models;

namespace Tyranids.BusinessLogic.Abstractions
{
    public interface IApiDataService<T>
    {
        Task<ApiModel> GetApiData(string endPoint);
        Task<ApiModel> PostApiData(string endPoint, HttpContent content);
    }
}