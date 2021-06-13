using DataManager.Abstractions;
using DataManager.Models;
using Globals;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;

namespace Tyranids.Api.Controllers
{
    [RoutePrefix("api/identity")]
    public class IdentityController : ApiController
    {
        private readonly IIdentityRespository _identityRespository;

        public IdentityController(IIdentityRespository identityRespository)
        {
            _identityRespository = identityRespository;
        }

        [HttpPost]
        [Route("Create")]
        public HttpResponseMessage CreateUser(IdentityModel identityModel)
        {
            //var result = _identityRespository.CreateUser(identityModel);

            //if(result == null)
            //{
            //    return new HttpResponseMessage(HttpStatusCode.InternalServerError);
            //}

            //if (!result.Succeeded)
            //{
            //    return new HttpResponseMessage(HttpStatusCode.Forbidden);
            //}

            //return new HttpResponseMessage(HttpStatusCode.OK)
            //{
            //    Content = new StringContent(JsonConvert.SerializeObject(HttpStatusCode.OK), Encoding.UTF8, WebTypes.Json)
            //};

            return null;
        }
    }
}