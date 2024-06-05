using AutoMapper;
using InnovationAdmin.Application.Contracts.Persistence;
using InnovationAdmin.Application.Exceptions;
using InnovationAdmin.Application.Responses;
using InnovationAdmin.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnovationAdmin.Application.Features.SysPrefFinancials.Commands.UpdateSysPrefFinancial
{
    public class UpdateSysPrefFinancialCommandHandler : IRequestHandler<UpdateSysPrefFinancialCommand, Response<UpdateSysPrefFinancialDto>>
    {
        private readonly IAsyncRepository<SysPrefFinancial> _sysPrefFinancialRepository;
        private readonly IAsyncRepository<SysPrefCompany> _sysPrefCompanyRepository;
        private readonly IMapper _mapper;

        public UpdateSysPrefFinancialCommandHandler(
            IAsyncRepository<SysPrefFinancial> sysPrefFinancialRepository,
            IAsyncRepository<SysPrefCompany> sysPrefCompanyRepository,
            IMapper mapper)
        {
            _sysPrefFinancialRepository = sysPrefFinancialRepository;
            _sysPrefCompanyRepository = sysPrefCompanyRepository;
            _mapper = mapper;
        }

        public async Task<Response<UpdateSysPrefFinancialDto>> Handle(UpdateSysPrefFinancialCommand request, CancellationToken cancellationToken)
        {
            // Validation
            var validator = new UpdateSysPrefFinancialCommandValidator(_sysPrefCompanyRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                throw new ValidationException(validationResult);
            }

            // Ensure the FinancialID exists
            var sysPrefFinancial = await _sysPrefFinancialRepository.GetByIdAsync(request.FinancialID);
            if (sysPrefFinancial == null)
            {
                throw new NotFoundException(nameof(SysPrefFinancial), request.FinancialID);
            }

            // Ensure the CompanyID exists
            var companyExists = await _sysPrefCompanyRepository.GetByIdAsync(request.CompanyID);
            if (companyExists == null)
            {
                throw new NotFoundException(nameof(SysPrefCompany), request.CompanyID);
            }

            // Map the updates
            sysPrefFinancial.CompanyID = request.CompanyID;
            sysPrefFinancial.DefaultPaymentMethod = request.DefaultPaymentMethod;
            sysPrefFinancial.LastCheckNo = request.LastCheckNo;
            sysPrefFinancial.ClaimAgeCollectionStart = request.ClaimAgeCollectionStart;
            sysPrefFinancial.ClaimAgeCollectionEnd = request.ClaimAgeCollectionEnd;
            sysPrefFinancial.DefaultReceiptBatchDescription = request.DefaultReceiptBatchDescription;
            sysPrefFinancial.ClaimPaidThreshold = request.ClaimPaidThreshold;
            sysPrefFinancial.ClaimStatusWriteOff = request.ClaimStatusWriteOff;
            sysPrefFinancial.DaysToBlock = request.DaysToBlock;

            await _sysPrefFinancialRepository.UpdateAsync(sysPrefFinancial);

            var updateSysPrefFinancialDto = _mapper.Map<UpdateSysPrefFinancialDto>(sysPrefFinancial);
            return new Response<UpdateSysPrefFinancialDto>(updateSysPrefFinancialDto, "success");
        }
    }
}
