using AutoMapper;
using InnovationAdmin.Application.Contracts.Persistence;
using InnovationAdmin.Application.Exceptions;
using InnovationAdmin.Application.Responses;
using InnovationAdmin.Domain.Entities;
using MediatR;

namespace InnovationAdmin.Application.Features.BillingMethodTypes.Commands.CreateBillingMethodType
{
    public class CreateBillingMethodTypeCommandHandler : IRequestHandler<CreateBillingMethodTypeCommand, Response<CreateBillingMethodTypeDto>>
    {
        private readonly IMapper _mapper;
        private readonly IBillingMethodTypeRepository _billingMethodTypeRepository;
        public CreateBillingMethodTypeCommandHandler(IMapper mapper, IBillingMethodTypeRepository billingMethodTypeRepository)
        {
            _mapper = mapper;
            _billingMethodTypeRepository = billingMethodTypeRepository;
        }

        public async Task<Response<CreateBillingMethodTypeDto>> Handle(CreateBillingMethodTypeCommand request, CancellationToken cancellationToken)
        {
            Response<CreateBillingMethodTypeDto> createBillingMethodCommandResponse = null;

            var validator = new CreateBillingMethodTypeValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                throw new ValidationException(validationResult);
            }
            else
            {
                var billingMethod = _mapper.Map<BillingMethodType>(request);


                billingMethod = await _billingMethodTypeRepository.AddAsync(billingMethod);
                createBillingMethodCommandResponse = new Response<CreateBillingMethodTypeDto>(_mapper.Map<CreateBillingMethodTypeDto>(billingMethod), "success");
            }

            return createBillingMethodCommandResponse;
        }

    
    }
}
