using Innovation_Admin.UI.Models.Account_Manager;
using Newtonsoft.Json;

namespace Innovation_Admin.UI.Models.ResponsesModel.AccountManager
{
    public class GetAccountManagerByIdResponseModel
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
        public AccountManagerDto Data { get; set; }
    }
}
