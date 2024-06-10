using Newtonsoft.Json;

namespace Innovation_Admin.UI.Models.Quote
{
    public class QuoteDto
    {
        [JsonProperty("iD")]
        public Guid ID { get; set; }

        [JsonProperty("name")]

        public string Name { get; set; }

        [JsonProperty("quoteBy")]

        public string QuoteBy { get; set; }
    }
}
