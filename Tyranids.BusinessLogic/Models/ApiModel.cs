namespace Tyranids.BusinessLogic.Models
{
    public class ApiModel
    {
        public string ErrorMessage { get; set; }
        public bool IsError { get; set; }
        public dynamic Response { get; set; }
    }
}
