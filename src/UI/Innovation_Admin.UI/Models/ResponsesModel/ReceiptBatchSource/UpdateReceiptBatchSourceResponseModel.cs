﻿using Innovation_Admin.UI.Models.ReceiptBatchSource;
using Newtonsoft.Json;

namespace Innovation_Admin.UI.Models.ResponsesModel.ReceiptBatchSource
{
    public class UpdateReceiptBatchSourceResponseModel
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
        public ReceiptBatchSourceDto UpdatedReceiptBatchSource { get; set; }
    }
}
