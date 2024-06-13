using Newtonsoft.Json;


namespace Innovation_Admin.UI.Models.DoNotTakeGroup
{
    public class DoNotTakeGroupDto
    {

        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("groupCode")]
        public int GroupCode { get; set; }

        [JsonProperty("groupName")]
        public string GroupName { get; set; }
    }
}
