using AutoMapper;
using InnovationAdmin.Application.Contracts.Persistence;
using InnovationAdmin.Application.Exceptions;
using InnovationAdmin.Application.Responses;
using InnovationAdmin.Domain.Entities;
using MediatR;

namespace InnovationAdmin.Application.Features.Quote.Commands.CreateQuote
{
    public class CreateQuoteCommandHandler : IRequestHandler<CreateQuoteCommand, Response<CreateQuoteDto>>
    {
        private readonly IQuotesRepository _quotesRepository;
        private readonly IMapper _mapper;

        public CreateQuoteCommandHandler(IQuotesRepository quotesRepository, IMapper mapper)
        {
            _quotesRepository = quotesRepository;
            _mapper = mapper;
        }

        public async Task<Response<CreateQuoteDto>> Handle(CreateQuoteCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateQuoteCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                throw new ValidationException(validationResult);
            }

            var quote = new Quotes
            {
                ID = Guid.NewGuid(),
                Name = request.Name,
                QuoteBy = request.QuoteBy
            };

            quote = await _quotesRepository.AddAsync(quote);

            var response = new Response<CreateQuoteDto>(_mapper.Map<CreateQuoteDto>(quote), "success");

            return response;
        }
    }
}
