using InnovationAdmin.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnovationAdmin.Domain.Entities
{
    public class SysPref_GeneralBehaviours : AuditableEntity
    {
        [Key]
        public Guid Preference_ID { get; set; }

        public bool Auto_Change_Claim_Status { get; set; }
        public bool Claim_Status_Receipting { get; set; }
        public bool Claim_Status_Payment { get; set; }
        public bool Claim_Status_Zero_Paid { get; set; }
        public bool Claim_Status_Procare_Claim_Load { get; set; }
        public bool Logout_Redirect { get; set; }
        public int Records_Locked_Seconds { get; set; }
        public int User_Timeout { get; set; }

    }
}
