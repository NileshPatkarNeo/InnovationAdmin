using InnovationAdmin.Application.Contracts.Persistence;
using InnovationAdmin.Application.Features.AdminRoles.Commands.CreateAdminRole;
using InnovationAdmin.Application.Features.AdminRoles.Commands.UpdateAdminRole;
using InnovationAdmin.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Diagnostics.CodeAnalysis;

namespace InnovationAdmin.Persistence.Repositories
{
    [ExcludeFromCodeCoverage]
    public class AdminRoleRepository : BaseRepository<Admin_Role>, IAdminRoleRepository
    {
        private readonly ILogger _logger;
        public AdminRoleRepository(ApplicationDbContext dbContext, ILogger<Admin_Role> logger) : base(dbContext, logger)
        {
            _logger = logger;
        }

        public async Task<CreateAdminRoleDto> CreateAdminRoleAsync(CreateAdminRoleCommand command)
        {
            var adminRole = new Admin_Role()
            {
                Role_Name = command.Name,
                Description = command.Description
                // Set other properties as needed
            };

            _dbContext.AdminRoles.Add(adminRole);
            await _dbContext.SaveChangesAsync();

            return new CreateAdminRoleDto()
            {
                Role_ID = adminRole.Role_ID,
                Role_Name = adminRole.Role_Name,
                Description = adminRole.Description
            };
        }

        public async Task<Admin_Role> GetAdminRoleByIdAsync(int id)
        {
            var adminRole = await _dbContext.AdminRoles.FindAsync(id);

            if (adminRole == null)
                return null;

            return new Admin_Role
            {
                Role_ID = adminRole.Role_ID,
                Role_Name = adminRole.Role_Name,
                Description = adminRole.Description
            };
        }

        public async Task<Admin_Role> UpdateAdminRoleAsync(UpdateAdminRoleCommand command)
        {
            var adminRole = await _dbContext.AdminRoles.FindAsync(command.Role_ID);

            if (adminRole == null)
                return null;

            adminRole.Role_Name = command.Role_Name;
            adminRole.Description = command.Description;
            // Update other properties as needed

            _dbContext.AdminRoles.Update(adminRole);
            await _dbContext.SaveChangesAsync();

            return new Admin_Role
            {
                Role_ID = adminRole.Role_ID,
                Role_Name = adminRole.Role_Name,
                Description = adminRole.Description
            };
        }

        public async Task<bool> DeleteAdminRoleAsync(int id)
        {
            var adminRole = await _dbContext.AdminRoles.FindAsync(id);
            if (adminRole == null) return false;

            _dbContext.AdminRoles.Remove(adminRole);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<Admin_Role>> GetAllAdminRolesAsync()
        {
            var adminRole = await _dbContext.AdminRoles.ToListAsync();
            return adminRole.Select(t => new Admin_Role()
            {
                Role_ID = t.Role_ID,
                Role_Name = t.Role_Name,
                Description = t.Description
            });
        }

    }

  
}
