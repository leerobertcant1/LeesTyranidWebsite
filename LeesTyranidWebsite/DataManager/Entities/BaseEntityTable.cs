namespace DataManager.Entities
{
    public abstract class BaseEntityTable
    {
        private static string database = "[TyranidsData]";
        private static string databaseAlias = "[dbo]";

        protected static string QueryPrefix = $"{database}.{databaseAlias}.";
    }
}
