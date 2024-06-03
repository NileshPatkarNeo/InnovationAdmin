using Innovation_Admin.UI.Models.AdminUser;
using Innovation_Admin.UI.Models.SysPrefSecurityEmail;
using Newtonsoft.Json;

namespace Innovation_Admin.UI.Models.ResponsesModel.SysPrefSecurityEmail
{
    public class UpdateSysPrefSecurityEmailResponseModel
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
        public SysPrefSecurityEmailDto UpdatedSysPrefSecurityEmail { get; set; }
    }
}
