using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnovationAdmin.Application.Features.AdminRoles.Queries.GetAdminRoleList
{
    public class AdminRoleListVm
    {
        public Guid Role_ID { get; set; }
        public string Role_Name { get; set; }
        public string Description { get; set; }
    }
}
