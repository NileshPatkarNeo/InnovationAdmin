using Innovation_Admin.UI.Models.CategoryType;
using Newtonsoft.Json;

namespace Innovation_Admin.UI.Models.ResponsesModel.CategoryType
{
    public class UpdateCategoryTypeResponseModel
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
        public CategoryTypeDto UpdatedCategoryType { get; set; }
    }
}
