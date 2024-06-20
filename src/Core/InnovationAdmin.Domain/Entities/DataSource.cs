using InnovationAdmin.Domain.Common;
using System.ComponentModel.DataAnnotations;


namespace InnovationAdmin.Domain.Entities
{
    public class DataSource : AuditableEntity
    {
        [Key]
        public Guid ID { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [MaxLength(50, ErrorMessage = "Name cannot exceed 50 characters.")]
        [MinLength(2, ErrorMessage = "Name should have at least 2 characters.")]
        [RegularExpression(@"^[a-zA-Z0-9\s]*$", ErrorMessage = "Name can only contain alphanumeric characters and spaces.")]
        public string Name { get; set; }
    }
}
