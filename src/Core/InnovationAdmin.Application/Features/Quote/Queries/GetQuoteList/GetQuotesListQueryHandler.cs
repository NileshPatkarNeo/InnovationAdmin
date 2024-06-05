using AutoMapper;
using InnovationAdmin.Application.Contracts.Persistence;
using InnovationAdmin.Application.Responses;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace InnovationAdmin.Application.Features.Quote.Queries.GetQuotesList
{
    public class GetQuotesListQueryHandler : IRequestHandler<GetQuotesListQuery, Response<IEnumerable<QuoteListVM>>>
    {
        private readonly IQuotesRepository _quotesRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<GetQuotesListQueryHandler> _logger;

        public GetQuotesListQueryHandler(IMapper mapper, IQuotesRepository quotesRepository, ILogger<GetQuotesListQueryHandler> logger)
        {
            _mapper = mapper;
            _quotesRepository = quotesRepository;
            _logger = logger;
        }

        public async Task<Response<IEnumerable<QuoteListVM>>> Handle(GetQuotesListQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handle Initiated");
            var allQuotes = (await _quotesRepository.ListAllAsync()).OrderBy(x => x.Name);
            var quotesList = _mapper.Map<IEnumerable<QuoteListVM>>(allQuotes);
            _logger.LogInformation("Handle Completed");
            return new Response<IEnumerable<QuoteListVM>>(quotesList, "success");
        }
    }
}
