using System.Collections.Generic;
using System.Threading.Tasks;
using DataManager.Abstractions;
using DataManager.Entities;
using DataManager.Models;

namespace DataManager.Repositories
{
    public class ToolRepository<ToolModel> : BaseRepository, IRepository<ToolModel>
    {
        public IEnumerable<ToolModel> GetAll(string connectionString, IQueryUnitOfWork queryUnitOfWork) =>
            queryUnitOfWork.LoadData<ToolModel>($"{GetAllFrom} {EntityTable.ToolEntity}", connectionString);
    }
}
