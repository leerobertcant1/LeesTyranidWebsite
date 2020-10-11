using System.Threading.Tasks;
using Tyranids.BusinessLogic.Abstractions;
using Tyranids.BusinessLogic.Models;

namespace Tyranids.BusinessLogic.Services
{
    public class ApiDataService : IApiDataService
    {
        public Task<ApiModel> GetApiData(string endPoint)
        {
            throw new System.NotImplementedException();
        }
    }
}
