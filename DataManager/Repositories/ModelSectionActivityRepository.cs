using System.Collections.Generic;
using DataManager.Abstractions;
using DataManager.Entities;

namespace DataManager.Repositories
{
    public class ModelSectionActivityRepository<ModelSectionActivityModel> : BaseRepository, IRepository<ModelSectionActivityModel>
    {
        public IEnumerable<ModelSectionActivityModel> GetAll(string connectionString, IQueryUnitOfWork queryUnitOfWork) =>
            queryUnitOfWork.LoadData<ModelSectionActivityModel>($"{GetAllFrom} {EntityTable.ModelSectionActivityEntity}", connectionString);

        public IEnumerable<ModelSectionActivityModel> GetAllWhere(string whereClause, string connectionString, IQueryUnitOfWork queryUnitOfWork) =>
            queryUnitOfWork.LoadData<ModelSectionActivityModel>($"{GetAllFrom} {EntityTable.ModelSectionActivityEntity} {whereClause}", connectionString);
    }
}
