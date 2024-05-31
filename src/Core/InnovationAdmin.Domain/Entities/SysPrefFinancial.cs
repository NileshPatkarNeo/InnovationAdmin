using InnovationAdmin.Domain.Common;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InnovationAdmin.Domain.Entities
{
    public class SysPrefFinancial : AuditableEntity
    {
        [Key]
        public Guid FinancialID { get; set; }

        [Required]
        public Guid CompanyID { get; set; }

        [ForeignKey("CompanyID")]
        public SysPrefCompany Company { get; set; }

        [Required]
        [StringLength(50)]
        public string DefaultPaymentMethod { get; set; }

        [Range(0, int.MaxValue)]
        public int LastCheckNo { get; set; }

        [Required]
        public DateTime ClaimAgeCollectionStart { get; set; }

        [Required]
        public DateTime ClaimAgeCollectionEnd { get; set; }

        [StringLength(100)]
        public string DefaultReceiptBatchDescription { get; set; }

        [Range(0, int.MaxValue)]
        public int ClaimPaidThreshold { get; set; }

        [StringLength(50)]
        public string ClaimStatusWriteOff { get; set; }

        [Range(0, int.MaxValue)]
        public int DaysToBlock { get; set; }
    }
}
