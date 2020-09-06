using System.Collections.Generic;
using DataManager.Abstractions;
using DataManager.Entities;

namespace DataManager.Repositories
{
    public class PictureRepository<PictureModel> : BaseRepository, IRepository<PictureModel>
    {
        public IEnumerable<PictureModel> GetAll(string connectionString, IQueryUnitOfWork queryUnitOfWork) =>
            queryUnitOfWork.LoadData<PictureModel>($"{GetAllFrom} {EntityTable.PictureEntity}", connectionString);

        public IEnumerable<PictureModel> GetAllWhere(string whereClause, string connectionString, IQueryUnitOfWork queryUnitOfWork) =>
            queryUnitOfWork.LoadData<PictureModel>($"{GetAllFrom} {EntityTable.PictureEntity} {whereClause}", connectionString);
    }
}
