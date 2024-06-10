using InnovationAdmin.Application.Contracts.Persistence;
using InnovationAdmin.Application.Features.Admin_Users.Queries.GetAdminUserList;
using InnovationAdmin.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnovationAdmin.Persistence.Repositories
{
    public class AdminUserRepository : BaseRepository<Admin_User>, IAdminUserRepository
    {
        private readonly ILogger _logger;
        public AdminUserRepository(ApplicationDbContext dbContext, ILogger<Admin_User> logger) : base(dbContext, logger)
        {
            _logger = logger;
        }


        public async Task<List<Admin_User>> GetActiveAdminUsers()
        {
            _logger.LogInformation("GetActiveAdminUsers Initiated");
            var activeAdminUsers = await _dbContext.Admin_Users.Where(u => u.Status).ToListAsync();
            _logger.LogInformation("GetActiveAdminUsers Completed");
            return activeAdminUsers;
        }

        public async Task<Admin_User> AddAdminUser(Admin_User adminUser)
        {
            _logger.LogInformation("AddAdminUser Initiated");
            await _dbContext.Admin_Users.AddAsync(adminUser);
            await _dbContext.SaveChangesAsync();
            _logger.LogInformation("AddAdminUser Completed");
            return adminUser;
        }

        public async Task<List<AdminUserListVm>> GetAdminUsersList()
        {
            _logger.LogInformation("GetActiveAdminUsers Initiated");
            var activeAdminUsers = await (from user in _dbContext.Admin_Users
                                          join role in _dbContext.AdminRoles
                                          on user.Role equals role.Role_ID
                                          select new AdminUserListVm
                                          {
                                              User_ID = user.User_ID,
                                              User_Name = user.User_Name,
                                              Status = user.Status,
                                              RoleId = user.Role,
                                              RoleName = role.Role_Name,
                                              Email = user.Email,
                                          }).ToListAsync();
            _logger.LogInformation("GetActiveAdminUsers Completed");
            return activeAdminUsers;
        }

    }
}
