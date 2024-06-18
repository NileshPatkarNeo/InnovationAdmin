using InnovationAdmin.Application.Features.CategoryTypes.Commands.CreateCategoryType;
using InnovationAdmin.Application.Features.CategoryTypes.Commands.DeleteCategoryType;
using InnovationAdmin.Application.Features.CategoryTypes.Commands.UpdateCategoryType;
using InnovationAdmin.Application.Features.CategoryTypes.Queries.GetCategoryTypeById;
using InnovationAdmin.Application.Features.CategoryTypes.Queries.GetCategoryTypeList;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace InnovationAdmin.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryTypeController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<CategoryTypeController> _logger;

        public CategoryTypeController(IMediator mediator, ILogger<CategoryTypeController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpPost(Name = "CategoryType")]
        public async Task<ActionResult> Create([FromBody] CreateCategoryTypeCommand createCategoryTypeCommand)
        {
            var response = await _mediator.Send(createCategoryTypeCommand);
            if (!response.Succeeded)
            {
                return BadRequest(response.Message);
            }

            return Ok(response);

        }

        [HttpGet("{id}", Name = "GetCategoryTypeById")]
        public async Task<ActionResult> GetCategoryTypeById(string id)
        {
            var getCategoryTypeQuery = new GetCategoryTypeByIdQuery { ID = id };
            var response = await _mediator.Send(getCategoryTypeQuery);

            if (!response.Succeeded)
            {
                return BadRequest(response.Message);
            }

            return Ok(response);
        }


        [HttpGet("all", Name = "GetAllCategoryType")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> GetAllCategoryType()
        {
            _logger.LogInformation("GetAllCategoryType Initiated");
            var response = await _mediator.Send(new GetCategoryTypeListQuery());
            _logger.LogInformation("GetAllCategoryType Completed");

            if (!response.Succeeded)
            {
                return BadRequest(response.Message);
            }

            return Ok(response);
        }

        [HttpPut(Name = "UpdateCategoryType")]
        [ProducesResponseType(StatusCodes.Status200OK)]

        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Update([FromBody] UpdateCategoryTypeCommand updateCategoryTypeCommand)
        {
            var response = await _mediator.Send(updateCategoryTypeCommand);
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

            var command = new DeleteCategoryTypeCommand() { ID = guid };
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
