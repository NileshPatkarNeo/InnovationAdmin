using Innovation_Admin.UI.Models.SysPrefGeneralBehaviour;
using Newtonsoft.Json;

namespace Innovation_Admin.UI.Models.ResponsesModel.SysPrefGeneralBehaviour
{
    public class GetSysPrefGeneralBehaviourByIdResponseModel
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
        public SysPrefGeneralBehaviourDto Data { get; set; }

    }
}
