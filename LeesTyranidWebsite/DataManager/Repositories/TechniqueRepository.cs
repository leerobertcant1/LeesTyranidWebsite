using System.Collections.Generic;
using System.Threading.Tasks;
using DataManager.Abstractions;
using DataManager.Entities;
using DataManager.Models;

namespace DataManager.Repositories
{
    public class TechniqueRepository<TechniqueModel> : BaseRepository, IRepository<TechniqueModel>
    {
        public IEnumerable<TechniqueModel> GetAll(string connectionString, IQueryUnitOfWork queryUnitOfWork) =>
           queryUnitOfWork.LoadData<TechniqueModel>($"{GetAllFrom} {EntityTable.TechniqueEntity}", connectionString);
    }
}
