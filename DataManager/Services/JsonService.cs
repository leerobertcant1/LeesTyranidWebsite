using System.Collections.Generic;
using DataManager.Abstractions;
using Newtonsoft.Json.Linq;
using System.Linq;

namespace DataManager.Services
{
    public class JsonService : IJsonService
    {
        public IEnumerable<T> ConvertJsonList<T>(string json)
        {
            var jArray = ConvertToJsonArray(json);

            var jObjectList = GetJObjectList(jArray);

            return GetObjectList<T>(jObjectList);
        }

        private JArray ConvertToJsonArray(string json) =>
              JArray.Parse(json);

        private IEnumerable<JObject> GetJObjectList(JArray jArray) =>
                 jArray.Select(j => JObject.Parse(j.ToString()));

        private IEnumerable<T> GetObjectList<T>(IEnumerable<JObject> jObjectList) =>
            jObjectList.Select(j => j.ToObject<T>());
    }
}
