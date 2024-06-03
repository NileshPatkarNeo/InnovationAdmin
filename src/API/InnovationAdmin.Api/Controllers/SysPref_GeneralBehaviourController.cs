using InnovationAdmin.Application.Features.SysPref_GeneralBehaviour.Commands.Create_SysPref_GeneralBehaviour;
using InnovationAdmin.Application.Features.SysPref_GeneralBehaviour.Commands.Delete_SysPref_GeneralBehaviour;
using InnovationAdmin.Application.Features.SysPref_GeneralBehaviour.Commands.Update_SysPref_GeneralBehaviour;
using InnovationAdmin.Application.Features.SysPref_GeneralBehaviour.Queries.Get_SysPref_GeneralBehaviour_List;
using InnovationAdmin.Application.Features.SysPref_GeneralBehaviour.Queries.GetById_SysPref_GeneralBehaviour;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace InnovationAdmin.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SysPref_GeneralBehaviourController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger _logger;

        public SysPref_GeneralBehaviourController(IMediator mediator, ILogger<SysPref_GeneralBehaviourController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        //[Authorize]
        [HttpGet("all", Name = "GetSysPref_GeneralBehaviour")]
        public async Task<ActionResult> GetAllSysPref()
        {
            _logger.LogInformation("GetSysPref_GeneralBehaviour Initiated");
            var dtos = await _mediator.Send(new Get_SysPref_GeneralBehaviour_List_Query());
            _logger.LogInformation("GetSysPref_GeneralBehaviour Completed");
            return Ok(dtos);
        }
        

        [HttpGet("{id}", Name = "GetSysPref_GeneralBehaviourById")]
        public async Task<ActionResult> GetSysPref_GeneralBehaviourId(string id)
        {
            if (!Guid.TryParse(id, out var guidId))
            {
                return BadRequest("Invalid ID format.");
            }

            var gettSysPref_GeneralBehaviourlQuery = new GetById_SysPref_GeneralBehaviours_Query { Preference_ID = guidId };
            var response = await _mediator.Send(gettSysPref_GeneralBehaviourlQuery);

            if (response == null)
            {
                return NotFound("System preference not found.");
            }

            return Ok(response);
        }



        [HttpPost(Name = "AddSysPref_GeneralBehaviour")]
        public async Task<ActionResult> Create([FromBody] Create_SysPref_GeneralBehaviour_Command createSyspref_generalBehaviourCommand)
        {
            // Additional manual validations
            if (createSyspref_generalBehaviourCommand.Records_Locked_Seconds <= 0 ||
                createSyspref_generalBehaviourCommand.User_Timeout <= 0)
            {
                return BadRequest("Records_Locked_Seconds and User_Timeout must be greater than 0.");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = await _mediator.Send(createSyspref_generalBehaviourCommand);
            return Ok(response);
        }


        [HttpPut(Name = "UpdateSysPref_GeneralBehaviour")]
         public async Task<ActionResult> Update([FromBody] Update_SysPref_GeneralBehaviour_Command updatesysCommand)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var response = await _mediator.Send(updatesysCommand);
            return Ok(response);
        }


        [HttpDelete("{id}", Name = "DeleteSysPref_GeneralBehaviour")]
        public async Task<ActionResult> Delete(string id)
        {
            if (!Guid.TryParse(id, out var guid))
            {
                return BadRequest("Invalid GUID format");
            }

            var deleteSysCommand = new Delete_SysPref_GeneralBehaviour_Command { Preference_ID = guid };
            await _mediator.Send(deleteSysCommand);
            return NoContent();
        }


    }
}
