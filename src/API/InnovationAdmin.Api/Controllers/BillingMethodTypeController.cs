using InnovationAdmin.Application.Features.BillingMethodTypes.Commands.CreateBillingMethodType;
using InnovationAdmin.Application.Features.BillingMethodTypes.Commands.DeleteBillingMethodType;
using InnovationAdmin.Application.Features.BillingMethodTypes.Commands.UpdateBillingMethodType;
using InnovationAdmin.Application.Features.BillingMethodTypes.Queries.GetBillingMethodTypeById;
using InnovationAdmin.Application.Features.BillingMethodTypes.Queries.GetBillingMethodTypeList;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace InnovationAdmin.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillingMethodTypeController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<BillingMethodTypeController> _logger;

        public BillingMethodTypeController(IMediator mediator, ILogger<BillingMethodTypeController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }


        [HttpPost(Name = "BillingMethod")]
        public async Task<ActionResult> Create([FromBody] CreateBillingMethodTypeCommand createBillingMethodTypeCommand)
        {
            var response = await _mediator.Send(createBillingMethodTypeCommand);
            if (!response.Succeeded)
            {
                return BadRequest(response.Message);
            }
            return Ok(response);
        }


        [HttpGet("{id}", Name = "GetBillingMethodById")]
        public async Task<ActionResult> GetBillingMethodById(string id)
        {
            var getBillingMethodQuery = new GetBillingMethodTypeByIdQuery { ID = id };
            var response = await _mediator.Send(getBillingMethodQuery);

            if (!response.Succeeded)
            {
                return BadRequest(response.Message);
            }
            return Ok(response);
        }


        [HttpGet("all", Name = "GetAllBillingMethod")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> GetAllBillingMethod()
        {
            _logger.LogInformation("GetAllBillingMethod Initiated");
            var response = await _mediator.Send(new GetBillingMethodTypeListQuery());
            _logger.LogInformation("GetAllBillingMethod Completed");

            if (!response.Succeeded)
            {
                return BadRequest(response.Message);
            }
            return Ok(response);
        }


        [HttpPut(Name = "UpdateBillingMethod")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Update([FromBody] UpdateBillingMethodTypeCommand updateBillingMethodTypeCommand)
        {
            var response = await _mediator.Send(updateBillingMethodTypeCommand);
            if (response.Succeeded)
            {
                return Ok(response);
            }
            return NotFound(response.Message);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            if (!Guid.TryParse(id, out var guid))
            {
                return BadRequest("Invalid GUID format");
            }

            var command = new DeleteBillingMethodTypeCommand() { ID = guid };
            try
            {
                var result = await _mediator.Send(command);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound("Resource not found");
            }
        }
    }
}
