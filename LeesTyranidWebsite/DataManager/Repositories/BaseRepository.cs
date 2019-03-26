using DataManager.Queries;

namespace DataManager.Repositories
{
    public abstract class BaseRepository
    {
        protected readonly string GetAllFrom = $"{QuerySyntax.Select} {QuerySyntax.AllFrom}";
    }
}
