using Newtonsoft.Json;

namespace Innovation_Admin.UI.Models.AdminRole
{
    public class AdminRoleDto
    {
        [JsonProperty("role_ID")]
        public Guid Role_ID { get; set; }

        [JsonProperty("role_Name")]

        public string Role_Name { get; set; }

        [JsonProperty("description")]

        public string Description { get; set; }
    }
}
