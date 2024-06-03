using AutoMapper;
using InnovationAdmin.Application.Contracts.Persistence;
using InnovationAdmin.Application.Exceptions;
using InnovationAdmin.Application.Responses;
using InnovationAdmin.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnovationAdmin.Application.Features.Admin_Users.Queries.GetAdminUserById
{
    public class AdminUserByIdQueryHandler :  IRequestHandler<AdminUserByIdQuery, Response<AdminUserByIdVm>>
    {
        private readonly IAsyncRepository<Admin_User> _admiuserRepository;
        private readonly IMapper _mapper;
        private readonly IDataProtector _protector;
        public AdminUserByIdQueryHandler(IMapper mapper, IAsyncRepository<Admin_User> admiuserRepository,  IDataProtectionProvider provider)
        {
            _mapper = mapper; 
            _admiuserRepository = admiuserRepository;
            _protector = provider.CreateProtector("");
        }

        public async Task<Response<AdminUserByIdVm>> Handle(AdminUserByIdQuery request, CancellationToken cancellationToken)
        {
            var @system = await _admiuserRepository.GetByIdAsync(new Guid(request.User_ID));
            var systemDto = _mapper.Map<AdminUserByIdVm>(system);

            if (@system == null)
            {
                throw new NotFoundException(nameof(AdminUserByIdVm), @system.User_ID);
            }

            var response = new Response<AdminUserByIdVm>(systemDto);
            return response;
        }
    }
}
