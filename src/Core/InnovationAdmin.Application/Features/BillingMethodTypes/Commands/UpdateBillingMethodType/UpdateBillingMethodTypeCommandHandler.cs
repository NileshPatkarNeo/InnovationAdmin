using AutoMapper;
using InnovationAdmin.Application.Contracts.Persistence;
using InnovationAdmin.Application.Exceptions;
using InnovationAdmin.Application.Features.DataSources.Commands.UpdateDataSource;
using InnovationAdmin.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnovationAdmin.Application.Features.BillingMethodTypes.Commands.UpdateBillingMethodType
{
    public class UpdateBillingMethodTypeCommandHandler : IRequestHandler<UpdateBillingMethodTypeCommand, Response<UpdateBillingMethodTypeCommandDto>>
    {
        private readonly IBillingMethodTypeRepository _billingMethodTypeRepository;
        private readonly IMapper _mapper;

        public UpdateBillingMethodTypeCommandHandler(IMapper mapper, IBillingMethodTypeRepository billingMethodTypeRepository)
        {
            _mapper = mapper;
            _billingMethodTypeRepository = billingMethodTypeRepository;

        }

        public async Task<Response<UpdateBillingMethodTypeCommandDto>> Handle(UpdateBillingMethodTypeCommand request, CancellationToken cancellationToken)
        {
            var billingMethodToUpdate = await _billingMethodTypeRepository.GetByIdAsync(request.ID);

            if (billingMethodToUpdate == null)
            {
                throw new NotFoundException(nameof(BillingMethodTypes), request.ID);
            }

            var validator = new UpdateBillingMethodTypeCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                throw new ValidationException(validationResult);

            _mapper.Map(request, billingMethodToUpdate);

            await _billingMethodTypeRepository.UpdateAsync(billingMethodToUpdate);


            return new Response<UpdateBillingMethodTypeCommandDto>(_mapper.Map<UpdateBillingMethodTypeCommandDto>(billingMethodToUpdate), "Updated successfully ");

        }
    }
}
