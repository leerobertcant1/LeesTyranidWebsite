using Api.Static_Values;
using DataManager.Abstractions;
using DataManager.Enums;
using Newtonsoft.Json;
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
            
        public string GetAllModels()
        {
            var items = _repositoryFactory.Make(EntityTypeEnum.Model).GetAll(GlobalTypes.DbConnectionString, _queryUnitOfWork);

            return JsonConvert.SerializeObject(items); 
        }
    }
}
