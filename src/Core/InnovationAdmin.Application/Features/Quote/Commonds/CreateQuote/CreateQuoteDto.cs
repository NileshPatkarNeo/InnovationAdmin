namespace InnovationAdmin.Application.Features.Quote.Commands.CreateQuote
{
    public class CreateQuoteDto
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string QuoteBy { get; set; }
    }
}
