using InnovationAdmin.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;

namespace InnovationAdmin.Domain.Entities
{
    public class Quotes : AuditableEntity
    {
        [Key]
        public Guid ID { get; set; }
        [Required(ErrorMessage = "Name is required")]
        [MaxLength(100)]
        [MinLength(2, ErrorMessage = "Name should have at least 2 characters.")]
        [StringLength(100, ErrorMessage = "Name length can't be more than 100.")]
       
        public string Name { get; set; }

        [Required(ErrorMessage = "QuoteBy is required")]
        [MaxLength(25)]
        [MinLength(2, ErrorMessage = "QuoteBy should have at least 2 characters.")]
        [StringLength(25, ErrorMessage = "QuoteBy length can't be more than 25.")]
      
        public string QuoteBy { get; set; }
    }
}
