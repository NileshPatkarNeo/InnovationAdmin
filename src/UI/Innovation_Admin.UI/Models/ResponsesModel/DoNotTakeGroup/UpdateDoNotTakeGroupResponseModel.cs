﻿using Innovation_Admin.UI.Models.DoNotTakeGroup;
using Newtonsoft.Json;

namespace Innovation_Admin.UI.Models.ResponsesModel.DoNotTakeGroup
{
    public class UpdateDoNotTakeGroupResponseModel
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
        public DoNotTakeGroupDto updatedoNotTakeGroup { get; set; }
    }
}