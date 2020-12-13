using DataManager.Models;
using System.Collections.Generic;

namespace Tyranids.MvcUi.Models
{
    public class ModelsViewModel
    {
        public IEnumerable<ModelModel> Models { get; set; }
        public string Type { get; set; }
    }
}
