using InnovationAdmin.Application.Contracts.Persistence;
using InnovationAdmin.Application.Exceptions;
using InnovationAdmin.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace InnovationAdmin.Application.Features.Quote.Commands.DeleteQuote
{
    public class DeleteQuoteCommandHandler : IRequestHandler<DeleteQuoteCommand>
    {
        private readonly IQuotesRepository _quotesRepository;

        public DeleteQuoteCommandHandler(IQuotesRepository quotesRepository)
        {
            _quotesRepository = quotesRepository;
        }

        public async Task<Unit> Handle(DeleteQuoteCommand request, CancellationToken cancellationToken)
        {
            var quoteId = request.ID;
            var quoteToDelete = await _quotesRepository.GetByIdAsync(quoteId);
            if (quoteToDelete == null)
            {
                throw new NotFoundException(nameof(Quotes), quoteId);
            }
            await _quotesRepository.DeleteAsync(quoteToDelete);
            return Unit.Value;
        }
    }
}
