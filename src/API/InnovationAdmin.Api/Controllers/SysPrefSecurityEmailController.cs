using InnovationAdmin.Application.Features.SysPrefSecurityEmails.Commands.CreateSysPrefSecurityEmail;
using InnovationAdmin.Application.Features.SysPrefSecurityEmails.Commands.DeleteSysPrefSecurityEmail;
using InnovationAdmin.Application.Features.SysPrefSecurityEmails.Commands.UpdateSysPrefSecurityEmail;
using InnovationAdmin.Application.Features.SysPrefSecurityEmails.Queries.GetSysPrefSecurityEmailById;
using InnovationAdmin.Application.Features.SysPrefSecurityEmails.Queries.GetSysPrefSecurityEmailList;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace InnovationAdmin.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SysPrefSecurityEmailController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<SysPrefSecurityEmailController> _logger;

        public SysPrefSecurityEmailController(IMediator mediator, ILogger<SysPrefSecurityEmailController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpPost(Name = "SysPrefSecurityEmail")]
        public async Task<ActionResult> Create([FromBody] CreateSysPrefSecurityEmailCommand createAdminUserCommand)
        {
            var response = await _mediator.Send(createAdminUserCommand);
            if (!response.Succeeded)
            {
                return BadRequest(response.Message);
            }

            return Ok(response);

        }

        [HttpGet("{id}", Name = "GetSysPrefSecurityEmailById")]
        public async Task<ActionResult> GetSysPrefSecurityEmailById(string id)
        {
            var getEventDetailQuery = new GetSysPrefSecurityEmailByIdQuery { SysPrefSecurityEmailId = id };
            var response = await _mediator.Send(getEventDetailQuery);

            if (!response.Succeeded)
            {
                return BadRequest(response.Message);
            }

            return Ok(response);
        }


        [HttpGet("all", Name = "GetAllSysPrefSecurityEmail")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> GetAllSysPrefSecurityEmail()
        {
            _logger.LogInformation("GetAllSysPrefSecurityEmail Initiated");
            var response = await _mediator.Send(new GetSysPrefSecurityEmailListQuery());
            _logger.LogInformation("GetAllSysPrefSecurityEmail Completed");

            if (!response.Succeeded)
            {
                return BadRequest(response.Message);
            }

            return Ok(response);
        }

        [HttpPut(Name = "UpdateSysPrefSecurityEmail")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Update([FromBody] UpdateSysPrefSecurityEmailCommand updateSysPrefSecurityEmailCommand)
        {
            var response = await _mediator.Send(updateSysPrefSecurityEmailCommand);
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

            var command = new DeleteSysPrefSecurityEmailCommand() { SysPrefSecurityEmailId = guid };
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
