using Newtonsoft.Json;

namespace Innovation_Admin.UI.Models.Account_Manager
{
    public class AccountManagerDto
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
