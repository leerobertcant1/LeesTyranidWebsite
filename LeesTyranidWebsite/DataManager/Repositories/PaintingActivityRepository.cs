using System.Collections.Generic;
using DataManager.Abstractions;
using DataManager.Entities;
using DataManager.Models;

namespace DataManager.Repositories
{
    public class PaintingActivityRepository<PaintingActivityModel> : BaseRepository, IRepository<PaintingActivityModel>
    {
        public IEnumerable<PaintingActivityModel> GetAll(string connectionString, IQueryUnitOfWork queryUnitOfWork) =>
            queryUnitOfWork.LoadData<PaintingActivityModel>($"{GetAllFrom} {EntityTable.PaintingActivityEntity}", connectionString);
    }
}
