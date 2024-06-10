using InnovationAdmin.Application.Features.AdminRoles.Commands.CreateAdminRole;
using InnovationAdmin.Application.Features.AdminRoles.Commands.DeleteAdminRole;
using InnovationAdmin.Application.Features.AdminRoles.Commands.UpdateAdminRole;
using InnovationAdmin.Application.Features.AdminRoles.Queries.GetAdminRole;
using InnovationAdmin.Application.Features.AdminRoles.Queries.GetAdminRoleList;
using InnovationAdmin.Application.Features.Quote.Commands.CreateQuote;
using InnovationAdmin.Application.Features.Quote.Commands.DeleteQuote;
using InnovationAdmin.Application.Features.Quote.Commands.UpdateQuote;
using InnovationAdmin.Application.Features.Quote.Queries.GetQuote;
using InnovationAdmin.Application.Features.Quote.Queries.GetQuotesList;
using InnovationAdmin.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace InnovationAdmin.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuoteController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<AdminRoleController> _logger;


        public QuoteController(IMediator mediator, ILogger<AdminRoleController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }


        [HttpPost]
        [Route("create")]
        public async Task<ActionResult<Quotes>> Create(CreateQuoteCommand command)
        {
            var response = await _mediator.Send(command);
            var quote = new Quotes
            {
                ID = response.Data.ID,
                Name = response.Data.Name,
                QuoteBy = response.Data.QuoteBy
            };
            _logger.LogInformation("Quotes Info: {@quote}", quote);
            return Ok(quote);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Quotes>> GetById(Guid id)
        {
            var query = new GetQuoteDetailQuery() { ID = id };
            var quote = await _mediator.Send(query);

            if (quote == null)
                return NotFound();
            Log.Information("Quotes Info: {@quote}", quote);
            return Ok(quote);
        }



        [HttpPut]
        public async Task<ActionResult<Quotes>> Update(UpdateQuoteCommand command)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = await _mediator.Send(command);
            if (response == null)
            {
                return NotFound();
            }

            var updatedQuote = new Quotes
            {
                ID = response.Data.ID,
                Name = response.Data.Name,
                QuoteBy = response.Data.QuoteBy
            };

            _logger.LogInformation("Updated Quote Info: {@updatedQuote}", updatedQuote);
            return Ok(updatedQuote);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            if (!Guid.TryParse(id, out var guid))
            {
                return BadRequest("Invalid GUID format");
            }

            var command = new DeleteQuoteCommand() { ID = guid };
            var result = await _mediator.Send(command);



            Log.Information("Deleted Quote with ID {QuoteId}", id);
            return NoContent();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Quotes>>> GetAll()
        {
            var query = new GetQuotesListQuery();
            var quotes = await _mediator.Send(query);

            return Ok(quotes);
        }
    }
}
