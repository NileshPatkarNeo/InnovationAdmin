using InnovationAdmin.Application.Features.CorrespondenceNotes.Commands.CreateCorrespondenceNote;
using InnovationAdmin.Application.Features.CorrespondenceNotes.Commands.DeleteCorrespondenceNote;
using InnovationAdmin.Application.Features.RemittanceType.Commands.CreateRemittanceType;
using InnovationAdmin.Application.Features.RemittanceType.Commands.DeleteRemittanceType;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InnovationAdmin.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CorrespondenceNotesController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger _logger;

        public CorrespondenceNotesController(IMediator mediator, ILogger<CorrespondenceNotesController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CreateCorrespondenceNoteCommand createCorrespondenceNoteCommand)
        {
            if (string.IsNullOrEmpty(createCorrespondenceNoteCommand.Note))
            {
                return BadRequest("Correspondence Note cannot be null or empty");
            }

            var response = await _mediator.Send(createCorrespondenceNoteCommand);
            if (response.Succeeded)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpDelete("{id}", Name = "DeleteCorrespondenceNote")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var command = new DeleteCorrespondenceNoteCommand { Id = id };
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
    }
}
