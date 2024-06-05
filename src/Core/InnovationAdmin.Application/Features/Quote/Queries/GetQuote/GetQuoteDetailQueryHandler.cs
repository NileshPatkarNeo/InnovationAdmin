using AutoMapper;
using InnovationAdmin.Application.Contracts.Persistence;
using InnovationAdmin.Application.Exceptions;
using InnovationAdmin.Application.Responses;
using InnovationAdmin.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace InnovationAdmin.Application.Features.Quote.Queries.GetQuote
{
    public class GetQuoteDetailQueryHandler : IRequestHandler<GetQuoteDetailQuery, Response<QuoteVM>>
    {
        private readonly IAsyncRepository<Quotes> _quotesRepository;
        private readonly IMapper _mapper;

        public GetQuoteDetailQueryHandler(IMapper mapper, IAsyncRepository<Quotes> quotesRepository)
        {
            _mapper = mapper;
            _quotesRepository = quotesRepository;
        }

        public async Task<Response<QuoteVM>> Handle(GetQuoteDetailQuery request, CancellationToken cancellationToken)
        {
            var quote = await _quotesRepository.GetByIdAsync(request.ID);

            if (quote == null)
            {
                throw new NotFoundException(nameof(QuoteVM), request.ID);
            }

            var quoteDetailDto = _mapper.Map<QuoteVM>(quote);
            var response = new Response<QuoteVM>(quoteDetailDto);
            return response;
        }
    }
}
