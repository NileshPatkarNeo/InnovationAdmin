using Innovation_Admin.UI.Models.SysPrefFinancial;
using Newtonsoft.Json;

namespace Innovation_Admin.UI.Models.ResponsesModel.SysPrefFinancial
{
    public class UpdateSysPrefFinancialResponseModel
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
        public SysPrefFinancialDto Data { get; set; }
    }
}
