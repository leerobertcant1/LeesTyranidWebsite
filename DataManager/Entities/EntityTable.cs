namespace DataManager.Entities
{
    public class EntityTable: BaseEntityTable
    {
        public static readonly string ClassificationEntity = $"{QueryPrefix}[Classification] CL";
        public static readonly string ModelEntity = $"{QueryPrefix}[Model] MO";
        public static readonly string ModelPicturesEntities = $"{QueryPrefix}[Model] MO INNER JOIN {QueryPrefix}[Picture] PI On PI.ModelId = MO.Id";
        public static readonly string ModelSectionEntity = $"{QueryPrefix}[ModelSection] MS";
        public static readonly string ModelSectionActivityEntity = $"{QueryPrefix}[ModelSectionActivity] MSA";
        public static readonly string PaintEntity = $"{QueryPrefix}[Paint] PA";
        public static readonly string PaintingActivityEntity = $"{QueryPrefix}[PaintingActivity] PAA";        
        public static readonly string PictureEntity = $"{QueryPrefix}[Picture] PI";
        public static readonly string TechniqueEntity = $"{QueryPrefix}[Technique] TE";
        public static readonly string ToolEntity = $"{QueryPrefix}[Tool] TO";
    }
}
