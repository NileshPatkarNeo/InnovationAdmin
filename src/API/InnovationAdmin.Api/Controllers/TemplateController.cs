using InnovationAdmin.Application.Features.Template.Commands.CreateTemplate;
using InnovationAdmin.Application.Features.Template.Commands.DeleteTemplate;
using InnovationAdmin.Application.Features.Template.Commands.UpdateTemplate;
using InnovationAdmin.Application.Features.Template.Queries.GetTemplate;
using InnovationAdmin.Application.Features.Template.Queries.GetTemplateList;
using InnovationAdmin.Application.Features.Template.Queries.GetTemplatesList;
using InnovationAdmin.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InnovationAdmin.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TemplateController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<TemplateController> _logger;

        public TemplateController(IMediator mediator, ILogger<TemplateController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpPost]
        [Route("create")]
        public async Task<ActionResult<Templates>> Create(CreateTemplateCommand command)
        {
            var response = await _mediator.Send(command);
            var template = new Templates
            {
                ID = response.Data.ID,
                Name = response.Data.Name,
                PdfTemplateFile = response.Data.PdfTemplateFile,
                Domain = response.Data.Domain,
                Size = response.Data.Size
            };
            _logger.LogInformation("Template Info: {@template}", template);
            return Ok(template);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Templates>> GetById(Guid id)
        {
            var query = new GetTemplateDetailQuery() { ID = id };
            var template = await _mediator.Send(query);

            if (template == null)
                return NotFound();
            _logger.LogInformation("Template Info: {@template}", template);
            return Ok(template);
        }

        [HttpPut]
        public async Task<ActionResult<Templates>> Update(UpdateTemplateCommand command)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = await _mediator.Send(command);
            if (response == null)
            {
                return NotFound();
            }

            var updatedTemplate = new Templates
            {
                ID = response.Data.ID,
                Name = response.Data.Name,
                PdfTemplateFile = response.Data.PdfTemplateFile,
                Domain = response.Data.Domain,
                Size = response.Data.Size
            };

            _logger.LogInformation("Updated Template Info: {@updatedTemplate}", updatedTemplate);
            return Ok(updatedTemplate);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            if (!Guid.TryParse(id, out var guid))
            {
                return BadRequest("Invalid GUID format");
            }

            var command = new DeleteTemplateCommand() { ID = guid };
            var result = await _mediator.Send(command);

            _logger.LogInformation("Deleted Template with ID {TemplateId}", id);
            return NoContent();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Templates>>> GetAll()
        {
            var query = new GetTemplatesListQuery();
            var templates = await _mediator.Send(query);

            return Ok(templates);
        }
    }
}
