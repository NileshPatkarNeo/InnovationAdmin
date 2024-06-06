using Innovation_Admin.UI.Models.Quote;
using Newtonsoft.Json;
using System;

namespace Innovation_Admin.UI.Models.ResponsesModel.Quote
{
    public class GetQuoteByIdResponseModel
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
        public QuoteDto Data { get; set; }
    }
}
