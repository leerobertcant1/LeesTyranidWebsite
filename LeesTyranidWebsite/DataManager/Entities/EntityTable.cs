namespace DataManager.Entities
{
    public static class EntityTable
    {
        private static string database = "[TyranidsData]";
        private static string databaseAlias = "[dbo]";

        public static readonly string ModelEntity = $"{database}.{databaseAlias}.[Model]";
        public static readonly string ModelSectionEntity = $"{database}.{databaseAlias}.[ModelSection]";
        public static readonly string ModelSectionActivityEntity = $"{database}.{databaseAlias}.[ModelSectionActivity]";
        public static readonly string PaintEntity = $"{database}.{databaseAlias}.[Paint]";
        public static readonly string PaintingActivityEntity = $"{database}.{databaseAlias}.[PaintingActivity]";
        public static readonly string PictureEntity = $"{database}.{databaseAlias}.[Picture]";
        public static readonly string TechniqueEntity = $"{database}.{databaseAlias}.[Technique]";
        public static readonly string ToolEntity = $"{database}.{databaseAlias}.[Tool]";
    }
}
