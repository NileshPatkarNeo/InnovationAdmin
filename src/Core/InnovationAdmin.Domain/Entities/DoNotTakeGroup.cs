

using System.ComponentModel.DataAnnotations;

namespace InnovationAdmin.Domain.Entities
{
    public class DoNotTakeGroup
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
