using DataManager.Enums;

namespace DataManager.Abstractions
{
    public interface IRepositoryFactory
    {
         IRepository<dynamic> Make(EntityTypeEnum entityTypeEnum);
    }
}
