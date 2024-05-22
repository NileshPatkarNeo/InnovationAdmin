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
        Task<CreateAdminRoleDto> CreateAdminRoleAsync(CreateAdminRoleCommand command);

        Task<Admin_Role> GetAdminRoleByIdAsync(int id);
        Task<Admin_Role> UpdateAdminRoleAsync(UpdateAdminRoleCommand command);
        Task<bool> DeleteAdminRoleAsync(int id);
        Task<IEnumerable<Admin_Role>> GetAllAdminRolesAsync();
    }
}
