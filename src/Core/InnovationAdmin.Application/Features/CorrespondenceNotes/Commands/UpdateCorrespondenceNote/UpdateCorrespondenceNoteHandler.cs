using AutoMapper;
using InnovationAdmin.Application.Contracts.Persistence;
using InnovationAdmin.Application.Exceptions;
using InnovationAdmin.Application.Features.RemittanceType.Commands.UpdateRemittanceType;
using InnovationAdmin.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnovationAdmin.Application.Features.CorrespondenceNotes.Commands.UpdateCorrespondenceNote
{
    public class UpdateCorrespondenceNoteHandler : IRequestHandler<UpdateCorrespondenceNoteCommand, Response<UpdateCorrespondenceNoteDto>>
    {
        private readonly IMapper _mapper;
        private readonly ICorrespondenceNotesRepository _correspondenceNotesRepository;

        public UpdateCorrespondenceNoteHandler(IMapper mapper, ICorrespondenceNotesRepository correspondenceNotesRepository)
        {
            _mapper = mapper;
            _correspondenceNotesRepository = correspondenceNotesRepository;
        }
        public async Task<Response<UpdateCorrespondenceNoteDto>> Handle(UpdateCorrespondenceNoteCommand request, CancellationToken cancellationToken)
        {
            var correspondenceNoteToUpdate = await _correspondenceNotesRepository.GetByIdAsync(request.Id);

            if (correspondenceNoteToUpdate == null)
            {
                throw new NotFoundException(nameof(CorrespondenceNotes), request.Id);
            }

            correspondenceNoteToUpdate.Note = request.Note;

            correspondenceNoteToUpdate.LastModifiedDate = DateTime.Now;

            await _correspondenceNotesRepository.UpdateAsync(correspondenceNoteToUpdate);

            var Dto = _mapper.Map<UpdateCorrespondenceNoteDto>(correspondenceNoteToUpdate);

            return new Response<UpdateCorrespondenceNoteDto>(Dto, "Correspondence Note updated successfully");
        }

    }
}
