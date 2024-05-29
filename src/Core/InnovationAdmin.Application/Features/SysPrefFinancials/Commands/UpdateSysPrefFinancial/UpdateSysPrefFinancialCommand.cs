using InnovationAdmin.Application.Features.AdminRoles.Commands.UpdateAdminRole;
using InnovationAdmin.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnovationAdmin.Application.Features.SysPrefFinancials.Commands.UpdateSysPrefFinancial
{
    public class UpdateSysPrefFinancialCommand: IRequest<Response<UpdateSysPrefFinancialDto>>
    {
       
        public Guid FinancialID { get; set; }

        [Required]
        public Guid CompanyID { get; set; }

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
