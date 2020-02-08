using DataManager.Abstractions;
using DataManager.Entities;
using System.Collections.Generic;

namespace DataManager.Repositories
{
    public class ModelRepository<ModelModel> : BaseRepository, IRepository<ModelModel>
    {
        public IEnumerable<ModelModel> GetAll(string connectionString, IQueryUnitOfWork queryUnitOfWork) =>
               queryUnitOfWork.LoadData<ModelModel>($"{GetAllFrom} {EntityTable.ModelEntity}", connectionString);
    }
}
