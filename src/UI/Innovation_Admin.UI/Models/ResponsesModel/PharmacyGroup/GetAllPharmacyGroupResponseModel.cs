using Newtonsoft.Json;

namespace Innovation_Admin.UI.Models.ResponsesModel.PharmacyGroup
{
    public class GetAllPharmacyGroupResponseModel
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
        public IEnumerable<Models.PharmacyGroup.PharmacyGroupDto> Data { get; set; }
    }
}
