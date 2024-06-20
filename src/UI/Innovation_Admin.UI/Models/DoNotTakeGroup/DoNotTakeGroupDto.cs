using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Innovation_Admin.UI.Models.DoNotTakeGroup
{
    public class DoNotTakeGroupDto
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("groupCode")]
        [Required]
        [DisplayName("Group Code")]
        [Remote(action: "IsGroupCodeUnique", controller: "Common", ErrorMessage = "Group Code is already in use.")]
        public int GroupCode { get; set; }

        [JsonProperty("groupName")]
        [Required]
        [DisplayName("Group Name")]
        public string GroupName { get; set; }
    }
}
