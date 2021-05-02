namespace DataManager.Models
{
    public class ModelModel
    {
        public string ClassificationId { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
    }

    public class ModelModelPicture : ModelModel
    {
        public string Location { get; set; }       
        public string Title { get; set; }
    }
}