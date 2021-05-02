using System.Collections.Generic;

namespace DataManager.Abstractions
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll(string connectionString, IQueryUnitOfWork queryUnitOfWork);
        IEnumerable<T> GetAllWhere(string whereClause, string connectionString, IQueryUnitOfWork queryUnitOfWork);
        IEnumerable<T> GetAllWhereJoined(string whereClause, string connectionString, IQueryUnitOfWork queryUnitOfWork, string entity);
    }
}
