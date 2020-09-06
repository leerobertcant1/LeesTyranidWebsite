using System.Collections.Generic;
using DataManager.Abstractions;
using DataManager.Entities;

namespace DataManager.Repositories
{
    public class PaintingActivityRepository<PaintingActivityModel> : BaseRepository, IRepository<PaintingActivityModel>
    {
        public IEnumerable<PaintingActivityModel> GetAll(string connectionString, IQueryUnitOfWork queryUnitOfWork) =>
            queryUnitOfWork.LoadData<PaintingActivityModel>($"{GetAllFrom} {EntityTable.PaintingActivityEntity}", connectionString);

        public IEnumerable<PaintingActivityModel> GetAllWhere(string whereClause, string connectionString, IQueryUnitOfWork queryUnitOfWork) =>
            queryUnitOfWork.LoadData<PaintingActivityModel>($"{GetAllFrom} {EntityTable.PaintingActivityEntity} {whereClause}", connectionString);
    }
}
