using InnovationAdmin.Application.Features.SysPrefCompanies.Commands.UpdateSysPrefCompany;
using InnovationAdmin.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnovationAdmin.Application.Features.ReceiptBatchSource.Commands.UpdateReceiptBatchSource
{
    public class UpdateReceiptBAtchSourceCommand : IRequest<Response<UpdateReceiptBAtchSourceDto>>
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }
    }
}
