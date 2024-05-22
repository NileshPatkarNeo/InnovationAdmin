using Innovation_Admin.UI.Models.SysPrefCompany;
using Newtonsoft.Json;

namespace Innovation_Admin.UI.Models.ResponsesModel.SysPrefCompany
{
    public class GetAllSysPrefCompanyResponseModel
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
        public IEnumerable<SysPrefCompanyDto> Data { get; set; }
    }
}
