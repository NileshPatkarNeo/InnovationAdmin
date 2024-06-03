



using AutoMapper;
using InnovationAdmin.Application.Contracts.Persistence;
using InnovationAdmin.Application.Exceptions;
using InnovationAdmin.Application.Responses;
using MediatR;

namespace InnovationAdmin.Application.Features.SysPrefSecurityEmails.Commands.UpdateSysPrefSecurityEmail
{
    public class UpdateSysPrefSecurityEmailCommandHandler : IRequestHandler<UpdateSysPrefSecurityEmailCommand, Response<UpdateSysPrefSecurityEmailCommandDto>>
    {
        private readonly ISysPrefSecurityEmailRepository _sysPrefSecurityEmailRepository;
        private readonly IMapper _mapper;

        public UpdateSysPrefSecurityEmailCommandHandler(IMapper mapper, ISysPrefSecurityEmailRepository sysPrefSecurityEmailRepository)
        {
            _mapper = mapper;
            _sysPrefSecurityEmailRepository = sysPrefSecurityEmailRepository;

        }


        public async Task<Response<UpdateSysPrefSecurityEmailCommandDto>> Handle(UpdateSysPrefSecurityEmailCommand request, CancellationToken cancellationToken)
        {
            var eventToUpdate = await _sysPrefSecurityEmailRepository.GetByIdAsync(request.SysPrefSecurityEmailId);

            if (eventToUpdate == null)
            {
                throw new NotFoundException(nameof(SysPrefSecurityEmails), request.SysPrefSecurityEmailId);
            }

            var validator = new UpdateSysPrefSecurityEmailCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                throw new ValidationException(validationResult);

            _mapper.Map(request, eventToUpdate);

            await _sysPrefSecurityEmailRepository.UpdateAsync(eventToUpdate);

            
            return new Response<UpdateSysPrefSecurityEmailCommandDto>(_mapper.Map<UpdateSysPrefSecurityEmailCommandDto>(eventToUpdate), "Updated successfully ");

        }
    }
}
