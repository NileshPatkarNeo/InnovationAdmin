using Innovation_Admin.UI.Models.ContractTerms;
using Newtonsoft.Json;

namespace Innovation_Admin.UI.Models.ResponsesModel.ContractTerm
{
    public class GetContractTermByIdResponseModel
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
        public ContractTermDto Data { get; set; }
    }
}
