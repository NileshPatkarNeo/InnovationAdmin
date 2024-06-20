using InnovationAdmin.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnovationAdmin.Domain.Entities
{
    public class RemittanceType : AuditableEntity
    {
        [Key]
        public Guid ID { get; set; }

        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

    }
}
