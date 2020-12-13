using System.Collections.Generic;
using System.Linq;

namespace Tyranids.Globals
{
    public static class GlobalFunctions
    {
        public static IList<T> CastIList<T>(dynamic data)
        {
            return (data as IEnumerable<T>).Cast<T>().ToList();
        }
    }
}
