using DataManager.Abstractions;
using DataManager.Entities;
using DataManager.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataManager.Repositories
{
    public class ModelRepository<ModelModel> : BaseRepository, IRepository<ModelModel>
    {
        public IEnumerable<ModelModel> GetAll(string connectionString, IQueryUnitOfWork queryUnitOfWork) =>
               queryUnitOfWork.LoadData<ModelModel>($"{GetAllFrom} {EntityTable.ModelEntity}", connectionString);
    }
}
