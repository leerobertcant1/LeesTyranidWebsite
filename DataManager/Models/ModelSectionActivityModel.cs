using System;

namespace DataManager.Models
{
    public class ModelSectionActivityModel: BaseModel
    {
        public DateTime DateAdded { get; set; }
        public string ModelId { get; set; }
        public string PaintingActivityId { get; set; }
        public string ToolId { get; set; }
        public string PictureId { get; set; }
    }
}
