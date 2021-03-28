using Newtonsoft.Json;

namespace DataManager.Models
{
    public class IdentityModel
    {
        [JsonProperty("Password")]
        public string Password { get; set; }
        [JsonProperty("Username")]
        public string Username { get; set; }
    }
}