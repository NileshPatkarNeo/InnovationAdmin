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

namespace InnovationAdmin.Application.Features.SysPrefSecurityEmails.Queries.GetSysPrefSecurityEmailList
{
    public class GetSysPrefSecurityEmailListQueryHandler : IRequestHandler<GetSysPrefSecurityEmailListQuery, Response<IEnumerable<GetSysPrefSecurityEmailListVm>>>
    {

        private readonly ISysPrefSecurityEmailRepository _sysPrefSecurityEmailRepository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        public GetSysPrefSecurityEmailListQueryHandler(IMapper mapper, ISysPrefSecurityEmailRepository sysPrefSecurityEmailRepository, ILogger<GetSysPrefSecurityEmailListQueryHandler> logger)
        {
            _mapper = mapper;
            _sysPrefSecurityEmailRepository = sysPrefSecurityEmailRepository;
            _logger = logger;
        }

        public async Task<Response<IEnumerable<GetSysPrefSecurityEmailListVm>>> Handle(GetSysPrefSecurityEmailListQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handle Initiated");
            var allAdminuser = (await _sysPrefSecurityEmailRepository.ListAllAsync()).OrderBy(x => x.DefaultFromName).ToList();
            var adminuser = _mapper.Map<IEnumerable<GetSysPrefSecurityEmailListVm>>(allAdminuser);
            _logger.LogInformation("Hanlde Completed");
            return new Response<IEnumerable<GetSysPrefSecurityEmailListVm>>(adminuser, "success");
        }
    }
    
}
