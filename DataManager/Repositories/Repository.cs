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
            return queryUnitOfWork.LoadData<T>($"{ GetAllFrom } { GetEntity(false) }", connectionString);
        }
     

        public IEnumerable<T> GetAllWhere(string whereClause, string connectionString, IQueryUnitOfWork queryUnitOfWork)
        {
            return queryUnitOfWork.LoadData<T>($"{ GetAllFrom } { GetEntity(false) } { whereClause }", connectionString);
        }

        public IEnumerable<T> GetAllWhereJoined(string whereClause, string connectionString, IQueryUnitOfWork queryUnitOfWork, string entity)
        {
            var query = $"{ GetAllFromModelsPictures } { GetEntity(true) } { whereClause }";

            return queryUnitOfWork.LoadData<T>(query, connectionString);
        }

        private string GetEntity(bool isJoined)
        {
            var modelType = typeof(T);

            if(modelType == typeof(ModelModel) || modelType == typeof(ModelModelPicture))
            {
                return isJoined ? EntityTable.ModelPicturesEntities : EntityTable.ModelEntity;
            }

            return string.Empty;
        }
    }
}