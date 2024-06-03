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

namespace InnovationAdmin.Application.Features.Admin_Users.Commands.UpdateAdminUser
{
    public class UpdateAdminUserCommandHandler : IRequestHandler<UpdateAdminUserCommand, Response<UpdateAdminUserCommandDto>>
    {
        private readonly IAdminUserRepository _adminuserRepository;
        private readonly IMapper _mapper;
       
        public UpdateAdminUserCommandHandler(IMapper mapper, IAdminUserRepository adminuserRepository)
        {
            _mapper = mapper;
            _adminuserRepository = adminuserRepository;
            
        }

        public async Task<Response<UpdateAdminUserCommandDto>> Handle(UpdateAdminUserCommand request, CancellationToken cancellationToken)
        {
            var eventToUpdate = await _adminuserRepository.GetByIdAsync(request.User_ID);

            if (eventToUpdate == null)
            {
                throw new NotFoundException(nameof(Admin_Users), request.User_ID);
            }

            var validator = new UpdateAdminUserCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                throw new ValidationException(validationResult);

            _mapper.Map(request, eventToUpdate);

            await _adminuserRepository.UpdateAsync(eventToUpdate);
            var dto = new UpdateAdminUserCommandDto()
            {
                User_ID = request.User_ID,
                User_Name = request.User_Name,
                Password = request.Password,
                Role = request.Role,
                Email = request.Email,
                Status = request.Status

            };

            return new Response<UpdateAdminUserCommandDto>(dto, "Updated successfully ");

        }
    }
}
