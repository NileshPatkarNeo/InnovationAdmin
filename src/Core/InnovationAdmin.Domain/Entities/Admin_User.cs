using InnovationAdmin.Domain.Common;
using System.ComponentModel.DataAnnotations;


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
        public Guid Role { get; set; }

        [Required]
        [EmailAddress]
        [MaxLength(100)]
        public string Email { get; set; }

        [Required]
        public bool Status { get; set; }
    }
}
