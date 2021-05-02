using DataManager.Queries;
namespace DataManager.Repositories
{
    public class BaseRepository
    {
        protected readonly string GetAllFrom = $"{QuerySyntax.Select} {QuerySyntax.AllFrom}";
        protected readonly string GetAllFromModelsPictures = $"{QuerySyntax.Select} {QuerySyntax.AllModelsPicturesFrom}";
    }
}
