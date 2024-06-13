using AutoMapper;
using InnovationAdmin.Application.Contracts.Persistence;
using InnovationAdmin.Application.Features.CorrespondenceNotes.Queries.GetCorrespondenceNoteQuery;
using InnovationAdmin.Application.Responses;
using MediatR;

namespace InnovationAdmin.Application.Features.CorrespondenceNotes.Queries.GetAllListCorrespondenceNoteQuery
{
    public class GetAllListCorrespondenceNoteQueryHandler : IRequestHandler<GetAllCorrespondenceNoteQuery, Response<IEnumerable<CorrespondenceNoteDto>>>
    {
        private readonly ICorrespondenceNotesRepository _correspondenceNotesRepository;
        private readonly IMapper _mapper;

        public GetAllListCorrespondenceNoteQueryHandler(ICorrespondenceNotesRepository correspondenceNotesRepository, IMapper mapper)
        {
            _correspondenceNotesRepository = correspondenceNotesRepository;
            _mapper = mapper;
        }

        public async Task<Response<IEnumerable<CorrespondenceNoteDto>>> Handle(GetAllCorrespondenceNoteQuery request, CancellationToken cancellationToken)
        {
            var correspondenceNotes = await _correspondenceNotesRepository.ListAllAsync();
            var correspondenceNotesDto = _mapper.Map<IEnumerable<CorrespondenceNoteDto>>(correspondenceNotes);
            return new Response<IEnumerable<CorrespondenceNoteDto>>(correspondenceNotesDto);
        }
    }
}
