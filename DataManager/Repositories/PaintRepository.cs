using System.Collections.Generic;
using DataManager.Abstractions;
using DataManager.Entities;

namespace DataManager.Repositories
{
    public class PaintRepository<PaintModel> : BaseRepository, IRepository<PaintModel>
    {
        public IEnumerable<PaintModel> GetAll(string connectionString, IQueryUnitOfWork queryUnitOfWork) =>
            queryUnitOfWork.LoadData<PaintModel>($"{GetAllFrom} {EntityTable.PaintEntity}", connectionString);

        public IEnumerable<PaintModel> GetAllWhere(string whereClause, string connectionString, IQueryUnitOfWork queryUnitOfWork) =>
            queryUnitOfWork.LoadData<PaintModel>($"{GetAllFrom} {EntityTable.PaintEntity} {whereClause}", connectionString);
    }
}
