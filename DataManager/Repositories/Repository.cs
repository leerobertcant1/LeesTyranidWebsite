using DataManager.Abstractions;
using DataManager.Entities;
using System.Collections.Generic;

namespace DataManager.Repositories
{
    public class Repository<T> : BaseRepository, IRepository<T>
    {
        public IEnumerable<T> GetAll(string connectionString, IQueryUnitOfWork queryUnitOfWork) =>
               queryUnitOfWork.LoadData<T>($"{GetAllFrom} {EntityTable.ModelEntity}", connectionString);

        public IEnumerable<T> GetAllWhere(string whereClause, string connectionString, IQueryUnitOfWork queryUnitOfWork) =>
             queryUnitOfWork.LoadData<T>($"{GetAllFrom} {EntityTable.ModelEntity} {whereClause}", connectionString);
    }
}
