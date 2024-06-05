using InnovationAdmin.Application.Contracts.Persistence;
using InnovationAdmin.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnovationAdmin.Application.Features.RemittanceType.Commands.DeleteRemittanceType
{
    public class DeleteRemittanceTypeCommandHandler : IRequestHandler<DeleteRemittanceTypeCommand, Response<bool>>
    {
        private readonly IRemittanceTypeRepository _remittanceTypeRepository;

        public DeleteRemittanceTypeCommandHandler(IRemittanceTypeRepository remittanceTypeRepository)
        {
            _remittanceTypeRepository = remittanceTypeRepository;
        }

        public async Task<Response<bool>> Handle(DeleteRemittanceTypeCommand request, CancellationToken cancellationToken)
        {
            var remittanceTypeToDelete = await _remittanceTypeRepository.GetByIdAsync(request.Id);

            if (remittanceTypeToDelete == null)
            {
                return new Response<bool>($"Remittance Type with id {request.Id} not found.");
            }

            await _remittanceTypeRepository.DeleteAsync(remittanceTypeToDelete);

            return new Response<bool>(true, "Remittance Type deleted successfully.");
        }

    }
}
