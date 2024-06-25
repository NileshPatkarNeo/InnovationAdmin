using Innovation_Admin.UI.Models.PharmacyGroup;
using Innovation_Admin.UI.Models.PharmacyType;
using Newtonsoft.Json;

namespace Innovation_Admin.UI.Models.ResponsesModel.PharmacyType
{
    public class GetPharmacyTypeByIdResponseModel
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
        public PharmacyTypeDto Data { get; set; }
    }
}
