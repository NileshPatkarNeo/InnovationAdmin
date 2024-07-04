using InnovationAdmin.Application.Features.Admin_Users.Queries.GetAdminUserList;
using InnovationAdmin.Application.Features.AuditTrail.Queries;
using InnovationAdmin.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnovationAdmin.Application.Contracts.Persistence
{
    public interface IAuditTrailRepository : IAsyncRepository<AuditTrail>
    {
        Task<List<AuditTrailDto>> GetAuditList();
    }
}
