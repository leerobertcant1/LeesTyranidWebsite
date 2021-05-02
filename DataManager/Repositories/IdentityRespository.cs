using DataManager.Abstractions;
using DataManager.Models;
using Microsoft.AspNet.Identity;

namespace DataManager.Repositories
{
    public class IdentityRespository : IIdentityRespository
    {
        public IdentityResult CreateUser(IdentityModel identityModel)
        {
            //Need to implement user creation here

            return null;
        }
    }
}
