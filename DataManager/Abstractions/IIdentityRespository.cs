using DataManager.Models;
using Microsoft.AspNet.Identity;

namespace DataManager.Abstractions
{
    public interface IIdentityRespository
    {
        IdentityResult CreateUser(IdentityModel identityModel);
    }
}
