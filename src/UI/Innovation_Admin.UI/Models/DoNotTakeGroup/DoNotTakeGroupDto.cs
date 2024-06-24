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
        [DisplayName("Group Code")]
        [Remote(action: "IsGroupCodeUnique", controller: "Common", AdditionalFields = "__RequestVerificationToken," + nameof(Id), ErrorMessage = "Group Code is already in use.")]
        [Range(1, int.MaxValue, ErrorMessage = "Group Code must be a positive number.")]
        [Required(ErrorMessage = "Group Code is required.")]
       
       
        public int GroupCode { get; set; }

        [JsonProperty("groupName")]
        [DisplayName("Group Name")]
        [MinLength(2, ErrorMessage = "Group should be at least 2 characters")]
        [Required(ErrorMessage = "Group Name is required.")]
        [MaxLength(50, ErrorMessage = "Group Name cannot exceed 50 characters.")]
    
        public string GroupName { get; set; }
    }
}
