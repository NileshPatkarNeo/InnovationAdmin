using InnovationAdmin.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnovationAdmin.Domain.Entities
{
    public class AccountManager : AuditableEntity
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
