using System.Collections.Generic;
using DataManager.Abstractions;
using DataManager.Entities;

namespace DataManager.Repositories
{
    public class ToolRepository<ToolModel> : BaseRepository, IRepository<ToolModel>
    {
        public IEnumerable<ToolModel> GetAll(string connectionString, IQueryUnitOfWork queryUnitOfWork) =>
            queryUnitOfWork.LoadData<ToolModel>($"{GetAllFrom} {EntityTable.ToolEntity}", connectionString);

        public IEnumerable<ToolModel> GetAllWhere(string whereClause, string connectionString, IQueryUnitOfWork queryUnitOfWork) =>
            queryUnitOfWork.LoadData<ToolModel>($"{GetAllFrom} {EntityTable.ToolEntity} {whereClause}", connectionString);
    }
}
