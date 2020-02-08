using System.Net.Http;
using System.Threading.Tasks;

namespace TyranidsApi.Abstractions
{
    public interface IApiService
    {
        Task<HttpResponseMessage> GetDataAsync(string endPoint);
    }
}
