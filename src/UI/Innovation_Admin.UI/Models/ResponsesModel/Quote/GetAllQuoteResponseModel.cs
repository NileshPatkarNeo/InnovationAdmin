using Innovation_Admin.UI.Models.Quote;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Innovation_Admin.UI.Models.ResponsesModel.Quote
{
    public class GetAllQuotesResponseModel
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
        public IEnumerable<QuoteDto> Data { get; set; }
    }
}
