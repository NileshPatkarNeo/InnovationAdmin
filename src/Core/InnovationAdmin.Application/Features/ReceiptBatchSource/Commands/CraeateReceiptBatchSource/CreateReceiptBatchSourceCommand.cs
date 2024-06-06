using InnovationAdmin.Application.Features.SysPrefCompanies.Commands.CreateSysPrefCompany;
using InnovationAdmin.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnovationAdmin.Application.Features.ReceiptBatchSource.Commands.CraeateReceiptBatchSource
{
    public class CreateReceiptBatchSourceCommand : IRequest<Response<CreateReceiptBatchDto>>
    {
        
        public string Name { get; set; }

        public string Type { get; set; }
    }
}

