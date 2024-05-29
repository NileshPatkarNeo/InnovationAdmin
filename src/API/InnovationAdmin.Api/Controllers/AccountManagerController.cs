﻿using InnovationAdmin.Application.Features.AccountManager.Commands.CreateAccountManager;
using InnovationAdmin.Application.Features.AccountManager.Commands.DeleteAccountManager;
using InnovationAdmin.Application.Features.AccountManager.Commands.UpdateAccountManager;
using InnovationAdmin.Application.Features.AccountManager.Queries.GetAccountManagerById;
using InnovationAdmin.Application.Features.AccountManager.Queries.GetAllAccountManager;
using InnovationAdmin.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InnovationAdmin.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountManagerController : ControllerBase
    {

        private readonly IMediator _mediator;
        private readonly ILogger _logger;

        public AccountManagerController(IMediator mediator, ILogger<SysPrefCompanyController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }
        [HttpPost]
        public async Task<ActionResult<Response<CreateAccountManagerDto>>> Create([FromBody] CreateAccountManagerCommand createAccountManagerCommand)
        {
          
                var response = await _mediator.Send(createAccountManagerCommand);
                return Ok(response);
         
        }

        [HttpGet("{accountId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAccountManagerById(Guid accountId)
        {
            try
            {
                var query = new GetAccountManagerByIdQuery(accountId);
                var response = await _mediator.Send(query);

                if (response.Data != null)
                {
                    return Ok(response);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred: {ex.Message}");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllAccountManagersQuery();
            var response = await _mediator.Send(query);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update( [FromBody] UpdateAccountManagerCommand command)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteAccountManagerCommand { Id = id };
            var response = await _mediator.Send(command);
            return Ok(response);
        }
    }
}