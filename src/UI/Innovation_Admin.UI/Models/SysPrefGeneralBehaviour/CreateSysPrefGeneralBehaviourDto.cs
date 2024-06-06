using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Innovation_Admin.UI.Models.SysPrefGeneralBehaviour
{
    public class CreateSysPrefGeneralBehaviourDto
    {
        public Guid Preference_ID { get; set; }
        public bool Auto_Change_Claim_Status { get; set; }
        public bool Claim_Status_Receipting { get; set; }
        public bool Claim_Status_Payment { get; set; }
        public bool Claim_Status_Zero_Paid { get; set; }
        public bool Claim_Status_Procare_Claim_Load { get; set; }
        public bool Logout_Redirect { get; set; }
        [Range(1, 7200, ErrorMessage = "Enter Seconds between 1-7200")]
        public int Records_Locked_Seconds { get; set; }

        [Range(1, 7200, ErrorMessage = "Enter Timeout between 1-7200")]
        public int User_Timeout { get; set; }

        [Required(ErrorMessage = "Message is Required")]
        [StringLength(1000)]
        [JsonProperty("message")]
        public string Message { get; set; }
    }
}
