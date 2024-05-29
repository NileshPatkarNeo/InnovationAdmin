using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Innovation_Admin.UI.Models.SysPrefSecurityEmail
{
    public class SysPrefSecurityEmailDto
    {
        [JsonProperty("sysPrefSecurityEmailId")]
        public Guid SysPrefSecurityEmailId { get; set; }

        [JsonProperty("defaultFromName")]
        public string DefaultFromName { get; set; }

        [JsonProperty("defaultFromAddress")]
        public string DefaultFromAddress { get; set; }

        [JsonProperty("defaultReplyToAddress")]
        public string DefaultReplyToAddress { get; set; }

        [JsonProperty("defaultReplyToName")]
        public string DefaultReplyToName { get; set; }

        [JsonProperty("status")]
        public int Status { get; set; }
    }
}
