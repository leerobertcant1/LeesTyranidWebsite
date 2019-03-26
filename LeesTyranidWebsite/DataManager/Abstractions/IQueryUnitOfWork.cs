using System.Collections.Generic;

namespace DataManager.Abstractions
{
    public interface IQueryUnitOfWork
    {
        IEnumerable<T> LoadData<T>(string query, string connectionString);
    }
}