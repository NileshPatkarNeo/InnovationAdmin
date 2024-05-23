using InnovationAdmin.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnovationAdmin.Domain.Entities
{
    public class Admin_User : AuditableEntity 
    {
        [Key]
        public Guid User_ID { get; set; }

       
        [Required]
        [MaxLength(50)]
        public string User_Name { get; set; }

       
        [Required]
        [MaxLength(100)]
        public string Password { get; set; }

        [Required]
        public int Role { get; set; }

        [Required]
        [EmailAddress]
        [MaxLength(100)]
        public string Email { get; set; }

        [Required]
        public bool Status { get; set; }
    }
}
