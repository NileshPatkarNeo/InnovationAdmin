
using AutoMapper;
using InnovationAdmin.Application.Contracts.Persistence;
using InnovationAdmin.Application.Exceptions;
using InnovationAdmin.Application.Features.Admin_Users.Commands.CreateAdminUser;
using InnovationAdmin.Application.Responses;
using InnovationAdmin.Domain.Entities;
using MediatR;

namespace InnovationAdmin.Application.Features.Admin_Users.Commands.CreateAdmin_User
{
    public class CreateAdminUserCommandHandler : IRequestHandler<CreateAdminUserCommand, Response<CreateAdminUserDto>>
    {
        private readonly IMapper _mapper;
        private readonly IAdminUserRepository _adminuserRepository;
  
        public CreateAdminUserCommandHandler(IMapper mapper, IAdminUserRepository adminuserRepository)
        {
            _mapper = mapper;
            _adminuserRepository = adminuserRepository;
        }

        public async Task<Response<CreateAdminUserDto>> Handle(CreateAdminUserCommand request, CancellationToken cancellationToken)
        {
            Response<CreateAdminUserDto> createAdminUserCommandResponse = new Response<CreateAdminUserDto>();

            var validator = new CreateAdminUserValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                throw new ValidationException(validationResult);
            }
            else
            {
                var adminUser = _mapper.Map<Admin_User>(request);
                adminUser = await _adminuserRepository.AddAsync(adminUser);
                createAdminUserCommandResponse = new Response<CreateAdminUserDto>(_mapper.Map<CreateAdminUserDto>(adminUser), "success");
            }

            return createAdminUserCommandResponse;
        }


    }
}
