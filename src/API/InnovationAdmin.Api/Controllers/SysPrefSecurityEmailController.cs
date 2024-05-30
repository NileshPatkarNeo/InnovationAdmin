using InnovationAdmin.Application.Features.Admin_Users.Commands.CreateAdmin_User;
using InnovationAdmin.Application.Features.Admin_Users.Commands.UpdateAdminUser;
using InnovationAdmin.Application.Features.Admin_Users.Queries.GetAdminUserById;
using InnovationAdmin.Application.Features.Admin_Users.Queries.GetAdminUserList;
using InnovationAdmin.Application.Features.SysPrefCompanies.Commands.CreateSysPrefCompany;

using InnovationAdmin.Application.Features.SysPrefSecurityEmails.Commands.CreateSysPrefSecurityEmail;
using InnovationAdmin.Application.Features.SysPrefSecurityEmails.Commands.DeleteSysPrefSecurityEmail;
using InnovationAdmin.Application.Features.SysPrefSecurityEmails.Commands.UpdateSysPrefSecurityEmail;
using InnovationAdmin.Application.Features.SysPrefSecurityEmails.Queries.GetSysPrefSecurityEmailById;
using InnovationAdmin.Application.Features.SysPrefSecurityEmails.Queries.GetSysPrefSecurityEmailList;
using MediatR;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using ILogger = Microsoft.Extensions.Logging.ILogger;

namespace InnovationAdmin.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SysPrefSecurityEmailController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger _logger;

        public SysPrefSecurityEmailController(IMediator mediator, ILogger<SysPrefCompanyController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }




        [HttpPost(Name = "SysPrefSecurityEmail")]
        public async Task<ActionResult> Create([FromBody] CreateSysPrefSecurityEmailCommand createAdminUserCommand)
        {
            var response = await _mediator.Send(createAdminUserCommand);
            if (!response.Succeeded)
            {
                return BadRequest(response.Message);
            }

            return Ok(response);


        }

        //[HttpPost]
        //public async Task<ActionResult> Create([FromBody] CreateSysPrefSecurityEmailCommand createSysPrefSecurityEmailCommand)
        //{
        //    if (string.IsNullOrWhiteSpace(createSysPrefSecurityEmailCommand.DefaultFromName) ||
        //        string.IsNullOrWhiteSpace(createSysPrefSecurityEmailCommand.DefaultFromAddress))
        //    {
        //        return BadRequest();
        //    }

        //    var response = await _mediator.Send(createSysPrefSecurityEmailCommand);
        //    if (response.Succeeded)
        //    {
        //        return Ok(response);
        //    }
        //    return BadRequest(response);
        //}

        [HttpGet("{id}", Name = "GetSysPrefSecurityEmailById")]
        public async Task<ActionResult> GetSysPrefSecurityEmailById(string id)
        {
            var getEventDetailQuery = new GetSysPrefSecurityEmailByIdQuery() { SysPrefSecurityEmailId = id };
            return Ok(await _mediator.Send(getEventDetailQuery));
        }

        [HttpGet("all", Name = "GetAllSysPrefSecurityEmail")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> GetAllSysPrefSecurityEmail()
        {
            _logger.LogInformation("GetAllSysPrefSecurityEmail Initiated");
            var dtos = await _mediator.Send(new GetSysPrefSecurityEmailListQuery());
            _logger.LogInformation("GetAllSysPrefSecurityEmail Completed");
            return Ok(dtos);
        }


        [HttpPut(Name = "UpdateSysPrefSecurityEmail")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Update([FromBody] UpdateSysPrefSecurityEmailCommand updateSysPrefSecurityEmailCommand)
        {

           

            var response = await _mediator.Send(updateSysPrefSecurityEmailCommand);
            if (response.Succeeded)
            {
                return Ok(response);
            }

            return Ok(response);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            if (!Guid.TryParse(id, out var guid))
            {
                return BadRequest("Invalid GUID format");
            }

            var command = new DeleteSysPrefSecurityEmailCommand() { SysPrefSecurityEmailId = guid };
            var result = await _mediator.Send(command);



    
            return NoContent();
        }
    }
}
