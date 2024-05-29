using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnovationAdmin.Application.Features.SysPrefFinancials.Commands.CreateSysPrefFinancial
{
    public class CreateSysPrefFinancialDto
    {
        public Guid FinancialID { get; set; }
        public Guid CompanyID { get; set; }
        public string DefaultPaymentMethod { get; set; }
        public int LastCheckNo { get; set; }
        public DateTime ClaimAgeCollectionStart { get; set; }
        public DateTime ClaimAgeCollectionEnd { get; set; }
        public string DefaultReceiptBatchDescription { get; set; }
        public int ClaimPaidThreshold { get; set; }
        public string ClaimStatusWriteOff { get; set; }
        public int DaysToBlock { get; set; }
    }
}
