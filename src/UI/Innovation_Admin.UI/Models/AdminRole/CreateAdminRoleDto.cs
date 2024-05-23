using Newtonsoft.Json;

namespace Innovation_Admin.UI.Models.AdminRole
{
    public class CreateAdminRoleDto
    {
        [JsonProperty("name")]

        public string Role_Name{ get; set; }

        [JsonProperty("description")]

        public string Description { get; set; }
    }
}
