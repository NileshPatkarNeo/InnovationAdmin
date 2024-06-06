using InnovationAdmin.Application.Features.PharmacyGroup.Commands.CreatePharmacyGroup;
using InnovationAdmin.Application.Features.PharmacyGroup.Commands.DeletePharmacyGroup;
using InnovationAdmin.Application.Features.PharmacyGroup.Commands.UpdatePharmacyGroup;
using InnovationAdmin.Application.Features.PharmacyGroup.Queries.GetAllListPharmacyGroupQuery;
using InnovationAdmin.Application.Features.PharmacyGroup.Queries.GetPharmacyGroupQuery;
using InnovationAdmin.Application.Features.RemittanceType.Commands.CreateRemittanceType;
using InnovationAdmin.Application.Features.RemittanceType.Commands.DeleteRemittanceType;
using InnovationAdmin.Application.Features.RemittanceType.Commands.UpdateRemittanceType;
using InnovationAdmin.Application.Features.RemittanceType.Queries.GetAllListRemittanceTypeQuery;
using InnovationAdmin.Application.Features.RemittanceType.Queries.GetRemittanceTypeQuery;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InnovationAdmin.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RemittanceTypeController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger _logger;

        public RemittanceTypeController(IMediator mediator, ILogger<RemittanceTypeController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }


        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CreateRemittanceTypeCommand createRemittanceTypeCommand)
        {
            if (string.IsNullOrEmpty(createRemittanceTypeCommand.Name))
            {
                return BadRequest("Remittance Type cannot be null or empty");
            }

            var response = await _mediator.Send(createRemittanceTypeCommand);
            if (response.Succeeded)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpDelete("{id}", Name = "DeleteRemittanceType")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var command = new DeleteRemittanceTypeCommand { Id = id };
            var result = await _mediator.Send(command);
            if (result.Data)
            {
                return Ok(result);
            }
            else if (!result.Succeeded)
            {
                return StatusCode(500, result);
            }
            return NotFound(result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(Guid id, [FromBody] UpdateRemittanceTypeCommand updateRemittanceTypeCommand)
        {
            if (id != updateRemittanceTypeCommand.Id)
            {
                return BadRequest("ID mismatch");
            }

            var response = await _mediator.Send(updateRemittanceTypeCommand);
            if (response.Succeeded)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpGet("{id}", Name = "GetRemittanceTypeById")]
        public async Task<ActionResult> GetRemittanceTypeById(string id)
        {
            if (!Guid.TryParse(id, out var guidId))
            {
                return BadRequest("Invalid ID format.");
            }

            var getremittanceType = new GetRemittanceTypeByIdQuery { Id = guidId };
            var response = await _mediator.Send(getremittanceType);

            if (response == null)
            {
                return NotFound("Remittance Type not found.");
            }

            return Ok(response);
        }

        [HttpGet("all", Name = "GetRemittanceType")]
        public async Task<ActionResult> GetRemittanceType()
        {
            _logger.LogInformation("RemittanceType Initiated");
            var dtos = await _mediator.Send(new GetAllRemittanceTypeQuery());
            _logger.LogInformation("RemittanceType Completed");
            return Ok(dtos);

        }
    }
}
