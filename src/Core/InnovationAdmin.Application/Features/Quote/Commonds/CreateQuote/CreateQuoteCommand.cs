using InnovationAdmin.Application.Responses;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace InnovationAdmin.Application.Features.Quote.Commands.CreateQuote
{
    public class CreateQuoteCommand : IRequest<Response<CreateQuoteDto>>
    {
        [Required]
        [MaxLength(100)]
        [MinLength(2, ErrorMessage = "Name should have at least 2 characters.")]
        [StringLength(100, ErrorMessage = "Name length can't be more than 100.")]
       
        public string Name { get; set; }

        [Required]
        [MaxLength(25)]
        [MinLength(2, ErrorMessage = "QuoteBy should have at least 2 characters.")]
        [StringLength(25, ErrorMessage = "QuoteBy length can't be more than 25.")]
        
        public string QuoteBy { get; set; }
    }
}
