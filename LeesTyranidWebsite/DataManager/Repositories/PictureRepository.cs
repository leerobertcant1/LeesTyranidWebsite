using System.Collections.Generic;
using System.Threading.Tasks;
using DataManager.Abstractions;
using DataManager.Entities;
using DataManager.Models;

namespace DataManager.Repositories
{
    public class PictureRepository<PictureModel> : BaseRepository, IRepository<PictureModel>
    {
        public IEnumerable<PictureModel> GetAll(string connectionString, IQueryUnitOfWork queryUnitOfWork) =>
            queryUnitOfWork.LoadData<PictureModel>($"{GetAllFrom} {EntityTable.PictureEntity}", connectionString);
    }
}
