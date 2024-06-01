using Innovation_Admin.UI.Models.PharmacyGroup;
using Newtonsoft.Json;

namespace Innovation_Admin.UI.Models.ResponsesModel.PharmacyGroup
{
    public class CreatePharmacyGroupResponseModel
    {
        [JsonProperty("isSuccess")]
        public bool IsSuccess { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("token")]
        public string Token { get; set; }

        [JsonProperty("statusCode")]
        public string StatusCode { get; set; }

        [JsonProperty("data")]
        public PharmacyGroupDto Data { get; set; }
    }
}
