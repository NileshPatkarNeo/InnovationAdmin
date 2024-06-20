using Innovation_Admin.UI.Models.Quote;
using Innovation_Admin.UI.Models.ResponsesModel.Quote;

namespace Innovation_Admin.UI.Services.IRepositories
{
    public interface IQuotes
    {
        Task<GetAllQuotesResponseModel> GetAllQuotes();
        Task<CreateQuoteResponseModel> CreateQuote(CreateQuoteDto newQuote);
        Task<UpdateQuoteResponseModel> UpdateQuote(QuoteDto updatedQuote);
        Task<GetQuoteByIdResponseModel> GetQuoteById(Guid quoteId);
        Task<bool> DeleteQuote(Guid quoteId);
    }
}
