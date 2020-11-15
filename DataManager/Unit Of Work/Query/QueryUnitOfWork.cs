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
            if(string.IsNullOrEmpty(query) || string.IsNullOrEmpty(connectionString))
            {
                return null;
            }

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                
                var rows =  connection.Query<T>(query).AsEnumerable();

                connection.Close();

                return rows;
            }
        }
    }
}
