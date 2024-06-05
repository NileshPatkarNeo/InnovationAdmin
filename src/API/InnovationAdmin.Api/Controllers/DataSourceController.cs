using InnovationAdmin.Application.Features.DataSources.Commands.CreateDataSource;
using InnovationAdmin.Application.Features.DataSources.Commands.DeleteDataSource;
using InnovationAdmin.Application.Features.DataSources.Commands.UpdateDataSource;
using InnovationAdmin.Application.Features.DataSources.Queries.GetDataSourceById;
using InnovationAdmin.Application.Features.DataSources.Queries.GetDataSourceList;
using InnovationAdmin.Application.Features.SysPrefSecurityEmails.Commands.CreateSysPrefSecurityEmail;
using InnovationAdmin.Application.Features.SysPrefSecurityEmails.Commands.DeleteSysPrefSecurityEmail;
using InnovationAdmin.Application.Features.SysPrefSecurityEmails.Commands.UpdateSysPrefSecurityEmail;
using InnovationAdmin.Application.Features.SysPrefSecurityEmails.Queries.GetSysPrefSecurityEmailById;
using InnovationAdmin.Application.Features.SysPrefSecurityEmails.Queries.GetSysPrefSecurityEmailList;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InnovationAdmin.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataSourceController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<DataSourceController> _logger;

        public DataSourceController(IMediator mediator, ILogger<DataSourceController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpPost(Name = "DataSource")]
        public async Task<ActionResult> Create([FromBody] CreateDataSourceCommand createDataSourceCommand)
        {
            var response = await _mediator.Send(createDataSourceCommand);
            if (!response.Succeeded)
            {
                return BadRequest(response.Message);
            }

            return Ok(response);

        }

        [HttpGet("{id}", Name = "GetDataSourceById")]
        public async Task<ActionResult> GetDataSourceById(string id)
        {
            var getDataSourceQuery = new GetDataSourceByIdQuery { ID = id };
            var response = await _mediator.Send(getDataSourceQuery);

            if (!response.Succeeded)
            {
                return BadRequest(response.Message);
            }

            return Ok(response);
        }


        [HttpGet("all", Name = "GetAllDataSource")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> GetAllDataSource()
        {
            _logger.LogInformation("GetAllDataSource Initiated");
            var response = await _mediator.Send(new GetDataSourceListQuery());
            _logger.LogInformation("GetAllDataSource Completed");

            if (!response.Succeeded)
            {
                return BadRequest(response.Message);
            }

            return Ok(response);
        }

        [HttpPut(Name = "UpdateDataSource")]
        [ProducesResponseType(StatusCodes.Status200OK)]

        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Update([FromBody] UpdateDataSourceCommand updateDataSourceCommand)
        {
            var response = await _mediator.Send(updateDataSourceCommand);
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

            var command = new DeleteDataSourceCommand() { ID = guid };
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
