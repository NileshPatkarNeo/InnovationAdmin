using InnovationAdmin.Application.Contracts.Persistence;
using InnovationAdmin.Application.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnovationAdmin.Application.Features.SysPrefSecurityEmails.Commands.DeleteSysPrefSecurityEmail
{
    public class DeleteSysPrefSecurityEmailCommandHandler : IRequestHandler<DeleteSysPrefSecurityEmailCommand>
    {
        private readonly ISysPrefSecurityEmailRepository _sysPrefSecurityEmailRepository;

        public DeleteSysPrefSecurityEmailCommandHandler(ISysPrefSecurityEmailRepository sysPrefSecurityEmailRepository)
        {
            _sysPrefSecurityEmailRepository = sysPrefSecurityEmailRepository;
        }

        public async Task<Unit> Handle(DeleteSysPrefSecurityEmailCommand request, CancellationToken cancellationToken)
        {
            var sysPrefFinancialId = request.SysPrefSecurityEmailId;
            var sysPrefFinancialToDelete = await _sysPrefSecurityEmailRepository.GetByIdAsync(sysPrefFinancialId);
            if (sysPrefFinancialToDelete == null)
            {
                throw new NotFoundException(nameof(SysPrefSecurityEmails), sysPrefFinancialId);
            }
            await _sysPrefSecurityEmailRepository.DeleteAsync(sysPrefFinancialToDelete);
            return Unit.Value;
            //throw new NotImplementedException();
        }
    }
}
