using System.Collections.Generic;

namespace Tyranids.MvcUi.Models
{
    public class ModelsViewModel
    {
        public IList<PictureViewModel> Models { get; set; } = new List<PictureViewModel>();
        public string Type { get; set; }
    }
}
