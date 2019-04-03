using System.Collections.Generic;
using System.Threading.Tasks;
using DataManager.Abstractions;
using DataManager.Entities;
using DataManager.Models;

namespace DataManager.Repositories
{
    public class ClassificationRepository : BaseRepository, IRepository<ClassificationModel>
    {
        public IEnumerable<ClassificationModel> GetAll(string connectionString, IQueryUnitOfWork queryUnitOfWork) =>
            queryUnitOfWork.LoadData<ClassificationModel>($"{GetAllFrom} {EntityTable.ClassificationEntity}", connectionString);
    }
}
