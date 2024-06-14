using InnovationAdmin.Application.Features.APAccountTypes.Commands.CreateAPAccountType;
using InnovationAdmin.Application.Features.APAccountTypes.Commands.DeleteAPAccountType;
using InnovationAdmin.Application.Features.APAccountTypes.Commands.UpdateAPAccountType;
using InnovationAdmin.Application.Features.APAccountTypes.Queries.GetAPAccountTypebyId;
using InnovationAdmin.Application.Features.APAccountTypes.Queries.GetAPAccountTypeList;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace InnovationAdmin.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class APAccountTypeController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<APAccountTypeController> _logger;

        public APAccountTypeController(IMediator mediator, ILogger<APAccountTypeController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpPost(Name = "APAccountType")]
        public async Task<ActionResult> Create([FromBody] CreateAPAccountTypeCommand createAPAccountTypeCommand)
        {
            var response = await _mediator.Send(createAPAccountTypeCommand);
            if (!response.Succeeded)
            {
                return BadRequest(response.Message);
            }
            return Ok(response);
        }

        [HttpGet("{id}", Name = "GetAPAccountTypeById")]
        public async Task<ActionResult> GetAPAccountTypeById(string id)
        {
            var getAPAccountTypeById = new GetAPAccountTypebyIdQuery { ID = id };
            var response = await _mediator.Send(getAPAccountTypeById);

            if (!response.Succeeded)
            {
                return BadRequest(response.Message);
            }

            return Ok(response);
        }

        [HttpGet("all", Name = "GetAllAPAccountType")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> GetAllAPAccountType()
        {
            _logger.LogInformation("GetAllAPAccountType Initiated");
            var response = await _mediator.Send(new GetAPAccountTypeListQuery());
            _logger.LogInformation("GetAllAPAccountType Completed");

            if (!response.Succeeded)
            {
                return BadRequest(response.Message);
            }
            return Ok(response);
        }

        [HttpPut(Name = "UpdateAPAccountType")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Update([FromBody] UpdateAPAccountTypeCommand updateAPAccountTypeCommand)
        {
            var response = await _mediator.Send(updateAPAccountTypeCommand);
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

            var command = new DeleteAPAccountTypeCommand() { ID = guid };
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
