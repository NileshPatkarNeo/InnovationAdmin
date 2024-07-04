using InnovationAdmin.Application.Contracts.Persistence;
using InnovationAdmin.Application.Features.Admin_Users.Queries.GetAdminUserList;
using InnovationAdmin.Application.Features.AuditTrail.Queries;
using InnovationAdmin.Domain.Entities;
using InnovationAdmin.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnovationAdmin.Persistence.Repositories
{
    public class AuditTrailRepository : BaseRepository<AuditTrail>, IAuditTrailRepository
    {
        private readonly ILogger _logger;
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager; 
        public AuditTrailRepository(ILogger<AuditTrail> logger, ApplicationDbContext dbContext, UserManager<ApplicationUser> userManager) : base(dbContext, logger)
        {
            _logger = logger;
            _userManager = userManager;
        }

        public async Task<List<AuditTrailDto>> GetAuditList()
        {
            var useList = _userManager.Users;
            _logger.LogInformation("GetActiveAdminUsers Initiated");
            var activeAdminUsers =  (from audit in _dbContext.AuditTrails
                                          join user in useList
                                          on audit.UserId equals user.Id
                                          select new AuditTrailDto
                                          {
                                              Id = audit.Id,
                                              UserName = user.UserName,
                                              Type = audit.Type,
                                              TableName = audit.TableName,
                                              DateTime = audit.DateTime,
                                              OldValues = audit.OldValues,
                                              NewValues = audit.NewValues,
                                              AffectedColumns = audit.AffectedColumns,
                                          }).ToList();
            _logger.LogInformation("GetActiveAdminUsers Completed");
            return activeAdminUsers;
        }
    }
}
