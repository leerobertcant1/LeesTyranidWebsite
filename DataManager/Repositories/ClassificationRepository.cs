using System.Collections.Generic;
using DataManager.Abstractions;
using DataManager.Entities;

namespace DataManager.Repositories
{
    public class ClassificationRepository<ClassificationModel> : BaseRepository, IRepository<ClassificationModel>
    {
        public IEnumerable<ClassificationModel> GetAll(string connectionString, IQueryUnitOfWork queryUnitOfWork) =>
            queryUnitOfWork.LoadData<ClassificationModel>($"{GetAllFrom} {EntityTable.ClassificationEntity}", connectionString);

        public IEnumerable<ClassificationModel> GetAllWhere(string whereClause, string connectionString, IQueryUnitOfWork queryUnitOfWork) =>
         queryUnitOfWork.LoadData<ClassificationModel>($"{GetAllFrom} {EntityTable.ClassificationEntity} {whereClause}", connectionString);
    }
}
