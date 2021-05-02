using DataManager.Abstractions;
using DataManager.Entities;
using DataManager.Enums;
using DataManager.Models;
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
        private readonly IQueryUnitOfWork _queryUnitOfWork;
        private readonly IRepository<ModelModel> _repository;
        IRepository<ModelModelPicture> _joinedRepository;

        public ModelsController(IQueryUnitOfWork queryUnitOfWork, IRepository<ModelModel> repository, IRepository<ModelModelPicture> joinedRepository)
        {
            _queryUnitOfWork = queryUnitOfWork;
            _repository = repository;
            _joinedRepository = joinedRepository;
        }

        [HttpGet]
        [Route("GetAll")]
        public HttpResponseMessage GetAll()
        {
            var items = _repository.GetAll(GlobalTypes.DbConnectionString, _queryUnitOfWork);
            var noItems = !items.Any();

            if (noItems)
            {
                return new HttpResponseMessage(HttpStatusCode.NoContent);
            }
              
            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(JsonConvert.SerializeObject(items), Encoding.UTF8, WebTypes.Json)
            };
        }

        [HttpGet]
        [Route("GetAllWhere")]
        public HttpResponseMessage GetAllWhere(ModelsClassEnum modelsClassEnum, bool pictures)
        {
            var whereClause = $"WHERE MO.ClassificationId = { (int) modelsClassEnum }";

            var items = pictures ? _joinedRepository.GetAllWhereJoined(whereClause, GlobalTypes.DbConnectionString, _queryUnitOfWork, EntityTable.PictureEntity) : 
                                   _repository.GetAllWhere(whereClause, GlobalTypes.DbConnectionString, _queryUnitOfWork);
            var noItems = !items.Any();

            if (noItems)
            {
                return new HttpResponseMessage(HttpStatusCode.NoContent);
            }
                
            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(JsonConvert.SerializeObject(items), Encoding.UTF8, WebTypes.Json)
            };
        }
    }
}
