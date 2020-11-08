using DataManager.Abstractions;
using DataManager.Enums;
using DataManager.Models;
using DataManager.Repositories;
using Globals;
using Newtonsoft.Json;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using Tyranids.Globals;

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
        [Route("GetAll")]
        public HttpResponseMessage GetAll()
        {
            var items = _repositoryFactory.Make(EntityTypeEnum.Model).GetAll(GlobalTypes.DbConnectionString, _queryUnitOfWork);
            var noItems = !items.Any();

            if (noItems)
                return new HttpResponseMessage(HttpStatusCode.NoContent);

            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(JsonConvert.SerializeObject(items), Encoding.UTF8, WebTypes.Json)
            };
        }

        [HttpGet]
        [Route("GetAllWhere")]
        public HttpResponseMessage GetAllWhere(ModelsClassEnum modelsClassEnum)
        {
            var whereClause = $"Where ClassificationId = {(int)modelsClassEnum}";

            var repository = new Repository<ModelModel>();
            var items = repository.GetAllWhere(whereClause, GlobalTypes.DbConnectionString, _queryUnitOfWork);
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
