using InnovationAdmin.Application.Responses;
using MediatR;

namespace InnovationAdmin.Application.Features.Quote.Queries.GetQuotesList
{
    public class GetQuotesListQuery : IRequest<Response<IEnumerable<QuoteListVM>>>
    {
    }
}
