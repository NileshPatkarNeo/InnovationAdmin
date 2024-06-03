using InnovationAdmin.Application.Features.Admin_Users.Commands.CreateAdmin_User;
using InnovationAdmin.Application.Features.Admin_Users.Commands.DeleteAdminUser;
using InnovationAdmin.Application.Features.Admin_Users.Commands.UpdateAdminUser;
using InnovationAdmin.Application.Features.Admin_Users.Queries.GetAdminUserById;
using InnovationAdmin.Application.Features.Admin_Users.Queries.GetAdminUserList;
using InnovationAdmin.Application.Features.SysPrefCompanies.Commands.UpdateSysPrefCompany;
using InnovationAdmin.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InnovationAdmin.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminUserController : ControllerBase
    {
        private readonly IMediator _mediator;

        private readonly ILogger _logger;

        public AdminUserController(IMediator mediator, ILogger<AdminUserController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }


        //[Authorize]
        [HttpGet("all", Name = "GetAllAdminUsers")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> GetAllAdminUsers()
        {
            _logger.LogInformation("GetAllAdminUsers Initiated");
            var dtos = await _mediator.Send(new AdminUserListQuery());
            _logger.LogInformation("GetAllAdminUsers Completed");
            return Ok(dtos);
        }

        [HttpGet("{id}", Name = "GetAdminUserById")]
        public async Task<ActionResult> GetEventById(string id)
        {
            var getEventDetailQuery = new AdminUserByIdQuery() { User_ID = id };
            return Ok(await _mediator.Send(getEventDetailQuery));
        }

        [HttpPost(Name = "AddCategory")]
        public async Task<ActionResult> Create([FromBody] CreateAdminUserCommand createAdminUserCommand)
        {
            var response = await _mediator.Send(createAdminUserCommand);
            if (!response.Succeeded)
            {
                return BadRequest(response.Message);
            }

            return Ok(response);


        }


        [HttpDelete("{id}", Name = "DeleteAdminUser")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(string id)
        {
            var deleteAdminUserCommand = new DeleteAdminUserCommand() { User_ID = id };
            await _mediator.Send(deleteAdminUserCommand);

            return NoContent();
        }


        [HttpPut(Name = "UpdateAdminUser")]
        [ProducesResponseType(StatusCodes.Status200OK)]
     
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Update(Guid id,[FromBody] UpdateAdminUserCommand updateAdminUserCommand)
        {

            if (id != updateAdminUserCommand.User_ID)
            {
                return BadRequest("ID mismatch");
            }

            var response = await _mediator.Send(updateAdminUserCommand);
            if (response.Succeeded)
            {
                return Ok(response);
            }
            
            return Ok(response);
        }
    }
}
