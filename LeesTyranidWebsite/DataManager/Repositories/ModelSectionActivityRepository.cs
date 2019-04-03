using System.Collections.Generic;
using System.Threading.Tasks;
using DataManager.Abstractions;
using DataManager.Entities;
using DataManager.Models;

namespace DataManager.Repositories
{
    public class ModelSectionActivityRepository<ModelSectionActivityModel> : BaseRepository, IRepository<ModelSectionActivityModel>
    {
        public IEnumerable<ModelSectionActivityModel> GetAll(string connectionString, IQueryUnitOfWork queryUnitOfWork) =>
            queryUnitOfWork.LoadData<ModelSectionActivityModel>($"{GetAllFrom} {EntityTable.ModelSectionActivityEntity}", connectionString);
    }
}
