using InnovationAdmin.Application.Features.DoNotTakeGroup.Commands.CreateDoNotTakeGroup;
using InnovationAdmin.Application.Features.DoNotTakeGroup.Commands.DeleteDoNotGroup;
using InnovationAdmin.Application.Features.DoNotTakeGroup.Commands.UpdateDoNotTakeGroup;
using InnovationAdmin.Application.Features.DoNotTakeGroup.Queries.GetAllListDoNoTakeGroupQuery;
using InnovationAdmin.Application.Features.DoNotTakeGroup.Queries.GetDoNotTakeGroupQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace InnovationAdmin.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoNotTakeGroupController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger _logger;

        public DoNotTakeGroupController(IMediator mediator, ILogger<DoNotTakeGroupController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CreateDoNotTakeGroupCommand doNotTakeGroupCommand)
        {
        

            var response = await _mediator.Send(doNotTakeGroupCommand);
            if (response.Succeeded)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }


        [HttpGet("{Id}")]
        public async Task<IActionResult> GetDoNotTakeGroupById(Guid Id)
        {
            var query = new GetDoNotTakeGroupByIdQuery(Id);
            var company = await _mediator.Send(query);

            if (company == null)
            {  
                return NotFound();
            }

            return Ok(company);
        }

        [HttpGet(Name = "GetAllDoNotTakeGroup")]
        public async Task<ActionResult> GetAll()
        {
            try
            {
                var query = new GetAllDoNotTakeGroupQuery();
                var result = await _mediator.Send(query);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while processing the request.");
                return BadRequest(ex.Message);
            }
        }


        //[HttpPut]
        //public async Task<ActionResult> Update([FromBody] UpdateDoNotTakeGroupCommand updateDoNotTakeGroupCommand)
        //{
        //    var response = await _mediator.Send(updateDoNotTakeGroupCommand);
        //    if (response.Succeeded)
        //    {
        //        return Ok(response);
        //    }
        //    return BadRequest(response);
        //}
        [HttpPut]
        public async Task<IActionResult> Update( [FromBody] UpdateDoNotTakeGroupCommand command)
        {
            // Your update logic here
            var result = await _mediator.Send(command);
            if (result.Succeeded)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpDelete("{id}", Name = "DeleteDoNotTakeGroup")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var command = new DeleteDoNotTakeGroupCommand { Id = id };
            var result = await _mediator.Send(command);
            if (result.Data)
            {
                return Ok(result);
            }
            return NotFound(result);
        }



    }
}
