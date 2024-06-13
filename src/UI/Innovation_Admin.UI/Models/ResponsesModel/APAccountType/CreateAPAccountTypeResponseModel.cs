using Innovation_Admin.UI.Models.APAccountType;
using Newtonsoft.Json;

namespace Innovation_Admin.UI.Models.ResponsesModel.APAccountType
{
    public class CreateAPAccountTypeResponseModel
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
        public CreateAPAccountTypeDto Data { get; set; }
    }
}
