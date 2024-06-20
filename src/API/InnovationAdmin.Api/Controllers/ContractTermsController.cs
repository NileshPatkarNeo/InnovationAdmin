using InnovationAdmin.Application.Features.ContractTerms.Commands.CreateContractTerm;
using InnovationAdmin.Application.Features.ContractTerms.Commands.DeleteContractTerm;
using InnovationAdmin.Application.Features.ContractTerms.Commands.UpdateContractTerm;
using InnovationAdmin.Application.Features.ContractTerms.Queries.GetContractTerm;
using InnovationAdmin.Application.Features.ContractTerms.Queries.GetContractTermsList;
using InnovationAdmin.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace InnovationAdmin.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContractTermController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<ContractTermController> _logger;

        public ContractTermController(IMediator mediator, ILogger<ContractTermController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpPost]
        [Route("create")]
        public async Task<ActionResult<ContractTerms>> Create(CreateContractTermCommand command)
        {
            var response = await _mediator.Send(command);
            var contractTerm = new ContractTerms
            {
                ID = response.Data.ID,
                Name = response.Data.Name,
                ContractType = response.Data.ContractType,
                ContractTypeCode = response.Data.ContractTypeCode
            };
            _logger.LogInformation("ContractTerms Info: {@contractTerm}", contractTerm);
            return Ok(contractTerm);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ContractTerms>> GetById(Guid id)
        {
            var query = new GetContractTermDetailQuery() { ID = id };
            var contractTerm = await _mediator.Send(query);

            if (contractTerm == null)
                return NotFound();
            Log.Information("ContractTerms Info: {@contractTerm}", contractTerm);
            return Ok(contractTerm);
        }

        [HttpPut]
        public async Task<ActionResult<ContractTerms>> Update(UpdateContractTermCommand command)
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

            var updatedContractTerm = new ContractTerms
            {
                ID = response.Data.ID,
                Name = response.Data.Name,
                ContractType = response.Data.ContractType,
                ContractTypeCode = response.Data.ContractTypeCode
            };

            _logger.LogInformation("Updated ContractTerm Info: {@updatedContractTerm}", updatedContractTerm);
            return Ok(updatedContractTerm);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            if (!Guid.TryParse(id, out var guid))
            {
                return BadRequest("Invalid GUID format");
            }

            var command = new DeleteContractTermCommand() { ID = guid };
            var result = await _mediator.Send(command);

            Log.Information("Deleted ContractTerm with ID {ContractTermId}", id);
            return NoContent();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ContractTerms>>> GetAll()
        {
            var query = new GetContractTermsListQuery();
            var contractTerms = await _mediator.Send(query);

            return Ok(contractTerms);
        }
    }
}
