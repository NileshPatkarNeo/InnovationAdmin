using InnovationAdmin.Application.Features.SysPrefCompanies.Commands.CreateSysPrefCompany;
using InnovationAdmin.Application.Features.SysPrefCompanies.Commands.DeleteSysPrefCommand;
using InnovationAdmin.Application.Features.SysPrefCompanies.Commands.UpdateSysPrefCompany;
using InnovationAdmin.Application.Features.SysPrefCompanies.Queries.GetAllListSysPrefCompnayQuery;
using InnovationAdmin.Application.Features.SysPrefCompanies.Queries.GetSysPrefCompanyQuery;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InnovationAdmin.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SysPrefCompanyController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger _logger;

        public SysPrefCompanyController(IMediator mediator, ILogger<SysPrefCompanyController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CreateSysPrefCompanyCommand createSysPrefCompanyCommand)
        {
            if (string.IsNullOrWhiteSpace(createSysPrefCompanyCommand.CompanyName) ||
                string.IsNullOrWhiteSpace(createSysPrefCompanyCommand.TermForPharmacy))
            {
                return BadRequest();
            }

            var response = await _mediator.Send(createSysPrefCompanyCommand);
            if (response.Succeeded)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }


        [HttpGet("{companyId}")]
        public async Task<IActionResult> GetSysPrefCompanyById(Guid companyId)
        {
            var query = new GetSysPrefCompanyByIdQuery(companyId) ;
            var company = await _mediator.Send(query);

            if (company == null)
            {
                return NotFound();
            }

            return Ok(company);
        }

        [HttpGet(Name = "GetAllSysPrefCompanies")]
        public async Task<ActionResult> GetAll()
        {
            try
            {
                var query = new GetAllSysPrefCompaniesQuery();
                var result = await _mediator.Send(query);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while processing the request.");
                return BadRequest(ex.Message);
            }
        }

       
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(Guid id, [FromBody] UpdateSysPrefCompanyCommand updateSysPrefCompanyCommand)
        {
            if (id != updateSysPrefCompanyCommand.CompanyID)
            {
                return BadRequest("ID mismatch");
            }

            var response = await _mediator.Send(updateSysPrefCompanyCommand);
            if (response.Succeeded)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpDelete("{id}", Name = "DeleteSysPrefCompany")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var command = new DeleteSysPrefCompanyCommand { CompanyId = id };
            var result = await _mediator.Send(command);
            if (result.Data)
            {
                return Ok(result);
            }
            return NotFound(result);
        }



    }
}
