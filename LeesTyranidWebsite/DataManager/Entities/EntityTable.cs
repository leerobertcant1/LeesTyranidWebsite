namespace DataManager.Entities
{
    public class EntityTable: BaseEntityTable
    {
        public static readonly string ClassificationEntity = $"{QueryPrefix}[Classification]";
        public static readonly string ModelEntity = $"{QueryPrefix}[Model]";
        public static readonly string ModelSectionEntity = $"{QueryPrefix}[ModelSection]";
        public static readonly string ModelSectionActivityEntity = $"{QueryPrefix}[ModelSectionActivity]";
        public static readonly string PaintEntity = $"{QueryPrefix}[Paint]";
        public static readonly string PaintingActivityEntity = $"{QueryPrefix}[PaintingActivity]";
        public static readonly string PictureEntity = $"{QueryPrefix}[Picture]";
        public static readonly string TechniqueEntity = $"{QueryPrefix}[Technique]";
        public static readonly string ToolEntity = $"{QueryPrefix}[Tool]";
    }
}
