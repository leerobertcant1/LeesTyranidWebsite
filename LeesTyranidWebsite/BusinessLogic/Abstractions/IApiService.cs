using System.Threading.Tasks;
using TyranidsApi.Models;

namespace BusinessLogic.Abstractions
{
    public interface IApiService
    {
         Task<AuthenticatedUser> Authenticate(string username, string password);
    }
}
