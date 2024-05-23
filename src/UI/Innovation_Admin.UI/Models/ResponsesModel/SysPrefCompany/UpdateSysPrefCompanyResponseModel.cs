using Innovation_Admin.UI.Models.SysPrefCompany;
using Newtonsoft.Json;

namespace Innovation_Admin.UI.Models.ResponsesModel.SysPrefCompany
{
    public class UpdateSysPrefCompanyResponseModel
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
        public SysPrefCompanyDto UpdatedSysPrefCompany { get; set; }
    }
}
