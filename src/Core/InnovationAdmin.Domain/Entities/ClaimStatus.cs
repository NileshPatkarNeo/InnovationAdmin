using InnovationAdmin.Domain.Common;
using System.ComponentModel.DataAnnotations;


namespace InnovationAdmin.Domain.Entities
{
    public  class ClaimStatus : AuditableEntity
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "Name must be between 1 and 100 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Color is required")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Color must be between 1 and 50 characters")]
        public string Color { get; set; }
    }
}
