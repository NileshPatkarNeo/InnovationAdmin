using InnovationAdmin.Application.Features.AdminRoles.Commands.DeleteAdminRole;
using InnovationAdmin.Application.Features.SysPrefFinancials.Commands.CreateSysPrefFinancial;
using InnovationAdmin.Application.Features.SysPrefFinancials.Commands.DeleteSysPrefFinancial;
using InnovationAdmin.Application.Features.SysPrefFinancials.Commands.UpdateSysPrefFinancial;
using InnovationAdmin.Application.Features.SysPrefFinancials.Queries.GetSysPrefFinancial;
using InnovationAdmin.Application.Features.SysPrefFinancials.Queries.GetSysPrefFinancialList;
using InnovationAdmin.Application.Responses;
using InnovationAdmin.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System;
using System.Threading.Tasks;

namespace InnovationAdmin.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SysPrefFinancialController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<SysPrefFinancialController> _logger;

        public SysPrefFinancialController(IMediator mediator, ILogger<SysPrefFinancialController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }



        [HttpPost]
        [Route("create")]
        public async Task<ActionResult<SysPrefFinancial>> Create(CreateSysPrefFinancialCommand command)
        {

            var sysPrefFinancial = await _mediator.Send(command);
            _logger.LogInformation("AdminRole Info: {@sysPrefFinancial}", sysPrefFinancial);
            return Ok(sysPrefFinancial);
        }



        //[HttpPost]
        //[Route("create")]
        //public async Task<ActionResult<SysPrefFinancial>> Create(CreateSysPrefFinancialCommand command)
        //{
        //    var response = await _mediator.Send(command);
        //    var sysPrefFinancial = new SysPrefFinancial
        //    {
        //        FinancialID = response.Data.FinancialID,
        //        CompanyID = response.Data.CompanyID,
        //        DefaultPaymentMethod = response.Data.DefaultPaymentMethod,
        //        LastCheckNo = response.Data.LastCheckNo,
        //        ClaimAgeCollectionStart = response.Data.ClaimAgeCollectionStart,
        //        ClaimAgeCollectionEnd = response.Data.ClaimAgeCollectionEnd,
        //        DefaultReceiptBatchDescription = response.Data.DefaultReceiptBatchDescription,
        //        ClaimPaidThreshold = response.Data.ClaimPaidThreshold,
        //        ClaimStatusWriteOff = response.Data.ClaimStatusWriteOff,
        //        DaysToBlock = response.Data.DaysToBlock
        //    };
        //    _logger.LogInformation("SysPrefFinancial Info: {@sysPrefFinancial}", sysPrefFinancial);
        //    return Ok(sysPrefFinancial);
        //}
        [HttpPut]
        [Route("update")]
        public async Task<ActionResult<SysPrefFinancial>> Update(UpdateSysPrefFinancialCommand command)
        {
            var sysPrefFinancial = await _mediator.Send(command);
            _logger.LogInformation("SysPrefFinancial Updated: {@sysPrefFinancial}", sysPrefFinancial);
            return Ok(sysPrefFinancial);
        }

        //[HttpPut]
        //public async Task<ActionResult<SysPrefFinancial>> Update(UpdateSysPrefFinancialCommand command)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var response = await _mediator.Send(command);
        //    if (response == null)
        //    {
        //        return NotFound();
        //    }

        //    var updatedSysPrefFinancial = new SysPrefFinancial
        //    {
        //        FinancialID = response.Data.FinancialID,
        //        CompanyID = response.Data.CompanyID,
        //        DefaultPaymentMethod = response.Data.DefaultPaymentMethod,
        //        LastCheckNo = response.Data.LastCheckNo,
        //        ClaimAgeCollectionStart = response.Data.ClaimAgeCollectionStart,
        //        ClaimAgeCollectionEnd = response.Data.ClaimAgeCollectionEnd,
        //        DefaultReceiptBatchDescription = response.Data.DefaultReceiptBatchDescription,
        //        ClaimPaidThreshold = response.Data.ClaimPaidThreshold,
        //        ClaimStatusWriteOff = response.Data.ClaimStatusWriteOff,
        //        DaysToBlock = response.Data.DaysToBlock
        //    };

        //    _logger.LogInformation("Updated SysPrefFinancial Info: {@updatedSysPrefFinancial}", updatedSysPrefFinancial);
        //    return Ok(updatedSysPrefFinancial);
        //}

       

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            if (!Guid.TryParse(id, out var guid))
            {
                return BadRequest("Invalid GUID format");
            }

            var command = new DeleteSysPrefFinancialCommand { FinancialID = guid };
            await _mediator.Send(command);

            Log.Information("Deleted SysPrefFinancial with ID {FinancialID}", id);
            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SysPrefFinancialVM>> GetById(Guid id)
        {
            var query = new GetSysPrefFinancialDetailQuery { FinancialID = id };
            var response = await _mediator.Send(query);
            _logger.LogInformation("SysPrefFinancial Retrieved: {@response}", response);
            return Ok(response);
        }


        [HttpGet]
        [Route("list")]
        public async Task<ActionResult<IEnumerable<SysPrefFinancialListVM>>> ListAll()
        {
            var query = new GetSysPrefFinancialsListQuery();
            var response = await _mediator.Send(query);
            _logger.LogInformation("SysPrefFinancial List Retrieved: {@response}", response);
            return Ok(response);
        }
    }
}
