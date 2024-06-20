using InnovationAdmin.Application.Features.CorrespondenceNotes.Commands.CreateCorrespondenceNote;
using InnovationAdmin.Application.Features.CorrespondenceNotes.Commands.DeleteCorrespondenceNote;
using InnovationAdmin.Application.Features.CorrespondenceNotes.Commands.UpdateCorrespondenceNote;
using InnovationAdmin.Application.Features.CorrespondenceNotes.Queries.GetAllListCorrespondenceNoteQuery;
using InnovationAdmin.Application.Features.CorrespondenceNotes.Queries.GetCorrespondenceNoteQuery;
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

        [HttpPut("{id}", Name = "UpdateCorrespondenceNote")]
        public async Task<ActionResult> Update(Guid id, [FromBody] UpdateCorrespondenceNoteCommand updateCorrespondenceNoteCommand)
        {
            if (id != updateCorrespondenceNoteCommand.Id)
            {
                return BadRequest("ID mismatch");
            }

            var response = await _mediator.Send(updateCorrespondenceNoteCommand);
            if (response.Succeeded)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpGet("{id}", Name = "GetCorrespondenceNoteById")]
        public async Task<ActionResult> GetCorrespondenceNoteById(string id)
        {
            if (!Guid.TryParse(id, out var guidId))
            {
                return BadRequest("Invalid ID format.");
            }

            var getcorrespondenceNote = new GetCorrespondenceNoteByIdQuery { Id = guidId };
            var response = await _mediator.Send(getcorrespondenceNote);

            if (response == null)
            {
                return NotFound("Correspondence Note not found.");
            }

            return Ok(response);
        }

        [HttpGet("all", Name = "GetCorrespondenceNotes")]
        public async Task<ActionResult> GetCorrespondenceNote()
        {
            _logger.LogInformation("CorrespondenceNote Initiated");
            var dtos = await _mediator.Send(new GetAllCorrespondenceNoteQuery());
            _logger.LogInformation("CorrespondenceNote Completed");
            return Ok(dtos);

        }
    }
}
