

using InnovationAdmin.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace InnovationAdmin.Domain.Entities
{
    public class DoNotTakeGroup : AuditableEntity
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(100)]
        public int GroupCode{ get; set; }
        [Required]
        [MaxLength(100)]
        public string GroupName { get; set; }
    }
}
