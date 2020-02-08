using System.Collections.Generic;

namespace DataManager.Abstractions
{
   public interface IJsonService
    {
        IEnumerable<T> ConvertJsonList<T>(string json);
    }
}
