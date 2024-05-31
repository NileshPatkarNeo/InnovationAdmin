using InnovationAdmin.Application.Contracts.Persistence;
using InnovationAdmin.Application.Exceptions;
using InnovationAdmin.Application.Features.AdminRoles.Commands.DeleteAdminRole;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnovationAdmin.Application.Features.SysPrefFinancials.Commands.DeleteSysPrefFinancial
{
    public class DeleteSysPrefFinancialCommandHandler : IRequestHandler<DeleteSysPrefFinancialCommand>
    {
        private readonly ISysPrefFinancialRepository _sysPrefFinancialRepository;

        public DeleteSysPrefFinancialCommandHandler(ISysPrefFinancialRepository sysPrefFinancialRepository)
        {
            _sysPrefFinancialRepository = sysPrefFinancialRepository;
        }

        public async Task<Unit> Handle(DeleteSysPrefFinancialCommand request, CancellationToken cancellationToken)
        {
            var sysPrefFinancialId = request.FinancialID;
            var sysPrefFinancialToDelete = await _sysPrefFinancialRepository.GetByIdAsync(sysPrefFinancialId);
            if (sysPrefFinancialToDelete == null)
            {
                throw new NotFoundException(nameof(SysPrefFinancials), sysPrefFinancialId);
            }
            await _sysPrefFinancialRepository.DeleteAsync(sysPrefFinancialToDelete);
            return Unit.Value;
            //throw new NotImplementedException();
        }
    }
}
