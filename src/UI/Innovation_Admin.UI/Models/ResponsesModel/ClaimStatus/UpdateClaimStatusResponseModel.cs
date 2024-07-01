﻿using Innovation_Admin.UI.Models.ClaimStatus;
using Newtonsoft.Json;

namespace Innovation_Admin.UI.Models.ResponsesModel.ClaimStatus
{
    public class UpdateClaimStatusResponseModel
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
        public ClaimStatusDto UpdatedClaimStatus { get; set; }
    }
}