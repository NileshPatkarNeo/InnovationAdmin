using AutoMapper;
using InnovationAdmin.Application.Contracts.Persistence;
using InnovationAdmin.Application.Exceptions;
using InnovationAdmin.Application.Responses;
using InnovationAdmin.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace InnovationAdmin.Application.Features.Quote.Commands.UpdateQuote
{
    public class UpdateQuoteCommandHandler : IRequestHandler<UpdateQuoteCommand, Response<UpdateQuoteDto>>
    {
        private readonly IQuotesRepository _quotesRepository;
        private readonly IMapper _mapper;
        private readonly IMessageRepository _messageRepository;

        public UpdateQuoteCommandHandler(IMapper mapper, IQuotesRepository quotesRepository, IMessageRepository messageRepository)
        {
            _mapper = mapper;
            _quotesRepository = quotesRepository;
            _messageRepository = messageRepository;
        }

        public async Task<Response<UpdateQuoteDto>> Handle(UpdateQuoteCommand request, CancellationToken cancellationToken)
        {
            var quoteToUpdate = await _quotesRepository.GetByIdAsync(request.ID);

            if (quoteToUpdate == null)
            {
                throw new NotFoundException(nameof(UpdateQuoteDto), request.ID);
            }

            var validator = new UpdateQuoteCommandValidator(_messageRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                throw new ValidationException(validationResult);

            _mapper.Map(request, quoteToUpdate);

            await _quotesRepository.UpdateAsync(quoteToUpdate);
            var dto = new UpdateQuoteDto
            {
                ID = request.ID,
                Name = request.Name,
                QuoteBy = request.QuoteBy
            };
            return new Response<UpdateQuoteDto>(dto, "Updated successfully");
        }
    }
}
