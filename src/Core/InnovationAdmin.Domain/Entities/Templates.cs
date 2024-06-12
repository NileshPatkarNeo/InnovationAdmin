using InnovationAdmin.Domain.Common;
using System.ComponentModel.DataAnnotations;


namespace InnovationAdmin.Domain.Entities
{
    public class Templates : AuditableEntity
    {
        [Key]
        public Guid ID { get; set; }

        [StringLength(50)]
        [Required]
        public string Name { get; set; }

        [StringLength(200)]
        [Required]
        public string PdfTemplateFile { get; set; }
       
        [StringLength(50)]
        [Required]
        public string Domain { get; set; }
       
        [StringLength(50)]
        [Required]
        public string Size { get; set; }


    }
}
