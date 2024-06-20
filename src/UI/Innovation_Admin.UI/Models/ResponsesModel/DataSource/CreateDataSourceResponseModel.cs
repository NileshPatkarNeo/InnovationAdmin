using Innovation_Admin.UI.Models.DataSource;
using Newtonsoft.Json;

namespace Innovation_Admin.UI.Models.ResponsesModel.DataSource
{
    public class CreateDataSourceResponseModel
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
        public CreateDataSourceDto Data { get; set; }
    }
}
