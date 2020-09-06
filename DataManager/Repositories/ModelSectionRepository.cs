using System.Collections.Generic;
using DataManager.Abstractions;
using DataManager.Entities;

namespace DataManager.Repositories
{
    public class ModelSectionRepository<ModelSectionModel> : BaseRepository, IRepository<ModelSectionModel>
    {
        public IEnumerable<ModelSectionModel> GetAll(string connectionString, IQueryUnitOfWork queryUnitOfWork) =>
             queryUnitOfWork.LoadData<ModelSectionModel>($"{GetAllFrom} {EntityTable.ModelSectionEntity}", connectionString);

        public IEnumerable<ModelSectionModel> GetAllWhere(string whereClause, string connectionString, IQueryUnitOfWork queryUnitOfWork) =>
            queryUnitOfWork.LoadData<ModelSectionModel>($"{GetAllFrom} {EntityTable.ModelSectionEntity} {whereClause}", connectionString);
    }
}

