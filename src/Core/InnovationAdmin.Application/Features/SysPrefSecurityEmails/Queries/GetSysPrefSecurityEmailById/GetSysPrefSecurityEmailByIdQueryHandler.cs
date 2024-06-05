using AutoMapper;
using InnovationAdmin.Application.Contracts.Persistence;
using InnovationAdmin.Application.Exceptions;
using InnovationAdmin.Application.Features.Admin_Users.Queries.GetAdminUserById;
using InnovationAdmin.Application.Responses;
using InnovationAdmin.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.DataProtection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnovationAdmin.Application.Features.SysPrefSecurityEmails.Queries.GetSysPrefSecurityEmailById
{
    public class GetSysPrefSecurityEmailByIdQueryHandler : IRequestHandler<GetSysPrefSecurityEmailByIdQuery, Response<GetSysPrefSecurityEmailByIdVm>>
    {
        private readonly IAsyncRepository<SysPrefSecurityEmail> _sysPrefSecurityEmail;
        private readonly IMapper _mapper;
        private readonly IDataProtector _protector;
        public GetSysPrefSecurityEmailByIdQueryHandler(IMapper mapper, IAsyncRepository<SysPrefSecurityEmail> sysPrefSecurityEmail, IDataProtectionProvider provider)
        {
            _mapper = mapper;
            _sysPrefSecurityEmail = sysPrefSecurityEmail;
            _protector = provider.CreateProtector("");
        }

        public async Task<Response<GetSysPrefSecurityEmailByIdVm>> Handle(GetSysPrefSecurityEmailByIdQuery request, CancellationToken cancellationToken)
        {
            var @system = await _sysPrefSecurityEmail.GetByIdAsync(new Guid(request.SysPrefSecurityEmailId));
            var systemDto = _mapper.Map<GetSysPrefSecurityEmailByIdVm>(system);

            if (@system == null)
            {
                throw new NotFoundException(nameof(GetSysPrefSecurityEmailByIdVm), @system.SysPrefSecurityEmailId);
            }

            var response = new Response<GetSysPrefSecurityEmailByIdVm>(systemDto);
            return response;
        }

    }
}

