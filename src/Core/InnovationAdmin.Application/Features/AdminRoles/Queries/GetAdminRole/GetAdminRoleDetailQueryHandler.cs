using AutoMapper;
using InnovationAdmin.Application.Contracts.Persistence;
using InnovationAdmin.Application.Exceptions;
using InnovationAdmin.Application.Responses;
using InnovationAdmin.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.DataProtection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnovationAdmin.Application.Features.AdminRoles.Queries.GetAdminRole
{
    public class GetAdminRoleDetailQueryHandler : IRequestHandler<GetAdminRoleDetailQuery, Response<AdminRoleVM>>
    {
        private readonly IAsyncRepository<Admin_Role> _adminRoleRepository;
        private readonly IMapper _mapper;

        private readonly IDataProtector _protector;
        public GetAdminRoleDetailQueryHandler(IMapper mapper, IAsyncRepository<Admin_Role> adminRoleRepository, IDataProtectionProvider provider)
        {
            _mapper = mapper;

            _adminRoleRepository = adminRoleRepository;

        }
        public async Task<Response<AdminRoleVM>> Handle(GetAdminRoleDetailQuery request, CancellationToken cancellationToken)
        {


            var @adminRole = await _adminRoleRepository.GetByIdAsync(request.Role_ID);
            var adminRoleDetailDto = _mapper.Map<AdminRoleVM>(@adminRole);


            if (@adminRole == null)
            {
                throw new NotFoundException(nameof(AdminRoleVM), @adminRole.Role_ID);
            }

            var response = new Response<AdminRoleVM>(adminRoleDetailDto);
            return response;
        }

    }

}
