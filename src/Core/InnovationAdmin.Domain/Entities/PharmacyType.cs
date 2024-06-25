using InnovationAdmin.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnovationAdmin.Domain.Entities
{
    public class PharmacyType :AuditableEntity
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(60)]
        public string Description { get; set; }

        [Required]
        [MaxLength(100)]
        public int Code { get; set; }

        public bool IsDeleted { get; set; }
    }
}
