using Dapper;
using DataManager.Abstractions;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace DataManager.Unit_Of_Work.Query
{
    public class QueryUnitOfWork : IQueryUnitOfWork
    {
        public IEnumerable<T> LoadData<T>(string query, string connectionString)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                var rows = connection.Query<T>(query).ToList();

                connection.Close();

                return rows.AsEnumerable();
            }      
        }
    }
}
