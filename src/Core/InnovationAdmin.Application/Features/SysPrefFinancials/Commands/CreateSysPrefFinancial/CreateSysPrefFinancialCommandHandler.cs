using AutoMapper;
using InnovationAdmin.Application.Contracts.Persistence;
using InnovationAdmin.Application.Exceptions;
using InnovationAdmin.Application.Features.AdminRoles.Commands.CreateAdminRole;
using InnovationAdmin.Application.Responses;
using InnovationAdmin.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnovationAdmin.Application.Features.SysPrefFinancials.Commands.CreateSysPrefFinancial
{
    public class CreateSysPrefFinancialCommandHandler : IRequestHandler<CreateSysPrefFinancialCommand, Response<CreateSysPrefFinancialDto>>
    {
        private readonly IAsyncRepository<SysPrefFinancial> _sysPrefFinancialRepository;
        private readonly IAsyncRepository<SysPrefCompany> _sysPrefCompanyRepository;
        private readonly IMapper _mapper;

        public CreateSysPrefFinancialCommandHandler(
            IAsyncRepository<SysPrefFinancial> sysPrefFinancialRepository,
            IAsyncRepository<SysPrefCompany> sysPrefCompanyRepository,
            IMapper mapper)
        {
            _sysPrefFinancialRepository = sysPrefFinancialRepository;
            _sysPrefCompanyRepository = sysPrefCompanyRepository;
            _mapper = mapper;
        }

        public async Task<Response<CreateSysPrefFinancialDto>> Handle(CreateSysPrefFinancialCommand request, CancellationToken cancellationToken)
        {
            Response<CreateSysPrefFinancialDto> createSysPrefFinancialCommandResponse = null;

            // Validation
            var validator = new CreateSysPrefFinancialCommandValidator(_sysPrefCompanyRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                throw new ValidationException(validationResult);
            }

            // Ensure the CompanyID exists
            var companyExists = await _sysPrefCompanyRepository.GetByIdAsync(request.CompanyID);
            if (companyExists == null)
            {
                throw new NotFoundException(nameof(SysPrefCompany), request.CompanyID);
            }

            var sysPrefFinancial = new SysPrefFinancial
            {
                FinancialID = Guid.NewGuid(),
                CompanyID = request.CompanyID,
                DefaultPaymentMethod = request.DefaultPaymentMethod,
                LastCheckNo = request.LastCheckNo,
                ClaimAgeCollectionStart = request.ClaimAgeCollectionStart,
                ClaimAgeCollectionEnd = request.ClaimAgeCollectionEnd,
                DefaultReceiptBatchDescription = request.DefaultReceiptBatchDescription,
                ClaimPaidThreshold = request.ClaimPaidThreshold,
                ClaimStatusWriteOff = request.ClaimStatusWriteOff,
                DaysToBlock = request.DaysToBlock
            };

            sysPrefFinancial = await _sysPrefFinancialRepository.AddAsync(sysPrefFinancial);

            var createSysPrefFinancialDto = _mapper.Map<CreateSysPrefFinancialDto>(sysPrefFinancial);
            return new Response<CreateSysPrefFinancialDto>(createSysPrefFinancialDto, "success");
        }
    }
}
