using AutoMapper;
using InnovationAdmin.Application.Contracts.Persistence;
using InnovationAdmin.Application.Responses;
using InnovationAdmin.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InnovationAdmin.Application.Exceptions;
using InnovationAdmin.Application.Features.SysPrefCompanies.Commands.CreateSysPrefCompany;
using InnovationAdmin.Application.Features.Admin_Users.Commands.CreateAdmin_User;
using InnovationAdmin.Application.Features.Admin_Users.Commands.CreateAdminUser;

namespace InnovationAdmin.Application.Features.AdminRoles.Commands.CreateAdminRole
{
    public class CreateAdminRoleCommandHandler : IRequestHandler<CreateAdminRoleCommand, Response<CreateAdminRoleDto>>
    {
        private readonly IAdminRoleRepository _adminRoleService;
        private readonly IMessageRepository _messageRepository;
        private readonly IMapper _mapper;



        public CreateAdminRoleCommandHandler(IAdminRoleRepository adminRoleService, IMessageRepository messageRepository , IMapper mapper )
        {
            _adminRoleService = adminRoleService;
            _messageRepository = messageRepository;
            _mapper = mapper;
        }

        public async Task<Response<CreateAdminRoleDto>> Handle(CreateAdminRoleCommand request, CancellationToken cancellationToken)
        {
            Response<CreateAdminRoleDto> createAdminRoleCommandResponse = null;

            var validator = new CreateAdminRoleCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                throw new ValidationException(validationResult);
            }
            else
            {
                var adminRole = new Admin_Role()
                {
                    Role_Name = request.Name,
                    Description = request.Description,
                };

                adminRole = await _adminRoleService.AddAsync(adminRole);
                createAdminRoleCommandResponse = new Response<CreateAdminRoleDto>(_mapper.Map<CreateAdminRoleDto>(adminRole), "success");
            }

            return createAdminRoleCommandResponse;
        }

    }
}
