namespace TyranidsApi.Models
{
    public class AuthenticatedUser
    {
        public string Access_Token { get; set; }

        public string Error { get; set; }

        public string Username { get; set; }
    }
}