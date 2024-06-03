using InnovationAdmin.Application.Features.PharmacyGroup.Commands.CreatePharmacyGroup;
using InnovationAdmin.Application.Features.PharmacyGroup.Commands.DeletePharmacyGroup;
using InnovationAdmin.Application.Features.PharmacyGroup.Commands.UpdatePharmacyGroup;
using InnovationAdmin.Application.Features.PharmacyGroup.Queries.GetAllListPharmacyGroupQuery;
using InnovationAdmin.Application.Features.PharmacyGroup.Queries.GetPharmacyGroupQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace InnovationAdmin.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger _logger;

        public CategoryController(IMediator mediator, ILogger<CategoryController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CreatePharmacyGroupCommand createPharmacyGroupCommand)
        {
            if (string.IsNullOrEmpty(createPharmacyGroupCommand.PharmacyName))
            {
                return BadRequest("PharmacyName cannot be null or empty");
            }

            var response = await _mediator.Send(createPharmacyGroupCommand);
            if (response.Succeeded)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }


        [HttpDelete("{id}", Name = "DeletePharmacyGroup")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var command = new DeletePharmacyGroupCommand { Id = id };
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
        public async Task<ActionResult> Update(Guid id, [FromBody] UpdatePharmacyGroupCommand updatePharmacyGroupCommand)
        {
            if (id != updatePharmacyGroupCommand.Id)
            {
                return BadRequest("ID mismatch");
            }

            var response = await _mediator.Send(updatePharmacyGroupCommand);
            if (response.Succeeded)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpGet("{id}", Name = "GetPharmacyGrouprById")]
        public async Task<ActionResult> GetPharmacyGrouprById(string id)
        {
            if (!Guid.TryParse(id, out var guidId))
            {
                return BadRequest("Invalid ID format.");
            }

            var getpharmacyGroup = new GetPharmacyGroupByIdQuery { Id = guidId };
            var response = await _mediator.Send(getpharmacyGroup);

            if (response == null)
            {
                return NotFound("System preference not found.");
            }

            return Ok(response);
        }

        [HttpGet("all", Name = "GetPharmacyGroup")]
        public async Task<ActionResult> GetPharmacyGroup()
        {
            _logger.LogInformation("PharmacyGroup Initiated");
            var dtos = await _mediator.Send(new GetAllPharmacyGroupQuery());
            _logger.LogInformation("PharmacyGroup Completed");
            return Ok(dtos);

        }

    }
}

