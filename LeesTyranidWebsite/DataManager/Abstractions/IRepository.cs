
using System.Collections.Generic;

namespace DataManager.Abstractions
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll(string connectionString, IQueryUnitOfWork queryUnitOfWork);
    }
}
