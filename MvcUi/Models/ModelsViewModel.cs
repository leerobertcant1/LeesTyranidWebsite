using DataManager.Models;
using System.Collections.Generic;

namespace Tyranids.MvcUi.Models
{
    public class ModelsViewModel
    {
        public IEnumerable<ModelModelPicture> Models { get; set; }
        public string Type { get; set; }
    }
}
