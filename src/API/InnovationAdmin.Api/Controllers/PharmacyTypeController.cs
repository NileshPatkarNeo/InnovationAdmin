using InnovationAdmin.Application.Features.PharmacyType.Commands.CreatePharmacyType;
using InnovationAdmin.Application.Features.PharmacyType.Commands.DeletePharmacyType;
using InnovationAdmin.Application.Features.PharmacyType.Commands.UpdatePharmacyType;
using InnovationAdmin.Application.Features.PharmacyType.Queries.GetAllListPharmacyTypeQuery;
using InnovationAdmin.Application.Features.PharmacyType.Queries.GetPharmacyTypeQuery;
using InnovationAdmin.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace InnovationAdmin.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PharmacyTypeController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger _logger;

        public PharmacyTypeController(IMediator mediator, ILogger<PharmacyTypeController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CreatePharmacyTypeCommand createPharmacyTypeCommand)
        {
            if (createPharmacyTypeCommand == null)
            {
                return BadRequest(new Response<CreatePharmacyTypeDto>
                {
                    Succeeded = false,
                    Message = "Invalid input"
                });
            }

            if (string.IsNullOrWhiteSpace(createPharmacyTypeCommand.Description))
            {
                return BadRequest(new Response<CreatePharmacyTypeDto>
                {
                    Succeeded = false,
                    Message = "Description cannot be blank"
                });
            }

            var response = await _mediator.Send(createPharmacyTypeCommand);
            if (response.Succeeded)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpGet(Name = "GetPharmacyType")]
        public async Task<ActionResult> GetAll()
        {
            try
            {
                var query = new GetAllPharmacyTypeQuery();
                var result = await _mediator.Send(query);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while processing the request.");
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}", Name = "GetPharmacyTypeById")]
        public async Task<ActionResult> GetPharmacyTypeById(string id)
        {            
            if (!Guid.TryParse(id, out var guidId))
            {
                return BadRequest("Invalid ID format.");
            }

            var getPharmacyTypeByIdQuery = new GetPharmacyTypeByIdQuery { Id = guidId };
            var response = await _mediator.Send(getPharmacyTypeByIdQuery);

            if (response == null)
            {
                return NotFound("System preference not found.");
            }

            return Ok(response);
        }


        [HttpPut("{id}")]
        public async Task<ActionResult> Update(Guid id, [FromBody] UpdatePharmacyTypeCommand updatePharmacytypeCommand)
        {
            if (id != updatePharmacytypeCommand.Id)
            {
                return BadRequest("ID mismatch");
            }

            var response = await _mediator.Send(updatePharmacytypeCommand);
            if (response.Succeeded)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }



        [HttpDelete("{id}", Name = "DeletePharmacyType")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var command = new DeletePharmacyTypeCommand { Id = id };
            var result = await _mediator.Send(command);
            if (result.Data)
            {
                return Ok(result);
            }
            return NotFound(result);
        }

       
    }
}
