﻿using Innovation_Admin.UI.Models.ResponsesModel;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Innovation_Admin.UI.Models.AdminRole
{
    public class AdminRoleDto
    {
        [JsonProperty("role_ID")]
        public Guid Role_ID { get; set; }

        [JsonProperty("role_Name")]

        public string Role_Name { get; set; }

        [JsonProperty("description")]

        public string Description { get; set; }

        [Required(ErrorMessage = "Message is Required")]
        [StringLength(1000)]
        [JsonProperty("message")]
        public string Message { get; set; }
    }
}
