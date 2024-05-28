using InnovationAdmin.Application.Features.AdminRoles.Commands.CreateAdminRole;
using InnovationAdmin.Application.Features.AdminRoles.Commands.UpdateAdminRole;
using InnovationAdmin.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnovationAdmin.Application.Contracts.Persistence
{
    public interface IAdminRoleRepository : IAsyncRepository<Admin_Role>
    {

    }
}
