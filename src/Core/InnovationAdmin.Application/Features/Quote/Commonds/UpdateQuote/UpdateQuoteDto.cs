namespace InnovationAdmin.Application.Features.Quote.Commands.UpdateQuote
{
    public class UpdateQuoteDto
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string QuoteBy { get; set; }
    }
}
