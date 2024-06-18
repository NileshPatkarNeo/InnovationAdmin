using InnovationAdmin.Application.Features.ClaimStatus.Commands.CreateClaimStatus;
using InnovationAdmin.Application.Features.ClaimStatus.Commands.DeleteClaimStatus;
using InnovationAdmin.Application.Features.ClaimStatus.Commands.UpdateClaimStatus;
using InnovationAdmin.Application.Features.ClaimStatus.Queries.GetAllListClaimStatusQuery;
using InnovationAdmin.Application.Features.ClaimStatus.Queries.GetClaimStatusQuery;
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
    public class ClaimStatusController : ControllerBase
    {

        private readonly IMediator _mediator;
        private readonly ILogger _logger;

        public ClaimStatusController(IMediator mediator, ILogger<ClaimStatusController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CreateClaimStatusCommand createClaimStatusCommand)
        {
            if (string.IsNullOrWhiteSpace(createClaimStatusCommand.Name) ||
                string.IsNullOrWhiteSpace(createClaimStatusCommand.Color))
            {
                return BadRequest();
            }

            var response = await _mediator.Send(createClaimStatusCommand);
            if (response.Succeeded)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }


        [HttpGet("{Id}")]
        public async Task<IActionResult> GetClaimStatusById(Guid Id)
        {
            var query = new GetClaimStatusByIdQuery(Id);
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
                var query = new GetAllClaimStatusQuery();
                var result = await _mediator.Send(query);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while processing the request.");
                return BadRequest(ex.Message);
            }
        }


        [HttpPut]
        public async Task<ActionResult> Update( [FromBody] UpdateClaimStatusCommand  updateClaimStatusCommand)
        {
            var response = await _mediator.Send(updateClaimStatusCommand);
            if (response.Succeeded)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var command = new  DeleteClaimStatusCommand { Id = id };
            var result = await _mediator.Send(command);
            if (result.Data)
            {
                return Ok(result);
            }
            return NotFound(result);
        }


    }
}
