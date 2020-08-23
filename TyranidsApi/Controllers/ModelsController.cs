using Api.Static_Values;
using DataManager.Abstractions;
using DataManager.Enums;
using Newtonsoft.Json;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;

namespace Api.Controllers
{
    [RoutePrefix("api/models")]
    public class ModelsController : ApiController
    {
        private IQueryUnitOfWork _queryUnitOfWork;
        private IRepositoryFactory _repositoryFactory;

        public ModelsController(IQueryUnitOfWork queryUnitOfWork, IRepositoryFactory repositoryFactory)
        {
            _queryUnitOfWork = queryUnitOfWork;
            _repositoryFactory = repositoryFactory;
        }

        [HttpGet]
        public HttpResponseMessage GetAll(EntityTypeEnum entityTypeEnum)
        {
            var items = _repositoryFactory.Make(entityTypeEnum).GetAll(GlobalTypes.DbConnectionString, _queryUnitOfWork);
            var noItems = !items.Any();

            if (noItems)
                return new HttpResponseMessage(HttpStatusCode.NoContent);

            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(JsonConvert.SerializeObject(items), Encoding.UTF8, WebTypes.Json)
            };
        }

        [HttpGet]
        public HttpResponseMessage GetAllModelsWhere(EntityTypeEnum entityTypeEnum, ModelsClassEnum classification)
        {
            var items = _repositoryFactory.Make(entityTypeEnum).GetAll(GlobalTypes.DbConnectionString, _queryUnitOfWork);
            var noItems = !items.Any();

            if (noItems)
                return new HttpResponseMessage(HttpStatusCode.NoContent);

            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(JsonConvert.SerializeObject(items), Encoding.UTF8, WebTypes.Json)
            };
        }
    }
}
