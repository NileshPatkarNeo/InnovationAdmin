using AutoMapper;
using InnovationAdmin.Application.Contracts.Persistence;
using InnovationAdmin.Application.Features.Admin_Users.Queries.GetAdminUserList;
using InnovationAdmin.Application.Responses;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnovationAdmin.Application.Features.AuditTrail.Queries
{
    public class AuditTrailQueryHandler : IRequestHandler<GetAllAuditTrailQuery, Response<IEnumerable<AuditTrailDto>>>
    {
        private readonly IAuditTrailRepository _auditTrailRepository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public AuditTrailQueryHandler(IMapper mapper, IAuditTrailRepository auditTrailRepository, ILogger<AdminUserListQueryHandler> logger)
        {
            _mapper = mapper;
            _auditTrailRepository = auditTrailRepository;
            _logger = logger;
        }

        public async Task<Response<IEnumerable<AuditTrailDto>>> Handle(GetAllAuditTrailQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handle Initiated");
            var allAdminuser = (await _auditTrailRepository.GetAuditList()).OrderBy(x => x.UserName).ToList();
            var adminuser = _mapper.Map<IEnumerable<AuditTrailDto>>(allAdminuser);
            _logger.LogInformation("Hanlde Completed");
            return new Response<IEnumerable<AuditTrailDto>>(adminuser, "success");
        }
    }
}
