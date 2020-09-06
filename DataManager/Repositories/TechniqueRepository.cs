using System.Collections.Generic;
using DataManager.Abstractions;
using DataManager.Entities;

namespace DataManager.Repositories
{
    public class TechniqueRepository<TechniqueModel> : BaseRepository, IRepository<TechniqueModel>
    {
        public IEnumerable<TechniqueModel> GetAll(string connectionString, IQueryUnitOfWork queryUnitOfWork) =>
           queryUnitOfWork.LoadData<TechniqueModel>($"{GetAllFrom} {EntityTable.TechniqueEntity}", connectionString);

        public IEnumerable<TechniqueModel> GetAllWhere(string whereClause, string connectionString, IQueryUnitOfWork queryUnitOfWork) =>
            queryUnitOfWork.LoadData<TechniqueModel>($"{GetAllFrom} {EntityTable.TechniqueEntity} {whereClause}", connectionString);
    }
}
