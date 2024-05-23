﻿using Innovation_Admin.UI.Models.AdminUser;
using Newtonsoft.Json;

namespace Innovation_Admin.UI.Models.ResponsesModel.AdminUser
{
    public class CreateAdminUserResponseModel
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
        public CreateAdminUserDto Data { get; set; }
    }
}
