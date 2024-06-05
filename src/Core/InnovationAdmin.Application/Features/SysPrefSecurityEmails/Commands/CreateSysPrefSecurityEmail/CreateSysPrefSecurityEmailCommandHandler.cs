using AutoMapper;
using InnovationAdmin.Application.Contracts.Persistence;
using InnovationAdmin.Application.Exceptions;

using InnovationAdmin.Application.Responses;
using InnovationAdmin.Domain.Entities;
using MediatR;

namespace InnovationAdmin.Application.Features.SysPrefSecurityEmails.Commands.CreateSysPrefSecurityEmail
{
    public class CreateSysPrefSecurityEmailCommandHandler : IRequestHandler<CreateSysPrefSecurityEmailCommand, Response<CreateSysPrefSecurityEmailDto>>
    {
        private readonly IMapper _mapper;
        private readonly ISysPrefSecurityEmailRepository _sysPrefSecurityEmailRepository;
        public CreateSysPrefSecurityEmailCommandHandler(IMapper mapper, ISysPrefSecurityEmailRepository sysPrefSecurityEmailRepository)
        {
            _mapper = mapper;
            _sysPrefSecurityEmailRepository = sysPrefSecurityEmailRepository;
        }

        public async Task<Response<CreateSysPrefSecurityEmailDto>> Handle(CreateSysPrefSecurityEmailCommand request, CancellationToken cancellationToken)
        {
            Response<CreateSysPrefSecurityEmailDto> createAdminUserCommandResponse = null;

            var validator = new CreateSysPrefSecurityEmailValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                throw new ValidationException(validationResult);
            }
            else
            {
                var adminUser = _mapper.Map<SysPrefSecurityEmail>(request);
              

                adminUser = await _sysPrefSecurityEmailRepository.AddAsync(adminUser);
                createAdminUserCommandResponse = new Response<CreateSysPrefSecurityEmailDto>(_mapper.Map<CreateSysPrefSecurityEmailDto>(adminUser), "success");
            }

            return createAdminUserCommandResponse;
        }
    }
}

