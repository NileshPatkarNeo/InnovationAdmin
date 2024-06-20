﻿using Innovation_Admin.UI.Models.ResponsesModel;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Innovation_Admin.UI.Models.SysPrefGeneralBehaviour
{
    public class SysPrefGeneralBehaviourDto
    {
        [JsonProperty("preference_ID")]
        public Guid Preference_ID { get; set; }

        [JsonProperty("auto_Change_Claim_Status")]
        public bool Auto_Change_Claim_Status { get; set; }

        [JsonProperty("claim_Status_Receipting")]
        public bool Claim_Status_Receipting { get; set; }

        [JsonProperty("claim_Status_Payment")]
        public bool Claim_Status_Payment { get; set; }

        [JsonProperty("claim_Status_Zero_Paid")]
        public bool Claim_Status_Zero_Paid { get; set; }

        [JsonProperty("claim_Status_Procare_Claim_Load")]
        public bool Claim_Status_Procare_Claim_Load { get; set; }

        [JsonProperty("logout_Redirect")]
        public bool Logout_Redirect { get; set; }

        [JsonProperty("records_Locked_Seconds")]
        [Required(ErrorMessage = "Records Locked Seconds is required")]
        [Range(1, 7200, ErrorMessage = "Records Locked Seconds must be between 1-7200")]
        public int Records_Locked_Seconds { get; set; }

        [JsonProperty("user_Timeout")]
        [Required(ErrorMessage = "User Timeout is required")]
        [Range(1, 7200, ErrorMessage = "user_Timeout must be between 1-7200")]
        public int User_Timeout { get; set; }

        [Required(ErrorMessage = "Message is Required")]
        [StringLength(1000)]
        [JsonProperty("message")]
        public string Message { get; set; }
    }
}
