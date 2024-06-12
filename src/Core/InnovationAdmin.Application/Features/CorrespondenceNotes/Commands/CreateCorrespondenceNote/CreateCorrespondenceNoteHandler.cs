using AutoMapper;
using InnovationAdmin.Application.Contracts.Persistence;
using InnovationAdmin.Application.Responses;
using MediatR;
using InnovationAdmin.Application.Exceptions;

namespace InnovationAdmin.Application.Features.CorrespondenceNotes.Commands.CreateCorrespondenceNote
{
    public class CreateCorrespondenceNoteHandler : IRequestHandler<CreateCorrespondenceNoteCommand, Response<CreateCorrespondenceNoteDto>>
    {
        private readonly IMapper _mapper;
        private readonly ICorrespondenceNotesRepository _correspondenceNotesRepository;
        private readonly IMessageRepository _messageRepository;
        public CreateCorrespondenceNoteHandler(IMapper mapper, ICorrespondenceNotesRepository correspondenceNotesRepository, IMessageRepository messageRepository)
        {
            _mapper = mapper;
            _correspondenceNotesRepository = correspondenceNotesRepository;
            _messageRepository = messageRepository;
        }
        public async Task<Response<CreateCorrespondenceNoteDto>> Handle(CreateCorrespondenceNoteCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateCorrespondenceNoteValidator(_messageRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                throw new ValidationException(validationResult);
            }

            var correspondenceNote = new Domain.Entities.CorrespondenceNotes
            {
                Note = request.Note
            };

            correspondenceNote = await _correspondenceNotesRepository.AddAsync(correspondenceNote);

            var correspondenceNoteDto = _mapper.Map<CreateCorrespondenceNoteDto>(correspondenceNote);

            return new Response<CreateCorrespondenceNoteDto>(correspondenceNoteDto, "Correspondence Note created successfully");
        }
    }
}
