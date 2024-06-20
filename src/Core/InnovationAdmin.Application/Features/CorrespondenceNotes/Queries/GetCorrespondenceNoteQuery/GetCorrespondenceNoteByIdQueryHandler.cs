using AutoMapper;
using InnovationAdmin.Application.Contracts.Persistence;
using InnovationAdmin.Application.Features.RemittanceType.Queries.GetRemittanceTypeQuery;
using InnovationAdmin.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnovationAdmin.Application.Features.CorrespondenceNotes.Queries.GetCorrespondenceNoteQuery
{
    public class GetCorrespondenceNoteByIdQueryHandler : IRequestHandler<GetCorrespondenceNoteByIdQuery, Response<CorrespondenceNoteDto>>
    {
        private readonly IMapper _mapper;
        private readonly ICorrespondenceNotesRepository _correspondenceNotesRepository;

        public GetCorrespondenceNoteByIdQueryHandler(ICorrespondenceNotesRepository correspondenceNotesRepository, IMapper mapper)
        {
            _correspondenceNotesRepository = correspondenceNotesRepository;
            _mapper = mapper;
        }

        public async Task<Response<CorrespondenceNoteDto>> Handle(GetCorrespondenceNoteByIdQuery request, CancellationToken cancellationToken)
        {
            var correspondenceNote = await _correspondenceNotesRepository.GetByIdAsync(request.Id);

            if (correspondenceNote == null)
            {
                return new Response<CorrespondenceNoteDto>("Type not found.");
            }

            var Dto = _mapper.Map<CorrespondenceNoteDto>(correspondenceNote);
            return new Response<CorrespondenceNoteDto>(Dto);
        }
    }
}
