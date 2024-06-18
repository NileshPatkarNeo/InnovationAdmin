using InnovationAdmin.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace InnovationAdmin.Domain.Entities
{
    public class ContractTerms : AuditableEntity
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [MaxLength(100)]
        [MinLength(2, ErrorMessage = "Name should have at least 2 characters.")]
        [StringLength(100, ErrorMessage = "Name length can't be more than 100.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "ContractType is required")]
        [MaxLength(50)]
        [MinLength(2, ErrorMessage = "ContractType should have at least 2 characters.")]
        [StringLength(50, ErrorMessage = "ContractType length can't be more than 50.")]
        public string ContractType { get; set; }

        [Required(ErrorMessage = "ContractTypeCode is required")]
        [Range(1, int.MaxValue, ErrorMessage = "ContractTypeCode should be a positive integer.")]
        public int ContractTypeCode { get; set; }
    }
}
