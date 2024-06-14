using InnovationAdmin.Application.Contracts.Persistence;
using InnovationAdmin.Application.Features.RemittanceType.Commands.DeleteRemittanceType;
using InnovationAdmin.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnovationAdmin.Application.Features.CorrespondenceNotes.Commands.DeleteCorrespondenceNote
{
    public class DeleteCorrespondenceNoteHandler : IRequestHandler<DeleteCorrespondenceNoteCommand, Response<bool>>
    {
        private readonly ICorrespondenceNotesRepository _correspondenceNotesRepository;

        public DeleteCorrespondenceNoteHandler(ICorrespondenceNotesRepository correspondenceNotesRepository)
        {
            _correspondenceNotesRepository = correspondenceNotesRepository;
        }
        public async Task<Response<bool>> Handle(DeleteCorrespondenceNoteCommand request, CancellationToken cancellationToken)
        {
            var correspondenceNoteToDelete = await _correspondenceNotesRepository.GetByIdAsync(request.Id);

            if (correspondenceNoteToDelete == null)
            {
                return new Response<bool>($"Remittance Type with id {request.Id} not found.");
            }

            await _correspondenceNotesRepository.DeleteAsync(correspondenceNoteToDelete);

            return new Response<bool>(true, " Correspondence Note deleted successfully.");
        }
    }
}
