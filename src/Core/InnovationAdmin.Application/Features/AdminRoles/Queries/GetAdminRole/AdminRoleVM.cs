using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnovationAdmin.Application.Features.AdminRoles.Queries.GetAdminRole
{
    public class AdminRoleVM
    {
        public Guid Role_ID { get; set; }
        public string Role_Name { get; set; }
        public string Description { get; set; }
    }
}
