using DataManager.Abstractions;
using DataManager.Entities;
using DataManager.Models;
using System.Collections.Generic;

namespace DataManager.Repositories
{
    public class Repository<T> : BaseRepository, IRepository<T>
    {
        public IEnumerable<T> GetAll(string connectionString, IQueryUnitOfWork queryUnitOfWork)
        {
            return queryUnitOfWork.LoadData<T>($"{ GetAllFrom } { GetEntity() }", connectionString);
        }
     

        public IEnumerable<T> GetAllWhere(string whereClause, string connectionString, IQueryUnitOfWork queryUnitOfWork)
        {
            return queryUnitOfWork.LoadData<T>($"{ GetAllFrom } { GetEntity() } { whereClause }", connectionString); ;
        }
             
        private string GetEntity()
        {
            var modelType = typeof(T);

            if(modelType == typeof(ModelModel))
            {
                return EntityTable.ModelEntity;
            }

            return string.Empty;
        }
    }
}