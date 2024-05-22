using AutoMapper;
using InnovationAdmin.Application.Contracts.Persistence;
using InnovationAdmin.Application.Responses;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnovationAdmin.Application.Features.AdminRoles.Queries.GetAdminRoleList
{
    public class GetAdminRolesListQueryHandler : IRequestHandler<GetAdminRolesListQuery, Response<IEnumerable<AdminRoleListVm>>>
    {
        private readonly IAdminRoleRepository _adminRoleRepository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        public GetAdminRolesListQueryHandler(IMapper mapper, IAdminRoleRepository adminRoleRepository, ILogger<GetAdminRolesListQueryHandler> logger)
        {
            _mapper = mapper;
            _adminRoleRepository = adminRoleRepository;
            _logger = logger;
        }
        public async Task<Response<IEnumerable<AdminRoleListVm>>> Handle(GetAdminRolesListQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handle Initiated");
            var allCategories = (await _adminRoleRepository.ListAllAsync()).OrderBy(x => x.Role_Name );
            var category = _mapper.Map<IEnumerable<AdminRoleListVm>>(allCategories);
            _logger.LogInformation("Hanlde Completed");
            return new Response<IEnumerable<AdminRoleListVm>>(category, "success");
        }
    }
}
