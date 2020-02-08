
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataManager.Abstractions
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll(string connectionString, IQueryUnitOfWork queryUnitOfWork);
    }
}
