using InnovationAdmin.Application.Features.DataSources.Queries.GetDataSourceById;
using InnovationAdmin.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnovationAdmin.Application.Features.BillingMethodTypes.Queries.GetBillingMethodTypeById
{
    public class GetBillingMethodTypeByIdQuery : IRequest<Response<GetBillingMethodTypeByIdVm>>
    {
        public String ID { get; set; }
    }
}
