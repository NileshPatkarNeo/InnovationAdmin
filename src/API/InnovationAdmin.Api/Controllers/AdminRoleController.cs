using InnovationAdmin.Application.Features.AdminRoles.Commands.CreateAdminRole;
using InnovationAdmin.Application.Features.AdminRoles.Commands.DeleteAdminRole;
using InnovationAdmin.Application.Features.AdminRoles.Commands.UpdateAdminRole;
using InnovationAdmin.Application.Features.AdminRoles.Queries.GetAdminRole;
using InnovationAdmin.Application.Features.AdminRoles.Queries.GetAdminRoleList;
using InnovationAdmin.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace InnovationAdmin.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminRoleController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AdminRoleController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("create")]
        public async Task<ActionResult<Admin_Role>> Create(CreateAdminRoleCommand command)
        {
            var adminRole = await _mediator.Send(command);
            Log.Information("AdminRole Info: {@adminRole}", adminRole);
            return Ok(adminRole);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Admin_Role>> GetById(Guid id)
        {
            var query = new GetAdminRoleDetailQuery() { Role_ID=id};
            var adminRole = await _mediator.Send(query);

            if (adminRole == null)
                return NotFound();
            Log.Information("Institute Info: {@adminRole}", adminRole);
            return Ok(adminRole);
        }

        [HttpPut]
        public async Task<ActionResult<Admin_Role>> Update(UpdateAdminRoleCommand command)
        {


            var updatedAdminRole = await _mediator.Send(command);

            if (updatedAdminRole == null)
            {
                return NotFound();
            }

            Log.Information("Updated AdminRole Info: {@updatedAdminRole}", updatedAdminRole);
            return Ok(updatedAdminRole);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteAdminRoleCommand() { Role_ID= id};
            var result = await _mediator.Send(command);

    

            Log.Information("Deleted Institute with ID {InstituteId}", id);
            return NoContent();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Admin_Role>>> GetAll()
        {
            var query = new GetAdminRolesListQuery();
            var institutes = await _mediator.Send(query);

            return Ok(institutes);
        }

    }
}
