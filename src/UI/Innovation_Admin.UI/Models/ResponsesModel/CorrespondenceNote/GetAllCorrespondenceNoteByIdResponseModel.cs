﻿using Innovation_Admin.UI.Models.CorrespondenceNote;
using Innovation_Admin.UI.Models.RemittanceType;
using Newtonsoft.Json;

namespace Innovation_Admin.UI.Models.ResponsesModel.CorrespondenceNote
{
    public class GetAllCorrespondenceNoteByIdResponseModel
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
        public CorrespondenceNoteDto Data { get; set; }
    }
}