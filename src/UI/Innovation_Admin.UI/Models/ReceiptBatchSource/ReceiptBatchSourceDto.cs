using Newtonsoft.Json;

namespace Innovation_Admin.UI.Models.ReceiptBatchSource
{
    public class ReceiptBatchSourceDto
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }
}
