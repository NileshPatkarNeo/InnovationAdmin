using InnovationAdmin.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnovationAdmin.Application.Features.BillingMethodTypes.Queries.GetBillingMethodTypeList
{
    public class GetBillingMethodTypeListQuery :IRequest<Response<IEnumerable<GetBillingMethodTypeListVm
        >>>
    {

    }
}
