using InnovationAdmin.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnovationAdmin.Domain.Entities
{
    public class SysPrefSecurityEmail : AuditableEntity
    {
        [Key]
        public Guid SysPrefSecurityEmailId { get; set; }

        [Required]
        [MaxLength(100)]
        public string DefaultFromName { get; set; }

        [Required]
        [MaxLength(100)]
        [EmailAddress]
        public string DefaultFromAddress { get; set; }

        [Required]
        [MaxLength(100)]
        [EmailAddress]
        public string DefaultReplyToAddress { get; set; }

        [Required]
        [MaxLength(100)]
        public string DefaultReplyToName { get; set; }


        [Required]
        [Range(0, 1)]
        public int Status {  get; set; }
    }
}
