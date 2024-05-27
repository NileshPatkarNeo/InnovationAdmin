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

      
    }

  
}
