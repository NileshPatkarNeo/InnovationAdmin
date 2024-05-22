using AutoMapper;
using InnovationAdmin.Application.Contracts.Persistence;
using InnovationAdmin.Application.Exceptions;
using InnovationAdmin.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnovationAdmin.Application.Features.AdminRoles.Commands.UpdateAdminRole
{
    public class UpdateAdminRoleCommandHandler : IRequestHandler<UpdateAdminRoleCommand, Response<UpdateAdminRoleDto>>
    {
        private readonly IAdminRoleRepository _adminRoleRepository;
        private readonly IMapper _mapper;
        private readonly IMessageRepository _messageRepository;

        public UpdateAdminRoleCommandHandler(IMapper mapper, IAdminRoleRepository adminRoleRepository, IMessageRepository messageRepository)
        {
            _mapper = mapper;
            _adminRoleRepository = adminRoleRepository;
            _messageRepository = messageRepository;
        }

        public async Task<Response<UpdateAdminRoleDto>> Handle(UpdateAdminRoleCommand request, CancellationToken cancellationToken)
        {
            var adminRoleToUpdate = await _adminRoleRepository.GetByIdAsync(request.Role_ID);


            if (adminRoleToUpdate == null)
            {
                throw new NotFoundException(nameof(UpdateAdminRoleDto), request.Role_ID);
            }

            var validator = new UpdateAdminRoleCommandValidator(_messageRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                throw new ValidationException(validationResult);

            _mapper.Map(request, adminRoleToUpdate);

            await _adminRoleRepository.UpdateAsync(adminRoleToUpdate);
            UpdateAdminRoleDto dto = new UpdateAdminRoleDto()
            {
                Role_ID = request.Role_ID,
                Role_Name = request.Role_Name,
                Description = request.Description,
            };
            return new Response<UpdateAdminRoleDto>(dto, "Updated successfully ");

        }
    }
}
