using Innovation_Admin.UI.Models.AdminRole;
using Newtonsoft.Json;

namespace Innovation_Admin.UI.Models.ResponsesModel.AdminRole
{
    public class GetAdminRoleByIdResponseModel
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
        public AdminRoleDto Data { get; set; }

    }
}
