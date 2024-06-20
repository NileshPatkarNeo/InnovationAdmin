using InnovationAdmin.Application.Features.ReceiptBatchSource.Commands.CraeateReceiptBatchSource;
using InnovationAdmin.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnovationAdmin.Application.Features.ClaimStatus.Commands.CreateClaimStatus
{
    public class CreateClaimStatusCommand : IRequest<Response<CreateClaimStatusDto>>
    {
      public string Name { get; set; }  
        public string Color { get; set; }
    }
}
