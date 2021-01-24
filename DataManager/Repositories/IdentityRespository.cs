using DataManager.Abstractions;
using DataManager.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace DataManager.Repositories
{
    public class IdentityRespository : IIdentityRespository
    {
        public IdentityResult CreateUser(IdentityModel identityModel)
        {
            var userStore = new UserStore<IdentityUser>();
            var manager = new UserManager<IdentityUser>(userStore);

            var user = new IdentityUser() { UserName = identityModel.Username};

            return manager.Create(user, identityModel.Password);
        }
    }
}
