using DataManager.Abstractions;
using DataManager.Enums;
using DataManager.Repositories;

namespace DataManager.Factories
{
    public class RepositoryFactory: IRepositoryFactory
    {
        IRepository<dynamic> IRepositoryFactory.Make(EntityTypeEnum entityTypeEnum)
        {
            switch (entityTypeEnum)
            {
                case EntityTypeEnum.Classification:
                    return new ClassificationRepository<dynamic>();
                case EntityTypeEnum.Model:
                    return new ModelRepository<dynamic>();
                case EntityTypeEnum.ModelSection:
                    return new ModelSectionRepository<dynamic>();
                case EntityTypeEnum.Painting:
                    return new PaintRepository<dynamic>();
                case EntityTypeEnum.PaintingActivity:
                    return new PaintingActivityRepository<dynamic>();
                case EntityTypeEnum.Picture:
                    return new TechniqueRepository<dynamic>();
                case EntityTypeEnum.Technique:
                    return new TechniqueRepository<dynamic>();
                case EntityTypeEnum.Tool:
                    return new ToolRepository<dynamic>();
                case EntityTypeEnum.None:
                    return null;
                default:
                    return null;
            }
        }
    }
}
