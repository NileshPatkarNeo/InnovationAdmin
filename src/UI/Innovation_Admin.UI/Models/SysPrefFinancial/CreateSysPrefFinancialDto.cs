﻿using Newtonsoft.Json;

namespace Innovation_Admin.UI.Models.SysPrefFinancial
{
    public class CreateSysPrefFinancialDto
    {
        [JsonProperty("companyID")]
        public Guid CompanyID { get; set; }

        [JsonProperty("defaultPaymentMethod")]
        public string DefaultPaymentMethod { get; set; }

        [JsonProperty("lastCheckNo")]
        public int LastCheckNo { get; set; }

        [JsonProperty("claimAgeCollectionStart")]
        public DateTime ClaimAgeCollectionStart { get; set; }

        [JsonProperty("claimAgeCollectionEnd")]
        public DateTime ClaimAgeCollectionEnd { get; set; }

        [JsonProperty("defaultReceiptBatchDescription")]
        public string DefaultReceiptBatchDescription { get; set; }

        [JsonProperty("claimPaidThreshold")]
        public int ClaimPaidThreshold { get; set; }

        [JsonProperty("claimStatusWriteOff")]
        public string ClaimStatusWriteOff { get; set; }

        [JsonProperty("daysToBlock")]
        public int DaysToBlock { get; set; }
    }
}
