
using InnovationAdmin.Application.Features.ReceiptBatchSource.Commands.CraeateReceiptBatchSource;
using InnovationAdmin.Application.Features.ReceiptBatchSource.Commands.DeleteReceiptBatchSource;
using InnovationAdmin.Application.Features.ReceiptBatchSource.Commands.UpdateReceiptBatchSource;
using InnovationAdmin.Application.Features.ReceiptBatchSource.Queries.GetAllListReceipyBatchSourceQuery;
using InnovationAdmin.Application.Features.ReceiptBatchSource.Queries.GetReceiptBatchSourceQuery;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InnovationAdmin.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReceiptBatchSourceController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger _logger;

        public ReceiptBatchSourceController(IMediator mediator, ILogger<ReceiptBatchSourceController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CreateReceiptBatchSourceCommand createReceiptBatchSourceCommand)
        {
            if (string.IsNullOrWhiteSpace(createReceiptBatchSourceCommand.Name) ||
                string.IsNullOrWhiteSpace(createReceiptBatchSourceCommand.Type))
            {
                return BadRequest();
            }

            var response = await _mediator.Send(createReceiptBatchSourceCommand);
            if (response.Succeeded)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }


        [HttpGet("{Id}")]
        public async Task<IActionResult> GetReceiptBatchSourceyById(Guid Id)
        {
            var query = new GetReceiptBatchSourceByIdQuery(Id);
            var batch = await _mediator.Send(query);

            if (batch == null)
            {
                return NotFound();
            }

            return Ok(batch);
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            try
            {
                var query = new GetAllReceiptBatchSourceQuery();
                var result = await _mediator.Send(query);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while processing the request.");
                return BadRequest(ex.Message);
            }
        }


        [HttpPut("{id}")]
        public async Task<ActionResult> Update(Guid id, [FromBody] UpdateReceiptBAtchSourceCommand updateReceiptBAtchSourceCommand)
        {
            if (id != updateReceiptBAtchSourceCommand.Id)
            {
                return BadRequest("ID mismatch");
            }

            var response = await _mediator.Send(updateReceiptBAtchSourceCommand);
            if (response.Succeeded)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var command = new DeleteReceiptBatchSourceCommand { Id = id };
            var result = await _mediator.Send(command);
            if (result.Data)
            {
                return Ok(result);
            }
            return NotFound(result);
        }



    }
}
