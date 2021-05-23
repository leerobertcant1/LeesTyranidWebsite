using System.Collections.Generic;

namespace Tyranids.MvcUi.Models
{
    public class PictureViewModel
    {
        public string Location { get; set; }
        public string Name { get; set; }
        public IList<string> Titles { get; set; } = new List<string>();
    }
}
