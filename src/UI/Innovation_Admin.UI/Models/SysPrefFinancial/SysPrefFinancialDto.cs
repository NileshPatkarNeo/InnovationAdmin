using System;
using System.ComponentModel.DataAnnotations;
using MessagePack;
using Newtonsoft.Json;

namespace Innovation_Admin.UI.Models.SysPrefFinancial
{
    public class SysPrefFinancialDto
    {
        [Required(ErrorMessage = "Financial ID is required.")]
        [JsonProperty("financialID")]
        public Guid FinancialID { get; set; }

        [Required(ErrorMessage = "Company ID is required.")]
        [JsonProperty("companyID")]
        public Guid CompanyID { get; set; }

        [IgnoreMember]
        [JsonProperty("companyName")]
        public string CompanyName { get; set; }

        [Required(ErrorMessage = "Default Payment Method is required.")]
        [MaxLength(100, ErrorMessage = "Default Payment Method cannot exceed 100 characters.")]
        [JsonProperty("defaultPaymentMethod")]
        public string DefaultPaymentMethod { get; set; }

        [Required(ErrorMessage = "Last Check No is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Last Check No must be a positive value.")]
        [JsonProperty("lastCheckNo")]
        public int LastCheckNo { get; set; }

        [Required(ErrorMessage = "Claim Age Collection Start is required.")]
        [JsonProperty("claimAgeCollectionStart")]
        public DateTime ClaimAgeCollectionStart { get; set; }

        [Required(ErrorMessage = "Claim Age Collection End is required.")]
        [JsonProperty("claimAgeCollectionEnd")]
        public DateTime ClaimAgeCollectionEnd { get; set; }

        [Required(ErrorMessage = "Default Receipt Batch Description is required.")]
        [MaxLength(200, ErrorMessage = "Default Receipt Batch Description cannot exceed 200 characters.")]
        [JsonProperty("defaultReceiptBatchDescription")]
        public string DefaultReceiptBatchDescription { get; set; }

        [Required(ErrorMessage = "Claim Paid Threshold is required.")]
        [Range(0, int.MaxValue, ErrorMessage = "Claim Paid Threshold must be a non-negative value.")]
        [JsonProperty("claimPaidThreshold")]
        public int ClaimPaidThreshold { get; set; }

        [Required(ErrorMessage = "Claim Status Write Off is required.")]
        [MaxLength(200, ErrorMessage = "Claim Status Write Off cannot exceed 200 characters.")]
        [JsonProperty("claimStatusWriteOff")]
        public string ClaimStatusWriteOff { get; set; }

        [Required(ErrorMessage = "Days To Block is required.")]
        [Range(0, int.MaxValue, ErrorMessage = "Days To Block must be a non-negative value.")]
        [JsonProperty("daysToBlock")]
        public int DaysToBlock { get; set; }


        [Required(ErrorMessage = "Message is Required")]
        [StringLength(1000)]
        [JsonProperty("message")]
        public string Message { get; set; }
    }       
}

