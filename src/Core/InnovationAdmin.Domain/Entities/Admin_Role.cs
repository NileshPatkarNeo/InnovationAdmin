using InnovationAdmin.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnovationAdmin.Domain.Entities
{
    public class Admin_Role : AuditableEntity
    {
       
        [Key]
        public Guid Role_ID { get; set; }

        
        [Required]
        [MaxLength(50)]
        public string Role_Name { get; set; }

        [Required]
        [MaxLength(200)]
        public string Description { get; set; }
    }
}
