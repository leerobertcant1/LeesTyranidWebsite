using System.Collections.Generic;

namespace Tyranids.BusinessLogic.Abstractions
{
    public interface IJsonService
    {
        IEnumerable<T> ConvertJsonList<T>(string json);
    }
}
