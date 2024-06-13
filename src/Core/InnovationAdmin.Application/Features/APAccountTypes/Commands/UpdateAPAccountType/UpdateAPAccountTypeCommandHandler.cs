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

namespace InnovationAdmin.Application.Features.APAccountTypes.Commands.UpdateAPAccountType
{
    public class UpdateAPAccountTypeCommandHandler : IRequestHandler<UpdateAPAccountTypeCommand
        , Response<UpdateAPAccountTypeCommandDto>>
    {
        private readonly IAPAccountTypeRepository _aPAccountTypeRepository;
        private readonly IMapper _mapper;

        public UpdateAPAccountTypeCommandHandler(IMapper mapper, IAPAccountTypeRepository aPAccountTypeRepository)
        {
            _mapper = mapper;
            _aPAccountTypeRepository = aPAccountTypeRepository;
        }

        public async Task<Response<UpdateAPAccountTypeCommandDto>> Handle(UpdateAPAccountTypeCommand request, CancellationToken cancellationToken)
        {
            var aPAccountTypeToUpdate = await _aPAccountTypeRepository.GetByIdAsync(request.ID);

            if (aPAccountTypeToUpdate == null)
            {
                throw new NotFoundException(nameof(APAccountTypes), request.ID);
            }

            var validator = new UpdateAPAccountTypeCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                throw new ValidationException(validationResult);

            _mapper.Map(request, aPAccountTypeToUpdate);

            await _aPAccountTypeRepository.UpdateAsync(aPAccountTypeToUpdate);


            return new Response<UpdateAPAccountTypeCommandDto>(_mapper.Map<UpdateAPAccountTypeCommandDto>(aPAccountTypeToUpdate), "Updated successfully ");

        }
    }
}
