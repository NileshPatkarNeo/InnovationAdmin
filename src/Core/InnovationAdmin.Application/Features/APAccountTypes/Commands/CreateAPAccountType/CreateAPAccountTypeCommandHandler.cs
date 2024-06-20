using AutoMapper;
using InnovationAdmin.Application.Contracts.Persistence;
using InnovationAdmin.Application.Exceptions;
using InnovationAdmin.Application.Responses;
using InnovationAdmin.Domain.Entities;
using MediatR;

namespace InnovationAdmin.Application.Features.APAccountTypes.Commands.CreateAPAccountType
{
    public class CreateAPAccountTypeCommandHandler : IRequestHandler<CreateAPAccountTypeCommand, Response<CreateAPAccountTypeDto>>
    {
        private readonly IMapper _mapper;
        private readonly IAPAccountTypeRepository _aPAccountTypeRepository;
        public CreateAPAccountTypeCommandHandler(IMapper mapper, IAPAccountTypeRepository aPAccountTypeRepository)
        {
            _mapper = mapper;
            _aPAccountTypeRepository = aPAccountTypeRepository;
        }

        public async Task<Response<CreateAPAccountTypeDto>> Handle(CreateAPAccountTypeCommand request, CancellationToken cancellationToken)
        {
            Response<CreateAPAccountTypeDto> createAPAccountCommandResponse = null;

            var validator = new CreateAPAccountTypeValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                throw new ValidationException(validationResult);
            }
            else
            {
                var dataSource = _mapper.Map<APAccountType>(request);


                dataSource = await _aPAccountTypeRepository.AddAsync(dataSource);
                createAPAccountCommandResponse = new Response<CreateAPAccountTypeDto>(_mapper.Map<CreateAPAccountTypeDto>(dataSource), "success");
            }

            return createAPAccountCommandResponse;
        }

    }
}
